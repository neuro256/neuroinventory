using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class DebitEditorNew : Form
    {
        private const decimal m_NudMaxValue = 9999999.0M;
        private DataSet m_DebitDataSet;

        public DataSet DebitDataSet { get => m_DebitDataSet; private set => m_DebitDataSet = value; }

        public static decimal NudMaxValue => m_NudMaxValue;

        public DebitEditorNew(DataSet p_DataSet)
        {
            InitializeComponent();

            DebitDataSet = p_DataSet;

            InitControls();
        }

        private void InitControls()
        {
            lwDebitData.AutoGenerateColumns = false;
            lwDebitData.DataSource = new BindingSource(DebitDataSet, "DebitReport");
            lwDebitData.CellEditActivation = ObjectListView.CellEditActivateMode.SingleClick;
            lwDebitData.SelectedBackColor = Color.LightBlue;
            lwDebitData.SelectedForeColor = Color.MidnightBlue;
            lwDebitData.RowHeight = 26;
            // Автоматическая нумерация строк
            lwDebitData.FormatRow += delegate (object sender, FormatRowEventArgs args)
            {
                args.Item.Text = (args.RowIndex + 1).ToString();
            };

            lwDebitData.RebuildColumns();

            dateTimePicker.Format = DateTimePickerFormat.Long;
            dateTimePicker.Value = DateTime.Today;
            dateTimePicker.ShowUpDown = false;
        }

        /// <summary>
        /// Начало редактирования ячейки столбца "количество"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lwDebitData_CellEditStarting(object sender, CellEditEventArgs e)
        {
            if (e.Column.AspectName == "amount")
            {
                NumericUpDown nud = new NumericUpDown();
                nud.Bounds = e.CellBounds;
                nud.Minimum = 0.0M;
                nud.Maximum = NudMaxValue;
                nud.DecimalPlaces = SQLiteSettingsManager.GetInstance().Measurement().GetDecimalPlacesByName(e.ListViewItem.SubItems[2].Text); // subitem[2] is measurement
                nud.Value = Convert.ToDecimal(e.Value, CultureInfo.GetCultureInfo("ru-RU"));
                e.Control = nud;
            }
        }

        /// <summary>
        /// Завершение редактирования ячейки столбца "количество"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lwDebitData_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            if (e.Column.AspectName == "amount")
            {
                string l_BalanceStr = DebitDataSet.Tables[0].Rows[e.ListViewItem.Index].Field<string>("balance");
                decimal l_Balance = Convert.ToDecimal(l_BalanceStr, CultureInfo.GetCultureInfo("ru-RU"));

                // Идет проверка, не выбрано ли количество, большее чем остаток тмц на складе
                if (Convert.ToDecimal(e.NewValue, CultureInfo.InvariantCulture) > l_Balance)
                    e.NewValue = l_Balance;
                if (!String.Equals(e.NewValue.ToString(), e.Value.ToString()))
                {
                    // Вычисление стоимости отпущенного тмц
                    string l_PriceStr = DebitDataSet.Tables[0].Rows[e.ListViewItem.Index].Field<string>("price");
                    decimal l_SumNewValue = Convert.ToDecimal(e.NewValue, CultureInfo.GetCultureInfo("ru-RU")) * Decimal.Parse(l_PriceStr, NumberStyles.Currency);
                    DebitDataSet.Tables[0].Rows[e.ListViewItem.Index].SetField("sum", l_SumNewValue.ToString("C"));
                }
            }
        }

        private void btnReleased_Click(object sender, EventArgs e)
        {
            try
            {
                // В первую очередь создаем отчет. Если отчет успешно создан и сохранен, записываем данные в базу данных
                if (CreateReport())
                {
                    // Отпускаем выбранные тмц 
                    foreach (DataRow row in DebitDataSet.Tables[0].Rows)
                    {
                        AddRecord(Convert.ToInt32(row["id"]), Convert.ToDecimal(row["amount"]), dateTimePicker.Value);
                    }
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Definitions.CREATE_REPORT_FAILED);
            }
        }

        private void AddRecord(int p_InventoryId, decimal p_Amount, DateTime p_Date)
        {
            SQLiteManager.GetInstance().Debit().Insert(p_InventoryId, p_Amount, p_Date);
        }

        public bool CreateReport()
        {
            DataSet dataSetDebitReport = GetDebitReportDataSet();
            Dictionary<string, object> debitReportFieldsData = GetReportFieldsData();

            ISpireReportWrapper gemboxReport = new GemboxXlsWrapper();

            string l_FileName = SQLiteManager.GetInstance().DebitReport().CreateFileName(Definitions.DEBIT_REPORT_FILENAME).ToString();
            if (gemboxReport.CreateReport(l_FileName, dataSetDebitReport, debitReportFieldsData))
            {
                SQLiteManager.GetInstance().DebitReport().Insert(DateTime.Now, l_FileName);
                return true;
            }

            return false;
        }

        private DataSet GetDebitReportDataSet()
        {
            DataTable debitReportTable = new DataTable("DebitReport");
            debitReportTable.Columns.Add("id");
            debitReportTable.Columns.Add("number");
            debitReportTable.Columns.Add("name");
            debitReportTable.Columns.Add("OKEIcode");
            debitReportTable.Columns.Add("measurement");
            debitReportTable.Columns.Add("amount");
            debitReportTable.Columns.Add("price");
            debitReportTable.Columns.Add("sum");

            int counter = 1;

            foreach (DataRow row in DebitDataSet.Tables[0].Rows)
            {
                DataRow newRow = debitReportTable.NewRow();

                newRow["id"] = row["id"].ToString();
                newRow["number"] = counter;
                newRow["name"] = row["name"].ToString();
                newRow["OKEIcode"] = row["OKEIcode"].ToString();
                newRow["measurement"] = row["measurement"].ToString();
                newRow["amount"] = row["amount"].ToString();
                newRow["price"] = decimal.Parse(row["price"].ToString(), NumberStyles.Currency).ToString("0.00");
                newRow["sum"] = decimal.Parse(row["sum"].ToString(), NumberStyles.Currency).ToString("0.00");

                counter++;

                debitReportTable.Rows.Add(newRow);
            }

            DataSet debitReportDataSet = new DataSet("Report");
            debitReportDataSet.Tables.Add(debitReportTable);

            return debitReportDataSet;
        }

        private Dictionary<string, object> GetReportFieldsData()
        {
            Dictionary<string, object> fieldsData = new Dictionary<string, object>();
            fieldsData["Date"] = DateAndMoneyConverter.DateToTextLong(dateTimePicker.Value, "г.");
            fieldsData["Date2"] = DateAndMoneyConverter.DateToTextLong(dateTimePicker.Value, "г.");
            fieldsData["TotalPrice"] = Convert.ToDecimal(GetTotalPrice(), CultureInfo.InvariantCulture).ToString("0.00");
            fieldsData["TotalPriceStr"] = GetTotalPriceStr();

            return fieldsData;
        }

        private double GetTotalPrice()
        {
            double sum = 0.0;

            foreach (DataRow row in DebitDataSet.Tables[0].Rows)
            {
                sum += Double.Parse(row["sum"].ToString(), NumberStyles.Currency);
            }

            return sum;
        }

        private string GetTotalPriceStr()
        {
            return DateAndMoneyConverter.CurrencyToTxt(GetTotalPrice(), true);
        }
    }
}
