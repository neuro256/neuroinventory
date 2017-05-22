using System;
using System.Collections.Generic;
using System.Data;

namespace NeuroInventory
{
    public class EmployeesSql : TableSql<EmployeesSql>
    {
        public EmployeesSql()
        {
            m_CommandDataSet = "SELECT * FROM employees";
            m_TableName = "employees";
        }

        public void Insert(string p_Surename, string p_Firstname, string p_Lastname, string p_Post, string p_Department)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["surename"] = p_Surename;
            values["firstname"] = p_Firstname;
            values["lastname"] = p_Lastname;
            values["post"] = p_Post.Length > 0 ? (object)p_Post : DBNull.Value;
            values["department"] = p_Department.Length > 0 ? (object)p_Department : DBNull.Value;

            SQLiteManager.GetInstance().Insert(m_TableName, values);
        }

        public void Update(object p_Id, string p_Surename, string p_Firstname, string p_Lastname, string p_Post, string p_Department)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["surename"] = p_Surename;
            values["firstname"] = p_Firstname;
            values["lastname"] = p_Lastname;
            values["post"] = p_Post.Length > 0 ? (object)p_Post : DBNull.Value;
            values["department"] = p_Department.Length > 0 ? (object) p_Department : DBNull.Value;

            string l_Where = $"id={p_Id}";

            SQLiteManager.GetInstance().Update(m_TableName, values, l_Where);
        }

        public void Remove(int p_ListviewSelectedItemIndex)
        {
            DataSet dataSet = ReturnDataSet();
            object selectedRecordId = dataSet.Tables[0].Rows[p_ListviewSelectedItemIndex]["id"];
            string l_Where = $"id={selectedRecordId}";

            SQLiteManager.GetInstance().Delete(m_TableName, l_Where);
        }
    }
}
