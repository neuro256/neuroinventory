using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroInventory
{
    public class CatalogsSql : TableSql
    {
        public CatalogsSql()
        {
            CommandDataSet = "SELECT * FROM catalogs";
            TableName = "catalogs";
        }

        public void Insert(int p_Type, int p_ParentId, string p_Name)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["type"] = p_Type;
            values["parent"] = p_ParentId;
            values["name"] = p_Name;

            SQLiteManager.GetInstance().Insert(TableName, values);
        }

        public void Remove(int p_Id)
        {
            string l_Where = $"id={p_Id}";

            SQLiteManager.GetInstance().Delete(TableName, l_Where);
        }

        public void Update(int p_Id, int p_Type, int p_ParentId, string p_Name)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["type"] = p_Type;
            values["parent"] = p_ParentId;
            values["name"] = p_Name;

            string l_Where = $"id={p_Id}";

            SQLiteManager.GetInstance().Update(TableName, values, l_Where);
        }
    }
}
