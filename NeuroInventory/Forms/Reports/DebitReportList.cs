using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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
            InitControls();
            InitCtxMenuStrip();
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

        private void InitControls()
        {
            dlvDebitReport.AutoGenerateColumns = false;
            dlvDebitReport.FullRowSelect = true;
            dlvDebitReport.GridLines = true;
            dlvDebitReport.HideSelection = false;
            dlvDebitReport.ShowGroups = false;
            dlvDebitReport.SelectColumnsOnRightClickBehaviour = ObjectListView.ColumnSelectBehaviour.Submenu;
            dlvDebitReport.ShowCommandMenuOnRightClick = true;
            dlvDebitReport.ShowItemToolTips = true;
            dlvDebitReport.UseCellFormatEvents = true;
            dlvDebitReport.UseFilterIndicator = true;
            dlvDebitReport.UseFiltering = true;
            bindingSource = new BindingSource(ReturnDataSet(), "debitReport");
            dlvDebitReport.DataSource = bindingSource;
            dlvDebitReport.SelectedBackColor = Color.LightBlue;
            dlvDebitReport.SelectedForeColor = Color.MidnightBlue;
            dlvDebitReport.RowHeight = Definitions.ROW_HEIGHT;
            dlvDebitReport.DoubleBuffered(true);
            // Автоматическая нумерация строк
            this.dlvDebitReport.FormatRow += delegate (object sender, FormatRowEventArgs args)
            {
                args.Item.Text = (args.RowIndex + 1).ToString();
            };

            dlvDebitReport.SelectedObject = null;
            dlvDebitReport.SelectedObjects = null;

            dlvDebitReport.RebuildColumns();
        }

        private void RefreshList()
        {
            bindingSource.DataSource = ReturnDataSet();
            dlvDebitReport.SelectedObject = null;
            dlvDebitReport.SelectedObjects = null;
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

        public override void InitListView()
        {
            base.InitListView();
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
                    DataRowView dataRowView = selectedObject as DataRowView;
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

        protected override ContextMenuStrip GetContextMenuStrip()
        {
            return contextMenuStripDebitReportList;
        }

        public override DataSet ReturnDataSet()
        {
            return SQLiteManager.GetInstance().DebitReport().ReturnDataSet();
        }

        private void dlvDebitReport_FormatCell(object sender, FormatCellEventArgs e)
        {
            if (e.Column?.AspectName == "document")
            {
                e.SubItem.BackColor = Color.LightBlue;
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
    }
}
