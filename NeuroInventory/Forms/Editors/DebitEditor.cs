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

            RestoreState();
        }

        private void InitControls()
        {
            this.lvDebitData.AutoGenerateColumns = false;
            this.lvDebitData.DataSource = new BindingSource(DebitDataSet, "DebitReport");
            this.lvDebitData.CellEditActivation = ObjectListView.CellEditActivateMode.SingleClick;
            this.lvDebitData.SelectedBackColor = Color.LightBlue;
            this.lvDebitData.SelectedForeColor = Color.MidnightBlue;
            this.lvDebitData.RowHeight = Definitions.ROW_HEIGHT;
            //this.lvDebitData.DoubleBuffered(true);
            // Автоматическая нумерация строк
            this.lvDebitData.FormatRow += delegate (object sender, FormatRowEventArgs args)
            {
                args.Item.Text = (args.RowIndex + 1).ToString();
            };

            columnPrice.AspectToStringConverter = delegate (object obj)
            {
                return string.Format(new CultureInfo("ru-RU"),
                      "{0:C}",
                      Convert.ToDecimal(obj, CultureInfo.InvariantCulture));
            };

            columnSum.AspectToStringConverter = delegate (object obj)
            {
                string str = string.Format(new CultureInfo("ru-RU"),
                      "{0:C}",
                      Convert.ToDecimal(obj, CultureInfo.InvariantCulture));
                return str;
            };

            // custom sorting by column
            lvDebitData.CustomSorter = delegate (OLVColumn column, SortOrder order)
            {
                switch (column.AspectName)
                {
                    case "debit_amount":
                        lvDebitData.ListViewItemSorter = new NeuroNumberComparer(columnAmount, order);
                        break;
                    case "price":
                        lvDebitData.ListViewItemSorter = new NeuroCurrencyComparer(columnPrice, order);
                        break;
                    case "sum":
                        lvDebitData.ListViewItemSorter = new NeuroCurrencyComparer(columnSum, order);
                        break;
                    case "balance":
                        lvDebitData.ListViewItemSorter = new NeuroNumberComparer(columnBalance, order);
                        break;
                    default:
                        lvDebitData.ListViewItemSorter = new ColumnComparer(column, order);
                        break;
                }
            };

            lvDebitData.PrimarySortColumn = columnName;
            lvDebitData.PrimarySortOrder = SortOrder.Ascending;
            lvDebitData.Sort();

            this.lvDebitData.RebuildColumns();

            dateTimePicker.Format = DateTimePickerFormat.Long;
            dateTimePicker.Value = DateTime.Today;
            dateTimePicker.ShowUpDown = false;
        }

        /// <summary>
        /// Начало редактирования ячейки столбца "количество"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvDebitData_CellEditStarting(object sender, CellEditEventArgs e)
        {
            if (e.Column.AspectName == "debit_amount")
            {
                NumericUpDown nud = new NumericUpDown();
                nud.Bounds = e.CellBounds;
                nud.Minimum = 0.0M;
                nud.Maximum = NudMaxValue;
                DataRowView dataRowView = e.RowObject as DataRowView;
                nud.DecimalPlaces = SQLiteSettingsManager.GetInstance().Measurement().GetDecimalPlacesByName(dataRowView["measurement"].ToString());
                nud.Value = MoneyConverter.ToCurrency(e.Value);
                e.Control = nud;
            }
        }

        /// <summary>
        /// Завершение редактирования ячейки столбца "количество"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvDebitData_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            if (e.Column.AspectName == "debit_amount")
            { 
                DataRowView dataRowView = e.RowObject as DataRowView;
                decimal balance = MoneyConverter.ToCurrency(dataRowView["balance"]);

                // Идет проверка, не выбрано ли количество, большее чем остаток тмц на складе
                if (MoneyConverter.ToCurrency(e.NewValue) > balance)
                    e.NewValue = balance;

                if (!Equals(e.NewValue, e.Value))
                {
                    // Вычисление стоимости отпущенного тмц
                    // ToString(CultureInfo.GetCultureInfo("en-US")) использовано т.к. локальная культура ru-RU использует в качестве разделителя целой и дробной части запятую, 
                    // и эта запятая автоматически записывается в newRow. То есть, в newRow хранится не decimal, а строковое значение sum с учетом культуры
                    dataRowView["sum"] = MoneyConverter.Multiply(e.NewValue, MoneyConverter.ToCurrency(dataRowView["price"])).ToString(CultureInfo.GetCultureInfo("en-US"));
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
                    foreach(var obj in lvDebitData.Objects)
                    {
                        DataRowView row = obj as DataRowView;
                        AddRecord(Convert.ToInt32(row["id"]), Convert.ToInt32(row["demandId"]), reportLastId, MoneyConverter.ToCurrency(row["debit_amount"]), dateTimePicker.Value);
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

            foreach (var obj in lvDebitData.Objects)
            {
                DataRowView row = obj as DataRowView;
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

            foreach (var obj in lvDebitData.Objects)
            {
                DataRowView row = obj as DataRowView;
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

            foreach (var obj in lvDebitData.Objects)
            {
                DataRowView row = obj as DataRowView;
                DataRow newRow = debitReportTable.NewRow();

                newRow["id"] = row["id"];
                newRow["number"] = counter;
                newRow["name"] = row["name"];
                newRow["OKEIcode"] = row["OKEIcode"];
                newRow["measurement"] = SQLiteSettingsManager.GetInstance().Measurement().GetShortName(row["measurement"].ToString());
                newRow["amount"] = row["debit_amount"].ToString();
                newRow["price"] = row["price"];
                newRow["sum"] = row["sum"];

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
            fieldsData["TotalPrice"] = GetTotalPrice(); 
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

        private decimal GetTotalPrice()
        {
            decimal sum = 0.0m;

            foreach(var row in lvDebitData.Objects)
            {
                DataRowView dataRowView = row as DataRowView;
                sum += Decimal.Parse(dataRowView["sum"].ToString(), NumberStyles.Currency, CultureInfo.InvariantCulture);
            }
            return sum;
        }

        private string GetTotalPriceStr()
        {
            return DateAndMoneyConverter.CurrencyToTxt(GetTotalPrice(), true);
        }

        private void SaveState()
        {
            byte[] columnSettings = lvDebitData.SaveState();
            ColumnSettings.GetInstance().LvDebitDataSettings = columnSettings;
        }

        private void RestoreState()
        {
            byte[] columnSettings = ColumnSettings.GetInstance().LvDebitDataSettings;
            if (columnSettings != null && columnSettings.Length > 0)
            {
                lvDebitData.RestoreState(columnSettings);
            }
        }

        private void DebitEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveState();
        }
    }
}
