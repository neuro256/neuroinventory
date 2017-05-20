using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;
using System.Collections;

namespace NeuroInventory
{
    public partial class TabProviders : Form, IInventoryTab
    {
        int m_ListviewSelectedIndex;

        public TabProviders()
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
            lwProviders.View = View.Details;
            lwProviders.FullRowSelect = true;
            lwProviders.MultiSelect = false;
            lwProviders.GridLines = true;
            lwProviders.ItemSelectionChanged += ListViewItemSelectionChanged;
            lwProviders.ColumnClick += ListViewColumnClick;
            lwProviders.ColumnWidthChanged += ListViewColumnWidthChanged;
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

        public void ShowTable()
        {
            if (!SQLiteManager.GetInstance().TestConnection())
                return;
            DataSet dataSet = new DataSet();
            try
            {
                dataSet = SQLiteManager.GetInstance().Providers().ReturnDataSet();
                //Заполняем список
                lwProviders.BeginUpdate();
                lwProviders.Items.Clear();
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    lwProviders.Items.Add(dataSet.Tables[0].Rows[i]["id"].ToString());
                    lwProviders.Items[i].SubItems.Add((i + 1).ToString());

                    for(int j = 1; j < dataSet.Tables[0].Columns.Count; j++)
                    {
                        lwProviders.Items[i].SubItems.Add(dataSet.Tables[0].Rows[i][j].ToString());
                    }
                }
                lwProviders.EndUpdate();
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
        /// Сортировка столбцов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ListViewColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Create an instance of the ColHeader class.
            ColHeader clickedCol = (ColHeader)lwProviders.Columns[e.Column];

            // Set the ascending property to sort in the opposite order.
            clickedCol.ascending = !clickedCol.ascending;

            // Get the number of items in the list.
            int numItems = lwProviders.Items.Count;

            // Turn off display while data is repoplulated.
            lwProviders.BeginUpdate();

            // Populate an ArrayList with a SortWrapper of each list item.
            ArrayList SortArray = new ArrayList();
            for (int i = 0; i < numItems; i++)
            {
                SortArray.Add(new SortWrapper(lwProviders.Items[i], e.Column));
            }

            // Sort the elements in the ArrayList using a new instance of the SortComparer
            // class. The parameters are the starting index, the length of the range to sort,
            // and the IComparer implementation to use for comparing elements. Note that
            // the IComparer implementation (SortComparer) requires the sort
            // direction for its constructor; true if ascending, othwise false.
            SortArray.Sort(0, SortArray.Count, new SortWrapper.SortComparer(clickedCol.ascending));

            // Clear the list, and repopulate with the sorted items.
            lwProviders.Items.Clear();
            for (int i = 0; i < numItems; i++)
                lwProviders.Items.Add(((SortWrapper)SortArray[i]).sortItem);

            // Turn display back on.
            lwProviders.EndUpdate();
        }

        /// <summary>
        /// Сокрытие столбца ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ListViewColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            // Удаляем из обработчика
            lwProviders.ColumnWidthChanged -= ListViewColumnWidthChanged;
            // Изменяем размер
            lwProviders.Columns[0].Width = 0;
            // Возвращаем обработчику
            lwProviders.ColumnWidthChanged += ListViewColumnWidthChanged;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataSet.Dispose();
            }
        }

        public void ListViewItemDoubleClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
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

        public void AddRecord()
        {
            throw new NotImplementedException();
        }

        public void RemoveRecord()
        {
            throw new NotImplementedException();
        }

        public void UpdateRecord()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
