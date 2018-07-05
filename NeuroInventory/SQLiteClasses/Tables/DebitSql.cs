using System;
using System.Collections.Generic;
using System.Data;

namespace NeuroInventory
{
    public class DebitSql : TableSql
    {
        public DebitSql()
        {
            CommandDataSet = String.Empty;
            TableName = "debit";
            PrimaryKey = "id";
        }

        public void SetCommandDataSet(int p_InventoryId)
        {
            CommandDataSet = "SELECT id, amount, " +
                "strftime('%d.%m.%Y', DATE(date)) AS date " +
                $"FROM debit WHERE debit.inventoryId = {p_InventoryId};";
        }

        public void Insert(int p_InventoryId, int p_DemandId, int p_reportId, decimal p_Amount, DateTime p_Date)
        {
            Dictionary<string, object> values = new Dictionary<string, object>
            {
                ["inventoryId"] = p_InventoryId,
                ["demandId"] = p_DemandId,
                ["reportId"] = p_reportId,
                ["amount"] = p_Amount,
                ["date"] = p_Date
            };

            SQLiteManager.GetInstance().Insert(TableName, values);
        }

        public void Remove(int p_SelectedItemId)
        {
            string l_Where = $"id={p_SelectedItemId}";
            SQLiteManager.GetInstance().Delete(TableName, l_Where);
        }

        public void RemoveByDemandId(object p_DemandId)
        {
            string l_Where = $"demandId={p_DemandId}";

            SQLiteManager.GetInstance().Delete(TableName, l_Where);
        }

        public void Update(object p_Id, int p_InventoryId, decimal p_Amount, DateTime p_Date)
        {
            Dictionary<string, object> values = new Dictionary<string, object>
            {
                ["inventoryId"] = p_InventoryId,
                ["amount"] = p_Amount,
                ["date"] = p_Date
            };

            string l_Where = $"id={p_Id}";

            SQLiteManager.GetInstance().Update(TableName, values, l_Where);
        }

        public object GetReportIdByDemandId(object selectedRecordId)
        {
            return SQLiteManager.GetInstance().CommandExecuteScalar($"select reportId from debit where demandId = {selectedRecordId}");
        }
    }
}
