using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class DemandEditorNew : Form
    {
        private const decimal m_NudMaxValue = 9999999.0M;
        private DataSet m_DemandDataSet;

        public DataSet DemandDataSet { get => m_DemandDataSet; private set => m_DemandDataSet = value; }

        public static decimal NudMaxValue => m_NudMaxValue;

        public DemandEditorNew(DataSet p_DataSet)
        {
            InitializeComponent();

            DemandDataSet = p_DataSet;

            InitControls();
        }

        private void InitControls()
        {
            cbEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEmployee.Sorted = false;
            DataSet employeeDataSet = SQLiteManager.GetInstance().Employees().ReturnDataSet("SELECT id, (surename || ' ' || firstname || ' ' || lastname) AS name FROM employees");
            cbEmployee.DataSource = employeeDataSet.Tables[0];
            cbEmployee.DisplayMember = "name";
            cbEmployee.ValueMember = "id";

            lwDemandData.AutoGenerateColumns = false;
            lwDemandData.DataSource = new BindingSource(DemandDataSet, "DemandReport");
            lwDemandData.CellEditActivation = ObjectListView.CellEditActivateMode.SingleClick;
            lwDemandData.SelectedBackColor = Color.LightBlue;
            lwDemandData.SelectedForeColor = Color.MidnightBlue;
            lwDemandData.RowHeight = 26;
            // Автоматическая нумерация строк
            lwDemandData.FormatRow += delegate (object sender, FormatRowEventArgs args)
            {
                args.Item.Text = (args.RowIndex + 1).ToString();
            };

            lwDemandData.RebuildColumns();

            dateTimePicker.Format = DateTimePickerFormat.Long;
            dateTimePicker.Value = DateTime.Today;
            dateTimePicker.ShowUpDown = false;
        }

        /// <summary>
        /// Начало редактирования ячейки столбца "количество"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lwDemandData_CellEditStarting(object sender, CellEditEventArgs e)
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
        private void lwDemandData_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            // Тестовое определение id записи
            //int id = Convert.ToInt32(DemandDataSet.Tables[0].Rows[e.ListViewItem.Index].Field<object>("id") ?? 0);

            if (e.Column.AspectName == "amount")
            {
                string l_BalanceStr = DemandDataSet.Tables[0].Rows[e.ListViewItem.Index].Field<string>("balance");
                decimal l_Balance = Convert.ToDecimal(l_BalanceStr, CultureInfo.GetCultureInfo("ru-RU"));

                // Идет проверка, не выбрано ли количество, большее чем остаток тмц на складе
                if (Convert.ToDecimal(e.NewValue, CultureInfo.InvariantCulture) > l_Balance)
                    e.NewValue = l_Balance;
                if (!String.Equals(e.NewValue.ToString(), e.Value.ToString()))
                {
                    // Вычисление стоимости отпущенного тмц
                    string l_PriceStr = DemandDataSet.Tables[0].Rows[e.ListViewItem.Index].Field<string>("price");
                    decimal l_SumNewValue = Convert.ToDecimal(e.NewValue, CultureInfo.GetCultureInfo("ru-RU")) * Decimal.Parse(l_PriceStr, NumberStyles.Currency);
                    DemandDataSet.Tables[0].Rows[e.ListViewItem.Index].SetField("sum", l_SumNewValue.ToString("C"));
                }
            }
        }

        private void btnReleased_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckAmount())
                    return;
                // В первую очередь создаем отчет. Если отчет успешно создан и сохранен, записываем данные в базу данных
                if (CreateReport())
                {
                    int reportLastId = SQLiteManager.GetInstance().DemandReport().ReturnLastInsertId();
                    // Отпускаем выбранные тмц 
                    foreach (DataRow row in DemandDataSet.Tables[0].Rows)
                    {
                        AddRecord(Convert.ToInt32(row["id"]), reportLastId, cbEmployee.SelectedValue, Convert.ToDecimal(row["amount"]), dateTimePicker.Value);
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

        private bool CheckAmount()
        {
            bool amountChecked = true;

            foreach (DataRow row in DemandDataSet.Tables[0].Rows)
            {
                if (Convert.ToDecimal(row["amount"]) <= 0)
                {
                    amountChecked = false;
                    break;
                }
            }

            if (!amountChecked)
                MessageBox.Show(Definitions.ZERO_AMOUNT);
            return amountChecked;
        }

        private void AddRecord(int p_InventoryId, int p_ReportLastId, object p_EmployeeId, decimal p_Amount, DateTime p_Date)
        {
            SQLiteManager.GetInstance().Demand().Insert(p_InventoryId, p_ReportLastId, p_EmployeeId, p_Amount, p_Date);
        }

        public bool CreateReport()
        {
            DataSet dataSetDemandReport = GetDemandReportDataSet();
            Dictionary<string, object> demandReportFieldsData = GetReportFieldsData();
            string l_FileName = SQLiteManager.GetInstance().DemandReport().CreateFileName(Definitions.DEMAND_REPORT_FILENAME).ToString();

            IReportWrapper spireDoc = new SpireDocWrapper(l_FileName, dataSetDemandReport, demandReportFieldsData);

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
            demandReportTable.Columns.Add("price");
            demandReportTable.Columns.Add("sum");
            demandReportTable.Columns.Add("amount");

            foreach (DataRow row in DemandDataSet.Tables[0].Rows)
            {
                DataRow newRow = demandReportTable.NewRow();

                newRow["id"] = row["id"].ToString();
                newRow["name"] = row["name"].ToString();
                newRow["OKEIcode"] = row["OKEIcode"].ToString();
                newRow["measurement"] = SQLiteSettingsManager.GetInstance().Measurement().GetShortName(row["measurement"].ToString());
                newRow["price"] = decimal.Parse(row["price"].ToString(), NumberStyles.Currency).ToString("0.00");
                newRow["sum"] = decimal.Parse(row["sum"].ToString(), NumberStyles.Currency).ToString("0.00");
                newRow["amount"] = row["amount"].ToString();

                demandReportTable.Rows.Add(newRow);
            }

            DataSet demandReportDataSet = new DataSet("Report");
            demandReportDataSet.Tables.Add(demandReportTable);

            return demandReportDataSet;
        }

        private Dictionary<string, object> GetReportFieldsData()
        {
            Dictionary<string, object> fieldsData = new Dictionary<string, object>();
            fieldsData["EmployeeInitialsBefore"] = $"{GetEmployeeInitials()} {GetEmployeeName()}";
            fieldsData["EmployeeInitialsAfter"] = $"{GetEmployeeName()} {GetEmployeeInitials()}";
            fieldsData["EmployeePost"] = GetEmployeePost();
            fieldsData["TotalPrice"] = GetTotalPriceStr();
            fieldsData["Number"] = GetDocumentNumber();
            fieldsData["Date"] = GetDate();

            return fieldsData;
        }

        private string GetDate()
        {
            return DateAndMoneyConverter.DateToTextSimple(dateTimePicker.Value);
        }

        private string GetDocumentNumber()
        {
            // number
            int docNumber = Numeration.GetInstance().DemandNumeration.DocCurrentNumber;
            Numeration.GetInstance().DemandNumeration.IncrementNumber();
            // prefix
            string prefix = String.Empty;
            if (!String.IsNullOrEmpty(Numeration.GetInstance().DemandNumeration.DocPrefix))
            {
                prefix = $"{Numeration.GetInstance().DemandNumeration.DocPrefix}_";
            }
            // date 
            string date = String.Empty;
            if(Numeration.GetInstance().DemandNumeration.IncludeDate)
            {
                date = $"_{ GetDate()}";
            }
            // result
            string resultNumber = $"{prefix}{docNumber.ToString("0000")}{date}";
            return resultNumber;
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

        private double GetTotalPrice()
        {
            double sum = 0.0;

            foreach (DataRow row in DemandDataSet.Tables[0].Rows)
            {
                sum += Double.Parse(row["sum"].ToString(), NumberStyles.Currency);
            }

            return sum;
        }

        private string GetTotalPriceStr()
        {
            return DateAndMoneyConverter.CurrencyToTxtFull(GetTotalPrice(), false);
        }
    }
}
