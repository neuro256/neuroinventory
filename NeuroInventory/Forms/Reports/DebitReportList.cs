using BrightIdeasSoftware;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class DebitReportList : InventoryView
    {
        BindingSource bindingSource = null;

        public DebitReportList()
        {
            InitializeComponent();
            SQLiteManager.GetInstance().DebitReport().SetCommandDataSet();
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
            contextMenuStripDebitReportList.Items.Clear();
            contextMenuStripDebitReportList.Items.AddRange(new[] { addMenuItem, editMenuItem, removeMenuItem });
            // Ассоциируем контекстное меню со списком
            dlvDebitReport.ContextMenuStrip = contextMenuStripDebitReportList;
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

            bindingSource = new BindingSource(ReturnDataSet(), "debitReport");
            dlvDebitReport.DataSource = bindingSource;
            // custom sorting by column
            dlvDebitReport.CustomSorter = delegate (OLVColumn column, SortOrder order)
            {
                switch (column.AspectName)
                {
                    case "date":
                        dlvDebitReport.ListViewItemSorter = new NeuroDateComparer(columnDate, order);
                        break;
                    default:
                        dlvDebitReport.ListViewItemSorter = new ColumnComparer(column, order);
                        break;
                }
            };
            dlvDebitReport.PrimarySortColumn = columnDate;
            dlvDebitReport.PrimarySortOrder = SortOrder.Ascending;
            dlvDebitReport.Sort();
            dlvDebitReport.RebuildColumns();
        }

        protected override FastDataListView GetListView()
        {
            return dlvDebitReport;
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

            this.Name = "DebitReportList";
            this.Text = "Список списаний";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            RemoveRecord();
        }

        public override void RemoveRecord()
        {
            if (dlvDebitReport.SelectedObjects?.Count > 0)
            {
                foreach (var selectedObject in dlvDebitReport.SelectedObjects)
                {
                    if (!(selectedObject is DataRowView dataRowView))
                        continue;

                    SQLiteManager.GetInstance().DebitReport().Remove(Convert.ToInt32(dataRowView["id"]));
                }
                SQLiteManager.GetInstance().DebitReport().SetCommandDataSet();
                RefreshList();
            }
            else
            {
                MessageBox.Show(Definitions.REMOVE_WARNING_STRING);
            }
        }

        public override DataSet ReturnDataSet()
        {
            return SQLiteManager.GetInstance().DebitReport().ReturnDataSet();
        }

        private void dlvDebitReport_FormatCell(object sender, FormatCellEventArgs e)
        {
            if (e.Column?.AspectName == "document")
            {
                e.SubItem.BackColor = Definitions.COLOR_SUBITEM_DOCUMENT_BACK_COLOR;//Color.LightBlue;
                e.SubItem.Text = Path.GetFileName(e.SubItem.Text);
            }
        }

        private void dlvDebitReport_CellClick(object sender, CellClickEventArgs e)
        {
            if (e.Column?.AspectName == "document")
            {
                DataRowView dataRowView = e.Model as DataRowView;
                NeuroFile.OpenFileInExplorer(dataRowView["document"].ToString());
            }
        }

        private void dlvDebitReport_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            if (e.Model != null)
            {
                contextMenuStripDebitReportList.Items["addToolStripMenuItem"].Visible = false;
                contextMenuStripDebitReportList.Items["editToolStripMenuItem"].Visible = false;
                contextMenuStripDebitReportList.Items["removeToolStripMenuItem"].Visible = true;
            }
            else
            {
                contextMenuStripDebitReportList.Items["addToolStripMenuItem"].Visible = false;
                contextMenuStripDebitReportList.Items["editToolStripMenuItem"].Visible = false;
                contextMenuStripDebitReportList.Items["removeToolStripMenuItem"].Visible = false;
            }
            e.MenuStrip = contextMenuStripDebitReportList;
        }

        public override void SaveState()
        {
            byte[] columnSettings = dlvDebitReport.SaveState();
            ColumnSettings.GetInstance().LvDebitReportListSettings = columnSettings;
        }

        public override void RestoreState()
        {
            byte[] columnSettings = ColumnSettings.GetInstance().LvDebitReportListSettings;
            if (columnSettings != null && columnSettings.Length > 0)
            {
                dlvDebitReport.RestoreState(columnSettings);
            }
        }

        private void DebitReportList_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveState();
        }
    }
}
