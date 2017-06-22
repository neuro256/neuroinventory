using System;
using System.Collections;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class TabReleased : InventoryView
    {
        private EmployeeFilter m_Filter;

        private EmployeeFilter Filter { get => m_Filter; set => m_Filter = value; }

        public TabReleased()
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

            this.Name = "TabDemand";
            this.Text = "TabDemand";

            EmployeeFilter.Filtration += EmployeeFiltration;
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
            // Добавление столбцов
            // Необходимо добавлять столбцы именно так, иначе ColumnHeader не сможет преобразоваться в ColHeader (используется в методе сортировки)
            lwReleased.Columns.Clear();
            lwReleased.Columns.Add(new ColHeader("ID", 50, HorizontalAlignment.Left, true));
            lwReleased.Columns.Add(new ColHeader("№", 50, HorizontalAlignment.Left, true));
            lwReleased.Columns.Add(new ColHeader("Дата поступления", 140, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwReleased.Columns.Add(new ColHeader("Наименование", 200, HorizontalAlignment.Left, true));
            lwReleased.Columns.Add(new ColHeader("Код ОКЕИ", 100, HorizontalAlignment.Left, true));
            lwReleased.Columns.Add(new ColHeader("Единица измерения", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwReleased.Columns.Add(new ColHeader("Кому отпущено", 200, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwReleased.Columns.Add(new ColHeader("Количество", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwReleased.Columns.Add(new ColHeader("Цена", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwReleased.Columns.Add(new ColHeader("Сумма", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwReleased.Columns.Add(new ColHeader("Документ", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
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
                    m_Listview.EnsureVisible(m_Listview.Items.Count - 1);
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
            if (m_Listview.SelectedItems.Count > 0)
            {
                EmployeeEditor editor = new EmployeeEditor(m_ListviewSelectedIndex);
                editor.StartPosition = FormStartPosition.CenterParent;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    ShowTable();
                    lwReleased.EnsureVisible(m_ListviewSelectedIndex);
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
            return lwReleased;
        }

        protected override ContextMenuStrip GetContextMenuStrip()
        {
            return contextMenuStripReleased;
        }

        public override DataSet ReturnDataSet()
        {
            return SQLiteManager.GetInstance().Employees().ReturnDataSet();
        }

        public override void ShowTable()
        {
            //DataSet dataSet = ReturnDataSet();
            //try
            //{
            //    //Заполняем список
            //    m_Listview.BeginUpdate();
            //    m_Listview.Items.Clear();
            //    for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            //    {
            //        m_Listview.Items.Add(dataSet.Tables[0].Rows[i]["id"].ToString());
            //        m_Listview.Items[i].SubItems.Add((i + 1).ToString());
            //        for (int j = 1; j < dataSet.Tables[0].Columns.Count - 1; j++)
            //        {
            //            ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem();
            //            subitem.Text = dataSet.Tables[0].Rows[i][j].ToString();
            //            subitem.Name = dataSet.Tables[0].Columns[j].ToString();
            //            if (subitem.Name == "document")
            //            {
            //                subitem.BackColor = Color.LightBlue;
            //                subitem.Tag = subitem.Text;
            //                subitem.Text = Path.GetFileName(subitem.Text);
            //            }
            //            m_Listview.Items[i].SubItems.Add(subitem);
            //        }
            //        m_Listview.Items[i].UseItemStyleForSubItems = false;
            //    }
            //    m_Listview.EndUpdate();
            //}
            //catch (SQLiteException se)
            //{
            //    MessageBox.Show(se.Message, "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //catch (ArgumentException se)
            //{
            //    MessageBox.Show("Error!:", se.Message);
            //}
            //finally
            //{
            //    dataSet.Dispose();
            //}
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
                    m_Listview.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void ListViewColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            
        }
    }
}
