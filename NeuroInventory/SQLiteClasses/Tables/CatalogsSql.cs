using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroInventory
{
    public class CatalogsSql : TableSql<CatalogsSql>
    {
        public CatalogsSql()
        {
            m_CommandDataSet = "SELECT * FROM catalogs";
            m_TableName = "catalogs";
        }

        public void Insert(int p_Type, int p_ParentId, string p_Name)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["type"] = p_Type;
            values["parent"] = p_ParentId;
            values["name"] = p_Name;

            SQLiteManager.GetInstance().Insert(m_TableName, values);
        }

        public void Remove(int p_Id)
        {
            string l_Where = $"id={p_Id}";

            SQLiteManager.GetInstance().Delete(m_TableName, l_Where);
        }

        public void Update(int p_Id, int p_Type, int p_ParentId, string p_Name)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["type"] = p_Type;
            values["parent"] = p_ParentId;
            values["name"] = p_Name;

            string l_Where = $"id={p_Id}";

            SQLiteManager.GetInstance().Update(m_TableName, values, l_Where);
        }

        public int ReturnLastInsertId()
        {
            return SQLiteManager.GetInstance().ReturnLastInsertId(m_TableName);
        }
    }
}
