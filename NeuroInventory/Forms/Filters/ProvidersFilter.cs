using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class ProvidersFilter : Form
    {
        public delegate void ProvidersFilterHandler();
        public static event ProvidersFilterHandler Filtration;

        public ProvidersFilter()
        {
            InitializeComponent();
            tbName.Focus();
        }

        private void tbSurename_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
                tbAddress.Focus();
        }

        private void tbFirstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                tbPhone.Focus();
        }

        private void tbLastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                tbMail.Focus();
        }

        private void tbPost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                tbINN.Focus();
        }

        private void tbINN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
                tbDocument.Focus();
        }

        private void tbDepartment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnFilter.Focus();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            SQLiteManager.GetInstance().Providers().Filter(tbName.Text, tbAddress.Text, tbPhone.Text, tbMail.Text, tbINN.Text, tbDocument.Text);
            Filtration?.Invoke();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbName.Text = String.Empty;
            tbAddress.Text = String.Empty;
            tbPhone.Text = String.Empty;
            tbMail.Text = String.Empty;
            tbINN.Text = String.Empty;
            tbDocument.Text = String.Empty;
            SQLiteManager.GetInstance().Providers().ClearFilter();
            Filtration?.Invoke();
        }

        private void ProvidersFilter_FormClosing(object sender, FormClosingEventArgs e)
        {
            SQLiteManager.GetInstance().Providers().ClearFilter();
            Filtration?.Invoke();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
