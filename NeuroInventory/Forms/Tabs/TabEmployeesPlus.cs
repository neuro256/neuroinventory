using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class TabEmployeesPlus : InventoryView
    {
        BindingSource bindingSource = null;

        public TabEmployeesPlus()
        {
            InitializeComponent();
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

        private void InitControls()
        {
            dlvEmployees.AutoGenerateColumns = false;
            dlvEmployees.FullRowSelect = true;
            dlvEmployees.GridLines = true;
            dlvEmployees.HideSelection = false;
            dlvEmployees.ShowGroups = false;
            dlvEmployees.SelectColumnsOnRightClickBehaviour = ObjectListView.ColumnSelectBehaviour.Submenu;
            dlvEmployees.ShowCommandMenuOnRightClick = true;
            dlvEmployees.ShowItemToolTips = true;
            dlvEmployees.UseCellFormatEvents = true;
            dlvEmployees.UseFilterIndicator = true;
            dlvEmployees.UseFiltering = true;
            // binging source
            bindingSource = new BindingSource(ReturnDataSet(), "employees");
            dlvEmployees.DataSource = bindingSource;
            //
            dlvEmployees.SelectedBackColor = Color.LightBlue;
            dlvEmployees.SelectedForeColor = Color.MidnightBlue;
            dlvEmployees.RowHeight = Definitions.ROW_HEIGHT;
            // highlightrenderer
            highlightTextRenderer1.CornerRoundness = 0.0f;
            highlightTextRenderer1.FramePen = new Pen(Color.MidnightBlue);
            highlightTextRenderer1.FillBrush = new SolidBrush(Color.LightBlue);
            //
            dlvEmployees.DefaultRenderer = highlightTextRenderer1;

            dlvEmployees.DoubleBuffered(true);
            // Автоматическая нумерация строк
            this.dlvEmployees.FormatRow += delegate (object sender, FormatRowEventArgs args)
            {
                args.Item.Text = (args.RowIndex + 1).ToString();
            };

            dlvEmployees.RebuildColumns();
        }

        private void RefreshList()
        {
            bindingSource.DataSource = ReturnDataSet();
        }

        protected override void InitForm()
        {
            base.InitForm();

            this.Name = "TabEmployeesPlus";
            this.Text = "TabEmployeesPlus";
        }

        public override void InitListView()
        {
            base.InitListView();
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
                foreach(var selectedObject in dlvEmployees.SelectedObjects)
                {
                    DataRowView dataRowView = selectedObject as DataRowView;
                    SQLiteManager.GetInstance().Employees().Remove(Convert.ToInt32(dataRowView["id"]));
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

        protected override ContextMenuStrip GetContextMenuStrip()
        {
            return contextMenuStripEmployees;
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
    }
}
