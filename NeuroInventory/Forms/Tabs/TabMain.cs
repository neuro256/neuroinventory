using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class TabMain : InventoryView
    {
        /// <summary>
        /// Структура, хранящая информацию о записи в таблицу Каталоги, соответствующей узлу дерева
        /// </summary>
        class TreeViewTag
        {
            public string name { get; set; }
            public int id { get; set; }
            public int type { get; set; }
            public int parent { get; set; }

            public TreeViewTag()
            {

            }

            public TreeViewTag(string p_name, int p_id, int p_type, int p_parent)
            {
                name = p_name;
                id = p_id;
                type = p_type;
                parent = p_parent;
            }
        }

        private TreeViewTag m_SelectedInventory = null;

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
            DataSet dataSetCatalogs = SQLiteManager.GetInstance().Catalogs().ReturnDataSet();

            treeView.BeginUpdate();
            treeView.Nodes.Clear();

            TreeNode catalogRoot = new TreeNode("Каталоги");
            treeView.Nodes.Add(catalogRoot);

            object rootId = SQLiteManager.GetInstance().CommandExecuteScalar("SELECT id FROM catalogs WHERE parent IS NULL");
            // Родительский узел должен быть только один и его столбец parent должен быть равен NULL
            if(rootId != null)
            {
                FillTreeNode(catalogRoot, Convert.ToInt32(rootId));
            }

            treeView.EndUpdate();
            treeView.ExpandAll();
        }

        /// <summary>
        /// Заполнение узла дочерними узлами. Рекурсивный метод
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="p_Id"></param>
        private void FillTreeNode(TreeNode parentNode, int p_Id)
        {
            DataSet dataSetChilds = SQLiteManager.GetInstance().Catalogs().ReturnDataSet($"SELECT * FROM catalogs WHERE parent = {p_Id}");

            if (dataSetChilds != null && dataSetChilds.Tables.Count > 0 && dataSetChilds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow catalogRow in dataSetChilds.Tables[0].Rows)
                {
                    TreeViewTag tvTag = new TreeViewTag();
                    tvTag.name = catalogRow["name"].ToString();
                    tvTag.id = Convert.ToInt32(catalogRow["id"]);
                    tvTag.parent = Convert.ToInt32(catalogRow["parent"]);
                    tvTag.type = Convert.ToInt32(catalogRow["type"]);

                    TreeNode catalogNode = new TreeNode();
                    catalogNode.Text = tvTag.name;
                    catalogNode.Tag = tvTag;

                    if (tvTag.type == 0)
                    {
                        catalogNode.ImageIndex = 0; // folder image
                        catalogNode.SelectedImageIndex = 0;
                    }
                    else
                    {
                        catalogNode.ImageIndex = 1; // file image
                        catalogNode.SelectedImageIndex = 1;
                    }
                    
                    parentNode.Nodes.Add(catalogNode);

                    FillTreeNode(catalogNode, tvTag.id);
                }
            }

            dataSetChilds.Dispose();

            return;
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeViewTag tvTag = e.Node.Tag as TreeViewTag;
            SelectInventoryByCatalog(tvTag);
        }

        /// <summary>
        /// Выбор тмц из каталога
        /// </summary>
        /// <param name="tvTag"></param>
        private void SelectInventoryByCatalog(TreeViewTag tvTag)
        {          
            if (tvTag.type == 1) // is file
            {
                m_SelectedInventory = tvTag;
                SQLiteManager.GetInstance().Inventory().SetCommandDataSet(m_SelectedInventory.id);
                ShowTable();
            }
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
            lwInventory.Columns.Add(new ColHeader("Дата поступления", 140, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwInventory.Columns.Add(new ColHeader("Накладная", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwInventory.Columns.Add(new ColHeader("Наименование", 200, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwInventory.Columns.Add(new ColHeader("Код ОКЕИ", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwInventory.Columns.Add(new ColHeader("Единица измерения", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwInventory.Columns.Add(new ColHeader("Количество", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwInventory.Columns.Add(new ColHeader("Цена", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwInventory.Columns.Add(new ColHeader("Сумма", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwInventory.Columns.Add(new ColHeader("Отпущен", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwInventory.Columns.Add(new ColHeader("Требование", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwInventory.Columns.Add(new ColHeader("Списать", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwInventory.Columns.Add(new ColHeader("Остаток", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
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
            if (m_SelectedInventory != null)
            {
                InventoryEditor editor = new InventoryEditor(m_SelectedInventory.id);
                editor.StartPosition = FormStartPosition.CenterParent;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    ShowTable();
                }
                m_Listview.SelectedItems.Clear();
            }
        }

        /// <summary>
        /// Удаление записи из таблицы
        /// </summary>
        public override void RemoveRecord()
        {
            if (m_Listview.SelectedItems.Count > 0)
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
                InventoryEditor editor = new InventoryEditor(m_SelectedInventory.id, m_ListviewSelectedIndex);
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
            if (m_SelectedInventory == null)
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
                    for (int j = 1; j < dataSet.Tables[0].Columns.Count - 1; j++)
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
                    // Добавление столбца "Остаток"
                    ListViewItem.ListViewSubItem subitemBalance = new ListViewItem.ListViewSubItem();
                    subitemBalance.Text = dataSet.Tables[0].Rows[i][dataSet.Tables[0].Columns.Count - 1].ToString();
                    subitemBalance.Name = "balance";
                    m_Listview.Items[i].SubItems.Add(subitemBalance);

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
