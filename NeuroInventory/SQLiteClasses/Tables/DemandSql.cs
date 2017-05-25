using System;
using System.Collections.Generic;
using System.Data;

namespace NeuroInventory
{
    public class DemandSql : TableSql<DemandSql>
    {
        public DemandSql()
        {
            m_CommandDataSet = String.Empty;
            m_TableName = "demand";
            SetTargetPath(@"documents\demand");
        }

        public void SetCommandDataSet(int p_InventoryId)
        {
            m_CommandDataSet = "SELECT id, " +
                "(SELECT surename || ' ' || firstname || ' ' || lastname" +
                " FROM employees WHERE employees.id = demand.employeeId) AS employeeId, " +
                "amount, " +
                "strftime('%d.%m.%Y', DATE(date)) AS date, " +
                $"document FROM demand WHERE demand.inventoryId = {p_InventoryId};";
        }

        public void Remove(int p_ListviewSelectedItemIndex)
        {
            DataSet dataSet = ReturnDataSet();
            object selectedRecordId = dataSet.Tables[0].Rows[p_ListviewSelectedItemIndex]["id"];
            string l_Where = $"id={selectedRecordId}";

            SQLiteManager.GetInstance().Delete(m_TableName, l_Where);
        }

        public void Insert(int p_InventoryId, object p_EmployeeId, decimal p_Amount, DateTime p_Date)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["inventoryId"] = p_InventoryId;
            values["employeeId"] = p_EmployeeId;
            values["amount"] = p_Amount;
            values["date"] = p_Date;

            SQLiteManager.GetInstance().Insert(m_TableName, values);
        }

        public void Update(object p_Id, int p_InventoryId, object p_EmployeeId, decimal p_Amount, DateTime p_Date)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["inventoryId"] = p_InventoryId;
            values["employeeId"] = p_EmployeeId;
            values["amount"] = p_Amount;
            values["date"] = p_Date;

            string l_Where = $"id={p_Id}";

            SQLiteManager.GetInstance().Update(m_TableName, values, l_Where);
        }
    }
}
