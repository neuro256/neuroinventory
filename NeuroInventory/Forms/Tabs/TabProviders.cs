using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using BrightIdeasSoftware;
using System.IO;

namespace NeuroInventory
{
    public partial class TabProviders : InventoryView
    {
        BindingSource bindingSource = null;

        public TabProviders()
        {
            InitializeComponent();
            InitForm();
            InitControls();
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
            contextMenuStripProviders.Items.Clear();
            contextMenuStripProviders.Items.AddRange(new[] { addMenuItem, editMenuItem, removeMenuItem });
            // Ассоциируем контекстное меню со списком
            dlvProviders.ContextMenuStrip = contextMenuStripProviders;
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
            dlvProviders.AutoGenerateColumns = false;
            dlvProviders.FullRowSelect = true;
            dlvProviders.GridLines = true;
            dlvProviders.HideSelection = false;
            dlvProviders.ShowGroups = false;
            dlvProviders.SelectColumnsOnRightClickBehaviour = ObjectListView.ColumnSelectBehaviour.Submenu;
            dlvProviders.ShowCommandMenuOnRightClick = true;
            dlvProviders.ShowItemToolTips = true;
            dlvProviders.UseCellFormatEvents = true;
            dlvProviders.UseFilterIndicator = true;
            dlvProviders.UseFiltering = true;
            bindingSource = new BindingSource(ReturnDataSet(), "providers");
            dlvProviders.DataSource = bindingSource;
            dlvProviders.SelectedBackColor = Color.LightBlue;
            dlvProviders.SelectedForeColor = Color.MidnightBlue;
            dlvProviders.RowHeight = Definitions.ROW_HEIGHT;
            dlvProviders.DoubleBuffered(true);
            // Автоматическая нумерация строк
            this.dlvProviders.FormatRow += delegate (object sender, FormatRowEventArgs args)
            {
                args.Item.Text = (args.RowIndex + 1).ToString();
            };

            dlvProviders.SelectedObject = null;
            dlvProviders.SelectedObjects = null;

            dlvProviders.RebuildColumns();
        }

        private void RefreshList()
        {
            bindingSource.DataSource = ReturnDataSet();
            dlvProviders.SelectedObject = null;
            dlvProviders.SelectedObjects = null;
        }

        protected override void InitForm()
        {
            base.InitForm();

            this.Name = "TabProviders";
            this.Text = "TabProviders";
        }

        public override void InitListView()
        {
            base.InitListView();
        }

        private void btnProviderAdd_Click(object sender, EventArgs e)
        {
            AddRecord();
        }

        private void btnProviderRemove_Click(object sender, EventArgs e)
        {
            RemoveRecord();
        }

        private void btnProviderEdit_Click(object sender, EventArgs e)
        {
            UpdateRecord();
        }

        /// <summary>
        /// Добавление записи в таблицу
        /// </summary>
        public override void AddRecord()
        {
            ProviderEditor editor = new ProviderEditor();
            editor.StartPosition = FormStartPosition.CenterParent;
            if(editor.ShowDialog() == DialogResult.OK)
            {
                RefreshList();
            }
        }

        /// <summary>
        /// Удаление записи из таблицы
        /// </summary>
        public override void RemoveRecord()
        {
            if(dlvProviders.SelectedObjects?.Count > 0)
            {
                foreach(var selectedObject in dlvProviders.SelectedObjects)
                {
                    DataRowView dataRowView = selectedObject as DataRowView;
                    SQLiteManager.GetInstance().Providers().Remove(Convert.ToInt32(dataRowView["id"]));
                }
                RefreshList();
            }
            else
            {
                MessageBox.Show(Definitions.REMOVE_WARNING_STRING);
            }
        }

        /// <summary>
        /// Редактирование записи из таблицы
        /// </summary>
        public override void UpdateRecord()
        {
            if(dlvProviders.SelectedObject != null)
            {
                DataRowView dataRowView = dlvProviders.SelectedObject as DataRowView;
                ProviderEditor editor = new ProviderEditor(Convert.ToInt32(dataRowView["id"]));
                editor.StartPosition = FormStartPosition.CenterParent;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    //RefreshList();
                    //bindingSource = new BindingSource(ReturnDataSet(), "providers");
                    bindingSource.DataSource = ReturnDataSet();
                    dlvProviders.RefreshObjects(bindingSource);
                }
            }
        }

        protected override ContextMenuStrip GetContextMenuStrip()
        {
            return contextMenuStripProviders;
        }

        public override DataSet ReturnDataSet()
        {
            return SQLiteManager.GetInstance().Providers().ReturnDataSet();
        }

        public override void Clear()
        {
            throw new NotImplementedException();
        }

        public override void Exit()
        {
            base.Exit();
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            TimedFilter(dlvProviders, ((TextBox)sender).Text, 0);
        }

        private void dlvProviders_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            if (e.Model != null)
            {
                contextMenuStripProviders.Items["addToolStripMenuItem"].Visible = false;
                contextMenuStripProviders.Items["editToolStripMenuItem"].Visible = true;
                contextMenuStripProviders.Items["removeToolStripMenuItem"].Visible = true;
            }
            else
            {
                contextMenuStripProviders.Items["addToolStripMenuItem"].Visible = true;
                contextMenuStripProviders.Items["editToolStripMenuItem"].Visible = false;
                contextMenuStripProviders.Items["removeToolStripMenuItem"].Visible = false;
            }
            e.MenuStrip = contextMenuStripProviders;
        }

        private void dlvProviders_FormatCell(object sender, FormatCellEventArgs e)
        {
            if(e.Column?.AspectName == "document")
            {
                e.SubItem.BackColor = Color.LightBlue;
                e.SubItem.Text = Path.GetFileName(e.SubItem.Text);
            }
        }

        private void dlvProviders_CellClick(object sender, CellClickEventArgs e)
        {
            if(e.Column?.AspectName == "document")
            {
                DataRowView dataRowView = e.Model as DataRowView;
                NeuroFile.OpenFileInExplorer(dataRowView["document"].ToString());
            }
        }

        public override void SaveState()
        {
            byte[] columnSettings = dlvProviders.SaveState();
            ColumnSettings.GetInstance().LvProvidersSettings = columnSettings;
        }

        public override void RestoreState()
        {
            byte[] columnSettings = ColumnSettings.GetInstance().LvProvidersSettings;
            if (columnSettings != null && columnSettings.Length > 0)
            {
                dlvProviders.RestoreState(columnSettings);
            }
        }
    }
}
