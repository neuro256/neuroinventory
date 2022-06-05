using BrightIdeasSoftware;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class TabInventory : InventoryView
    {
        /// <summary>
        /// Тип узла древовидного списка каталогов
        /// </summary>
        enum TreeNodeType
        {
            FOLDER,
            FILE
        }

        private TreeNodeType GetNodeType(object obj)
        {
            if (Convert.ToInt32(obj) == 0)
                return TreeNodeType.FOLDER;
            else
                return TreeNodeType.FILE;
        }


        BindingSource bindingSource = null;
        BindingSource bindingSourceCatalogs = null;

        public TabInventory()
        {
            InitializeComponent();
            InitForm();
            InitControls();
        }

        private void InitControls()
        {
            InitListView();
            InitCtxMenuStrip();
            InitContextMenuStripCatalogs();
            SetupTreeView();
            RestoreState();
        }

        public override void RebuildList()
        {
            RefreshList();
        }

        private void InitContextMenuStripCatalogs()
        {
            // Инициализация контекстного меню, привязанного к древовидному списку
            ToolStripMenuItem addFolderItem = new ToolStripMenuItem("Создать каталог");
            addFolderItem.Name = "addFolderItem";
            addFolderItem.Click += AddFolderItem_Click;
            ToolStripMenuItem renameFolderItem = new ToolStripMenuItem("Переименовать каталог");
            renameFolderItem.Name = "renameFolderItem";
            renameFolderItem.Click += RenameFolderItem_Click;
            ToolStripMenuItem addFileItem = new ToolStripMenuItem("Создать список тмц");
            addFileItem.Name = "addFileItem";
            addFileItem.Click += AddFileItem_Click;
            ToolStripMenuItem renameFileItem = new ToolStripMenuItem("Переименовать список тмц");
            renameFileItem.Name = "renameFileItem";
            renameFileItem.Click += RenameFileItem_Click;
            ToolStripMenuItem removeFolderItem = new ToolStripMenuItem("Удалить каталог");
            removeFolderItem.Name = "removeFolderItem";
            removeFolderItem.Click += RemoveFolderItem_Click;
            ToolStripMenuItem removeFileItem = new ToolStripMenuItem("Удалить список тмц");
            removeFileItem.Name = "removeFileItem";
            removeFileItem.Click += RemoveFileItem_Click;

            contextMenuStripCatalogs.Items.Clear();
            contextMenuStripCatalogs.Items.AddRange(new[] { addFolderItem, addFileItem, renameFolderItem, renameFileItem, removeFolderItem, removeFileItem });
            dtlCatalogs.ContextMenuStrip = contextMenuStripCatalogs;
        }

        /// <summary>
        /// Удаление списка тмц
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveFileItem_Click(object sender, EventArgs e)
        {
            DataRowView dataRowView = dtlCatalogs.SelectedObject as DataRowView;
            if (dataRowView != null && GetNodeType(dataRowView["type"]) == TreeNodeType.FILE)
            {
                // Удалить тмц из базы данных
                SQLiteManager.GetInstance().Catalogs().Remove(Convert.ToInt32(dataRowView["id"]));
                RefreshCatalogs();
            }
        }

        /// <summary>
        /// Удаление каталога тмц
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveFolderItem_Click(object sender, EventArgs e)
        {
            DataRowView dataRowView = dtlCatalogs.SelectedObject as DataRowView;
            if (dataRowView != null && GetNodeType(dataRowView["type"]) == TreeNodeType.FOLDER)
            {
                // Удалить каталога из базы данных
                RecursiveRemoveFolder(Convert.ToInt32(dataRowView["id"]));
                RefreshCatalogs();
            }
        }

        private void RecursiveRemoveFolder(int selectedItemId)
        {
            try
            {
                DataSet dataSetChilds = SQLiteManager.GetInstance().Catalogs().ReturnDataSet($"SELECT * FROM catalogs WHERE parent={selectedItemId}");
                if (dataSetChilds?.Tables[0]?.Rows?.Count > 0)
                {
                    foreach (DataRow childRow in dataSetChilds.Tables[0].Rows)
                    {
                        RecursiveRemoveFolder(Convert.ToInt32(childRow["id"]));
                    }
                }
                SQLiteManager.GetInstance().Catalogs().Remove(selectedItemId);
                return;
            }
            catch { }
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

        /// <summary>
        /// Переименовывание каталога
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RenameFolderItem_Click(object sender, EventArgs e)
        {
            RenameNode();
        }

        /// <summary>
        /// Переименовывание списка тмц
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RenameFileItem_Click(object sender, EventArgs e)
        {
            RenameNode();
        }

        private void RenameNode()
        {
            try
            {
                DialogName dialogName = new DialogName();
                dialogName.StartPosition = FormStartPosition.CenterParent;
                if (dialogName.ShowDialog() == DialogResult.OK)
                {
                    DataRowView dataRowView = dtlCatalogs.SelectedObject as DataRowView;
                    if (dataRowView != null)
                    {
                        int type = Convert.ToInt32(dataRowView["type"]);
                        int id = Convert.ToInt32(dataRowView["id"]);
                        int parent = Convert.ToInt32(dataRowView["parent"]);
                        // Изменить запись в таблице Каталоги
                        SQLiteManager.GetInstance().Catalogs().Update(id, type, parent, dialogName.name);

                        dataRowView["name"] = dialogName.name;
                        dtlCatalogs.SelectedObject = dataRowView;
                        dtlCatalogs.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddNode(TreeNodeType nodeType)
        {
            DialogName dialogName = new DialogName();
            dialogName.StartPosition = FormStartPosition.CenterParent;
            if (dialogName.ShowDialog() == DialogResult.OK)
            {
                if (dtlCatalogs.SelectedObject != null)
                {
                    DataRowView dataRowView = dtlCatalogs.SelectedObject as DataRowView;
                    if (GetNodeType(dataRowView["type"]) == TreeNodeType.FOLDER)
                    {
                        // Добавить запись в таблицу Каталоги
                        int parent = Convert.ToInt32(dataRowView["id"]);
                        SQLiteManager.GetInstance().Catalogs().Insert((int)nodeType, parent, dialogName.name);

                        RefreshCatalogs();
                    }
                }
            }
        }

        /// <summary>
        /// Заполнение древовидного списка каталогов
        /// </summary>
        public void SetupTreeView()
        {
            DataSet dataSetCatalogs = SQLiteManager.GetInstance().Catalogs().ReturnDataSet();

            dtlCatalogs.KeyAspectName = "id";
            dtlCatalogs.ParentKeyAspectName = "parent";
            dtlCatalogs.RootKeyValueString = "0";
            bindingSourceCatalogs = new BindingSource(dataSetCatalogs, "catalogs");
            dtlCatalogs.DataSource = bindingSourceCatalogs;
            dtlCatalogs.AutoGenerateColumns = false;
            dtlCatalogs.ShowKeyColumns = false;
            dtlCatalogs.ShowItemToolTips = true;
            dtlCatalogs.SmallImageList = imageListMain;
            dtlCatalogs.IsSimpleDragSource = true;
            dtlCatalogs.IsSimpleDropSink = true;
            dtlCatalogs.ExpandAll();

            // Отображение иконок в элементах списка
            catalogsNameColumn.ImageGetter = delegate (object row)
            {
                DataRowView dataRowView = row as DataRowView;
                if (GetNodeType(dataRowView["type"]) == TreeNodeType.FOLDER)
                {
                    return "folder";
                }
                else
                {
                    return "file";
                }
            };

            // drag n drop
            SimpleDropSink dropSink = new SimpleDropSink();
            dropSink.CanDropOnItem = true;
            dropSink.FeedbackColor = Definitions.COLOR_DROPSINK_FEEDBACK_COLOR;//Color.LightBlue;
            dropSink.AutoScroll = true;
            dtlCatalogs.DropSink = dropSink;

            dropSink.ModelCanDrop += delegate (object sender, ModelDropEventArgs e)
            {
                DataRowView dataRowView = e.TargetModel as DataRowView;
                if (dataRowView == null || GetNodeType(dataRowView["type"]) == TreeNodeType.FOLDER)
                {
                    e.Effect = DragDropEffects.None;
                }
                else
                {
                    e.Effect = DragDropEffects.Move;
                }
            };

            dropSink.ModelDropped += delegate (object sender, ModelDropEventArgs e)
            {
                if (e.TargetModel == null)
                    return;
                DataRowView targetRow = e.TargetModel as DataRowView;

                foreach (var row in e.SourceModels)
                {
                    DataRowView sourceRow = row as DataRowView;
                    int catalogId = SQLiteManager.GetInstance().Inventory().GetCatalogId(Convert.ToInt32(sourceRow["id"]));
                    int targerId = Convert.ToInt32(targetRow["id"]);
                    if (catalogId != targerId)
                    {
                        SQLiteManager.GetInstance().Inventory().Update(Convert.ToInt32(sourceRow["id"]), targerId);
                    }
                }

                RefreshList();
            };

            dtlCatalogs.RebuildColumns();
        }

        private void RefreshCatalogs()
        {
            DataSet dataSetCatalogs = SQLiteManager.GetInstance().Catalogs().ReturnDataSet();
            bindingSourceCatalogs.DataSource = dataSetCatalogs;
            dtlCatalogs.ExpandAll();
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
            contextMenuStripInventory.Items.Clear();
            contextMenuStripInventory.Items.AddRange(new[] { addMenuItem, editMenuItem, removeMenuItem });
            // Ассоциируем контекстное меню со списком
            dlvInventory.ContextMenuStrip = contextMenuStripInventory;
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

            dlvInventory.CheckBoxes = true;
            dlvInventory.PersistentCheckBoxes = true;
            bindingSource = new BindingSource();
            dlvInventory.DataSource = bindingSource;
            dlvInventory.IsSimpleDragSource = true;
            dlvInventory.IsSimpleDropSink = true;

            this.dlvInventory.FormatCell += delegate (object cender, FormatCellEventArgs args)
            {
                if (args.Column?.AspectName == "amount")
                {
                    DataRowView dataRowView = args.Model as DataRowView;
                    int l_DecimalPlaces = SQLiteSettingsManager.GetInstance().Measurement().GetDecimalPlacesByName(dataRowView["measurement"].ToString());
                    args.SubItem.Text = String.Format($"{{0:n{l_DecimalPlaces}}}", args.SubItem.Text);
                }
                else if (args.Column?.AspectName == "invoice")
                {
                    args.SubItem.BackColor = Definitions.COLOR_SUBITEM_DOCUMENT_BACK_COLOR;
                    args.SubItem.Text = Path.GetFileName(args.SubItem.Text);
                }
                else if (args.Column?.AspectName == "balance")
                {

                    DataRowView dataRowView = args.Model as DataRowView;
                    object balance = dataRowView["balance"];
                    int l_DecimalPlaces = SQLiteSettingsManager.GetInstance().Measurement().GetDecimalPlacesByName(dataRowView["measurement"].ToString());
                    if (!Equals(balance, DBNull.Value))
                    {
                        //if (Convert.ToDecimal(balance) <= 0)
                        //{
                        //    args.SubItem.BackColor = Definitions.COLOR_SUBITEM_BALANCE_MIN_BACK_COLOR;
                        //}
                        args.SubItem.Text = String.Format($"{{0:n{l_DecimalPlaces}}}", balance);
                    }
                    else
                    {
                        args.SubItem.Text = String.Format($"{{0:n{l_DecimalPlaces}}}", dataRowView["amount"]);
                    }
                }
            };

            this.dlvInventory.FormatRow += delegate (object cender, FormatRowEventArgs args)
            {
                DataRowView dataRowView = args.Model as DataRowView;
                if (!Equals(dataRowView["balance"], DBNull.Value))
                {
                    if (Convert.ToDecimal(dataRowView["balance"]) <= 0)
                    {
                        args.Item.BackColor = Definitions.COLOR_ROW_BALANCE_BACK_COLOR;//Color.LightPink;
                    }
                }
            };

            columnPrice.AspectToStringConverter = delegate (object obj)
            {
                return string.Format(new CultureInfo("ru-RU"),
                      "{0:C}",
                      Convert.ToDecimal(obj, CultureInfo.InvariantCulture));
            };

            columnSum.AspectToStringConverter = delegate (object obj)
            {
                return string.Format(new CultureInfo("ru-RU"),
                      "{0:C}",
                      Convert.ToDecimal(obj, CultureInfo.InvariantCulture));
            };

            // custom sorting by column
            dlvInventory.CustomSorter = delegate (OLVColumn column, SortOrder order)
            {
                switch(column.AspectName)
                {
                    case "date":
                        dlvInventory.ListViewItemSorter = new NeuroDateComparer(columnDate, order);
                        break;
                    case "invoiceDate":
                        dlvInventory.ListViewItemSorter = new NeuroDateComparer(columnInvoiceDate, order);
                        break;
                    case "amount":
                        dlvInventory.ListViewItemSorter = new NeuroNumberComparer(columnAmount, order);
                        break;
                    case "price":
                        dlvInventory.ListViewItemSorter = new NeuroCurrencyComparer(columnPrice, order);
                        break;
                    case "sum":
                        dlvInventory.ListViewItemSorter = new NeuroCurrencyComparer(columnSum, order);
                        break;
                    default:
                        dlvInventory.ListViewItemSorter = new ColumnComparer(column, order);
                        break;
                }
            };

            dlvInventory.PrimarySortColumn = columnDate;
            dlvInventory.PrimarySortOrder = SortOrder.Ascending;
            dlvInventory.Sort();

            // drag n drop
            SimpleDropSink dropSink = new SimpleDropSink();
            dropSink.CanDropOnItem = true;
            dropSink.FeedbackColor = Definitions.COLOR_DROPSINK_FEEDBACK_COLOR;
            dlvInventory.DropSink = dropSink;

            //dlvInventory.UseTranslucentHotItem = true;
            //dlvInventory.UseTranslucentSelection = true;

            // Make the hot item show an overlay when it changes
            //if (dlvInventory.UseTranslucentHotItem)
            //{
            //    dlvInventory.HotItemStyle.Overlay = new InventoryOverlay();
            //    dlvInventory.HotItemStyle = dlvInventory.HotItemStyle;
            //}

            //dlvInventory.UseTranslucentSelection = dlvInventory.UseTranslucentHotItem;

            dlvInventory.CellToolTip.Font = new Font("Microsoft Sans Serif", 24);
            dlvInventory.CellToolTip.IsBalloon = true;

            dlvInventory.RebuildColumns();
        }

        protected override FastDataListView GetListView()
        {
            return dlvInventory;
        }

        private void RefreshList()
        {
            if (dtlCatalogs.SelectedObject != null || dtlCatalogs.SelectedObjects?.Count > 0)
            {
                bindingSource.DataMember = "inventory";
                bindingSource.DataSource = ReturnDataSet();
            }
        }

        private void ResetList()
        {
            bindingSource.DataMember = "inventory";
            bindingSource.DataSource = null;
        }

        protected override void InitForm()
        {
            base.InitForm();

            this.Name = "tabInventoryPlus";
            this.Text = "tabInventoryPlus";
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
            DataRowView dataRowViewCatalogs = dtlCatalogs.SelectedObject as DataRowView;
            DataRowView dataRowViewInventory = dlvInventory.SelectedObject as DataRowView;

            if (dataRowViewCatalogs != null && GetNodeType(dataRowViewCatalogs["type"]) == TreeNodeType.FILE)
            {
                InventoryEditor editor = new InventoryEditor(Convert.ToInt32(dataRowViewCatalogs["id"]));
                editor.StartPosition = FormStartPosition.CenterParent;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                }
            }
            else
            {
                MessageBox.Show(Definitions.INSERT_WARNING_STRING);
            }
        }

        /// <summary>
        /// Удаление записи из таблицы
        /// </summary>
        public override void RemoveRecord()
        {
            if(dlvInventory.SelectedObjects?.Count > 0)
            {
                foreach (var selectedObject in dlvInventory.SelectedObjects)
                {
                    DataRowView dataRowView = selectedObject as DataRowView;
                    SQLiteManager.GetInstance().Inventory().Remove(Convert.ToInt32(dataRowView["id"]));
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
            DataRowView dataRowViewCatalogs = dtlCatalogs.SelectedObject as DataRowView;
            DataRowView dataRowViewInventory = dlvInventory.SelectedObject as DataRowView;
            if (dataRowViewCatalogs != null && GetNodeType(dataRowViewCatalogs["type"]) == TreeNodeType.FILE
                && dataRowViewInventory != null)
            {
                InventoryEditor editor = new InventoryEditor(Convert.ToInt32(dataRowViewCatalogs["id"]), Convert.ToInt32(dataRowViewInventory["id"]));
                editor.StartPosition = FormStartPosition.CenterParent;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                }
            }
        }

        public override DataSet ReturnDataSet()
        {
            return SQLiteManager.GetInstance().Inventory().ReturnDataSet();
        }

        public override void Clear()
        {
            throw new NotImplementedException();
        }

        public override void Exit()
        {
            base.Exit();
        }

        #region RELEASED

        private void btnDemand_Click(object sender, EventArgs e)
        {
            if(dlvInventory.CheckedObjects?.Count > 0)
            {
                DemandEditor editor = new DemandEditor(GetDemandDataSet());
                editor.StartPosition = FormStartPosition.CenterParent;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                }
            }
            else
            {
                MessageBox.Show(Definitions.DEMAND_SELECTION_WARNING_STRING);
            }
        }

        private DataSet GetDemandDataSet()
        {
            DataTable demandTable = new DataTable("DemandReport");
            demandTable.Columns.Add("id");
            demandTable.Columns.Add("name");
            demandTable.Columns.Add("OKEIcode");
            demandTable.Columns.Add("invoice_code");
            demandTable.Columns.Add("measurement");
            demandTable.Columns.Add("price");
            demandTable.Columns.Add("amount");
            demandTable.Columns.Add("sum");
            demandTable.Columns.Add("balance");

            foreach (var obj in dlvInventory.CheckedObjects)
            {
                DataRow newRow = demandTable.NewRow();
                DataRowView dataRowView = obj as DataRowView;

                newRow["id"] = dataRowView["id"];
                newRow["name"] = dataRowView["name"];
                newRow["OKEIcode"] = dataRowView["OKEIcode"];
                newRow["invoice_code"] = dataRowView["invoiceCodeStr"];
                newRow["measurement"] = dataRowView["measurement"];
                newRow["price"] = dataRowView["price"];
                newRow["amount"] = 0;
                newRow["sum"] = 0.0m;
                newRow["balance"] = CalculateBalance(dataRowView);

                demandTable.Rows.Add(newRow);
            }

            DataSet demandDataSet = new DataSet("Report");
            demandDataSet.Tables.Add(demandTable);

            return demandDataSet;
        }

        private static object CalculateBalance(DataRowView dataRowView)
        {
            object balance = dataRowView["balance"];
            object balanceValue = null;
            if (balance != null && !Equals(balance, DBNull.Value))
            {
                balanceValue = balance;
            }
            else
            {
                balanceValue = dataRowView["amount"];
            }

            return balanceValue;
        }

        #endregion

        private void dlvInventory_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            OLVListItem item = e.Item as OLVListItem;
            DataRowView dataRowView = item.RowObject as DataRowView;

            object l_Balance = dataRowView["balance"];
            if (!Equals(l_Balance, DBNull.Value))
            {
                decimal l_BalanceValue = Convert.ToDecimal(l_Balance);

                if (l_BalanceValue <= 0)
                {
                    item.Checked = false;
                }
            }
        }

        private void dlvInventory_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            if (e.Model != null)
            {
                contextMenuStripInventory.Items["addToolStripMenuItem"].Visible = false;
                contextMenuStripInventory.Items["editToolStripMenuItem"].Visible = true;
                contextMenuStripInventory.Items["removeToolStripMenuItem"].Visible = true;
            }
            else
            {
                contextMenuStripInventory.Items["addToolStripMenuItem"].Visible = true;
                contextMenuStripInventory.Items["editToolStripMenuItem"].Visible = false;
                contextMenuStripInventory.Items["removeToolStripMenuItem"].Visible = false;
            }
            e.MenuStrip = contextMenuStripInventory;
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            TimedFilter(dlvInventory, ((TextBox)sender).Text, 0);
        }

        private void dlvInventory_CellClick(object sender, CellClickEventArgs e)
        {
            if(e.Column?.AspectName == "invoice")
            {
                DataRowView dataRowView = e.Model as DataRowView;
                NeuroFile.OpenFileInExplorer(dataRowView["invoice"].ToString());
            }
        }

        private void dtlCatalogs_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            DataRowView dataRowView = e.Model as DataRowView;
            if(e.Model != null)
            {
                if(!Equals(dataRowView["parent"], "0")) // !is root
                {
                    if(GetNodeType(dataRowView["type"]) == TreeNodeType.FOLDER) // is folder
                    {
                        contextMenuStripCatalogs.Items["addFolderItem"].Visible = true;
                        contextMenuStripCatalogs.Items["addFileItem"].Visible = true;
                        contextMenuStripCatalogs.Items["renameFolderItem"].Visible = true;
                        contextMenuStripCatalogs.Items["renameFileItem"].Visible = false;
                        contextMenuStripCatalogs.Items["removeFolderItem"].Visible = true;
                        contextMenuStripCatalogs.Items["removeFileItem"].Visible = false;
                    }
                    else // is file
                    {
                        contextMenuStripCatalogs.Items["addFolderItem"].Visible = false;
                        contextMenuStripCatalogs.Items["addFileItem"].Visible = false;
                        contextMenuStripCatalogs.Items["renameFolderItem"].Visible = false;
                        contextMenuStripCatalogs.Items["renameFileItem"].Visible = true;
                        contextMenuStripCatalogs.Items["removeFolderItem"].Visible = false;
                        contextMenuStripCatalogs.Items["removeFileItem"].Visible = true;
                    }
                }
                else // is root
                {
                    contextMenuStripCatalogs.Items["addFolderItem"].Visible = true;
                    contextMenuStripCatalogs.Items["addFileItem"].Visible = true;
                    contextMenuStripCatalogs.Items["renameFolderItem"].Visible = false;
                    contextMenuStripCatalogs.Items["renameFileItem"].Visible = false;
                    contextMenuStripCatalogs.Items["removeFolderItem"].Visible = false;
                    contextMenuStripCatalogs.Items["removeFileItem"].Visible = false;
                }
                contextMenuStripCatalogs.Show(dtlCatalogs, e.Location);
            }
            else
            {
                contextMenuStripCatalogs.Hide();
                contextMenuStripCatalogs.Items["addFolderItem"].Visible = false;
                contextMenuStripCatalogs.Items["addFileItem"].Visible = false;
                contextMenuStripCatalogs.Items["renameFolderItem"].Visible = false;
                contextMenuStripCatalogs.Items["renameFileItem"].Visible = false;
                contextMenuStripCatalogs.Items["removeFolderItem"].Visible = false;
                contextMenuStripCatalogs.Items["removeFileItem"].Visible = false;
            }
        }

        private void dtlCatalogs_CellClick(object sender, CellClickEventArgs e)
        {
            SelectInventory(dtlCatalogs.SelectedObjects);
        }

        private void SelectInventory(IList selectedObjects)
        {
            if(selectedObjects?.Count > 0)
            {
                List<int> l_InventoryIds = new List<int>();

                foreach(var node in selectedObjects)
                {
                    DataRowView dataRowView = node as DataRowView;
                    if (GetNodeType(dataRowView["type"]) == TreeNodeType.FILE) // is file
                    {
                        l_InventoryIds.Add(Convert.ToInt32(dataRowView["id"]));
                    }
                }
                if(l_InventoryIds.Count > 0)
                {
                    SQLiteManager.GetInstance().Inventory().SetCommandDataSet(l_InventoryIds);
                    RefreshList();
                }
                else
                {
                    ResetList();
                }
            }
        }

        public override void SaveState()
        {
            byte[] columnSettings = dlvInventory.SaveState();
            ColumnSettings.GetInstance().LvInventorySettings = columnSettings;
        }

        public override void RestoreState()
        {
            byte[] columnSettings = ColumnSettings.GetInstance().LvInventorySettings;
            if (columnSettings != null && columnSettings.Length > 0)
            {
                dlvInventory.RestoreState(columnSettings);
            }
        }

        public override void FocusFilter()
        {
            tbFilter.Clear();
            tbFilter.Focus();
        }

        private void dlvInventory_CellToolTipShowing(object sender, ToolTipShowingEventArgs e)
        {
            if (dlvInventory.SelectedObjects != null && dlvInventory.SelectedObjects.Count > 1)
            {
                decimal sum = 0;
                foreach (object obj in dlvInventory.SelectedObjects)
                {
                    DataRowView dataRowView = obj as DataRowView;
                    if (dataRowView != null && dataRowView["sum"] != null)
                    {
                        if (decimal.TryParse(dataRowView["sum"].ToString(), NumberStyles.Currency, CultureInfo.CreateSpecificCulture("en-EN"), out decimal result))
                        {
                            sum += result;
                        }
                    }
                }
                e.Text = $"{Definitions.INVENTORY_TOTAL_SUM}{sum}";
            }
        }
    }
}
