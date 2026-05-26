using BrightIdeasSoftware;
using System;
using System.Data;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class TabEmployees : InventoryView
    {
        BindingSource bindingSource = null;

        public TabEmployees()
        {
            InitializeComponent();
            InitForm();
            InitControls();          
        }

        private void InitControls()
        {
            InitListView();
            InitCtxMenuStrip();
            RestoreState();
        }

        public override void RebuildList()
        {
            RefreshList();
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
            contextMenuStripEmployees.Items.Clear();
            contextMenuStripEmployees.Items.AddRange(new[] { addMenuItem, editMenuItem, removeMenuItem });
            // Ассоциируем контекстное меню со списком
            dlvEmployees.ContextMenuStrip = contextMenuStripEmployees;
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

            // binging source
            bindingSource = new BindingSource(ReturnDataSet(), "employees");
            dlvEmployees.DataSource = bindingSource;
            // primary sort column
            dlvEmployees.PrimarySortColumn = olvColumn1;
            dlvEmployees.PrimarySortOrder = SortOrder.Ascending;
            dlvEmployees.Sort();
            dlvEmployees.RebuildColumns();
        }

        protected override FastDataListView GetListView()
        {
            return dlvEmployees;
        }

        private void RefreshList()
        {
            dlvEmployees.BeginUpdate();

            try
            {
                int topIndex = dlvEmployees.TopItemIndex;

                bindingSource.DataSource = ReturnDataSet();

                if (dlvEmployees.GetItemCount() > 0)
                {
                    topIndex = Math.Min(topIndex, dlvEmployees.GetItemCount() - 1);

                    if (topIndex >= 0)
                        dlvEmployees.TopItemIndex = topIndex;
                }
            }
            finally
            {
                dlvEmployees.EndUpdate();
            }
        }

        protected override void InitForm()
        {
            base.InitForm();

            this.Name = "TabEmployees";
            this.Text = "TabEmployees";
        }

        private void btnEmployeeAdd_Click(object sender, EventArgs e)
        {
            AddRecord();
        }

        private void btnEmployeeRemove_Click(object sender, EventArgs e)
        {
            RemoveRecord();
        }

        private void btnEmployeeEdit_Click(object sender, EventArgs e)
        {
            UpdateRecord();
        }

        /// <summary>
        /// Добавление записи в таблицу
        /// </summary>
        public override void AddRecord()
        {
            EmployeeEditor editor = new EmployeeEditor();
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
            if(dlvEmployees.SelectedObjects?.Count > 0)
            {
                // Множественное удаление
                dlvEmployees.Freeze();
                foreach(var selectedObject in dlvEmployees.SelectedObjects)
                {
                    if (!(selectedObject is DataRowView dataRowView))
                        continue;
                    SQLiteManager.GetInstance().Employees().Remove(Convert.ToInt32(dataRowView["id"]));
                }
                dlvEmployees.Unfreeze();
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
            if(dlvEmployees.SelectedObject != null)
            {
                DataRowView dataRowView = dlvEmployees.SelectedObject as DataRowView;
                EmployeeEditor employeeEditor = new EmployeeEditor(Convert.ToInt32(dataRowView["id"]));
                employeeEditor.StartPosition = FormStartPosition.CenterParent;
                if(employeeEditor.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                }
            }
        }

        public override DataSet ReturnDataSet()
        {
            return SQLiteManager.GetInstance().Employees().ReturnDataSet();
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
            TimedFilter(dlvEmployees, ((TextBox)sender).Text, 0);
        }

        private void dlvEmployees_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            if(e.Model != null)
            {
                contextMenuStripEmployees.Items["addToolStripMenuItem"].Visible = false;
                contextMenuStripEmployees.Items["editToolStripMenuItem"].Visible = true;
                contextMenuStripEmployees.Items["removeToolStripMenuItem"].Visible = true;
            }
            else
            {
                contextMenuStripEmployees.Items["addToolStripMenuItem"].Visible = true;
                contextMenuStripEmployees.Items["editToolStripMenuItem"].Visible = false;
                contextMenuStripEmployees.Items["removeToolStripMenuItem"].Visible = false;
            }
            e.MenuStrip = contextMenuStripEmployees;
        }

        public override void SaveState()
        {
            byte[] columnSettings = dlvEmployees.SaveState();
            ColumnSettings.GetInstance().LvEmployeesSettings = columnSettings;
        }

        public override void RestoreState()
        {
            byte[] columnSettings = ColumnSettings.GetInstance().LvEmployeesSettings;
            if (columnSettings != null && columnSettings.Length > 0)
            {
                dlvEmployees.RestoreState(columnSettings);
            }
        }

        public override void FocusFilter()
        {
            tbFilter.Clear();
            tbFilter.Focus();
        }
    }
}
