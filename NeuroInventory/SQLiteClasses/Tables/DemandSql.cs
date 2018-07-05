using System;
using System.Collections.Generic;
using System.Data;

namespace NeuroInventory
{
    public class DemandSql : TableSql
    {
        public DemandSql()
        {
            CommandDataSet = String.Empty;
            TableName = "demand";
            PrimaryKey = "id";
        }

        public void SetCommandDataSet(int p_InventoryId)
        {
            CommandDataSet = "SELECT id, " +
                "(SELECT surename || ' ' || firstname || ' ' || lastname" +
                " FROM employees WHERE employees.id = demand.employeeId) AS employeeId, " +
                "amount, " +
                "strftime('%d.%m.%Y', DATE(date)) AS date " +
                $"FROM demand WHERE demand.inventoryId = {p_InventoryId};";
        }

        public void Remove(int p_SelectedItemId)
        {
            string l_Where = $"id={p_SelectedItemId}";

            SQLiteManager.GetInstance().Delete(TableName, l_Where);
        }

        public void Insert(int p_InventoryId, int p_ReportLastId, object p_EmployeeId, decimal p_Amount, DateTime p_Date)
        {
            Dictionary<string, object> values = new Dictionary<string, object>
            {
                ["inventoryId"] = p_InventoryId,
                ["reportId"] = p_ReportLastId,
                ["employeeId"] = p_EmployeeId,
                ["amount"] = p_Amount,
                ["date"] = p_Date
            };

            SQLiteManager.GetInstance().Insert(TableName, values);
        }

        public void Update(object p_Id, int p_InventoryId, object p_EmployeeId, decimal p_Amount, DateTime p_Date)
        {
            Dictionary<string, object> values = new Dictionary<string, object>
            {
                ["inventoryId"] = p_InventoryId,
                ["employeeId"] = p_EmployeeId,
                ["amount"] = p_Amount,
                ["date"] = p_Date
            };

            string l_Where = $"id={p_Id}";

            SQLiteManager.GetInstance().Update(TableName, values, l_Where);
        }

        public object GetReportId(object selectedRecordId)
        {
            return SQLiteManager.GetInstance().CommandExecuteScalar($"select reportId from demand where id = {selectedRecordId}");   
        }
    }
}
