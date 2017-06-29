using System;
using System.Data;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class ReleasedFilter : Form
    {
        public delegate void ReleasedFilterHandler();
        public static event ReleasedFilterHandler Filtration;

        public ReleasedFilter()
        {
            InitializeComponent();
            InitControls();
            tbName.Focus();
        }

        private void InitControls()
        {
            // Настройка селектора единицы измерения
            cbMeasurement.DropDownStyle = ComboBoxStyle.DropDownList;
            DataSet measurementDataSet = SQLiteSettingsManager.GetInstance().Measurement().ReturnDataSet();
            cbMeasurement.DataSource = measurementDataSet.Tables[0];
            cbMeasurement.DisplayMember = "name";
            cbMeasurement.ValueMember = "name";

            // Настройка селектора даты
            dateTimePicker.Format = DateTimePickerFormat.Short;
            dateTimePicker.Value = DateTime.Today;
            dateTimePicker.ShowUpDown = false;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            DateTime l_Date = chbDate.Checked ? dateTimePicker.Value.Date : DateTime.MaxValue;
            string l_Measurement = chbMeasurement.Checked ? cbMeasurement.Text : String.Empty;
            object l_Amount = chbAmount.Checked ? (object)nudAmount.Value : null;
            object l_Price = chbPrice.Checked ? (object)nudPrice.Value : null;

            SQLiteManager.GetInstance().Released().Filter(l_Date, tbEmployee.Text, tbName.Text, tbOKEI.Text, l_Measurement, l_Amount, l_Price);
            Filtration?.Invoke();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = DateTime.Now;
            tbEmployee.Text = String.Empty;
            tbName.Text = String.Empty;
            tbOKEI.Text = String.Empty;
            cbMeasurement.SelectedIndex = 0;
            nudAmount.Value = 0;
            nudPrice.Value = 0;

            chbDate.Checked = false;
            chbMeasurement.Checked = false;
            chbAmount.Checked = false;
            chbPrice.Checked = false;

            SQLiteManager.GetInstance().Released().ClearFilter();
            Filtration?.Invoke();
        }

        private void ReleasedFilter_FormClosing(object sender, FormClosingEventArgs e)
        {
            SQLiteManager.GetInstance().Released().ClearFilter();
            Filtration?.Invoke();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dateTimePicker_CloseUp(object sender, EventArgs e)
        {
            chbDate.Checked = true;
        }

        private void nudAmount_ValueChanged(object sender, EventArgs e)
        {
            chbAmount.Checked = true;
        }

        private void nudPrice_ValueChanged(object sender, EventArgs e)
        {
            chbPrice.Checked = true;
        }

        private void cbMeasurement_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;

            tbOKEI.Text = SQLiteSettingsManager.GetInstance().Measurement().GetOKEIByName(cbMeasurement.SelectedValue.ToString());
            nudAmount.DecimalPlaces = SQLiteSettingsManager.GetInstance().Measurement().GetDecimalPlacesByName(cbMeasurement.SelectedValue.ToString());
            chbMeasurement.Checked = true;
        }

        private void ReleasedFilter_Shown(object sender, EventArgs e)
        {
            nudAmount.DecimalPlaces = SQLiteSettingsManager.GetInstance().Measurement().GetDecimalPlacesByName(cbMeasurement.SelectedValue.ToString());
        }
    }
}
