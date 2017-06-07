using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class DemandReport : Form
    {
        public DemandReport()
        {
            InitializeComponent();
            InitControls();
        }

        private void InitControls()
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
            lwDemandReport.Columns.Clear();
            lwDemandReport.Columns.Add(new ColHeader("ID", 50, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwDemandReport.Columns.Add(new ColHeader("№", 50, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwDemandReport.Columns.Add(new ColHeader("Наименование", 200, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwDemandReport.Columns.Add(new ColHeader("Код ОКЕИ", 140, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwDemandReport.Columns.Add(new ColHeader("Единица измерения", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwDemandReport.Columns.Add(new ColHeader("Количество", 200, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwDemandReport.Columns.Add(new ColHeader("Цена", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwDemandReport.Columns.Add(new ColHeader("Сумма", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwDemandReport.Columns.Add(new ColHeader("Затребовал", 250, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwDemandReport.Columns.Add(new ColHeader("Количество", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            lwDemandReport.Columns.Add(new ColHeader("Дата", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
        }

        private void ShowTable()
        {
            if (!SQLiteManager.GetInstance().TestConnection())
                return;
            DataSet dataSet = ReturnDataSet();
            try
            {
                //Заполняем список
                lwDemandReport.BeginUpdate();
                lwDemandReport.Items.Clear();
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    lwDemandReport.Items.Add(dataSet.Tables[0].Rows[i]["id"].ToString());
                    lwDemandReport.Items[i].SubItems.Add((i + 1).ToString());
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataSet.Dispose();
            }
        }

        private DataSet ReturnDataSet()
        {
            int l_SelectedEmployeeId = cbEmployee.SelectedValue != null ? Convert.ToInt32(cbEmployee.SelectedValue) : 0;
            int l_SelectedCatalogId = cbCatalog.SelectedValue != null ? Convert.ToInt32(cbCatalog.SelectedValue) : 0;
            SQLiteManager.GetInstance().DemandReport().SetCommandDataSet(l_SelectedEmployeeId, l_SelectedCatalogId);
            return SQLiteManager.GetInstance().DemandReport().ReturnDataSet();
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
    }
}
