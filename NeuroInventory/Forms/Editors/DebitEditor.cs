using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class DebitEditor : Form
    {
        private const decimal m_NudMaxValue = 9999999.0M;
        private DataSet m_DebitDataSet;
        private bool m_Clicked = false;

        public DataSet DebitDataSet { get => m_DebitDataSet; private set => m_DebitDataSet = value; }

        public static decimal NudMaxValue => m_NudMaxValue;

        public DebitEditor(DataSet p_DataSet)
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
            lwDebitData.DoubleBuffered(true);
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
            if (e.Column.AspectName == "debit_amount")
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
            if (e.Column.AspectName == "debit_amount")
            {
                string l_BalanceStr = DebitDataSet.Tables[0].Rows[e.ListViewItem.Index].Field<string>("balance");
                decimal l_Balance = Convert.ToDecimal(l_BalanceStr, CultureInfo.GetCultureInfo("ru-RU"));

                // Идет проверка, не выбрано ли количество, большее чем остаток тмц на складе
                if (Convert.ToDecimal(e.NewValue, CultureInfo.InvariantCulture) > l_Balance)
                    e.NewValue = l_Balance;

                if (!Equals(e.NewValue, e.Value))
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
                if (!CheckAmount() || m_Clicked)
                    return;
                m_Clicked = true;
                // В первую очередь создаем отчет. Если отчет успешно создан и сохранен, записываем данные в базу данных
                if (CreateReport())
                {
                    int reportLastId = SQLiteManager.GetInstance().DebitReport().ReturnLastInsertId();
                    // Отпускаем выбранные тмц 
                    foreach (DataRow row in DebitDataSet.Tables[0].Rows)
                    {
                        AddRecord(Convert.ToInt32(row["id"]), Convert.ToInt32(row["demandId"]), reportLastId, Convert.ToDecimal(row["debit_amount"]), dateTimePicker.Value);
                    }
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                m_Clicked = false;
                MessageBox.Show(ex.Message, Definitions.CREATE_REPORT_FAILED);
            }
        }

        private bool CheckAmount()
        {
            bool amountChecked = true;

            foreach (DataRow row in DebitDataSet.Tables[0].Rows)
            {
                if (Convert.ToDecimal(row["debit_amount"]) <= 0)
                {
                    amountChecked = false;
                    break;
                }
            }

            if (!amountChecked)
                MessageBox.Show(Definitions.ZERO_AMOUNT);
            return amountChecked;
        }

        private void AddRecord(int p_InventoryId, int p_DemandId, int p_reportId, decimal p_Amount, DateTime p_Date)
        {
            SQLiteManager.GetInstance().Debit().Insert(p_InventoryId, p_DemandId, p_reportId, p_Amount, p_Date);
        }

        public bool CreateReport()
        {
            string l_DocumentNumber = GetDocumentNumber();
            string l_FileName = SQLiteManager.GetInstance().DebitReport().CreateFileName(l_DocumentNumber, Definitions.DEBIT_REPORT_FILENAME, Definitions.DEBIT_REPORT_EXTENSION).ToString();

            GemboxReportBuilder builder = new GemboxReportBuilder();
            builder.AddAdditionalData(GetReportFieldsData(l_DocumentNumber));
            builder.AddDebitDataSet(GetDebitReportDataSet());
            builder.AddInvoiceDataSet(GetInvoiceReportDataSet());
            builder.AddDestinationPath(l_FileName);

            ReportData l_ReportData = builder.Build();

            IReportWrapper gemboxReport = new GemboxXlsWrapper(l_ReportData);
            if (gemboxReport.CreateReport())
            {
                SQLiteManager.GetInstance().DebitReport().Insert(DateTime.Now, l_FileName);
                return true;
            }

            return false;
        }

        private DataSet GetInvoiceReportDataSet()
        {
            DataTable debitReportTable = new DataTable("InvoiceReport");
            debitReportTable.Columns.Add("number");
            debitReportTable.Columns.Add("date_entrance");
            debitReportTable.Columns.Add("date_debit");
            debitReportTable.Columns.Add("invoice_code");
            debitReportTable.Columns.Add("invoiceDate");

            int counter = 1;

            List<string> l_UniqueCodes = new List<string>();

            foreach (DataRow row in DebitDataSet.Tables[0].Rows)
            {
                string l_CurrentInvoiceCode = row["invoice_code"].ToString();
                if (!String.IsNullOrEmpty(l_CurrentInvoiceCode) && !l_UniqueCodes.Contains(l_CurrentInvoiceCode))
                {
                    DataRow newRow = debitReportTable.NewRow();

                    newRow["number"] = counter;
                    string date = Convert.ToDateTime(row["date"]).ToShortDateString();
                    newRow["date_entrance"] = DateAndMoneyConverter.DateToTextSimple(Convert.ToDateTime(row["date"]));
                    newRow["date_debit"] = DateAndMoneyConverter.DateToTextSimple(dateTimePicker.Value);
                    newRow["invoice_code"] = row["invoice_code"].ToString();
                    if (!String.IsNullOrEmpty(row["invoiceDate"].ToString()))
                    {
                        newRow["invoiceDate"] = DateAndMoneyConverter.DateToTextSimple(Convert.ToDateTime(row["invoiceDate"]));
                    }

                    counter++;

                    debitReportTable.Rows.Add(newRow);
                    l_UniqueCodes.Add(l_CurrentInvoiceCode);
                }
            }

            DataSet debitReportDataSet = new DataSet("Invoice");
            debitReportDataSet.Tables.Add(debitReportTable);

            return debitReportDataSet;
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
                newRow["measurement"] = SQLiteSettingsManager.GetInstance().Measurement().GetShortName(row["measurement"].ToString());
                newRow["amount"] = row["debit_amount"].ToString();
                newRow["price"] = decimal.Parse(row["price"].ToString(), NumberStyles.Currency).ToString("0.00");
                newRow["sum"] = decimal.Parse(row["sum"].ToString(), NumberStyles.Currency).ToString("0.00");

                counter++;

                debitReportTable.Rows.Add(newRow);
            }

            DataSet debitReportDataSet = new DataSet("Debit");
            debitReportDataSet.Tables.Add(debitReportTable);

            return debitReportDataSet;
        }

        private Dictionary<string, object> GetReportFieldsData(string p_DocumentNumber)
        {
            Dictionary<string, object> fieldsData = new Dictionary<string, object>();
            fieldsData["Date"] = DateAndMoneyConverter.DateToTextLong(dateTimePicker.Value, "г.");
            fieldsData["Date2"] = DateAndMoneyConverter.DateToTextLong(dateTimePicker.Value, "г.");
            fieldsData["TotalPrice"] = Convert.ToDecimal(GetTotalPrice(), CultureInfo.InvariantCulture).ToString("0.00");
            fieldsData["TotalPriceStr"] = GetTotalPriceStr();
            fieldsData["Number"] = p_DocumentNumber;

            return fieldsData;
        }

        private string GetDate()
        {
            return DateAndMoneyConverter.DateToTextSimple(dateTimePicker.Value);
        }

        private string GetDocumentNumber()
        {
            // number
            int docNumber = Numeration.GetInstance().DebitNumeration.DocCurrentNumber;
            Numeration.GetInstance().DebitNumeration.IncrementNumber();
            // prefix
            string prefix = String.Empty;
            if (!String.IsNullOrEmpty(Numeration.GetInstance().DebitNumeration.DocPrefix))
            {
                prefix = $"{Numeration.GetInstance().DebitNumeration.DocPrefix}_";
            }
            // date 
            string date = String.Empty;
            if (Numeration.GetInstance().DebitNumeration.IncludeDate)
            {
                date = $"_{ GetDate()}";
            }
            // result
            string resultNumber = $"{prefix}{docNumber.ToString("0000")}{date}";
            return resultNumber;
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
