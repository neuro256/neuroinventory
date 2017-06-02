using System;
using System.IO;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class AuthenticationWindow : Form
    {
        public AuthenticationWindow()
        {
            InitializeComponent();
            tbPassword.Focus();
        }

        private void AuthenticationWindow_Load(object sender, EventArgs e)
        {
            // База данных с настройками программы и данными о пользователе
            SQLiteSettingsManager.GetInstance().databaseName = @"settings.db";
            // Если файл бд не найден, создаем ее заново
            if (!File.Exists(SQLiteSettingsManager.GetInstance().databaseName) || !SQLiteSettingsManager.GetInstance().TestConnection())
            {
                SQLiteSettingsManager.GetInstance().CreateDatabase(SQLiteSettingsManager.GetInstance().databaseName);
                SQLiteSettingsManager.GetInstance().CreateTables();
            }

            tbLogin.Text = SQLiteSettingsManager.GetInstance().User().GetLogin();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!IsValidData())
                return;
            // Авторизация прошла успешно
            DialogResult = DialogResult.OK;
            Close();
        }

        private bool IsValidData()
        {
            bool isValid = true;
            if (!String.Equals(tbLogin.Text.Trim(), SQLiteSettingsManager.GetInstance().User().GetLogin()) ||
                !String.Equals(tbPassword.Text.Trim(), SQLiteSettingsManager.GetInstance().User().GetPassword()))
            {
                MessageBox.Show(Definitions.INVALID_LOGIN_OR_PASSWORD);
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
                btnOK.Focus();
            }
        }
    }
}
