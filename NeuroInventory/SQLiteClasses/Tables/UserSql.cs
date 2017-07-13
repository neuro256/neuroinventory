using System.Collections.Generic;

namespace NeuroInventory
{
    public class UserSql : TableSql<UserSql>
    {
        public new string connectionString
        {
            get
            {
                m_ConnectionStr = SQLiteSettingsManager.GetInstance().connectionString;
                return m_ConnectionStr;
            }
        }

        public UserSql()
        {
            CommandDataSet = "SELECT * FROM user";
            TableName = "user";
        }

        public void Update(string p_Login, string p_Password)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["login"] = p_Login;
            values["password"] = p_Password;

            string l_Where = $"id={ReturnLastInsertId()}";

            SQLiteSettingsManager.GetInstance().Update(TableName, values, l_Where);
        }

        public string GetLogin()
        {
            return SQLiteSettingsManager.GetInstance().CommandExecuteScalar($"SELECT login FROM user WHERE id={ReturnLastInsertId()};").ToString();
        }

        public string GetPassword()
        {
            return SQLiteSettingsManager.GetInstance().CommandExecuteScalar($"SELECT password FROM user WHERE id={ReturnLastInsertId()};").ToString();
        }

        public new int ReturnLastInsertId()
        {
            return SQLiteSettingsManager.GetInstance().ReturnLastInsertId(TableName);
        }
    }
}
