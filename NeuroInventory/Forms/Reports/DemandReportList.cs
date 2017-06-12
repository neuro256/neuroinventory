using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class DemandReportList : InventoryView
    {
        private object m_SelectedRecordId;

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
            base.AddRecord();
        }

        public override void RemoveRecord()
        {
            base.RemoveRecord();
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
