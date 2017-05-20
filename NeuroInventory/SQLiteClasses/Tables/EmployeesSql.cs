using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroInventory
{
    public class EmployeesSql : TableSql<EmployeesSql>
    {
        public EmployeesSql()
        {
            _commandDataSet = "SELECT * FROM employees";
            _tableName = "employees";
        }

        public void Insert(string p_Surename, string p_Firstname, string p_Lastname, string p_Post, string p_Department)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["surename"] = p_Surename;
            values["firstname"] = p_Firstname;
            values["lastname"] = p_Lastname;
            values["post"] = p_Post.Length > 0 ? (object)p_Post : DBNull.Value;
            values["department"] = p_Department.Length > 0 ? (object)p_Department : DBNull.Value;

            SQLiteManager.GetInstance().Insert(_tableName, values);
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

            SQLiteManager.GetInstance().Update(_tableName, values, l_Where);
        }

        public void Remove(int p_ListviewSelectedItemIndex)
        {
            DataSet dataSet = SQLiteManager.GetInstance().Employees().ReturnDataSet();
            object selectedRecordId = dataSet.Tables[0].Rows[p_ListviewSelectedItemIndex]["id"];
            string l_Where = $"id={selectedRecordId}";

            SQLiteManager.GetInstance().Delete(_tableName, l_Where);
        }
    }
}
