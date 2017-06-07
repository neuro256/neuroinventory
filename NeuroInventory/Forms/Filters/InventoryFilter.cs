using System;
using System.Data;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class InventoryFilter : Form
    {
        public delegate void InventoryFilterHandler();
        public static event InventoryFilterHandler Filtration;

        public InventoryFilter()
        {
            InitializeComponent();
            InitControls();
            cbProviders.Focus();
        }

        private void InitControls()
        {
            // Настройка селектора поставщика
            cbProviders.DropDownStyle = ComboBoxStyle.DropDown;
            DataSet providersDataSet = SQLiteManager.GetInstance().Providers().ReturnDataSet();
            cbProviders.DataSource = providersDataSet.Tables[0];
            cbProviders.DisplayMember = "name"; // Отображаемое значение (столбец таблицы Поставщики)
            cbProviders.ValueMember = "id"; // Реальное значение (столбец таблицы Поставщики)

            // Настройка селектора единицы измерения
            cbMeasurement.DropDownStyle = ComboBoxStyle.DropDown;
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
            object l_Provider = chbProvider.Checked ? cbProviders.SelectedValue : null;
            DateTime l_Date = chbDate.Checked ? dateTimePicker.Value : DateTime.MaxValue;
            string l_Measurement = chbMeasurement.Checked ? cbMeasurement.Text : String.Empty;
            object l_Amount = chbAmount.Checked ? (object)nudAmount.Value : null;
            object l_Price = chbPrice.Checked ? (object)nudPrice.Value : null;

            SQLiteManager.GetInstance().Inventory().Filter(l_Provider, l_Date, tbInvoice.Text, tbName.Text, tbOKEI.Text, l_Measurement, l_Amount, l_Price);
            Filtration?.Invoke();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cbProviders.SelectedIndex = 0;
            dateTimePicker.Value = DateTime.Now;
            tbInvoice.Text = String.Empty;
            tbName.Text = String.Empty;
            tbOKEI.Text = String.Empty;
            cbMeasurement.SelectedIndex = 0;
            nudAmount.Value = 0;
            nudPrice.Value = 0;

            chbProvider.Checked = false;
            chbDate.Checked = false;
            chbMeasurement.Checked = false;
            chbAmount.Checked = false;
            chbPrice.Checked = false;

            SQLiteManager.GetInstance().Inventory().ClearFilter();
            Filtration?.Invoke();
        }

        private void InventoryFilter_FormClosing(object sender, FormClosingEventArgs e)
        {
            SQLiteManager.GetInstance().Inventory().ClearFilter();
            Filtration?.Invoke();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbProviders_SelectionChangeCommitted(object sender, EventArgs e)
        {
            chbProvider.Checked = true;
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
            tbOKEI.Text = SQLiteSettingsManager.GetInstance().Measurement().GetOKEIByName(cbMeasurement.Text);
            nudAmount.DecimalPlaces = SQLiteSettingsManager.GetInstance().Measurement().GetDecimalPlacesByName(cbMeasurement.Text);
            chbMeasurement.Checked = true;
        }

        private void InventoryFilter_Shown(object sender, EventArgs e)
        {
            tbOKEI.Text = SQLiteSettingsManager.GetInstance().Measurement().GetOKEIByName(cbMeasurement.Text);
            nudAmount.DecimalPlaces = SQLiteSettingsManager.GetInstance().Measurement().GetDecimalPlacesByName(cbMeasurement.Text);
        }
    }
}
