using System;
using System.Collections;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class TabEmployees : Form, IInventoryTab
    {
        int m_ListviewSelectedIndex;

        public TabEmployees()
        {
            InitializeComponent();
            InitForm();
            InitListView();
            m_ListviewSelectedIndex = -1;
        }

        private void InitForm()
        {
            this.Name = "tabEmployees";
            this.Text = "tabEmployees";
            this.Size = new System.Drawing.Size(1200, 650);
            this.FormBorderStyle = FormBorderStyle.None;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
            this.ControlBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
        }

        public void InitListView()
        {
            lwEmployees.View = View.Details;
            lwEmployees.FullRowSelect = true;
            lwEmployees.MultiSelect = false;
            lwEmployees.GridLines = true;
            lwEmployees.ItemSelectionChanged += ListViewItemSelectionChanged;
            lwEmployees.ColumnClick += ListViewColumnClick;
            lwEmployees.ColumnWidthChanged += ListViewColumnWidthChanged;
            lwEmployees.MouseDoubleClick += ListViewItemDoubleClick;
            // Добавление столбцов
            // Необходимо добавлять столбцы именно так, иначе ColumnHeader не сможет преобразоваться в ColHeader (используется в методе сортировки)
            lwEmployees.Columns.Clear();
            lwEmployees.Columns.Add(new ColHeader("ID", 50, HorizontalAlignment.Left, true));
            lwEmployees.Columns.Add(new ColHeader("№", 50, HorizontalAlignment.Left, true));
            lwEmployees.Columns.Add(new ColHeader("Фамилия", 200, HorizontalAlignment.Left, true));
            lwEmployees.Columns.Add(new ColHeader("Имя", 200, HorizontalAlignment.Left, true));
            lwEmployees.Columns.Add(new ColHeader("Отчество", 200, HorizontalAlignment.Left, true));
            lwEmployees.Columns.Add(new ColHeader("Должность", 200, HorizontalAlignment.Left, true));
            lwEmployees.Columns.Add(new ColHeader("Отдел", 200, HorizontalAlignment.Left, true));
        }

        public void ShowTable()
        {
            if (!SQLiteManager.GetInstance().TestConnection())
                return;
            DataSet dataSet = new DataSet();
            try
            {
                dataSet = SQLiteManager.GetInstance().Employees().ReturnDataSet();
                //Заполняем список
                lwEmployees.BeginUpdate();
                lwEmployees.Items.Clear();
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    lwEmployees.Items.Add(dataSet.Tables[0].Rows[i]["id"].ToString());
                    lwEmployees.Items[i].SubItems.Add((i + 1).ToString());
                    for (int j = 1; j < dataSet.Tables[0].Columns.Count; j++)
                    {
                        lwEmployees.Items[i].SubItems.Add(dataSet.Tables[0].Rows[i][j].ToString());
                    }
                    // Example coloring
                    lwEmployees.Items[i].SubItems[5].BackColor = System.Drawing.Color.GreenYellow;
                    lwEmployees.Items[i].UseItemStyleForSubItems = false;
                }
                lwEmployees.EndUpdate();
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
        public void AddRecord()
        {
            EmployeeEditor editor = new EmployeeEditor();
            if(editor.ShowDialog() == DialogResult.OK)
            {
                ShowTable();
            }
        }

        /// <summary>
        /// Удаление записи из таблицы
        /// </summary>
        public void RemoveRecord()
        {
            if(lwEmployees.SelectedItems.Count > 0)
            {
                SQLiteManager.GetInstance().Employees().Remove(m_ListviewSelectedIndex);
                ShowTable();
            }
        }

        /// <summary>
        /// Редактирование записи из таблицы
        /// </summary>
        public void UpdateRecord()
        {
            if(lwEmployees.SelectedItems.Count > 0)
            {
                EmployeeEditor editor = new EmployeeEditor(m_ListviewSelectedIndex);
                if(editor.ShowDialog() == DialogResult.OK)
                {
                    ShowTable();
                }
            }
        }

        public void ListViewItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            DataSet dataSet = SQLiteManager.GetInstance().Employees().ReturnDataSet();
            try
            {
                // При выборе строки событие ItemSelectionChanged возникает два раза:
                // первый раз, когда выделенная в данный момент строка теряут фокус,
                // второй - когда строка, в которой сделан щелчок, получает фокус.
                // Нас интересует строка, которая получает фокус.
                if (e.IsSelected)
                {
                    m_ListviewSelectedIndex = e.ItemIndex;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataSet.Dispose();
            }
        }

        /// <summary>
        /// Сортировка столбцов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ListViewColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Create an instance of the ColHeader class.
            ColHeader clickedCol = (ColHeader)lwEmployees.Columns[e.Column];

            // Set the ascending property to sort in the opposite order.
            clickedCol.ascending = !clickedCol.ascending;

            // Get the number of items in the list.
            int numItems = lwEmployees.Items.Count;

            // Turn off display while data is repoplulated.
            lwEmployees.BeginUpdate();

            // Populate an ArrayList with a SortWrapper of each list item.
            ArrayList SortArray = new ArrayList();
            for (int i = 0; i < numItems; i++)
            {
                SortArray.Add(new SortWrapper(lwEmployees.Items[i], e.Column));
            }

            // Sort the elements in the ArrayList using a new instance of the SortComparer
            // class. The parameters are the starting index, the length of the range to sort,
            // and the IComparer implementation to use for comparing elements. Note that
            // the IComparer implementation (SortComparer) requires the sort
            // direction for its constructor; true if ascending, othwise false.
            SortArray.Sort(0, SortArray.Count, new SortWrapper.SortComparer(clickedCol.ascending));

            // Clear the list, and repopulate with the sorted items.
            lwEmployees.Items.Clear();
            for (int i = 0; i < numItems; i++)
                lwEmployees.Items.Add(((SortWrapper)SortArray[i]).sortItem);

            // Turn display back on.
            lwEmployees.EndUpdate();
        }

        /// <summary>
        /// Сокрытие столбца ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ListViewColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            // Удаляем из обработчика
            lwEmployees.ColumnWidthChanged -= ListViewColumnWidthChanged;
            // Изменяем размер
            lwEmployees.Columns[0].Width = 0;
            // Возвращаем обработчику
            lwEmployees.ColumnWidthChanged += ListViewColumnWidthChanged;
        }

        /// <summary>
        /// Редактирование выбранной по двойному нажатию мышкой записи 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ListViewItemDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = lwEmployees.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;

            if (item != null)
            {
                m_ListviewSelectedIndex = item.Index;
                UpdateRecord();
            }
            else
            {
                // No item is selected
                this.lwEmployees.SelectedItems.Clear();
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO EXAMPLE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lwEmployees_MouseUp(object sender, MouseEventArgs e)
        { 
            if((lwEmployees.GetItemAt(e.X, e.Y)?.SubItems[5]?.Bounds.Contains(e.X, e.Y) ?? false))
            {
                MessageBox.Show($"Mouse up: {lwEmployees.GetItemAt(e.X, e.Y).SubItems[5].Text}");
            }
            if(e.Button == MouseButtons.Right)
            {
                ListViewHitTestInfo info = lwEmployees.HitTest(e.X, e.Y);
                ListViewItem item = info.Item;

                if (item != null)
                {
                    m_ListviewSelectedIndex = item.Index;
                    contextMenuStripEmployees.Items[0].Visible = false;
                    contextMenuStripEmployees.Items[1].Visible = true;
                    contextMenuStripEmployees.Items[2].Visible = true;
                }
                else
                {
                    // No item is selected
                    this.lwEmployees.SelectedItems.Clear();
                    contextMenuStripEmployees.Items[0].Visible = true;
                    contextMenuStripEmployees.Items[1].Visible = false;
                    contextMenuStripEmployees.Items[2].Visible = false;
                }
            }
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
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
    }
}
