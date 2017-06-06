using System;
using System.IO;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class AuthenticationEditor : Form
    {
        public AuthenticationEditor()
        {
            InitializeComponent();
            tbPassword.Focus();
        }

        private void AuthenticationEditor_Load(object sender, EventArgs e)
        {
            tbLogin.Text = SQLiteSettingsManager.GetInstance().User().GetLogin();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!IsValidData())
                return;
            if (!IsPasswordsEquals())
                return;
            SQLiteSettingsManager.GetInstance().User().Update(tbLogin.Text.Trim(), tbPassword.Text.Trim());
            DialogResult = DialogResult.OK;
            Close();
        }

        private bool IsPasswordsEquals()
        {
            if (String.Equals(tbPassword.Text.Trim(), tbPasswordRepeat.Text.Trim()))
                return true;
            return false;
        }

        private bool IsValidData()
        {
            bool isValid = true;
            if (String.IsNullOrEmpty(tbLogin.Text) || String.IsNullOrEmpty(tbPassword.Text) || String.IsNullOrEmpty(tbPasswordRepeat.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены");
                isValid = false;
            }
            return isValid;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tbLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                tbPassword.Focus();
            }
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                tbPasswordRepeat.Focus();
            }
        }

        private void tbPasswordRepeat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnOK.Focus();
            }
        }
    }
}
