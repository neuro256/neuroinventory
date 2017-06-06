using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class EmployeeFilter : Form
    {
        public delegate void EmployeeFilterHandler();
        public static event EmployeeFilterHandler Filtration;

        public EmployeeFilter()
        {
            InitializeComponent();
            tbSurename.Focus();
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
                btnFilter.Focus();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            SQLiteManager.GetInstance().Employees().Filter(tbSurename.Text, tbFirstname.Text, tbLastname.Text, tbPost.Text, tbDepartment.Text);
            Filtration?.Invoke();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbSurename.Text = String.Empty;
            tbFirstname.Text = String.Empty;
            tbLastname.Text = String.Empty;
            tbPost.Text = String.Empty;
            tbDepartment.Text = String.Empty;
            SQLiteManager.GetInstance().Employees().ClearFilter();
            Filtration?.Invoke();
        }

        private void EmployeeFilter_FormClosing(object sender, FormClosingEventArgs e)
        {
            SQLiteManager.GetInstance().Employees().ClearFilter();
            Filtration?.Invoke();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
