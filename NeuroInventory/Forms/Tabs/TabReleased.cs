using System;
using System.Collections;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class TabReleased : InventoryView
    {
        class ReleasedIds
        {
            public int inventoryId;
            public int demandId;
        }

        private ReleasedFilter m_Filter;

        private ReleasedFilter Filter { get => m_Filter; set => m_Filter = value; }

        public TabReleased()
        {
            InitializeComponent();
            InitForm();
            InitListView();
            InitContextMenuStrip();
            m_ListviewSelectedIndex = 0;
            SQLiteManager.GetInstance().Released().SetCommandSet();
        }

        protected override void InitForm()
        {
            base.InitForm();

            this.Name = "TabDemand";
            this.Text = "TabDemand";

            ReleasedFilter.Filtration += ReleasedFiltration;
        }

        public override void InitListView()
        {
            base.InitListView();

            lwReleased.View = View.Details;
            lwReleased.FullRowSelect = true;
            lwReleased.Scrollable = true;
            lwReleased.GridLines = true;
            lwReleased.CheckBoxes = true;
            lwReleased.OwnerDraw = true;
            lwReleased.HeaderStyle = ColumnHeaderStyle.Clickable;
            lwReleased.DoubleBuffered(true);
            // Добавление столбцов
            // Необходимо добавлять столбцы именно так, иначе ColumnHeader не сможет преобразоваться в ColHeader (используется в методе сортировки)
            lwReleased.Columns.Clear();
            lwReleased.Columns.Add(new ColHeader("№", 60, HorizontalAlignment.Left, true));
            lwReleased.Columns.Add(new ColHeader("Дата поступления", 120, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwReleased.Columns.Add(new ColHeader("Дата отпуска", 120, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwReleased.Columns.Add(new ColHeader("Номер накладной", 120, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwReleased.Columns.Add(new ColHeader("Наименование", 350, HorizontalAlignment.Left, true));
            lwReleased.Columns.Add(new ColHeader("Код ОКЕИ", 80, HorizontalAlignment.Left, true));
            lwReleased.Columns.Add(new ColHeader("Единица измерения", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwReleased.Columns.Add(new ColHeader("Кому отпущено", 250, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwReleased.Columns.Add(new ColHeader("Количество", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwReleased.Columns.Add(new ColHeader("Цена", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwReleased.Columns.Add(new ColHeader("Сумма", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwReleased.Columns.Add(new ColHeader("Документ", 200, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwReleased.Columns.Add(new ColHeader("Состояние списания", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
        }

        private void btnReleasedRemove_Click(object sender, EventArgs e)
        {
            RemoveRecord();
        }

        /// <summary>
        /// Удаление записи из таблицы
        /// </summary>
        public override void RemoveRecord()
        {
            if(m_Listview.SelectedItems.Count > 0)
            {
                SQLiteManager.GetInstance().Released().Remove(m_ListviewSelectedIndex);
                RemoveFromListViewAt(m_ListviewSelectedIndex);
                m_Listview.SelectedItems.Clear();
            }
            else
            {
                MessageBox.Show(Definitions.REMOVE_WARNING_STRING);
            }
        }

        protected override ListView GetListView()
        {
            return lwReleased;
        }

        protected override ContextMenuStrip GetContextMenuStrip()
        {
            return contextMenuStripReleased;
        }

        public override DataSet ReturnDataSet()
        {
            return SQLiteManager.GetInstance().Released().ReturnDataSet();
        }

        public override void ShowTable()
        {
            DataSet dataSet = ReturnDataSet();
            try
            {
                int l_DecimalPlaces = 0;
                //Заполняем список
                m_Listview.BeginUpdate();
                m_Listview.Items.Clear();
                m_Listview.Columns[0].Tag = false;

                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    ListViewItem newItem = new ListViewItem();
                    newItem.Text = (i + 1).ToString();
                    newItem.Name = dataSet.Tables[0].Rows[i]["id"].ToString();
                    ReleasedIds ids = new ReleasedIds();
                    ids.inventoryId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["id"]);
                    ids.demandId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["demandId"]);
                    newItem.Tag = ids;
                    m_Listview.Items.Add(newItem);

                    for (int j = 1; j < dataSet.Tables[0].Columns.Count; j++)
                    {
                        ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem();
                        subitem.Text = dataSet.Tables[0].Rows[i][j].ToString();
                        subitem.Name = dataSet.Tables[0].Columns[j].ToString();
                        // Костыль для правильного отображения количества тмц (десятичные знаки после запятой)
                        if (subitem.Name == "amount")
                        {
                            l_DecimalPlaces = SQLiteSettingsManager.GetInstance().Measurement().GetDecimalPlacesByName(dataSet.Tables[0].Rows[i]["measurement"].ToString());
                            subitem.Text = String.Format($"{{0:n{l_DecimalPlaces}}}", dataSet.Tables[0].Rows[i][j]);
                        }
                        else if (subitem.Name == "price" || subitem.Name == "sum")
                        {
                            subitem.Text = Convert.ToDecimal(subitem.Text, CultureInfo.InvariantCulture).ToString("C");
                        }

                        if (subitem.Name == "document")
                        {
                            subitem.BackColor = Color.LightBlue;
                            subitem.Tag = subitem.Text;
                            subitem.Text = Path.GetFileName(subitem.Text);
                        }

                        if(subitem.Name == "balance")
                        {
                            object balance = dataSet.Tables[0].Rows[i]["balance"];
                            if (Equals(balance, DBNull.Value))
                            {
                                subitem.BackColor = Color.DarkOrange;
                                subitem.Text = Definitions.NOT_DEBIT_STRING;
                            }
                            else if(!Convert.ToInt32(balance).Equals(0))
                            {
                                subitem.BackColor = Color.Coral;
                                subitem.Text = Definitions.NOT_DEBIT_STRING;
                            }
                            else
                            {
                                subitem.BackColor = Color.LightGreen;
                                subitem.Text = Definitions.DEBIT_STRING;
                            }
                        }

                        if (subitem.Name != "demandId")
                        {
                            m_Listview.Items[i].SubItems.Add(subitem);
                        }
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
                Filter = new ReleasedFilter();
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

        private void ReleasedFiltration()
        {
            ShowTable();
        }

        #region DRAW CHECKBOXES

        private void lwReleased_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.DrawBackground();
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(e.Header.Tag);
                }
                catch (Exception)
                {
                }
                CheckBoxRenderer.DrawCheckBox(e.Graphics,
                    new Point(e.Bounds.Left + 4, e.Bounds.Top + 4),
                    value ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal :
                    System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void lwReleased_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lwReleased_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        public override void ListViewColumnClick(object sender, ColumnClickEventArgs e)
        {
            try
            {
                if (e.Column == 0)
                {
                    bool value = false;
                    try
                    {
                        value = Convert.ToBoolean(this.lwReleased.Columns[e.Column].Tag);
                    }
                    catch (Exception)
                    {
                    }
                    this.lwReleased.Columns[e.Column].Tag = !value;
                    foreach (ListViewItem item in this.lwReleased.Items)
                        item.Checked = !value;

                    this.lwReleased.Invalidate();
                }
                else
                {
                    // Сортировка по столбцу 

                    /*
                    // Create an instance of the ColHeader class.
                    ColHeader clickedCol = (ColHeader)m_Listview.Columns[e.Column];

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
                        SortArray.Add(new SortWrapper(m_Listview.Items[i], e.Column));
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
                    m_Listview.EndUpdate(); */
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        public override void ListViewColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            
        }

        public override void ListViewItemMouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    ListViewHitTestInfo info = m_Listview.HitTest(e.X, e.Y);
                    ListViewItem item = info.Item;

                    if (item != null)
                    {
                        m_ListviewSelectedIndex = item.Index;
                        m_ContextMenuStrip.Items["addToolStripMenuItem"].Visible = false;
                        m_ContextMenuStrip.Items["editToolStripMenuItem"].Visible = false;
                        m_ContextMenuStrip.Items["removeToolStripMenuItem"].Visible = true;
                    }
                    else
                    {
                        // No item is selected
                        this.m_Listview.SelectedItems.Clear();
                        m_ContextMenuStrip.Items["addToolStripMenuItem"].Visible = false;
                        m_ContextMenuStrip.Items["editToolStripMenuItem"].Visible = false;
                        m_ContextMenuStrip.Items["removeToolStripMenuItem"].Visible = false;
                    }
                }
                else if(e.Button == MouseButtons.Left)
                {
                    if (m_Listview.GetItemAt(e.X, e.Y)?.SubItems["document"]?.Bounds.Contains(e.X, e.Y) ?? false)
                    {
                        string l_FileName = m_Listview.GetItemAt(e.X, e.Y)?.SubItems["document"].Tag.ToString();
                        NeuroFile.OpenFileInExplorer(l_FileName);
                        m_Listview.SelectedItems.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Списать выбранные тмц
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDebitReport_Click(object sender, EventArgs e)
        {
            if(lwReleased.CheckedItems.Count > 0)
            {
                DebitEditor editor = new DebitEditor(GetDebitDataSet());
                editor.StartPosition = FormStartPosition.CenterParent;
                if(editor.ShowDialog() == DialogResult.OK)
                {
                    ShowTable();
                }
            }
            else
            {
                MessageBox.Show(Definitions.DEBIT_SELECTION_WARNING_STRING);
            }
        }

        private DataSet GetDebitDataSet()
        {
            DataTable debitTable = new DataTable("DebitReport");
            debitTable.Columns.Add("id");
            debitTable.Columns.Add("demandId");
            debitTable.Columns.Add("date");
            debitTable.Columns.Add("invoice_code");
            debitTable.Columns.Add("name");
            debitTable.Columns.Add("OKEIcode");
            debitTable.Columns.Add("measurement");
            debitTable.Columns.Add("price");
            debitTable.Columns.Add("amount");
            debitTable.Columns.Add("sum");

            foreach (ListViewItem item in lwReleased.CheckedItems)
            {
                DataRow newRow = debitTable.NewRow();

                newRow["id"] = (item.Tag as ReleasedIds).inventoryId;
                newRow["demandId"] = (item.Tag as ReleasedIds).demandId;
                newRow["date"] = item.SubItems["ordate"].Text;
                newRow["invoice_code"] = item.SubItems["invoiceCodeStr"].Text;
                newRow["name"] = item.SubItems["name"].Text;
                newRow["OKEIcode"] = item.SubItems["OKEIcode"].Text;
                newRow["measurement"] = item.SubItems["measurement"].Text;
                newRow["price"] = item.SubItems["price"].Text;
                newRow["amount"] = item.SubItems["amount"].Text;
                newRow["sum"] = item.SubItems["sum"].Text;

                debitTable.Rows.Add(newRow);
            }

            DataSet debitDataSet = new DataSet("Report");
            debitDataSet.Tables.Add(debitTable);

            return debitDataSet;
        }
    }
}
