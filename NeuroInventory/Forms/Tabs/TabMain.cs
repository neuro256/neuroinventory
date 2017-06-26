using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class TabMain : InventoryView
    {
        /// <summary>
        /// Тип узла древовидного списка каталогов
        /// </summary>
        enum TreeNodeType
        {
            FOLDER, 
            FILE
        }

        /// <summary>
        /// Структура, хранящая информацию о записи в таблицу Каталоги, соответствующей узлу дерева
        /// </summary>
        class TreeViewTag
        {
            public string name { get; set; }
            public int id { get; set; }
            public TreeNodeType type { get; set; }
            public int parent { get; set; }
            public bool isRoot { get; set; }

            public TreeViewTag()
            {

            }

            public TreeViewTag(string p_name, int p_id, TreeNodeType p_type, int p_parent, bool p_IsRoot = false)
            {
                name = p_name;
                id = p_id;
                type = p_type;
                parent = p_parent;
                isRoot = p_IsRoot;
            }
        }

        private InventoryFilter m_Filter;
        public InventoryFilter Filter { get => m_Filter; set => m_Filter = value; }

        private TreeViewTag m_SelectedInventory = null;
        public delegate void SelectedInventory(string sender);
        public event SelectedInventory OnSelectedInventory;

        public TabMain()
        {
            InitializeComponent();
            InitForm();
            InitListView();
            InitContextMenuStrip();
            InitContextMenuStripCatalogs();
            PopulateTreeView();
            m_ListviewSelectedIndex = 0;
        }

        private void InitContextMenuStripCatalogs()
        {
            // Инициализация контекстного меню, привязанного к древовидному списку
            ToolStripMenuItem addFolderItem = new ToolStripMenuItem("Создать каталог");
            addFolderItem.Name = "addFolderItem";
            addFolderItem.Click += AddFolderItem_Click;
            ToolStripMenuItem addFileItem = new ToolStripMenuItem("Создать список тмц");
            addFileItem.Name = "addFileItem";
            addFileItem.Click += AddFileItem_Click;
            ToolStripMenuItem removeFolderItem = new ToolStripMenuItem("Удалить каталог");
            removeFolderItem.Name = "removeFolderItem";
            removeFolderItem.Click += RemoveFolderItem_Click;
            ToolStripMenuItem removeFileItem = new ToolStripMenuItem("Удалить список тмц");
            removeFileItem.Name = "removeFileItem";
            removeFileItem.Click += RemoveFileItem_Click;

            contextMenuStripCatalogs.Items.Clear();
            contextMenuStripCatalogs.Items.AddRange(new[] { addFolderItem, addFileItem, removeFolderItem, removeFileItem });
            treeView.ContextMenuStrip = contextMenuStripCatalogs;
        }

        /// <summary>
        /// Удаление файла тмц
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveFileItem_Click(object sender, EventArgs e)
        {
            if (m_SelectedInventory != null && m_SelectedInventory.type == TreeNodeType.FILE)
            {
                // Удалить тмц из базы данных
                SQLiteManager.GetInstance().Catalogs().Remove(m_SelectedInventory.id);
                // Удалить тмц из древовидного списка
                treeView.Nodes.Remove(treeView.SelectedNode);

                treeView.SelectedNode = null;
                m_SelectedInventory = null;

                // Очистить таблицу ТМЦ
                ShowTable();
                // Очистить заголовок
                OnSelectedInventory?.Invoke(String.Empty);
            }
        }

        /// <summary>
        /// Удаление каталога тмц
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveFolderItem_Click(object sender, EventArgs e)
        {
            if (m_SelectedInventory != null && m_SelectedInventory.type == TreeNodeType.FOLDER)
            {
                treeView.BeginUpdate();
                RecursiveRemoveFolder(m_SelectedInventory.id);
                treeView.EndUpdate();
                // Очистить таблицу ТМЦ
                ShowTable();
            }
        }

        private void RecursiveRemoveFolder(int p_Id)
        {
            try
            {
                DataSet dataSetChilds = SQLiteManager.GetInstance().Catalogs().ReturnDataSet($"SELECT * FROM catalogs WHERE parent={p_Id}");
                if (dataSetChilds?.Tables[0]?.Rows?.Count > 0)
                {
                    foreach (DataRow childRow in dataSetChilds.Tables[0].Rows)
                    {
                        RecursiveRemoveFolder(Convert.ToInt32(childRow["id"]));
                    }
                }
                SQLiteManager.GetInstance().Catalogs().Remove(p_Id);
                TreeNode removedNode = GetNodeByKey(p_Id.ToString());
                treeView.Nodes.Remove(removedNode);
                return;
            }
            catch { }
        }

        /// <summary>
        /// Возвращает узел древовидного списка по ключу (ключом служит параметр Name узла)
        /// </summary>
        /// <param name="p_Key"></param>
        /// <returns></returns>
        private TreeNode GetNodeByKey(string p_Key)
        {
            List<TreeNode> nodeList = treeView.SelectedNode.GetAllNodes();
            return nodeList.FirstOrDefault(x => x.Name == p_Key);
        }

        /// <summary>
        /// Добавление файла тмц
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddFileItem_Click(object sender, EventArgs e)
        {
            AddNode(TreeNodeType.FILE);
        }

        /// <summary>
        /// Добавление каталога
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddFolderItem_Click(object sender, EventArgs e)
        {
            AddNode(TreeNodeType.FOLDER);
        }

        private void AddNode(TreeNodeType p_Type)
        {
            try
            {
                DialogName dialogName = new DialogName();
                dialogName.StartPosition = FormStartPosition.CenterParent;
                if (dialogName.ShowDialog() == DialogResult.OK)
                {
                    if (m_SelectedInventory != null && m_SelectedInventory.type == TreeNodeType.FOLDER)
                    {
                        // Добавить запись в таблицу Каталоги
                        SQLiteManager.GetInstance().Catalogs().Insert((int)p_Type, m_SelectedInventory.id, dialogName.name);
                        // Получить id добавленной записи
                        int lastInsertId = SQLiteManager.GetInstance().Catalogs().ReturnLastInsertId();


                        TreeViewTag tvTag = new TreeViewTag();
                        tvTag.name = dialogName.name;
                        tvTag.id = lastInsertId;
                        tvTag.parent = m_SelectedInventory.id;
                        tvTag.type = p_Type;
                        tvTag.isRoot = false;

                        TreeNode newNode = new TreeNode();
                        newNode.Name = lastInsertId.ToString();
                        newNode.Text = dialogName.name;
                        newNode.Tag = tvTag;

                        if (p_Type == TreeNodeType.FOLDER)
                        {
                            newNode.ImageIndex = 0; // folder image
                            newNode.SelectedImageIndex = 0;
                        }
                        else
                        {
                            newNode.ImageIndex = 1; // file image
                            newNode.SelectedImageIndex = 1;
                        }

                        treeView.BeginUpdate();
                        treeView.SelectedNode.Nodes.Add(newNode);
                        newNode.Parent.Expand();
                        treeView.EndUpdate();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void treeView_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    treeView.SelectedNode = treeView.GetNodeAt(e.X, e.Y);

                    TreeViewTag tvTag = treeView.SelectedNode?.Tag as TreeViewTag ?? null;
                    if (tvTag != null)
                    {
                        if (!tvTag.isRoot)
                        {
                            if (tvTag.type == TreeNodeType.FOLDER) // is folder
                            {
                                contextMenuStripCatalogs.Items["addFolderItem"].Visible = true;
                                contextMenuStripCatalogs.Items["addFileItem"].Visible = true;
                                contextMenuStripCatalogs.Items["removeFolderItem"].Visible = true;
                                contextMenuStripCatalogs.Items["removeFileItem"].Visible = false;
                            }
                            else if (tvTag.type == TreeNodeType.FILE) // is file
                            {
                                contextMenuStripCatalogs.Items["addFolderItem"].Visible = false;
                                contextMenuStripCatalogs.Items["addFileItem"].Visible = false;
                                contextMenuStripCatalogs.Items["removeFolderItem"].Visible = false;
                                contextMenuStripCatalogs.Items["removeFileItem"].Visible = true;
                            }
                        }
                        else // is root
                        {
                            contextMenuStripCatalogs.Items["addFolderItem"].Visible = true;
                            contextMenuStripCatalogs.Items["addFileItem"].Visible = true;
                            contextMenuStripCatalogs.Items["removeFolderItem"].Visible = false;
                            contextMenuStripCatalogs.Items["removeFileItem"].Visible = false;
                        }
                        contextMenuStripCatalogs.Show(treeView, e.Location);
                    }
                    else
                    {
                        contextMenuStripCatalogs.Hide();
                        contextMenuStripCatalogs.Items["addFolderItem"].Visible = false;
                        contextMenuStripCatalogs.Items["addFileItem"].Visible = false;
                        contextMenuStripCatalogs.Items["removeFolderItem"].Visible = false;
                        contextMenuStripCatalogs.Items["removeFileItem"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Заполнение древовидного списка каталогов
        /// </summary>
        public void PopulateTreeView()
        {
            DataSet dataSetCatalogs = SQLiteManager.GetInstance().Catalogs().ReturnDataSet();

            treeView.BeginUpdate();
            treeView.Nodes.Clear();

            TreeNode catalogRoot = new TreeNode();
            treeView.Nodes.Add(catalogRoot);

            object rootId = SQLiteManager.GetInstance().CommandExecuteScalar("SELECT id FROM catalogs WHERE parent IS NULL");
            // Родительский узел должен быть только один и его столбец parent должен быть равен NULL
            if (rootId != null)
            {
                TreeViewTag tvTag = new TreeViewTag();
                tvTag.name = "Каталоги";
                tvTag.id = Convert.ToInt32(rootId);
                tvTag.parent = 0;
                tvTag.type = 0;
                tvTag.isRoot = true;

                catalogRoot.Name = tvTag.id.ToString();
                catalogRoot.Text = tvTag.name;
                catalogRoot.Tag = tvTag;

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
            try
            {
                DataSet dataSetChilds = SQLiteManager.GetInstance().Catalogs().ReturnDataSet($"SELECT * FROM catalogs WHERE parent = {p_Id}");

                if (dataSetChilds?.Tables[0]?.Rows.Count > 0)
                {
                    foreach (DataRow catalogRow in dataSetChilds.Tables[0].Rows)
                    {
                        TreeViewTag tvTag = new TreeViewTag();
                        tvTag.name = catalogRow["name"].ToString();
                        tvTag.id = Convert.ToInt32(catalogRow["id"]);
                        tvTag.parent = Convert.ToInt32(catalogRow["parent"]);
                        tvTag.type = (TreeNodeType)Convert.ToInt32(catalogRow["type"]);
                        tvTag.isRoot = false;

                        TreeNode catalogNode = new TreeNode();
                        catalogNode.Name = tvTag.id.ToString();
                        catalogNode.Text = tvTag.name;
                        catalogNode.Tag = tvTag;

                        if (tvTag.type == TreeNodeType.FOLDER)
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
            catch { }
        }

        private void treeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            //TreeViewTag tvTag = e.Node.Tag as TreeViewTag;
            //SelectInventoryByCatalog(tvTag);
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeViewTag tvTag = e.Node.Tag as TreeViewTag;
            SelectInventoryByCatalog(tvTag);
            //SelectInventoryByCatalog(treeView.SelectedNodes);
        }

        private void SelectInventoryByCatalog(List<TreeNode> selectedNodes)
        {
            List<int> l_InventoryIds = new List<int>();
            lwInventory.Groups.Clear();
            foreach (var node in treeView.SelectedNodes)
            {
                if((node.Tag as TreeViewTag).type == TreeNodeType.FILE)
                {
                    l_InventoryIds.Add((node.Tag as TreeViewTag).id);
                    lwInventory.Groups.Add((node.Tag as TreeViewTag).id.ToString(), (node.Tag as TreeViewTag).name);
                }
            }
            if (l_InventoryIds.Count > 0)
            {
                SQLiteManager.GetInstance().Inventory().SetCommandDataSet(l_InventoryIds);
                ShowTable();
            }
        }

        /// <summary>
        /// Выбор тмц из каталога
        /// </summary>
        /// <param name="tvTag"></param>
        private void SelectInventoryByCatalog(TreeViewTag tvTag)
        {
            if (tvTag == null)
                return;
            if (m_SelectedInventory != tvTag)
            {
                m_SelectedInventory = tvTag;
                if (tvTag.type == TreeNodeType.FILE) // is file
                {
                    SQLiteManager.GetInstance().Inventory().SetCommandDataSet(m_SelectedInventory.id);
                    ShowTable();
                    OnSelectedInventory?.Invoke(tvTag.name);
                }
            }
        }

        protected override void InitForm()
        {
            base.InitForm();

            this.Name = "tabInventory";
            this.Text = "tabInventory";

            InventoryFilter.Filtration += InventoryFilter_Filtration;
            DebitEditor.CheckDebit += DebitEditor_CheckDebit;
        }

        private void DebitEditor_CheckDebit()
        {
            ShowTable();
        }

        private void InventoryFilter_Filtration()
        {
            ShowTable();
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
            lwInventory.Columns.Add(new ColHeader("Списать", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwInventory.Columns.Add(new ColHeader("Остаток", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
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
            if (m_SelectedInventory != null && m_SelectedInventory.type == TreeNodeType.FILE)
            {
                InventoryEditor editor = new InventoryEditor(m_SelectedInventory.id);
                editor.StartPosition = FormStartPosition.CenterParent;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    ShowTable();
                    if (m_Listview.Items.Count > 0)
                    {
                        m_Listview.EnsureVisible(m_Listview.Items.Count - 1);
                    }
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
                RemoveFromListViewAt(m_ListviewSelectedIndex);
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
            if (m_Listview.SelectedItems.Count > 0 && m_SelectedInventory.type == TreeNodeType.FILE)
            {
                InventoryEditor editor = new InventoryEditor(m_SelectedInventory.id, m_ListviewSelectedIndex);
                editor.StartPosition = FormStartPosition.CenterParent;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    ShowTable();
                    lwInventory.EnsureVisible(m_ListviewSelectedIndex);
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
            if (treeView.SelectedNode == null)
            {
                m_Listview.BeginUpdate();
                m_Listview.Items.Clear();
                m_Listview.EndUpdate();
                return;
            }
            if (m_SelectedInventory == null || m_SelectedInventory.type == TreeNodeType.FOLDER)
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
                    m_Listview.Items[i].Group = m_Listview.Groups[dataSet.Tables[0].Rows[i]["catalogId"].ToString()];
                    for (int j = 1; j < dataSet.Tables[0].Columns.Count - 1; j++)
                    {
                        ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem();
                        subitem.Text = dataSet.Tables[0].Rows[i][j].ToString();
                        subitem.Name = dataSet.Tables[0].Columns[j].ToString();
                        if (subitem.Name == "invoice")
                        {
                            subitem.BackColor = Color.LightBlue;
                            subitem.Tag = subitem.Text;
                            subitem.Text = Path.GetFileName(subitem.Text);
                        }
                        if(subitem.Name != "catalogId")
                            m_Listview.Items[i].SubItems.Add(subitem);
                    }
                    // Добавление элемента столбца Отпущен
                    ListViewItem.ListViewSubItem subitemReleased = new ListViewItem.ListViewSubItem();
                    subitemReleased.BackColor = Color.LightBlue;
                    subitemReleased.Text = "Отпущен";
                    subitemReleased.Name = "released";
                    m_Listview.Items[i].SubItems.Add(subitemReleased);
                    // Добавление элемента столбца Cписать
                    ListViewItem.ListViewSubItem subitemDebit = new ListViewItem.ListViewSubItem();
                    subitemDebit.BackColor = Color.LightSeaGreen;
                    subitemDebit.Text = "Списать";
                    subitemDebit.Name = "debit";
                    m_Listview.Items[i].SubItems.Add(subitemDebit);
                    // Добавление столбца "Остаток"
                    ListViewItem.ListViewSubItem subitemBalance = new ListViewItem.ListViewSubItem();
                    object balance = dataSet.Tables[0].Rows[i][dataSet.Tables[0].Columns.Count - 1];
                    if (!Equals(balance, DBNull.Value) && Convert.ToDecimal(balance) <= 0)
                        subitemBalance.BackColor = Color.Red;
                    subitemBalance.Text = balance.ToString();
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

            if (e.Button == MouseButtons.Left)
            {
                if (m_Listview.GetItemAt(e.X, e.Y)?.SubItems["released"]?.Bounds.Contains(e.X, e.Y) ?? false)
                {
                    string l_InventoryName = m_Listview.GetItemAt(e.X, e.Y)?.SubItems["name"].Text;
                    int l_DecimalPlaces = SQLiteSettingsManager.GetInstance().Measurement().GetDecimalPlacesByName(m_Listview.GetItemAt(e.X, e.Y)?.SubItems["measurement"].Text);
                    DemandEditor demandEditor = new DemandEditor(l_InventoryName, Convert.ToInt32(m_Listview.GetItemAt(e.X, e.Y).Text), l_DecimalPlaces);
                    demandEditor.StartPosition = FormStartPosition.CenterParent; // Применить эту опцию и к другим окнам
                    if (demandEditor.ShowDialog() == DialogResult.OK)
                    {
                        ShowTable();
                    }
                    m_Listview.SelectedItems.Clear();
                }
                else if (m_Listview.GetItemAt(e.X, e.Y)?.SubItems["debit"]?.Bounds.Contains(e.X, e.Y) ?? false)
                {
                    string l_InventoryName = m_Listview.GetItemAt(e.X, e.Y)?.SubItems["name"].Text;
                    int l_DecimalPlaces = SQLiteSettingsManager.GetInstance().Measurement().GetDecimalPlacesByName(m_Listview.GetItemAt(e.X, e.Y)?.SubItems["measurement"].Text);
                    DebitEditor debitEditor = new DebitEditor(l_InventoryName, Convert.ToInt32(m_Listview.GetItemAt(e.X, e.Y).Text), l_DecimalPlaces);
                    debitEditor.StartPosition = FormStartPosition.CenterParent;
                    if (debitEditor.ShowDialog() == DialogResult.OK)
                    {
                        ShowTable();
                    }
                    m_Listview.SelectedItems.Clear();
                }
                else if (m_Listview.GetItemAt(e.X, e.Y)?.SubItems["invoice"]?.Bounds.Contains(e.X, e.Y) ?? false)
                {
                    string l_FileName = m_Listview.GetItemAt(e.X, e.Y)?.SubItems["invoice"].Tag.ToString();
                    NeuroFile.GetInstance().OpenFileInExplorer(l_FileName);
                    m_Listview.SelectedItems.Clear();
                }
            }
        }

        public override void Exit()
        {
            Filter?.Close();
            base.Exit();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (Filter == null || !Filter.Created)
            {
                Filter = new InventoryFilter();
                Filter.Dock = DockStyle.Top;
                Filter.TopLevel = false;
                Filter.MdiParent = MdiParent;
                Filter.Parent = Parent;
                Filter.Show();
            }
            else if (Filter != null && Filter.IsHandleCreated)
            {
                Filter.Close();
            }
        }

        #region DRAG_N_DROP

        private void lwInventory_ItemDrag(object sender, ItemDragEventArgs e)
        {
            lwInventory.DoDragDrop(lwInventory.SelectedItems, DragDropEffects.Move);
        }

        private void lwInventory_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)))
                e.Effect = e.AllowedEffect;
        }

        private void treeView_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)))
                {
                    foreach (ListViewItem item in (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection)))
                    {
                        Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                        TreeNode destNode = ((TreeView)sender).GetNodeAt(pt);
                        // получить id тмц и тип целевого узла
                        int itemId = Convert.ToInt32(item.Text);
                        TreeViewTag tag = destNode.Tag as TreeViewTag;
                        if (tag.type == TreeNodeType.FILE && SQLiteManager.GetInstance().Inventory().GetCatalogId(itemId) != tag.id)
                        {
                            SQLiteManager.GetInstance().Inventory().Update(itemId, tag.id);
                            RemoveFromListView(item);
                        }

                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void treeView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        #endregion
    }
}
