using BrightIdeasSoftware;
using System;
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
            lwDemandData.DataSource = new BindingSource(DemandDataSet, "demand");
            lwDemandData.CellEditActivation = ObjectListView.CellEditActivateMode.SingleClick;
            lwDemandData.SelectedBackColor = Color.LightBlue;
            lwDemandData.SelectedForeColor = Color.MidnightBlue;
            lwDemandData.RowHeight = 26;
            lwDemandData.RebuildColumns(); 
        }

        private void lwDemandData_CellEditStarting(object sender, CellEditEventArgs e)
        {
            if (e.Column.AspectName == "amount")
            {
                NumericUpDown nud = new NumericUpDown();
                nud.Bounds = e.CellBounds;
                nud.Minimum = 0.0M;
                nud.Maximum = NudMaxValue;
                nud.DecimalPlaces = SQLiteSettingsManager.GetInstance().Measurement().GetDecimalPlacesByName(e.ListViewItem.SubItems[3].Text);
                nud.Value = Convert.ToDecimal(e.Value, CultureInfo.GetCultureInfo("ru-RU"));
                e.Control = nud;
            }
        }

        private void lwDemandData_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            // Тестовое определение id записи
            //int id = Convert.ToInt32(DemandDataSet.Tables[0].Rows[e.ListViewItem.Index].Field<object>("id") ?? 0);

            if (e.Column.AspectName == "amount")
            {
                string l_BalanceStr = DemandDataSet.Tables[0].Rows[e.ListViewItem.Index].Field<string>("balance");
                decimal l_Balance = Convert.ToDecimal(l_BalanceStr, CultureInfo.GetCultureInfo("ru-RU"));

                if (Convert.ToDecimal(e.NewValue, CultureInfo.InvariantCulture) > l_Balance)
                    e.NewValue = l_Balance;
                if (!String.Equals(e.NewValue.ToString(), e.Value.ToString()))
                {
                    string l_PriceStr = DemandDataSet.Tables[0].Rows[e.ListViewItem.Index].Field<string>("price");
                    decimal l_SumNewValue = Convert.ToDecimal(e.NewValue, CultureInfo.GetCultureInfo("ru-RU")) * Decimal.Parse(l_PriceStr, NumberStyles.Currency);
                    DemandDataSet.Tables[0].Rows[e.ListViewItem.Index].SetField("sum", l_SumNewValue.ToString("C"));
                }
            }
        }

        private void btnReleased_Click(object sender, EventArgs e)
        {
            // Передать DataSet во вкладку Отпущенные
        }
    }
}
