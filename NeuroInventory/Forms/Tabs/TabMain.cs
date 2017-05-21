using System;
using System.Data;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class TabMain : InventoryTab
    {
        public TabMain()
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

            this.Name = "tabInventory";
            this.Text = "tabInventory";
        }

        public override void InitListView()
        {
            base.InitListView();

            lwInventory.Columns.Clear();
            lwInventory.Columns.Add(new ColHeader("ID", 50, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwInventory.Columns.Add(new ColHeader("№", 50, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwInventory.Columns.Add(new ColHeader("Поставщик", 200, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwInventory.Columns.Add(new ColHeader("Дата поступления", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwInventory.Columns.Add(new ColHeader("Накладная", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwInventory.Columns.Add(new ColHeader("Наименование", 200, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwInventory.Columns.Add(new ColHeader("Код ОКЕИ", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwInventory.Columns.Add(new ColHeader("Единица измерения", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwInventory.Columns.Add(new ColHeader("Количество", 50, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwInventory.Columns.Add(new ColHeader("Цена", 50, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwInventory.Columns.Add(new ColHeader("Сумма", 50, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwInventory.Columns.Add(new ColHeader("Отпущен", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwInventory.Columns.Add(new ColHeader("Требование", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwInventory.Columns.Add(new ColHeader("Списать", 50, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwInventory.Columns.Add(new ColHeader("Остаток", 50, System.Windows.Forms.HorizontalAlignment.Left, true));
        }

        private void btnCollapseExpand_Click(object sender, EventArgs e)
        {
            splitContainerMain.SuspendLayout();
            if(!splitContainerMain.Panel1Collapsed)
            {
                splitContainerMain.Panel1Collapsed = true;
                btnCollapseExpand.Text = ">";
            }
            else
            {
                splitContainerMain.Panel1Collapsed = false;
                btnCollapseExpand.Text = "<";
            }
        }

        private void btnInventoryAdd_Click(object sender, EventArgs e)
        {
            AddRecord();
        }

        private void btnInventoryRemove_Click(object sender, EventArgs e)
        {
            RemoveRecord();
        }

        private void btnInventoryEdit_Click(object sender, EventArgs e)
        {
            UpdateRecord();
        }

        /// <summary>
        /// Добавление записи в таблицу
        /// </summary>
        public override void AddRecord()
        {
        }

        /// <summary>
        /// Удаление записи из таблицы
        /// </summary>
        public override void RemoveRecord()
        {
        }

        /// <summary>
        /// Редактирование записи из таблицы
        /// </summary>
        public override void UpdateRecord()
        {
        }

        protected override ListView GetListView()
        {
            return lwInventory;
        }

        protected override ContextMenuStrip GetContextMenuStrip()
        {
            return contextMenuStripInventory;
        }

        public override DataSet ReturnDataSet()
        {
            return null;
        }

        public override void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
