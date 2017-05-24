using System;
using System.Data;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class TabEmployees : InventoryView
    {
        public TabEmployees()
        {
            InitializeComponent();
            InitForm();
            InitListView();
            InitContextMenuStrip();
            m_ListviewSelectedIndex = 0;
        }

        protected override void InitForm()
        {
            base.InitForm();

            this.Name = "tabEmployees";
            this.Text = "tabEmployees";
        }

        public override void InitListView()
        {
            base.InitListView();
            // Добавление столбцов
            // Необходимо добавлять столбцы именно так, иначе ColumnHeader не сможет преобразоваться в ColHeader (используется в методе сортировки)
            lwEmployees.Columns.Clear();
            lwEmployees.Columns.Add(new ColHeader("ID", 50, HorizontalAlignment.Left, true));
            lwEmployees.Columns.Add(new ColHeader("№", 50, HorizontalAlignment.Left, true));
            lwEmployees.Columns.Add(new ColHeader("Фамилия", 200, HorizontalAlignment.Left, true));
            lwEmployees.Columns.Add(new ColHeader("Имя", 200, HorizontalAlignment.Left, true));
            lwEmployees.Columns.Add(new ColHeader("Отчество", 200, HorizontalAlignment.Left, true));
            lwEmployees.Columns.Add(new ColHeader("Должность", 200, HorizontalAlignment.Left, true));
            lwEmployees.Columns.Add(new ColHeader("Отдел", 200, HorizontalAlignment.Left, true));
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
                ShowTable();
            }
            m_Listview.SelectedItems.Clear();
        }

        /// <summary>
        /// Удаление записи из таблицы
        /// </summary>
        public override void RemoveRecord()
        {
            if(m_Listview.SelectedItems.Count > 0)
            {
                SQLiteManager.GetInstance().Employees().Remove(m_ListviewSelectedIndex);
                ShowTable();
            }
            m_Listview.SelectedItems.Clear();
        }

        /// <summary>
        /// Редактирование записи из таблицы
        /// </summary>
        public override void UpdateRecord()
        {
            if(m_Listview.SelectedItems.Count > 0)
            {
                EmployeeEditor editor = new EmployeeEditor(m_ListviewSelectedIndex);
                editor.StartPosition = FormStartPosition.CenterParent;
                if(editor.ShowDialog() == DialogResult.OK)
                {
                    ShowTable();
                }
            }
            m_Listview.SelectedItems.Clear();
        }

        protected override ListView GetListView()
        {
            return lwEmployees;
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
    }
}
