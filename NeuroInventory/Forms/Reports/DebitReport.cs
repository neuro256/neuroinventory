using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class DebitReport : Form, IReportView
    {
        private int m_lwSelectedIndex;

        public int LwSelectedIndex { get => m_lwSelectedIndex; set => m_lwSelectedIndex = value; }

        public DebitReport()
        {
            InitializeComponent();
            InitControls();
        }

        public void InitControls()
        {
            cbCatalog.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCatalog.Sorted = false;
            DataSet catalogDataSet = SQLiteManager.GetInstance().Catalogs().ReturnDataSet("SELECT id, name FROM catalogs");
            cbCatalog.DataSource = catalogDataSet.Tables[0];
            cbCatalog.DisplayMember = "name";
            cbCatalog.ValueMember = "id";

            dateTimePicker.Format = DateTimePickerFormat.Short;
            dateTimePicker.Value = DateTime.Today;
            dateTimePicker.ShowUpDown = false;

            lwDebitReport.View = View.Details;
            lwDebitReport.FullRowSelect = true;
            lwDebitReport.Scrollable = true;
            lwDebitReport.GridLines = true;
            lwDebitReport.CheckBoxes = true;
            lwDebitReport.OwnerDraw = true;
            lwDebitReport.HeaderStyle = ColumnHeaderStyle.Clickable;
            lwDebitReport.Columns.Clear();
            lwDebitReport.Columns.Add(new ColHeader("№", 50, System.Windows.Forms.HorizontalAlignment.Left, true)); // 1
            lwDebitReport.Columns.Add(new ColHeader("Наименование", 200, System.Windows.Forms.HorizontalAlignment.Left, true)); // 2
            lwDebitReport.Columns.Add(new ColHeader("Код ОКЕИ", 140, System.Windows.Forms.HorizontalAlignment.Left, true)); // 3
            lwDebitReport.Columns.Add(new ColHeader("Единица измерения", 100, System.Windows.Forms.HorizontalAlignment.Left, true)); // 4
            lwDebitReport.Columns.Add(new ColHeader("Общее количество", 200, System.Windows.Forms.HorizontalAlignment.Left, true)); // 5
            lwDebitReport.Columns.Add(new ColHeader("Количество списанного", 200, System.Windows.Forms.HorizontalAlignment.Left, true)); // 6
            lwDebitReport.Columns.Add(new ColHeader("Цена", 100, System.Windows.Forms.HorizontalAlignment.Left, true)); // 7
            lwDebitReport.Columns.Add(new ColHeader("Сумма списанного", 200, System.Windows.Forms.HorizontalAlignment.Left, true)); // 8
        }

        public void ShowTable()
        {
            DataSet dataSet = ReturnDataSet();
            try
            {
                //Заполняем список
                lwDebitReport.BeginUpdate();
                lwDebitReport.Items.Clear();
                lwDebitReport.Columns[0].Tag = false;
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    ListViewItem newItem = new ListViewItem();
                    newItem.Text = (i + 1).ToString();
                    newItem.Name = dataSet.Tables[0].Rows[i]["id"].ToString();
                    newItem.Tag = dataSet.Tables[0].Rows[i]["id"];
                    lwDebitReport.Items.Add(newItem);
                    for (int j = 1; j < dataSet.Tables[0].Columns.Count; j++)
                    {
                        ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem();
                        subitem.Text = dataSet.Tables[0].Rows[i][j].ToString();
                        subitem.Name = dataSet.Tables[0].Columns[j].ToString();
                        lwDebitReport.Items[i].SubItems.Add(subitem);
                    }
                }
                lwDebitReport.EndUpdate();
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

        public DataSet ReturnDataSet()
        {
            int l_SelectedCatalogId = cbCatalog.SelectedValue != null ? Convert.ToInt32(cbCatalog.SelectedValue) : 0;

            if (cbFilter.Checked)
                SQLiteManager.GetInstance().DebitReport().SetCommandDataSetInner(l_SelectedCatalogId);
            else
                SQLiteManager.GetInstance().DebitReport().SetCommandDataSetLeft(l_SelectedCatalogId);

            return SQLiteManager.GetInstance().DebitReport().ReturnDataSet();
        }

        private double GetTotalPrice()
        {
            double sum = 0.0;
            if (lwDebitReport.CheckedItems.Count > 0)
            {
                foreach (ListViewItem item in lwDebitReport.CheckedItems)
                {
                    sum += Convert.ToDouble(item.SubItems[7].Text, CultureInfo.InvariantCulture);
                }
            }
            return sum;
        }

        private string GetTotalPriceStr()
        {
            return DateAndMoneyConverter.CurrencyToTxt(GetTotalPrice(), true);
        }

        private void DebitReport_Shown(object sender, EventArgs e)
        {
            ShowTable();
        }

        private void cbEmployee_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ShowTable();
        }

        private void cbCatalog_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ShowTable();
        }

        private void lwDebitReport_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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

        private void lwDebitReport_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lwDebitReport_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lwDebitReport_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(this.lwDebitReport.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                this.lwDebitReport.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in this.lwDebitReport.Items)
                    item.Checked = !value;

                this.lwDebitReport.Invalidate();
            }
            else
            {
                // Create an instance of the ColHeader class.
                ColHeader clickedCol = (ColHeader)lwDebitReport.Columns[e.Column];

                // Set the ascending property to sort in the opposite order.
                clickedCol.ascending = !clickedCol.ascending;

                // Get the number of items in the list.
                int numItems = lwDebitReport.Items.Count;

                // Turn off display while data is repoplulated.
                lwDebitReport.BeginUpdate();

                // Populate an ArrayList with a SortWrapper of each list item.
                ArrayList SortArray = new ArrayList();
                for (int i = 0; i < numItems; i++)
                {
                    SortArray.Add(new SortWrapper(lwDebitReport.Items[i], e.Column));
                }

                // Sort the elements in the ArrayList using a new instance of the SortComparer
                // class. The parameters are the starting index, the length of the range to sort,
                // and the IComparer implementation to use for comparing elements. Note that
                // the IComparer implementation (SortComparer) requires the sort
                // direction for its constructor; true if ascending, othwise false.
                SortArray.Sort(0, SortArray.Count, new SortWrapper.SortComparer(clickedCol.ascending));

                // Clear the list, and repopulate with the sorted items.
                lwDebitReport.Items.Clear();
                for (int i = 0; i < numItems; i++)
                    lwDebitReport.Items.Add(((SortWrapper)SortArray[i]).sortItem);

                // Turn display back on.
                lwDebitReport.EndUpdate();
            }
        }

        private void lwDebitReport_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                // При выборе строки событие ItemSelectionChanged возникает два раза:
                // первый раз, когда выделенная в данный момент строка теряут фокус,
                // второй - когда строка, в которой сделан щелчок, получает фокус.
                // Нас интересует строка, которая получает фокус.
                if (e.IsSelected)
                {
                    LwSelectedIndex = e.ItemIndex;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Создание отчета (требование-накладная)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReport_Click(object sender, EventArgs e)
        {
            CreateReport();
        }

        public void CreateReport()
        {
            if (lwDebitReport.CheckedItems.Count > 0)
            {
                DataSet dataSetDebitReport = GetDebitReportDataSet();
                Dictionary<string, object> DebitReportFieldsData = GetReportFieldsData();

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Файлы документов (*.xls)|*.xls";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Устаревший код
                    //IReportWrapper gemboxReport = new GemboxXlsWrapper(saveFileDialog.FileName, dataSetDebitReport, DebitReportFieldsData);
                    //if (gemboxReport.CreateReport(saveFileDialog.FileName, dataSetDebitReport, DebitReportFieldsData))
                    //{
                    //    SQLiteManager.GetInstance().DebitReport().Insert(DateTime.Now, saveFileDialog.FileName);
                    //}
                }
            }
            else
            {
                MessageBox.Show(Definitions.SELECT_RECORDS);
            }
        }

        private Dictionary<string, object> GetReportFieldsData()
        {
            Dictionary<string, object> fieldsData = new Dictionary<string, object>();
            fieldsData["Date"] = DateAndMoneyConverter.DateToTextLong(dateTimePicker.Value, "г.");
            fieldsData["Date2"] = DateAndMoneyConverter.DateToTextLong(dateTimePicker.Value, "г.");
            fieldsData["TotalPrice"] = Convert.ToDecimal(GetTotalPrice(), CultureInfo.InvariantCulture).ToString("0.00"); 
            fieldsData["TotalPriceStr"] = GetTotalPriceStr();

            return fieldsData;
        }

        private DataSet GetDebitReportDataSet()
        {
            DataTable DebitReportTable = new DataTable("DebitReport");
            DebitReportTable.Columns.Add("id");
            DebitReportTable.Columns.Add("number");
            DebitReportTable.Columns.Add("name");
            DebitReportTable.Columns.Add("OKEIcode");
            DebitReportTable.Columns.Add("measurement");
            DebitReportTable.Columns.Add("amount");
            DebitReportTable.Columns.Add("price");
            DebitReportTable.Columns.Add("sum");

            int counter = 1;

            foreach (ListViewItem item in lwDebitReport.CheckedItems)
            {
                DataRow newRow = DebitReportTable.NewRow();

                newRow["id"] = item.Text;
                newRow["number"] = counter;
                newRow["name"] = item.SubItems[1].Text;
                newRow["OKEIcode"] = item.SubItems[2].Text;
                newRow["measurement"] = item.SubItems[3].Text;
                newRow["amount"] = !String.IsNullOrEmpty(item.SubItems[5].Text) ? item.SubItems[5].Text : "0";
                newRow["price"] = Convert.ToDecimal(item.SubItems[6].Text, CultureInfo.InvariantCulture).ToString("0.00");
                newRow["sum"] = !String.Equals(item.SubItems[7].Text, "0.00") ? Convert.ToDecimal(item.SubItems[7].Text, CultureInfo.InvariantCulture).ToString("0.00") : "0.00";

                counter++;

                DebitReportTable.Rows.Add(newRow);
            }

            DataSet DebitReportDataSet = new DataSet("Report");
            DebitReportDataSet.Tables.Add(DebitReportTable);

            return DebitReportDataSet;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }

        private void DebitReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cbFilter_CheckedChanged(object sender, EventArgs e)
        {
            ShowTable();
        }
    }
}
