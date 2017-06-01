using System;
using System.Collections.Generic;
using System.Data;

namespace NeuroInventory
{
    public class EmployeesSql : TableSql<EmployeesSql>
    {
        public EmployeesSql()
        {
            CommandDataSet = "SELECT * FROM employees";
            TableName = "employees";
        }

        public void Filter(string p_Surename, string p_Firstname, string p_Lastname, string p_Post, string p_Department)
        {
            string l_Post = !String.IsNullOrEmpty(p_Post) ? $"post like '%{p_Post}%'" : $"(post like '%{p_Post}%' OR post IS NULL)";
            string l_Department = !String.IsNullOrEmpty(p_Department) ? $"department like '%{p_Department}%'" : $"(department like '%{p_Department}%' OR department IS NULL)";

            CommandDataSet = "SELECT * FROM employees WHERE " +
                $"surename like '%{p_Surename}%' AND " +
                $"firstname like '%{p_Firstname}%' AND " +
                $"lastname like '%{p_Lastname}%' AND " +
                $"{l_Post} AND " +
                $"{l_Department}"; 
        }

        public void ClearFilter()
        {
            CommandDataSet = "SELECT * FROM employees";
        }

        public void Insert(string p_Surename, string p_Firstname, string p_Lastname, string p_Post, string p_Department)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["surename"] = p_Surename;
            values["firstname"] = p_Firstname;
            values["lastname"] = p_Lastname;
            values["post"] = !String.IsNullOrEmpty(p_Post) ? (object)p_Post : DBNull.Value;
            values["department"] = !String.IsNullOrEmpty(p_Department) ? (object)p_Department : DBNull.Value;

            SQLiteManager.GetInstance().Insert(TableName, values);
        }

        public void Update(object p_Id, string p_Surename, string p_Firstname, string p_Lastname, string p_Post, string p_Department)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["surename"] = p_Surename;
            values["firstname"] = p_Firstname;
            values["lastname"] = p_Lastname;
            values["post"] = !String.IsNullOrEmpty(p_Post) ? (object)p_Post : DBNull.Value;
            values["department"] = !String.IsNullOrEmpty(p_Department) ? (object) p_Department : DBNull.Value;

            string l_Where = $"id={p_Id}";

            SQLiteManager.GetInstance().Update(TableName, values, l_Where);
        }

        public void Remove(int p_ListviewSelectedItemIndex)
        {
            DataSet dataSet = ReturnDataSet();
            object selectedRecordId = dataSet.Tables[0].Rows[p_ListviewSelectedItemIndex]["id"];
            string l_Where = $"id={selectedRecordId}";

            SQLiteManager.GetInstance().Delete(TableName, l_Where);
        }
    }
}
