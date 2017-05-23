using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class InventoryEditor : Form
    {
        private EditorMode m_EditorMode;
        private int m_ListviewSelectedIndex;
        private object m_SelectedRecordId;
        private string m_SelectedDocument;
        private string m_CurrentDocument;

        public InventoryEditor()
        {
            InitializeComponent();
            m_EditorMode = EditorMode.INSERT;
            PopulateInfo();
            cbProviders.Focus();
        }

        public InventoryEditor(int p_Id)
        {
            InitializeComponent();
            m_EditorMode = EditorMode.UPDATE;
            m_ListviewSelectedIndex = p_Id;
            PopulateInfo();
            ShowInfo();
            cbProviders.Focus();
        }

        private void PopulateInfo()
        {
            // Настройка селектора поставщика
            cbProviders.DropDownStyle = ComboBoxStyle.DropDownList;
            DataSet providersDataSet = SQLiteManager.GetInstance().Providers().ReturnDataSet();
            cbProviders.DataSource = providersDataSet.Tables[0];
            cbProviders.DisplayMember = "name"; // Отображаемое значение (столбец таблицы Поставщики)
            cbProviders.ValueMember = "id"; // Реальное значение (столбец таблицы Поставщики)

            // Настройка селектора единицы измерения
            cbMeasurement.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMeasurement.Items.Add("");
            cbMeasurement.Items.Add("Единица");
            cbMeasurement.Items.Add("Килогорамм");
            cbMeasurement.Items.Add("Литр");

            // Настройка селектора даты
            dateTimePicker.Format = DateTimePickerFormat.Short;
            dateTimePicker.Value = DateTime.Today;
            dateTimePicker.ShowUpDown = false;
        }

        // TODO
        private void ShowInfo()
        {
            DataSet dataSet = SQLiteManager.GetInstance().Inventory().ReturnDataSet();
            m_SelectedRecordId = dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["id"];
            cbProviders.Text = dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["providerId"].ToString();
            dateTimePicker.Value = Convert.ToDateTime(dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["date"]);
            string fileName = Path.GetFileName(dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["invoice"].ToString());
            tbInvoice.Text = fileName;
            tbName.Text = dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["name"].ToString();
            tbOKEI.Text = dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["OKEIcode"].ToString();
            cbMeasurement.Text = dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["measurement"].ToString();
            nudAmount.Value = Convert.ToDecimal(dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["amount"]);
            nudPrice.Value = Convert.ToDecimal(dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["price"]);
            nudReleased.Value = Convert.ToDecimal(dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["released"]);

            m_CurrentDocument = dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["invoice"].ToString();
            m_SelectedDocument = dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["invoice"].ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            if (String.IsNullOrEmpty(tbName.Text) || nudAmount.Value == 0 || nudPrice.Value == 0 || nudReleased.Value == 0)
            {
                MessageBox.Show("Заполните обязательные поля");
                cbProviders.Focus();
                return;
            }

            if(m_EditorMode == EditorMode.UPDATE)
            {
                SQLiteManager.GetInstance().Inventory().Update(m_SelectedRecordId, cbProviders.SelectedValue, dateTimePicker.Value, tbName.Text, tbOKEI.Text, cbMeasurement.Text, nudAmount.Value, nudPrice.Value, nudReleased.Value, m_SelectedDocument, m_CurrentDocument);
            }
            else
            {
                SQLiteManager.GetInstance().Inventory().Insert(cbProviders.SelectedValue, dateTimePicker.Value, tbName.Text, tbOKEI.Text, cbMeasurement.Text, nudAmount.Value, nudPrice.Value, nudReleased.Value, m_SelectedDocument);
            }

            DialogResult = DialogResult.OK;
            Close();
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
        }
    }
}
