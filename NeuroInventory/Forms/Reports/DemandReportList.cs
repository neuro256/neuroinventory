using BrightIdeasSoftware;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class DemandReportList : InventoryView
    {
        BindingSource bindingSource = null;

        public DemandReportList()
        {
            InitializeComponent();
            SQLiteManager.GetInstance().DemandReport().SetCommandDataSet();
            InitForm();
            InitListView();
            InitCtxMenuStrip();
            RestoreState();
        }

        private void InitCtxMenuStrip()
        {
            // Создаем элементы меню и добавляем их
            ToolStripMenuItem addMenuItem = new ToolStripMenuItem("Добавить");
            addMenuItem.Name = "addToolStripMenuItem";
            addMenuItem.Click += addToolStripMenuItem_Click;
            ToolStripMenuItem editMenuItem = new ToolStripMenuItem("Редактировать");
            editMenuItem.Name = "editToolStripMenuItem";
            editMenuItem.Click += editToolStripMenuItem_Click;
            ToolStripMenuItem removeMenuItem = new ToolStripMenuItem("Удалить");
            removeMenuItem.Name = "removeToolStripMenuItem";
            removeMenuItem.Click += removeToolStripMenuItem_Click;
            contextMenuStripDemandReportList.Items.Clear();
            contextMenuStripDemandReportList.Items.AddRange(new[] { addMenuItem, editMenuItem, removeMenuItem });
            // Ассоциируем контекстное меню со списком
            dlvDemandReport.ContextMenuStrip = contextMenuStripDemandReportList;
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveRecord();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateRecord();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRecord();
        }

        public override void InitListView()
        {
            base.InitListView();

            bindingSource = new BindingSource(ReturnDataSet(), "demandReport");
            dlvDemandReport.DataSource = bindingSource;
            dlvDemandReport.RebuildColumns();
        }

        protected override DataListView GetListView()
        {
            return dlvDemandReport;
        }

        private void RefreshList()
        {
            bindingSource.DataSource = ReturnDataSet();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            RemoveRecord();
        }

        public override void RemoveRecord()
        {
            if (dlvDemandReport.SelectedObjects?.Count > 0)
            {
                foreach (var selectedObject in dlvDemandReport.SelectedObjects)
                {
                    DataRowView dataRowView = selectedObject as DataRowView;
                    SQLiteManager.GetInstance().DemandReport().Remove(Convert.ToInt32(dataRowView["id"]));
                }
                SQLiteManager.GetInstance().DemandReport().SetCommandDataSet();
                RefreshList();
            }
            else
            {
                MessageBox.Show(Definitions.REMOVE_WARNING_STRING);
            }
        }

        public override DataSet ReturnDataSet()
        {
            return SQLiteManager.GetInstance().DemandReport().ReturnDataSet();
        }

        private void dlvDemandReport_FormatCell(object sender, FormatCellEventArgs e)
        {
            if (e.Column?.AspectName == "document")
            {
                e.SubItem.BackColor = Color.LightBlue;
                e.SubItem.Text = Path.GetFileName(e.SubItem.Text);
            }
        }

        private void dlvDemandReport_CellClick(object sender, CellClickEventArgs e)
        {
            if (e.Column?.AspectName == "document")
            {
                DataRowView dataRowView = e.Model as DataRowView;
                NeuroFile.OpenFileInExplorer(dataRowView["document"].ToString());
            }
        }

        private void dlvDemandReport_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            if (e.Model != null)
            {
                contextMenuStripDemandReportList.Items["addToolStripMenuItem"].Visible = false;
                contextMenuStripDemandReportList.Items["editToolStripMenuItem"].Visible = false;
                contextMenuStripDemandReportList.Items["removeToolStripMenuItem"].Visible = true;
            }
            else
            {
                contextMenuStripDemandReportList.Items["addToolStripMenuItem"].Visible = false;
                contextMenuStripDemandReportList.Items["editToolStripMenuItem"].Visible = false;
                contextMenuStripDemandReportList.Items["removeToolStripMenuItem"].Visible = false;
            }
            e.MenuStrip = contextMenuStripDemandReportList;
        }

        public override void SaveState()
        {
            byte[] columnSettings = dlvDemandReport.SaveState();
            ColumnSettings.GetInstance().LvDemandReportListSettings = columnSettings;
        }

        public override void RestoreState()
        {
            byte[] columnSettings = ColumnSettings.GetInstance().LvDemandReportListSettings;
            if (columnSettings != null && columnSettings.Length > 0)
            {
                dlvDemandReport.RestoreState(columnSettings);
            }
        }

        private void DemandReportList_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveState();
        }
    }
}
