using BrightIdeasSoftware;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class DemandEditorNew : Form
    {
        private DataSet m_DemandDataSet;

        public DataSet DemandDataSet { get => m_DemandDataSet; private set => m_DemandDataSet = value; }

        public DemandEditorNew(DataSet p_DataSet)
        {
            InitializeComponent();

            DemandDataSet = p_DataSet;
            lwDemandData.AutoGenerateColumns = false;
            lwDemandData.DataSource = new BindingSource(DemandDataSet, "demand");

            lwDemandData.CellEditActivation = ObjectListView.CellEditActivateMode.DoubleClick;
            lwDemandData.SelectedBackColor = Color.LightBlue;
            lwDemandData.SelectedForeColor = Color.MidnightBlue;

            //OLVColumn aNewColumn = new OLVColumn();
            //aNewColumn.IsButton = true;
            //aNewColumn.ButtonSize = new Size(200, 35);
            //aNewColumn.Text = "asdfaf";
            // ... configure it and finally ...
            //this.lwDemandData.AllColumns.Add(aNewColumn);
            //this.lwDemandData.RebuildColumns();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
