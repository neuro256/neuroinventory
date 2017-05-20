using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class ProviderEditor : Form
    {
        private EditorMode m_EditorMode;
        private int m_ListviewSelectedItemIndex;
        private object selectedRecordId;

        public ProviderEditor()
        {
            InitializeComponent();
        }

        public ProviderEditor(int p_Id)
        {
            InitializeComponent();
            m_EditorMode = EditorMode.UPDATE;
            m_ListviewSelectedItemIndex = p_Id;
            ShowInfo();
            tbName.Focus();
        }

        private void ShowInfo()
        {
            DataSet dataSet = SQLiteManager.GetInstance().Providers().ReturnDataSet();
            selectedRecordId = dataSet.Tables[0].Rows[m_ListviewSelectedItemIndex]["id"];
            tbName.Text = dataSet.Tables[0].Rows[m_ListviewSelectedItemIndex]["name"].ToString();
            tbAddress.Text = dataSet.Tables[0].Rows[m_ListviewSelectedItemIndex]["address"].ToString();
            tbPhone.Text = dataSet.Tables[0].Rows[m_ListviewSelectedItemIndex]["phone"].ToString();
            tbMail.Text = dataSet.Tables[0].Rows[m_ListviewSelectedItemIndex]["mail"].ToString();
            tbDocument.Text = dataSet.Tables[0].Rows[m_ListviewSelectedItemIndex]["document"].ToString();
        }

        private void tbLink_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Filter = "Файлы документов (*.doc, *jpeg, *jpg, *png)|*.doc, *jpeg, *jpg, *png";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                tbLink.Text = openFileDialog.FileName;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
