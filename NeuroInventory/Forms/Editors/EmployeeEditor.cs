using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace NeuroInventory
{
    public enum EditorMode
    {
        INSERT,
        UPDATE
    }

    public partial class EmployeeEditor : Form
    {
        private EditorMode m_EditorMode;
        private int m_SelectedItemId;

        public EmployeeEditor()
        {
            InitializeComponent();
            m_EditorMode = EditorMode.INSERT;
            tbSurename.Focus();
        }

        public EmployeeEditor(int p_Id)
        {
            InitializeComponent();
            m_EditorMode = EditorMode.UPDATE;
            m_SelectedItemId = p_Id;
            ShowInfo();
            tbSurename.Focus();
        }

        private void ShowInfo()
        {
            DataSet dataSet = SQLiteManager.GetInstance().Employees().ReturnDataSet();
            DataRow dataRow = dataSet.Tables[0].Rows.Find(m_SelectedItemId);
            if(dataRow != null)
            {
                tbSurename.Text = dataRow["surename"].ToString();
                tbFirstname.Text = dataRow["firstname"].ToString();
                tbLastname.Text = dataRow["lastname"].ToString();
                tbPost.Text = dataRow["post"].ToString();
                tbDepartment.Text = dataRow["department"].ToString();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            if (!IsValidData())
            {
                tbSurename.Focus();
                return;
            }

            if (m_EditorMode == EditorMode.UPDATE)
            {
                SQLiteManager.GetInstance().Employees().Update(m_SelectedItemId, tbSurename.Text, tbFirstname.Text, tbLastname.Text, tbPost.Text, tbDepartment.Text);
            }
            else
            {
                SQLiteManager.GetInstance().Employees().Insert(tbSurename.Text, tbFirstname.Text, tbLastname.Text, tbPost.Text, tbDepartment.Text);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool IsValidData()
        {
            bool isValid = true;
            errorProviderEmployees.Clear();

            if(String.IsNullOrEmpty(tbSurename.Text))
            {
                errorProviderEmployees.SetError(tbSurename, Definitions.VALIDATION_WARNING_STRING);
                isValid = false;
            }

            if(String.IsNullOrEmpty(tbFirstname.Text))
            {
                errorProviderEmployees.SetError(tbFirstname, Definitions.VALIDATION_WARNING_STRING);
                isValid = false;
            }

            if(String.IsNullOrEmpty(tbLastname.Text))
            {
                errorProviderEmployees.SetError(tbLastname, Definitions.VALIDATION_WARNING_STRING);
                isValid = false;
            }

            return isValid;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void tbSurename_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
                tbFirstname.Focus();
        }

        private void tbFirstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                tbLastname.Focus();
        }

        private void tbLastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                tbPost.Focus();
        }

        private void tbPost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                tbDepartment.Focus();
        }

        private void tbDepartment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnOk.Focus();
        }
    }
}
