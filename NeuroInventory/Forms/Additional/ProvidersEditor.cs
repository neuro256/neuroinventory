using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class ProviderEditor : Form
    {
        private EditorMode m_EditorMode;
        private int m_ListviewSelectedItemIndex;
        private object m_SelectedRecordId;
        private string m_SelectedDocument;
        private string m_CurrentDocument;

        public ProviderEditor()
        {
            InitializeComponent();
            m_EditorMode = EditorMode.INSERT;
            m_SelectedDocument = String.Empty;
            m_CurrentDocument = String.Empty;
            tbName.Focus();
        }

        public ProviderEditor(int p_Id)
        {
            InitializeComponent();
            m_EditorMode = EditorMode.UPDATE;
            m_ListviewSelectedItemIndex = p_Id;
            m_SelectedDocument = String.Empty;
            m_CurrentDocument = String.Empty;
            ShowInfo();
            tbName.Focus();
        }

        private void ShowInfo()
        {
            DataSet dataSet = SQLiteManager.GetInstance().Providers().ReturnDataSet();
            m_SelectedRecordId = dataSet.Tables[0].Rows[m_ListviewSelectedItemIndex]["id"];
            tbName.Text = dataSet.Tables[0].Rows[m_ListviewSelectedItemIndex]["name"].ToString();
            tbAddress.Text = dataSet.Tables[0].Rows[m_ListviewSelectedItemIndex]["address"].ToString();
            tbPhone.Text = dataSet.Tables[0].Rows[m_ListviewSelectedItemIndex]["phone"].ToString();
            tbMail.Text = dataSet.Tables[0].Rows[m_ListviewSelectedItemIndex]["mail"].ToString();
            string fileName = Path.GetFileName(dataSet.Tables[0].Rows[m_ListviewSelectedItemIndex]["document"].ToString());
            tbDocument.Text = fileName;
            m_CurrentDocument = dataSet.Tables[0].Rows[m_ListviewSelectedItemIndex]["document"].ToString();
            m_SelectedDocument = dataSet.Tables[0].Rows[m_ListviewSelectedItemIndex]["document"].ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();
            if(String.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Заполните обязательные поля");
                tbName.Focus();
                return;
            }

            if(m_EditorMode == EditorMode.UPDATE)
            {
                SQLiteManager.GetInstance().Providers().Update(m_SelectedRecordId, tbName.Text, tbAddress.Text, tbPhone.Text, tbMail.Text, m_SelectedDocument, m_CurrentDocument);
            }
            else
            {
                SQLiteManager.GetInstance().Providers().Insert(tbName.Text, tbAddress.Text, tbPhone.Text, tbMail.Text, m_SelectedDocument);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                tbAddress.Focus();
            }
        }

        private void tbAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                tbPhone.Focus();
            }
        }

        private void tbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                tbMail.Focus();
            }
        }

        private void tbMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                btnLink.Focus();
            }
        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Filter = "Файлы документов (*.doc; *.docx; *.xls; *.xlsx; *.jpg; *.png; *.bmp; *.pdf; *.djvu)" +
                "|*.doc; *.docx; *.xls; *.xlsx; *.jpg; *.png; *.bmp; *.pdf; *.djvu |All files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                tbDocument.Text = openFileDialog.SafeFileName;
                m_SelectedDocument = openFileDialog.FileName;
            }
        }

        private void btnClearPath_Click(object sender, EventArgs e)
        {
            tbDocument.Text = String.Empty;
            m_SelectedDocument = String.Empty;
        }
    }
}
