using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class DemandReport : Form, IReportView
    {
        private int m_lwSelectedIndex;

        public int LwSelectedIndex { get => m_lwSelectedIndex; set => m_lwSelectedIndex = value; }

        public DemandReport()
        {
            InitializeComponent();
            InitControls();
        }

        public void InitControls()
        {
            cbEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEmployee.Sorted = false;
            DataSet employeeDataSet = SQLiteManager.GetInstance().Employees().ReturnDataSet("SELECT id, (surename || ' ' || firstname || ' ' || lastname) AS name FROM employees");
            cbEmployee.DataSource = employeeDataSet.Tables[0];
            cbEmployee.DisplayMember = "name";
            cbEmployee.ValueMember = "id";

            cbCatalog.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCatalog.Sorted = false;
            DataSet catalogDataSet = SQLiteManager.GetInstance().Catalogs().ReturnDataSet("SELECT id, name FROM catalogs");
            cbCatalog.DataSource = catalogDataSet.Tables[0];
            cbCatalog.DisplayMember = "name";
            cbCatalog.ValueMember = "id";

            lwDemandReport.View = View.Details;
            lwDemandReport.FullRowSelect = true;
            lwDemandReport.Scrollable = true;
            lwDemandReport.GridLines = true;
            lwDemandReport.CheckBoxes = true;
            lwDemandReport.OwnerDraw = true;
            lwDemandReport.HeaderStyle = ColumnHeaderStyle.Clickable;
            lwDemandReport.Columns.Clear();
            lwDemandReport.Columns.Add(new ColHeader("№", 50, System.Windows.Forms.HorizontalAlignment.Left, true)); // 1
            lwDemandReport.Columns.Add(new ColHeader("Наименование", 200, System.Windows.Forms.HorizontalAlignment.Left, true)); // 2
            lwDemandReport.Columns.Add(new ColHeader("Код ОКЕИ", 140, System.Windows.Forms.HorizontalAlignment.Left, true)); // 3
            lwDemandReport.Columns.Add(new ColHeader("Единица измерения", 100, System.Windows.Forms.HorizontalAlignment.Left, true)); // 4
            lwDemandReport.Columns.Add(new ColHeader("Количество", 200, System.Windows.Forms.HorizontalAlignment.Left, true)); // 5
            lwDemandReport.Columns.Add(new ColHeader("Цена", 100, System.Windows.Forms.HorizontalAlignment.Left, true)); // 6
            lwDemandReport.Columns.Add(new ColHeader("Сумма", 100, System.Windows.Forms.HorizontalAlignment.Left, true)); // 7
            lwDemandReport.Columns.Add(new ColHeader("Затребовал", 250, System.Windows.Forms.HorizontalAlignment.Left, true)); // 8
            lwDemandReport.Columns.Add(new ColHeader("Должность", 200, System.Windows.Forms.HorizontalAlignment.Left, true)); // 9
            lwDemandReport.Columns.Add(new ColHeader("Количество", 100, System.Windows.Forms.HorizontalAlignment.Left, true)); // 10
            lwDemandReport.Columns.Add(new ColHeader("Дата", 100, System.Windows.Forms.HorizontalAlignment.Left, true)); // 11
        }

        public void ShowTable()
        {
            if (!SQLiteManager.GetInstance().TestConnection())
                return;
            DataSet dataSet = ReturnDataSet();
            try
            {
                //Заполняем список
                lwDemandReport.BeginUpdate();
                lwDemandReport.Items.Clear();
                lwDemandReport.Columns[0].Tag = false;
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    ListViewItem newItem = new ListViewItem();
                    newItem.Text = (i + 1).ToString();
                    newItem.Name = dataSet.Tables[0].Rows[i]["id"].ToString();
                    newItem.Tag = dataSet.Tables[0].Rows[i]["id"];
                    lwDemandReport.Items.Add(newItem);
                    for (int j = 1; j < dataSet.Tables[0].Columns.Count; j++)
                    {
                        ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem();
                        subitem.Text = dataSet.Tables[0].Rows[i][j].ToString();
                        subitem.Name = dataSet.Tables[0].Columns[j].ToString();
                        lwDemandReport.Items[i].SubItems.Add(subitem);
                    }
                }
                lwDemandReport.EndUpdate();
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
            int l_SelectedEmployeeId = cbEmployee.SelectedValue != null ? Convert.ToInt32(cbEmployee.SelectedValue) : 0;
            int l_SelectedCatalogId = cbCatalog.SelectedValue != null ? Convert.ToInt32(cbCatalog.SelectedValue) : 0;
            SQLiteManager.GetInstance().DemandReport().SetCommandDataSet(l_SelectedEmployeeId, l_SelectedCatalogId);
            return SQLiteManager.GetInstance().DemandReport().ReturnDataSet();
        }

        private string GetEmployeeInitials()
        {
            int l_SelectedEmployeeId = cbEmployee.SelectedValue != null ? Convert.ToInt32(cbEmployee.SelectedValue) : 0;
            return SQLiteManager.GetInstance().Employees().GetInitialsById(l_SelectedEmployeeId);
        }

        private string GetEmployeeName()
        {
            int l_SelectedEmployeeId = cbEmployee.SelectedValue != null ? Convert.ToInt32(cbEmployee.SelectedValue) : 0;
            return SQLiteManager.GetInstance().Employees().GetNameById(l_SelectedEmployeeId);
        }

        private string GetEmployeePost()
        {
            int l_SelectedEmployeeId = cbEmployee.SelectedValue != null ? Convert.ToInt32(cbEmployee.SelectedValue) : 0;
            return SQLiteManager.GetInstance().Employees().GetEmployeePostById(l_SelectedEmployeeId);
        }

        private double GetTotalPrice()
        {
            double sum = 0.0;
            if (lwDemandReport.CheckedItems.Count > 0)
            {
                foreach (ListViewItem item in lwDemandReport.CheckedItems)
                {
                    sum += Convert.ToDouble(item.SubItems[5].Text, CultureInfo.InvariantCulture) * Convert.ToDouble(item.SubItems[9].Text, CultureInfo.InvariantCulture);
                }
            }
            return sum;
        }

        private string GetTotalPriceStr()
        {
            return DateAndMoneyConverter.CurrencyToTxtFull(GetTotalPrice(), false);
        }

        private Dictionary<string, string> GetReportFieldsData()
        {
            Dictionary<string, string> fieldsData = new Dictionary<string, string>();
            fieldsData["EmployeeInitialsBefore"] = $"{GetEmployeeInitials()} {GetEmployeeName()}";
            fieldsData["EmployeeInitialsAfter"] = $"{GetEmployeeName()} {GetEmployeeInitials()}";
            fieldsData["EmployeePost"] = GetEmployeePost();
            fieldsData["TotalPrice"] = GetTotalPriceStr();

            return fieldsData;
        }

        private void DemandReport_Shown(object sender, EventArgs e)
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

        private void lwDemandReport_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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

        private void lwDemandReport_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lwDemandReport_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lwDemandReport_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(this.lwDemandReport.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                this.lwDemandReport.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in this.lwDemandReport.Items)
                    item.Checked = !value;

                this.lwDemandReport.Invalidate();
            }
            else
            {
                // Create an instance of the ColHeader class.
                ColHeader clickedCol = (ColHeader)lwDemandReport.Columns[e.Column];

                // Set the ascending property to sort in the opposite order.
                clickedCol.ascending = !clickedCol.ascending;

                // Get the number of items in the list.
                int numItems = lwDemandReport.Items.Count;

                // Turn off display while data is repoplulated.
                lwDemandReport.BeginUpdate();

                // Populate an ArrayList with a SortWrapper of each list item.
                ArrayList SortArray = new ArrayList();
                for (int i = 0; i < numItems; i++)
                {
                    SortArray.Add(new SortWrapper(lwDemandReport.Items[i], e.Column));
                }

                // Sort the elements in the ArrayList using a new instance of the SortComparer
                // class. The parameters are the starting index, the length of the range to sort,
                // and the IComparer implementation to use for comparing elements. Note that
                // the IComparer implementation (SortComparer) requires the sort
                // direction for its constructor; true if ascending, othwise false.
                SortArray.Sort(0, SortArray.Count, new SortWrapper.SortComparer(clickedCol.ascending));

                // Clear the list, and repopulate with the sorted items.
                lwDemandReport.Items.Clear();
                for (int i = 0; i < numItems; i++)
                    lwDemandReport.Items.Add(((SortWrapper)SortArray[i]).sortItem);

                // Turn display back on.
                lwDemandReport.EndUpdate();
            }
        }

        private void lwDemandReport_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
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
            if (lwDemandReport.CheckedItems.Count > 0)
            {
                DataSet dataSetDemandReport = GetDemandReportDataSet();
                Dictionary<string, string> demandReportFieldsData = GetReportFieldsData();

                SpireDocWrapper spireDoc = new SpireDocWrapper();

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Файлы документов (*.doc)|*.doc";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if(spireDoc.CreateReport(saveFileDialog.FileName, dataSetDemandReport, demandReportFieldsData))
                    {
                        SQLiteManager.GetInstance().DemandReport().Insert(Convert.ToInt32(cbEmployee.SelectedValue), DateTime.Now, saveFileDialog.FileName);
                    }
                }
            }
            else
            {
                MessageBox.Show(Definitions.SELECT_RECORDS);
            }
        }

        private DataSet GetDemandReportDataSet()
        {
            DataTable demandReportTable = new DataTable("DemandReport");
            demandReportTable.Columns.Add("id");
            demandReportTable.Columns.Add("name");
            demandReportTable.Columns.Add("codeOKEI");
            demandReportTable.Columns.Add("measurement");
            demandReportTable.Columns.Add("price");
            demandReportTable.Columns.Add("sum");
            demandReportTable.Columns.Add("amount");

            foreach (ListViewItem item in lwDemandReport.CheckedItems)
            {
                DataRow newRow = demandReportTable.NewRow();

                newRow["id"] = item.Text;
                newRow["name"] = item.SubItems[1].Text;
                newRow["codeOKEI"] = item.SubItems[2].Text;
                newRow["measurement"] = item.SubItems[3].Text;
                newRow["price"] = Convert.ToDecimal(item.SubItems[5].Text, CultureInfo.InvariantCulture).ToString("#.00");
                newRow["sum"] = (Convert.ToDecimal(item.SubItems[5].Text, CultureInfo.InvariantCulture) * Convert.ToDecimal(item.SubItems[9].Text, CultureInfo.InvariantCulture)).ToString("#.00");
                newRow["amount"] = item.SubItems[9].Text;

                demandReportTable.Rows.Add(newRow);
            }

            DataSet demandReportDataSet = new DataSet("Report");
            demandReportDataSet.Tables.Add(demandReportTable);

            return demandReportDataSet;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }

        private void DemandReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
