using System;
using System.Collections.Generic;
using System.Data;

namespace NeuroInventory
{
    public class DebitSql : TableSql<DebitSql>
    {
        public DebitSql()
        {
            CommandDataSet = String.Empty;
            TableName = "debit";
            SetTargetPath(@"documents\debit");
        }

        public void SetCommandDataSet(int p_InventoryId)
        {
            CommandDataSet = "SELECT id, amount, " +
                "strftime('%d.%m.%Y', DATE(date)) AS date, " +
                $"document FROM debit WHERE debit.inventoryId = {p_InventoryId};";
        }

        public void Insert(int p_InventoryId, decimal p_Amount, DateTime p_Date)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["inventoryId"] = p_InventoryId;
            values["amount"] = p_Amount;
            values["date"] = p_Date;

            SQLiteManager.GetInstance().Insert(TableName, values);
        }

        public void Remove(int p_ListviewSelectedIndex)
        {
            DataSet dataSet = ReturnDataSet();
            object selectedRecordId = dataSet.Tables[0].Rows[p_ListviewSelectedIndex]["id"];
            string l_Where = $"id={selectedRecordId}";

            SQLiteManager.GetInstance().Delete(TableName, l_Where);
        }

        public void Update(object p_Id, int p_InventoryId, decimal p_Amount, DateTime p_Date)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["inventoryId"] = p_InventoryId;
            values["amount"] = p_Amount;
            values["date"] = p_Date;

            string l_Where = $"id={p_Id}";

            SQLiteManager.GetInstance().Update(TableName, values, l_Where);
        }
    }
}
