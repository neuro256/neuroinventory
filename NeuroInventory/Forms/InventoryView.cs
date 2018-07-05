using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace NeuroInventory
{
    public class InventoryView : Form, IInventoryView
    {
        private int listviewSelectedIndex;
        private int selectedItemId;
        protected ListView m_Listview = null;
        protected ContextMenuStrip m_ContextMenuStrip = null;
        private bool useCheckox = false;
        private Dictionary<string, bool> contextMenuStripValues = null;

        protected bool UseCheckox { get => useCheckox; set => useCheckox = value; }
        protected int ListviewSelectedIndex { get => listviewSelectedIndex; set => listviewSelectedIndex = value; }
        protected int SelectedItemId { get => selectedItemId; set => selectedItemId = value; }
        protected Dictionary<string, bool> ContextMenuStripValues { get => contextMenuStripValues; set => contextMenuStripValues = value; }

        protected virtual void InitForm()
        {
            this.Size = new System.Drawing.Size(1200, 650);
            this.FormBorderStyle = FormBorderStyle.None;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
            this.ControlBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
        }

        public virtual void InitListView()
        {
            m_Listview = GetListView();
            m_Listview.View = View.Details;
            m_Listview.FullRowSelect = true;
            m_Listview.MultiSelect = false;
            m_Listview.BorderStyle = BorderStyle.None;
            m_Listview.Scrollable = true;
            m_Listview.GridLines = true;
            m_Listview.ShowItemToolTips = true;
            m_Listview.MinimumSize = new System.Drawing.Size(0, 0);
            m_Listview.ItemSelectionChanged += ListViewItemSelectionChanged;
            m_Listview.ColumnClick += ListViewColumnClick;
            m_Listview.MouseDoubleClick += ListViewItemDoubleClick;
            m_Listview.MouseUp += ListViewItemMouseUp;
        }

        public void InitContextMenuStrip()
        {
            m_ContextMenuStrip = GetContextMenuStrip();
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
            m_ContextMenuStrip.Items.Clear();
            m_ContextMenuStrip.Items.AddRange(new[] { addMenuItem, editMenuItem, removeMenuItem });
            // Значения contextMenuStrip в различных ситациях по умолчанию 
            contextMenuStripValues = new Dictionary<string, bool>();
            contextMenuStripValues.Add("addOnItem", false);
            contextMenuStripValues.Add("editOnItem", true);
            contextMenuStripValues.Add("removeOnItem", true);
            contextMenuStripValues.Add("addOnSpace", true);
            contextMenuStripValues.Add("editOnSpace", false);
            contextMenuStripValues.Add("removeOnSpace", false);
            // Ассоциируем контекстное меню со списком
            m_Listview.ContextMenuStrip = m_ContextMenuStrip;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRecord();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateRecord();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveRecord();
        }

        public virtual void ShowTable()
        {
            DataSet dataSet = ReturnDataSet();
            try
            {
                //Заполняем список
                m_Listview.BeginUpdate();
                m_Listview.Items.Clear();
                if(UseCheckox)
                {
                    m_Listview.Columns[0].Tag = false;
                }
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    ListViewItem lvItem = new ListViewItem
                    {
                        Text = (i + 1).ToString(),
                        Name = dataSet.Tables[0].Rows[i]["id"].ToString(),
                        Tag = dataSet.Tables[0].Rows[i]["id"]
                    };

                    m_Listview.Items.Add(lvItem);

                    for (int j = 1; j < dataSet.Tables[0].Columns.Count; j++)
                    {
                        ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem
                        {
                            Text = dataSet.Tables[0].Rows[i][j].ToString(),
                            Name = dataSet.Tables[0].Columns[j].ToString()
                        };

                        ShowTable_ModifySubItem(subItem);
                        ShowTable_ModifySubItem(subItem, dataSet.Tables[0].Rows[i]);

                        m_Listview.Items[i].SubItems.Add(subItem);
                    }
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

        /// <summary>
        /// Обновление нумерации списка
        /// </summary>
        private void RefreshTableNumeration()
        {
            try
            {
                //Заполняем список
                m_Listview.BeginUpdate();
                for (int i = 0; i < m_Listview.Items.Count; i++)
                {
                    m_Listview.Items[i].SubItems[0].Text = (i + 1).ToString();
                }
                m_Listview.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!:", ex.Message);
            }
        }

        /// <summary>
        /// Обновление нумерации списка
        /// </summary>
        private void RefreshTableNumeration(int p_SubitemNumber)
        {
            try
            {
                //Заполняем список
                m_Listview.BeginUpdate();
                for (int i = 0; i < m_Listview.Items.Count; i++)
                {
                    m_Listview.Items[i].SubItems[p_SubitemNumber].Text = (i + 1).ToString();
                }
                m_Listview.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!:", ex.Message);
            }
        }

        /// <summary>
        /// Сортировка столбцов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ListViewColumnClick(object sender, ColumnClickEventArgs e)
        {
            try
            {
                if (UseCheckox && e.Column == 0)
                {
                    bool value = false;
                    try
                    {
                        value = Convert.ToBoolean(m_Listview.Columns[e.Column].Tag);
                    }
                    catch (Exception)
                    {
                    }
                    GetListView().Columns[e.Column].Tag = !value;
                    foreach (ListViewItem item in GetListView().Items)
                        item.Checked = !value;

                    GetListView().Invalidate();
                }
                else
                {
                    ListViewSortByColumn(e.Column);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Сортировка по столбцу
        /// </summary>
        /// <param name="p_ColumnIndex"></param>
        private void ListViewSortByColumn(int p_ColumnIndex)
        { 
            // Create an instance of the ColHeader class.
            ColHeader clickedCol = (ColHeader)m_Listview.Columns[p_ColumnIndex];

            // Set the ascending property to sort in the opposite order.
            clickedCol.ascending = !clickedCol.ascending;

            // Get the number of items in the list.
            int numItems = m_Listview.Items.Count;

            // Turn off display while data is repoplulated.
            m_Listview.BeginUpdate();

            // Populate an ArrayList with a SortWrapper of each list item.
            ArrayList SortArray = new ArrayList();
            for (int i = 0; i < numItems; i++)
            {
                SortArray.Add(new SortWrapper(m_Listview.Items[i], p_ColumnIndex));
            }

            // Sort the elements in the ArrayList using a new instance of the SortComparer
            // class. The parameters are the starting index, the length of the range to sort,
            // and the IComparer implementation to use for comparing elements. Note that
            // the IComparer implementation (SortComparer) requires the sort
            // direction for its constructor; true if ascending, othwise false.
            SortArray.Sort(0, SortArray.Count, new SortWrapper.SortComparer(clickedCol.ascending));

            // Clear the list, and repopulate with the sorted items.
            m_Listview.Items.Clear();
            for (int i = 0; i < numItems; i++)
                m_Listview.Items.Add(((SortWrapper)SortArray[i]).sortItem);

            // Turn display back on.
            m_Listview.EndUpdate();
        }

        /// <summary>
        /// Редактирование выбранной по двойному нажатию мышкой записи 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ListViewItemDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ListViewHitTestInfo info = m_Listview.HitTest(e.X, e.Y);
                ListViewItem item = info.Item;

                if (item != null && item.Selected)
                {
                    ListviewSelectedIndex = item.Index;
                    if (item.Tag is TabReleased.ReleasedIds)
                    {
                        SelectedItemId = (item.Tag as TabReleased.ReleasedIds).demandId;
                    }
                    else
                    {
                        SelectedItemId = Convert.ToInt32(item.Tag);
                    }
                    UpdateRecord();
                    m_Listview.SelectedItems.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Событие при выборе строки в списке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void ListViewItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                // При выборе строки событие ItemSelectionChanged возникает два раза:
                // первый раз, когда выделенная в данный момент строка теряут фокус,
                // второй - когда строка, в которой сделан щелчок, получает фокус.
                // Нас интересует строка, которая получает фокус.
                if (e.IsSelected)
                {
                    ListviewSelectedIndex = e.ItemIndex;
                    if (e.Item.Tag is TabReleased.ReleasedIds)
                    {
                        SelectedItemId = (e.Item.Tag as TabReleased.ReleasedIds).demandId;
                    }
                    else
                    {
                        SelectedItemId = Convert.ToInt32(e.Item.Tag);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public virtual void ListViewItemMouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    ListViewHitTestInfo info = m_Listview.HitTest(e.X, e.Y);
                    ListViewItem item = info.Item;

                    if (item != null)
                    {
                        ListviewSelectedIndex = item.Index;
                        if (item.Tag is TabReleased.ReleasedIds)
                        {
                            SelectedItemId = (item.Tag as TabReleased.ReleasedIds).demandId;
                        }
                        else
                        {
                            SelectedItemId = Convert.ToInt32(item.Tag);
                        }
                        m_ContextMenuStrip.Items["addToolStripMenuItem"].Visible = ContextMenuStripValues["addOnItem"];
                        m_ContextMenuStrip.Items["editToolStripMenuItem"].Visible = ContextMenuStripValues["editOnItem"];
                        m_ContextMenuStrip.Items["removeToolStripMenuItem"].Visible = ContextMenuStripValues["removeOnItem"];
                    }
                    else
                    {
                        // No item is selected
                        this.m_Listview.SelectedItems.Clear();
                        m_ContextMenuStrip.Items["addToolStripMenuItem"].Visible = ContextMenuStripValues["addOnSpace"];
                        m_ContextMenuStrip.Items["editToolStripMenuItem"].Visible = ContextMenuStripValues["editOnSpace"];
                        m_ContextMenuStrip.Items["removeToolStripMenuItem"].Visible = ContextMenuStripValues["removeOnSpace"];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void RemoveFromListView(ListViewItem p_Item)
        {
            m_Listview.Items.Remove(p_Item);
            RefreshTableNumeration();
        }

        public void RemoveFromListViewAt(int p_Index)
        {
            m_Listview.Items.RemoveAt(p_Index);
            RefreshTableNumeration();
        }

        public void RemoveFromListViewAt(int p_Index, int p_SubitemNumber)
        {
            m_Listview.Items.RemoveAt(p_Index);
            RefreshTableNumeration(p_SubitemNumber);
        }

        public virtual DataSet ReturnDataSet() { return null; }
        public virtual void AddRecord() { }
        public virtual void RemoveRecord() { }
        public virtual void UpdateRecord() { }
        public virtual void Clear() { }
        protected virtual ListView GetListView() { return null; }
        protected virtual ContextMenuStrip GetContextMenuStrip() { return null; }
        public virtual void ShowTable_ModifySubItem(ListViewItem.ListViewSubItem subItem) { }
        public virtual void ShowTable_ModifySubItem(ListViewItem.ListViewSubItem subItem, DataRow dataRow) { }

        public virtual void Exit()
        {
            Close();
        }
    }
}
