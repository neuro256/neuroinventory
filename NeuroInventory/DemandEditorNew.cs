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
            lwDemandData.AutoGenerateColumns = false;
            lwDemandData.DataSource = new BindingSource(DemandDataSet, "demand");

            lwDemandData.CellEditActivation = ObjectListView.CellEditActivateMode.SingleClick;
            lwDemandData.SelectedBackColor = Color.LightBlue;
            lwDemandData.SelectedForeColor = Color.MidnightBlue;
            lwDemandData.RowHeight = 26;
            lwDemandData.RebuildColumns();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
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
                nud.Value = Convert.ToDecimal(e.Value, CultureInfo.InvariantCulture);
                e.Control = nud;
            }
        }

        private void lwDemandData_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            if (e.Column.AspectName == "amount")
            {
                //Here you can verify data, if the data is wrong, call
                if (Convert.ToDecimal(e.NewValue, CultureInfo.InvariantCulture) > NudMaxValue)
                    e.Cancel = true;
                //foreach(DataRow row in DemandDataSet.Tables[0].Rows)
                //{
                //    row[6] = "123";
                //}
            }
        }
    }
}
