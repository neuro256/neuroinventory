using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class TabMain : InventoryView
    {
        public TabMain()
        {
            InitializeComponent();
            InitForm();
            InitListView();
            InitContextMenuStrip();
            PopulateTreeView();
            m_ListviewSelectedIndex = 0;
        }

        private void PopulateTreeView()
        {
            treeView.Nodes.Add("Каталог");
            treeView.Nodes[0].Nodes.Add("ТМЦ 1");
            treeView.Nodes[0].Nodes.Add("ТМЦ 2");
            TreeNode node = new TreeNode("ТМЦ 3", 1, 1);
            treeView.Nodes[0].Nodes.Add(node);
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
            InventoryEditor editor = new InventoryEditor();
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
                SQLiteManager.GetInstance().Inventory().Remove(m_ListviewSelectedIndex);
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
                InventoryEditor editor = new InventoryEditor(m_ListviewSelectedIndex);
                if(editor.ShowDialog() == DialogResult.OK)
                {
                    ShowTable();
                }
            }
            m_Listview.SelectedItems.Clear();
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
            return SQLiteManager.GetInstance().Inventory().ReturnDataSet();
        }

        public override void Clear()
        {
            throw new NotImplementedException();
        }

        public override void ShowTable()
        {
            if (!SQLiteManager.GetInstance().TestConnection())
                return;
            DataSet dataSet = ReturnDataSet();
            try
            {
                //Заполняем список
                m_Listview.BeginUpdate();
                m_Listview.Items.Clear();
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    m_Listview.Items.Add(dataSet.Tables[0].Rows[i]["id"].ToString());
                    m_Listview.Items[i].SubItems.Add((i + 1).ToString());
                    for (int j = 1; j < dataSet.Tables[0].Columns.Count; j++)
                    {
                        ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem();
                        subitem.Text = dataSet.Tables[0].Rows[i][j].ToString();
                        subitem.Name = dataSet.Tables[0].Columns[j].ToString();
                        m_Listview.Items[i].SubItems.Add(subitem);
                    }
                    // Добавление элемента столбца Отпущен
                    ListViewItem.ListViewSubItem subitemReleased = new ListViewItem.ListViewSubItem();
                    subitemReleased.BackColor = Color.LawnGreen;
                    subitemReleased.Text = "Отпущен";
                    subitemReleased.Name = "released";
                    m_Listview.Items[i].SubItems.Add(subitemReleased);
                    // Добавление элемента столбца Требование
                    ListViewItem.ListViewSubItem subitemDemand = new ListViewItem.ListViewSubItem();
                    subitemDemand.BackColor = Color.DarkSeaGreen;
                    subitemDemand.Text = "Требование";
                    subitemDemand.Name = "demand";
                    m_Listview.Items[i].SubItems.Add(subitemDemand);
                    // Добавление элемента столбца Cписать
                    ListViewItem.ListViewSubItem subitemDebit = new ListViewItem.ListViewSubItem();
                    subitemDebit.BackColor = Color.DarkSlateGray;
                    subitemDebit.Text = "Списать";
                    subitemDebit.Name = "debit";
                    m_Listview.Items[i].SubItems.Add(subitemDebit);
                    // TODO : добавить столбец ОСТАТОК
                    m_Listview.Items[i].UseItemStyleForSubItems = false;
                }
                m_Listview.EndUpdate();
            }
            catch (SQLiteException se)
            {
                MessageBox.Show(se.Message, "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException se)
            {
                MessageBox.Show("Error!:", se.Message);
            }
            finally
            {
                dataSet.Dispose();
            }
        }

        public override void ListViewItemMouseUp(object sender, MouseEventArgs e)
        {
            base.ListViewItemMouseUp(sender, e);

            if ((m_Listview.GetItemAt(e.X, e.Y)?.SubItems["released"]?.Bounds.Contains(e.X, e.Y) ?? false) ||
                (m_Listview.GetItemAt(e.X, e.Y)?.SubItems["demand"]?.Bounds.Contains(e.X, e.Y) ?? false))
            {
                //MessageBox.Show($"Mouse up: {m_Listview.GetItemAt(e.X, e.Y).SubItems["date"].Text}");
                //MessageBox.Show($"Mouse up: {m_Listview.GetItemAt(e.X, e.Y).Text}"); // Возвращает ID
                DemandEditor demandEditor = new DemandEditor(Convert.ToInt32(m_Listview.GetItemAt(e.X, e.Y).Text));
                demandEditor.StartPosition = FormStartPosition.CenterParent; // Применить эту опцию и к другим окнам
                if (demandEditor.ShowDialog() == DialogResult.OK)
                {
                    ShowTable();
                }
                m_Listview.SelectedItems.Clear();
            }
            else if(m_Listview.GetItemAt(e.X, e.Y)?.SubItems["debit"]?.Bounds.Contains(e.X, e.Y) ?? false)
            {
                DebitEditor debitEditor = new DebitEditor(Convert.ToInt32(m_Listview.GetItemAt(e.X, e.Y).Text));
                debitEditor.StartPosition = FormStartPosition.CenterParent;
                if(debitEditor.ShowDialog() == DialogResult.OK)
                {
                    ShowTable();
                }
                m_Listview.SelectedItems.Clear();
            }
        }
    }
}
