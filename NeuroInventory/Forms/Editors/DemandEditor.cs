using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class DemandEditor : Form
    {
        private const decimal m_NudMaxValue = 9999999.0M;

        private static readonly CultureInfo RuCulture = CultureInfo.GetCultureInfo("ru-RU");

        private readonly Dictionary<string, int> m_DecimalPlacesCache = new Dictionary<string, int>();

        private DataSet m_DemandDataSet;
        private bool m_Clicked = false;

        public DataSet DemandDataSet { get => m_DemandDataSet; private set => m_DemandDataSet = value; }

        public static decimal NudMaxValue => m_NudMaxValue;

        public DemandEditor(DataSet p_DataSet)
        {
            InitializeComponent();

            this.BackColor = Definitions.COLOR_FORM_MAIN_BACK_COLOR;
            panelLeftUpper.BackColor = Definitions.COLOR_FORM_MAIN_BACK_COLOR;

            DemandDataSet = p_DataSet;

            InitControls();

            RestoreState();
        }

        private void InitControls()
        {
            cbEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEmployee.Sorted = false;
            
            DataSet employeeDataSet = SQLiteManager.GetInstance().Employees().ReturnDataSet("SELECT id, (surename || ' ' || firstname || ' ' || lastname) AS name FROM employees ORDER BY name ASC");
            cbEmployee.DataSource = employeeDataSet.Tables[0];
            cbEmployee.DisplayMember = "name";
            cbEmployee.ValueMember = "id";

            lvDemandData.AutoGenerateColumns = false;
            lvDemandData.UseCellFormatEvents = true;
            lvDemandData.DataSource = new BindingSource(DemandDataSet, "DemandReport");
            lvDemandData.CellEditActivation = ObjectListView.CellEditActivateMode.SingleClick;
            lvDemandData.SelectedBackColor = Definitions.COLOR_SELECTED_BACK_COLOR;
            lvDemandData.SelectedForeColor = Definitions.COLOR_SELECTED_FORE_COLOR;
            lvDemandData.RowHeight = Definitions.ROW_HEIGHT;
            // Автоматическая нумерация строк
            lvDemandData.FormatRow += delegate (object sender, FormatRowEventArgs args)
            {
                args.Item.Text = (args.RowIndex + 1).ToString();
            };

            columnAmount.AspectGetter = r =>
            {
                if (!(r is DataRowView row))
                    return 0m;

                return MoneyConverter.GetDecimalValue(row["amount"]);
            };

            lvDemandData.FormatCell += delegate (object sender, FormatCellEventArgs args)
            {
                if (args.Column.AspectName != "amount")
                    return;

                if (!(args.Model is DataRowView rowView))
                    return;

                decimal amount = MoneyConverter.GetDecimalValue(rowView["amount"]);
                decimal balance = MoneyConverter.GetDecimalValue(rowView["balance"]);
                string measurement = rowView["measurement"]?.ToString();
                int decimalPlaces = GetDecimalPlaces(measurement);

                args.SubItem.Text =
                    $"{FormatAmount(amount, decimalPlaces)} / " +
                    $"{FormatAmount(balance, decimalPlaces)}";
            };

            columnPrice.AspectToStringConverter = delegate (object value)
            {
                if (value == null || value == DBNull.Value)
                    return string.Empty;

                decimal amount = MoneyConverter.ToCurrency(value);
                return MoneyConverter.FormatCurrency(amount);
            };

            columnSum.AspectToStringConverter = delegate (object value)
            {
                if (value == null || value == DBNull.Value)
                    return string.Empty;

                decimal sum = MoneyConverter.ToCurrency(value);
                return MoneyConverter.FormatCurrency(sum);
            };

            // custom sorting by column
            lvDemandData.CustomSorter = delegate (OLVColumn column, SortOrder order)
            {
                switch (column.AspectName)
                {
                    case "amount":
                        lvDemandData.ListViewItemSorter = new NeuroNumberComparer(columnAmount, order);
                        break;
                    case "price":
                        lvDemandData.ListViewItemSorter = new NeuroCurrencyComparer(columnPrice, order);
                        break;
                    case "sum":
                        lvDemandData.ListViewItemSorter = new NeuroCurrencyComparer(columnSum, order);
                        break;
                    default:
                        lvDemandData.ListViewItemSorter = new ColumnComparer(column, order);
                        break;
                }
            };

            lvDemandData.PrimarySortColumn = columnName;
            lvDemandData.PrimarySortOrder = SortOrder.Ascending;
            lvDemandData.Sort();
            lvDemandData.RebuildColumns();

            dateTimePicker.Format = DateTimePickerFormat.Long;
            dateTimePicker.Value = DateTime.Today;
            dateTimePicker.ShowUpDown = false;

            int GetDecimalPlaces(string measurement)
            {
                if(measurement == null) 
                    measurement = string.Empty;

                if (m_DecimalPlacesCache.TryGetValue(measurement, out int decimalPlaces))
                    return decimalPlaces;

                decimalPlaces =
                    SQLiteSettingsManager.GetInstance()
                        .Measurement()
                        .GetDecimalPlacesByName(measurement);

                m_DecimalPlacesCache[measurement] = decimalPlaces;

                return decimalPlaces;
            }

            string FormatAmount(decimal value, int decimalPlaces)
            {
                return value.ToString($"N{decimalPlaces}", RuCulture);
            }
        }

        /// <summary>
        /// Начало редактирования ячейки столбца "количество"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvDemandData_CellEditStarting(object sender, CellEditEventArgs e)
        {
            if (e.Column.AspectName == "amount")
            {
                if (!(e.RowObject is DataRowView rowView))
                    return;

                NumericUpDown nud = new NumericUpDown();
                nud.Bounds = e.CellBounds;
                nud.Minimum = 0m;

                decimal balance = MoneyConverter.GetDecimalValue(rowView["balance"]);

                // Ограничение остатком
                nud.Maximum = balance;

                nud.DecimalPlaces =
                    SQLiteSettingsManager.GetInstance()
                        .Measurement()
                        .GetDecimalPlacesByName(
                            rowView["measurement"]?.ToString() ?? string.Empty);

                nud.Value = MoneyConverter.GetDecimalValue(e.Value);

                e.Control = nud;
            }
        }

        /// <summary>
        /// Завершение редактирования ячейки столбца "количество"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvDemandData_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            if (e.Column.AspectName == "amount" && e.NewValue != null)
            {
                if (!(e.RowObject is DataRowView rowView))
                    return;

                decimal newAmount = MoneyConverter.GetDecimalValue(e.NewValue);
                decimal oldAmount = MoneyConverter.GetDecimalValue(e.Value);

                decimal balance = MoneyConverter.GetDecimalValue(rowView["balance"]);
                decimal price = MoneyConverter.GetDecimalValue(rowView["price"]);

                if (newAmount > balance)
                    newAmount = balance;

                e.NewValue = newAmount;
                rowView["amount"] = newAmount;

                if (newAmount != oldAmount)
                {
                    rowView["sum"] = newAmount * price;
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
                    int reportLastId = SQLiteManager.GetInstance().DemandReport().ReturnLastInsertId();
                    // Отпускаем выбранные тмц 
                    foreach(var obj in lvDemandData.Objects)
                    {
                        if(!(obj is DataRowView row))
                            continue;

                        decimal amount = MoneyConverter.GetDecimalValue(row["amount"]);
                        AddRecord(
                            Convert.ToInt32(row["id"]),
                            reportLastId,
                            cbEmployee.SelectedValue,
                            amount,
                            dateTimePicker.Value
                        );
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
            foreach (var obj in lvDemandData.Objects)
            {
                if (!(obj is DataRowView row))
                    continue;

                decimal amount = MoneyConverter.GetDecimalValue(row["amount"]);

                if (amount <= 0)
                {
                    MessageBox.Show(Definitions.ZERO_AMOUNT);
                    return false;
                }
            }
            return true;
        }

        private void AddRecord(int p_InventoryId, int p_ReportLastId, object p_EmployeeId, decimal p_Amount, DateTime p_Date)
        {
            SQLiteManager.GetInstance().Demand().Insert(p_InventoryId, p_ReportLastId, p_EmployeeId, p_Amount, p_Date);
        }

        public bool CreateReport()
        {
            string l_DocumentNumber = GetDocumentNumber();
            string l_FileName = SQLiteManager.GetInstance().DemandReport().CreateFileName(l_DocumentNumber, Definitions.DEMAND_REPORT_FILENAME, Definitions.DEMAND_REPORT_EXTENSION).ToString();

            SpireReportBuilder builder = new SpireReportBuilder();
            builder.AddDestinationPath(l_FileName);
            builder.AddDemandDataSet(GetDemandReportDataSet());
            builder.AddAdditionalData(GetReportFieldsData(l_DocumentNumber));

            ReportData l_ReportData = builder.Build();

            IReportWrapper spireDoc = new SpireDocWrapper(l_ReportData);

            if (spireDoc.CreateReport())
            {
                SQLiteManager.GetInstance().DemandReport().Insert(Convert.ToInt32(cbEmployee.SelectedValue), DateTime.Now, l_FileName);
                return true;
            }

            return false;
        }

        private DataSet GetDemandReportDataSet()
        {
            DataTable demandReportTable = new DataTable("DemandReport");
            demandReportTable.Columns.Add("id");
            demandReportTable.Columns.Add("name");
            demandReportTable.Columns.Add("OKEIcode");
            demandReportTable.Columns.Add("measurement");
            demandReportTable.Columns.Add("price", typeof(decimal));
            demandReportTable.Columns.Add("sum", typeof(decimal));
            demandReportTable.Columns.Add("amount", typeof(decimal));

            foreach(var obj in lvDemandData.Objects)
            {
                if (!(obj is DataRowView row))
                    continue;

                DataRow newRow = demandReportTable.NewRow();

                newRow["id"] = row["id"];
                newRow["name"] = row["name"];
                newRow["OKEIcode"] = row["OKEIcode"];
                newRow["measurement"] = SQLiteSettingsManager.GetInstance().Measurement().GetShortName(row["measurement"].ToString());
                
                newRow["price"] = MoneyConverter.RoundCurrency(MoneyConverter.GetDecimalValue(row["price"]));
                newRow["sum"] = MoneyConverter.RoundCurrency(MoneyConverter.GetDecimalValue(row["sum"]));
                newRow["amount"] = MoneyConverter.GetDecimalValue(row["amount"]);

                demandReportTable.Rows.Add(newRow);
            }

            DataSet demandReportDataSet = new DataSet("Report");
            demandReportDataSet.Tables.Add(demandReportTable);

            return demandReportDataSet;
        }

        private Dictionary<string, object> GetReportFieldsData(string p_DocumentNumber)
        {
            Dictionary<string, object> fieldsData = new Dictionary<string, object>();
            fieldsData["EmployeeInitialsBefore"] = $"{GetEmployeeInitials()} {GetEmployeeName()}";
            fieldsData["EmployeeInitialsAfter"] = $"{GetEmployeeName()} {GetEmployeeInitials()}";
            fieldsData["EmployeePost"] = GetEmployeePost();
            fieldsData["TotalPrice"] = GetTotalPriceStr();
            fieldsData["Number"] = p_DocumentNumber;
            fieldsData["Date"] = GetDate();

            return fieldsData;
        }

        private string GetDate()
        {
            return DateAndMoneyConverter.DateToTextSimple(dateTimePicker.Value);
        }

        private string GetDocumentNumber()
        {
            int docNumber = Numeration.GetInstance().DemandNumeration.DocCurrentNumber;
            Numeration.GetInstance().DemandNumeration.IncrementNumber();

            string prefix = string.IsNullOrEmpty(Numeration.GetInstance().DemandNumeration.DocPrefix)
                ? string.Empty
                : $"{Numeration.GetInstance().DemandNumeration.DocPrefix}_";

            string date = Numeration.GetInstance().DemandNumeration.IncludeDate
                ? $"_{GetDate()}"
                : string.Empty;

            return $"{prefix}{docNumber.ToString("0000")}{date}";
        }

        private string GetEmployeeInitials()
        {
            int l_SelectedEmployeeId = cbEmployee.SelectedValue != null ? Convert.ToInt32(cbEmployee.SelectedValue) : 0;
            return SQLiteManager.GetInstance().Employees().GetInitialsById(l_SelectedEmployeeId);
        }

        private string GetEmployeeName()
        {
            int l_SelectedEmployeeId = cbEmployee.SelectedValue != null ? Convert.ToInt32(cbEmployee.SelectedValue) : 0;
            return SQLiteManager.GetInstance().Employees().GetNameById(l_SelectedEmployeeId);
        }

        private string GetEmployeePost()
        {
            int l_SelectedEmployeeId = cbEmployee.SelectedValue != null ? Convert.ToInt32(cbEmployee.SelectedValue) : 0;
            return SQLiteManager.GetInstance().Employees().GetEmployeePostById(l_SelectedEmployeeId);
        }

        private decimal GetTotalPrice()
        {
            decimal sum = 0.0m;

            foreach (var row in lvDemandData.Objects)
            {
                if (row is DataRowView dataRowView)
                {
                    sum += MoneyConverter.GetDecimalValue(dataRowView["sum"]);
                }
            }
            return sum;
        }

        private string GetTotalPriceStr()
        {
            return DateAndMoneyConverter.CurrencyToTxtFull(GetTotalPrice(), false);
        }

        private void SaveState()
        {
            byte[] columnSettings = lvDemandData.SaveState();
            ColumnSettings.GetInstance().LvDemandDataSettings = columnSettings;
        }

        private void RestoreState()
        {
            byte[] columnSettings = ColumnSettings.GetInstance().LvDemandDataSettings;
            if (columnSettings != null && columnSettings.Length > 0)
            {
                lvDemandData.RestoreState(columnSettings);
            }
        }

        private void DemandEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveState();
        }
    }
}
