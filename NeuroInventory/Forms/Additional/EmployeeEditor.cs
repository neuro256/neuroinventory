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
        private int m_ListviewSelectedItemIndex;
        private object selectedRecordId;

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
            m_ListviewSelectedItemIndex = p_Id;
            ShowInfo();
            tbSurename.Focus();
        }

        private void ShowInfo()
        {
            DataSet dataSet = SQLiteManager.GetInstance().Employees().ReturnDataSet();
            selectedRecordId = dataSet.Tables[0].Rows[m_ListviewSelectedItemIndex]["id"];
            tbSurename.Text = dataSet.Tables[0].Rows[m_ListviewSelectedItemIndex]["surename"].ToString();
            tbFirstname.Text = dataSet.Tables[0].Rows[m_ListviewSelectedItemIndex]["firstname"].ToString();
            tbLastname.Text = dataSet.Tables[0].Rows[m_ListviewSelectedItemIndex]["lastname"].ToString();
            tbPost.Text = dataSet.Tables[0].Rows[m_ListviewSelectedItemIndex]["post"].ToString();
            tbDepartment.Text = dataSet.Tables[0].Rows[m_ListviewSelectedItemIndex]["department"].ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();
            if (tbSurename.Text.Length == 0 || tbFirstname.Text.Length == 0 || tbLastname.Text.Length == 0)
            {
                MessageBox.Show("Заполните обязательные поля");
                tbSurename.Focus();
                return;
            }

            if (m_EditorMode == EditorMode.UPDATE)
            {
                SQLiteManager.GetInstance().Employees().Update(selectedRecordId, tbSurename.Text, tbFirstname.Text, tbLastname.Text, tbPost.Text, tbDepartment.Text);
            }
            else
            {
                SQLiteManager.GetInstance().Employees().Insert(tbSurename.Text, tbFirstname.Text, tbLastname.Text, tbPost.Text, tbDepartment.Text);
            }

            DialogResult = DialogResult.OK;
            Close();
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
