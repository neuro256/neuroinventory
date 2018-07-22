using System;
using System.Collections.Generic;
using System.Data;

namespace NeuroInventory
{
    public class EmployeesSql : TableSql
    {
        public EmployeesSql()
        {
            CommandDataSet = "SELECT * FROM employees ORDER BY surename, firstname, lastname ASC";
            TableName = "employees";
            PrimaryKey = "id";
        }

        public void Insert(string p_Surename, string p_Firstname, string p_Lastname, string p_Post, string p_Department)
        {
            Dictionary<string, object> values = new Dictionary<string, object>
            {
                ["surename"] = p_Surename,
                ["firstname"] = p_Firstname,
                ["lastname"] = p_Lastname,
                ["post"] = !String.IsNullOrEmpty(p_Post) ? (object)p_Post : DBNull.Value,
                ["department"] = !String.IsNullOrEmpty(p_Department) ? (object)p_Department : DBNull.Value
            };

            SQLiteManager.GetInstance().Insert(TableName, values);
        }

        public void Update(object p_Id, string p_Surename, string p_Firstname, string p_Lastname, string p_Post, string p_Department)
        {
            Dictionary<string, object> values = new Dictionary<string, object>
            {
                ["surename"] = p_Surename,
                ["firstname"] = p_Firstname,
                ["lastname"] = p_Lastname,
                ["post"] = !String.IsNullOrEmpty(p_Post) ? (object)p_Post : DBNull.Value,
                ["department"] = !String.IsNullOrEmpty(p_Department) ? (object)p_Department : DBNull.Value
            };

            string l_Where = $"id={p_Id}";

            SQLiteManager.GetInstance().Update(TableName, values, l_Where);
        }

        public void Remove(int p_SelectedItemId)
        {
            string l_Where = $"id={p_SelectedItemId}";

            SQLiteManager.GetInstance().Delete(TableName, l_Where);
        }

        public string GetInitialsById(int p_SelectedEmployeeId)
        {
            string l_EmployeeInitials = SQLiteManager.GetInstance().CommandExecuteScalar($"SELECT (SUBSTR(firstname, 0, 2) || '.' || SUBSTR(lastname, 0, 2) || '.') initials FROM employees WHERE id={p_SelectedEmployeeId};").ToString();
            return l_EmployeeInitials;
        }

        public string GetNameById(int p_SelectedEmployeeId)
        {
            string l_EmployeeName = SQLiteManager.GetInstance().CommandExecuteScalar($"SELECT surename FROM employees WHERE id={p_SelectedEmployeeId};").ToString();
            return l_EmployeeName;
        }

        public string GetEmployeePostById(int p_SelectedEmployeeId)
        {
            string l_EmployeePost = SQLiteManager.GetInstance().CommandExecuteScalar($"SELECT post FROM employees WHERE id={p_SelectedEmployeeId};").ToString();
            return l_EmployeePost;
        }
    }
}
