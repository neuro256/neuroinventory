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
            this.BackColor = Definitions.COLOR_FORM_MAIN_BACK_COLOR;
            tbPassword.Focus();
        }

        private void AuthenticationWindow_Load(object sender, EventArgs e)
        {
            // База данных с настройками программы и данными о пользователе
            SQLiteSettingsManager.GetInstance().databaseName = @"settings.db";
            SQLiteSettingsManager.GetInstance().Password = "76cT8dbr";
            string pathToSettingsDB = Definitions.APPLICATION_SETTINGS_PATH;
            if(!Directory.Exists(pathToSettingsDB))
            {
                Directory.CreateDirectory(pathToSettingsDB);
            }
            // Если файл бд не найден, создаем ее заново
            if (!File.Exists(pathToSettingsDB + SQLiteSettingsManager.GetInstance().databaseName) || !SQLiteSettingsManager.GetInstance().TestConnection())
            {
                SQLiteSettingsManager.GetInstance().CreateDatabase(pathToSettingsDB + SQLiteSettingsManager.GetInstance().databaseName);
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
