using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class DemandReportList : InventoryView
    {
        public DemandReportList()
        {
            InitializeComponent();
            SQLiteManager.GetInstance().DemandReport().SetCommandDataSet();
            InitForm();
            InitListView();
            InitContextMenuStrip();
            ShowTable();
            m_ListviewSelectedIndex = 0;
        }

        protected override void InitForm()
        {
            this.Size = new Size(800, 600);
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
            this.ControlBox = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;

            this.Name = "DemandReportList";
            this.Text = "Список требований";
        }

        public override void InitListView()
        {
            base.InitListView();

            lvDemandReportList.Columns.Clear();
            lvDemandReportList.Columns.Add(new ColHeader("ID", 50, HorizontalAlignment.Left, true));
            lvDemandReportList.Columns.Add(new ColHeader("№", 50, HorizontalAlignment.Left, true));
            lvDemandReportList.Columns.Add(new ColHeader("Сотрудник", 250, HorizontalAlignment.Left, true));
            lvDemandReportList.Columns.Add(new ColHeader("Дата", 100, HorizontalAlignment.Left, true));
            lvDemandReportList.Columns.Add(new ColHeader("Документ", 200, HorizontalAlignment.Left, true));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddRecord();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            RemoveRecord();
        }

        public override void AddRecord()
        {
            DemandReport report = new DemandReport();
            report.StartPosition = FormStartPosition.CenterParent;
            if(report.ShowDialog() == DialogResult.OK)
            {
                SQLiteManager.GetInstance().DemandReport().SetCommandDataSet();
                ShowTable();
            }
        }

        public override void RemoveRecord()
        {
            if(m_Listview.SelectedItems.Count > 0)
            {
                SQLiteManager.GetInstance().DemandReport().Remove(m_ListviewSelectedIndex);
                m_Listview.SelectedItems.Clear();
                SQLiteManager.GetInstance().DemandReport().SetCommandDataSet();
                ShowTable();
            }
            else
            {
                MessageBox.Show(Definitions.REMOVE_WARNING_STRING);
            }
        }

        protected override ListView GetListView()
        {
            return lvDemandReportList;
        }

        protected override ContextMenuStrip GetContextMenuStrip()
        {
            return contextMenuStripDemandReportList;
        }

        public override DataSet ReturnDataSet()
        {
            return SQLiteManager.GetInstance().DemandReport().ReturnDataSet();
        }
    }
}
