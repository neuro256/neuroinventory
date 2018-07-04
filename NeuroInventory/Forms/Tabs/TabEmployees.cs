using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class TabEmployees : InventoryView
    {
        private EmployeeFilter m_Filter;

        private EmployeeFilter Filter { get => m_Filter; set => m_Filter = value; }

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

            EmployeeFilter.Filtration += EmployeeFiltration;
        }

        public override void InitListView()
        {
            base.InitListView();
            // Добавление столбцов
            // Необходимо добавлять столбцы именно так, иначе ColumnHeader не сможет преобразоваться в ColHeader (используется в методе сортировки)
            lvEmployees.Columns.Clear();

            List<ColumnSettings> lvEmployeesSettings = UISettings.GetInstance().LvEmployeesSettings.GetColumnSettingsList();

            foreach (var colSettings in lvEmployeesSettings)
            {
                lvEmployees.Columns.Add(new ColHeader(colSettings.Text, colSettings.Width, colSettings.Align, colSettings.Ascending));
            }

            lvEmployees.DoubleBuffered(true);
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
                if (m_Listview.Items.Count > 0)
                {
                    m_Listview.EnsureVisible(m_ListviewSelectedIndex);
                }
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
                RemoveFromListViewAt(m_ListviewSelectedIndex, 1);
                m_Listview.SelectedItems.Clear();
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
            if (m_Listview.SelectedItems.Count > 0)
            {
                EmployeeEditor editor = new EmployeeEditor(m_ListviewSelectedIndex);
                editor.StartPosition = FormStartPosition.CenterParent;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    ShowTable();
                    lvEmployees.EnsureVisible(m_ListviewSelectedIndex);
                }
                m_Listview.SelectedItems.Clear();
            }
            else
            {
                MessageBox.Show(Definitions.UPDATE_WARNING_STRING);
            }
        }

        protected override ListView GetListView()
        {
            return lvEmployees;
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
            Filter?.Close();
            base.Exit();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if(Filter == null || !Filter.Created)
            {
                Filter = new EmployeeFilter();
                Filter.Dock = DockStyle.Top;
                Filter.TopLevel = false;
                Filter.MdiParent = MdiParent;
                Filter.Parent = Parent;
                Filter.Show();
            }
            else if(Filter != null && Filter.IsHandleCreated)
            {
                Filter.Close();
            }
        }

        private void EmployeeFiltration()
        {
            ShowTable();
        }

        private void lvEmployees_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            List<ColumnSettings> lvNewSettings = UISettings.GetInstance().LvEmployeesSettings.GetColumnSettingsList();

            if (lvNewSettings != null)
            {
                lvNewSettings[e.ColumnIndex].Width = lvEmployees.Columns[e.ColumnIndex].Width;

                UISettings.GetInstance().LvEmployeesSettings.SetColumnSettingsList(lvNewSettings);
            }

            if (lvEmployees.Columns[e.ColumnIndex].Width < Definitions.MIN_COLUMN_WIDTH)
            {
                lvEmployees.Columns[e.ColumnIndex].Width = Definitions.MIN_COLUMN_WIDTH;
            }
        }
    }
}
