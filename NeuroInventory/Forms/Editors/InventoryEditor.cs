using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class InventoryEditor : Form
    {
        private EditorMode m_EditorMode;
        private int m_ListviewSelectedIndex;
        private int m_CatalogId;
        private object m_SelectedRecordId;
        private string m_SelectedDocument;
        private string m_CurrentDocument;

        public InventoryEditor(int p_CatalogId)
        {
            InitializeComponent();
            m_EditorMode = EditorMode.INSERT;
            PopulateRedactorInfo();
            cbProviders.Focus();
            m_CatalogId = p_CatalogId;
        }

        public InventoryEditor(int p_CatalogId, int p_Id)
        {
            InitializeComponent();
            m_EditorMode = EditorMode.UPDATE;
            m_ListviewSelectedIndex = p_Id;
            PopulateRedactorInfo();
            ShowInfo();
            cbProviders.Focus();
            m_CatalogId = p_CatalogId;
        }

        private void PopulateRedactorInfo()
        {
            // Настройка селектора поставщика
            cbProviders.DropDownStyle = ComboBoxStyle.DropDownList;
            DataSet providersDataSet = SQLiteManager.GetInstance().Providers().ReturnDataSet();
            cbProviders.DataSource = providersDataSet.Tables[0];
            cbProviders.DisplayMember = "name"; // Отображаемое значение (столбец таблицы Поставщики)
            cbProviders.ValueMember = "id"; // Реальное значение (столбец таблицы Поставщики)

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

        private void ShowInfo()
        {
            DataSet dataSet = SQLiteManager.GetInstance().Inventory().ReturnDataSet();
            m_SelectedRecordId = dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["id"];
            cbProviders.Text = dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["providerId"].ToString();
            dateTimePicker.Value = Convert.ToDateTime(dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["date"]);
            string fileName = Path.GetFileName(dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["invoice"].ToString());
            tbInvoice.Text = fileName;
            nudInvoiceCode.Value = Convert.ToDecimal(dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["invoiceCode"]);
            tbName.Text = dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["name"].ToString();
            tbOKEI.Text = dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["OKEIcode"].ToString();
            cbMeasurement.Text = dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["measurement"].ToString();
            nudAmount.Value = Convert.ToDecimal(dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["amount"]);
            nudPrice.Value = Convert.ToDecimal(dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["price"], CultureInfo.InvariantCulture);

            m_CurrentDocument = dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["invoice"].ToString();
            m_SelectedDocument = dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["invoice"].ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            if (!IsValidData())
            {
                cbProviders.Focus();
                return;
            }

            if(m_EditorMode == EditorMode.UPDATE)
            {
                SQLiteManager.GetInstance().Inventory().Update(m_SelectedRecordId, m_CatalogId, cbProviders.SelectedValue, dateTimePicker.Value, nudInvoiceCode.Value, tbName.Text, tbOKEI.Text, cbMeasurement.Text, nudAmount.Value, nudPrice.Value, m_SelectedDocument, m_CurrentDocument);
            }
            else
            {
                SQLiteManager.GetInstance().Inventory().Insert(m_CatalogId, cbProviders.SelectedValue, dateTimePicker.Value, nudInvoiceCode.Value, tbName.Text, tbOKEI.Text, cbMeasurement.Text, nudAmount.Value, nudPrice.Value, m_SelectedDocument);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool IsValidData()
        {
            bool isValid = true;
            errorProviderInventory.Clear();

            if(String.IsNullOrEmpty(tbName.Text))
            {
                errorProviderInventory.SetError(tbName, Definitions.VALIDATION_WARNING_STRING);
                isValid = false;
            }

            if(nudAmount.Value == 0)
            {
                errorProviderInventory.SetError(nudAmount, Definitions.VALIDATION_WARNING_STRING);
                isValid = false;
            }

            if(nudPrice.Value == 0)
            {
                errorProviderInventory.SetError(nudPrice, Definitions.VALIDATION_WARNING_STRING);
                isValid = false;
            }

            return isValid;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Filter = "Файлы документов (*.doc; *.docx; *.xls; *.xlsx; *.jpg; *.png; *.bmp; *.pdf; *.djvu)" +
                "|*.doc; *.docx; *.xls; *.xlsx; *.jpg; *.png; *.bmp; *.pdf; *.djvu |All files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                tbInvoice.Text = openFileDialog.SafeFileName;
                m_SelectedDocument = openFileDialog.FileName;
            }
        }

        private void btnCLear_Click(object sender, EventArgs e)
        {
            tbInvoice.Text = String.Empty;
            m_SelectedDocument = String.Empty;
            nudInvoiceCode.Value = 0;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            errorProviderInventory.Clear();
        }

        private void nudAmount_ValueChanged(object sender, EventArgs e)
        {
            errorProviderInventory.Clear();
        }

        private void nudPrice_ValueChanged(object sender, EventArgs e)
        {
            errorProviderInventory.Clear();
        }

        private void tbInvoice_MouseClick(object sender, MouseEventArgs e)
        {
            NeuroFile.OpenFileInExplorer(m_SelectedDocument);
        }

        private void cbMeasurement_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tbOKEI.Text = SQLiteSettingsManager.GetInstance().Measurement().GetOKEIByName(cbMeasurement.SelectedValue.ToString());
            nudAmount.DecimalPlaces = SQLiteSettingsManager.GetInstance().Measurement().GetDecimalPlacesByName(cbMeasurement.SelectedValue.ToString());
        }

        private void InventoryEditor_Shown(object sender, EventArgs e)
        {
            tbOKEI.Text = SQLiteSettingsManager.GetInstance().Measurement().GetOKEIByName(cbMeasurement.SelectedValue.ToString());
            nudAmount.DecimalPlaces = SQLiteSettingsManager.GetInstance().Measurement().GetDecimalPlacesByName(cbMeasurement.SelectedValue.ToString());
        }
    }
}
