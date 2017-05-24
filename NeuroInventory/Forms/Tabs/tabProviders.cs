using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;
using System.Collections;

namespace NeuroInventory
{
    public partial class TabProviders : InventoryView
    {
        public TabProviders()
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
            lwProviders.Columns.Clear();
            lwProviders.Columns.Add(new ColHeader("ID", 50, HorizontalAlignment.Left, true));
            lwProviders.Columns.Add(new ColHeader("№", 50, HorizontalAlignment.Left, true));
            lwProviders.Columns.Add(new ColHeader("Название", 200, HorizontalAlignment.Left, true));
            lwProviders.Columns.Add(new ColHeader("адрес", 200, HorizontalAlignment.Left, true));
            lwProviders.Columns.Add(new ColHeader("телефон", 200, HorizontalAlignment.Left, true));
            lwProviders.Columns.Add(new ColHeader("e-mail", 200, HorizontalAlignment.Left, true));
            lwProviders.Columns.Add(new ColHeader("Карточка предприятия", 200, HorizontalAlignment.Left, true));
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
            if (m_Listview.SelectedItems.Count > 0)
            {
                SQLiteManager.GetInstance().Providers().Remove(m_ListviewSelectedIndex);
                ShowTable();
            }
            m_Listview.SelectedItems.Clear();
        }

        /// <summary>
        /// Редактирование записи из таблицы
        /// </summary>
        public override void UpdateRecord()
        {
            if (m_Listview.SelectedItems.Count > 0)
            {
                ProviderEditor editor = new ProviderEditor(m_ListviewSelectedIndex);
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    ShowTable();
                }
            }
            m_Listview.SelectedItems.Clear();
        }

        protected override ListView GetListView()
        {
            return lwProviders;
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
    }
}
