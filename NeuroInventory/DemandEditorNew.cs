using BrightIdeasSoftware;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class DemandEditorNew : Form
    {
        public DemandEditorNew()
        {
            InitializeComponent();
            dataListView1.AutoGenerateColumns = false;
            DataSet inventoryData = SQLiteManager.GetInstance().Inventory().ReturnDataSet();
            dataListView1.DataSource = new BindingSource(inventoryData, "inventory");

            dataListView1.CellEditActivation = ObjectListView.CellEditActivateMode.DoubleClick;
            OLVColumn aNewColumn = new OLVColumn();
            aNewColumn.IsButton = true;
            aNewColumn.ButtonSize = new Size(200, 35);
            aNewColumn.Text = "asdfaf";
            // ... configure it and finally ...
            this.dataListView1.AllColumns.Add(aNewColumn);
            this.dataListView1.RebuildColumns();
        }
    }
}
