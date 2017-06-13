using System;
using System.Collections.Generic;
using System.Data;

namespace NeuroInventory
{
    public class DebitReportSql : TableSql<DebitReportSql>
    {
        public DebitReportSql()
        {
            CommandDataSet = String.Empty;
            TableName = "debitReport";
            SetTargetPath(@"documents\debitReports");
        }

        public void SetCommandDataSet()
        {
            CommandDataSet = "SELECT id, " +
                "strftime('%d.%m.%Y', DATE(date)) AS date, " +
                "document " +
                "FROM debitReport";
        }

        public void SetCommandDataSet(int p_CatalogId)
        {
            List<int> catalogIds = GetCatalogIds(p_CatalogId);
            string catalogIdsStr = String.Empty;

            foreach (int cId in catalogIds)
            {
                catalogIdsStr += $"OR inventory.catalogId={cId} ";
            }

            CommandDataSet = "SELECT inventory.id, " +
                "inventory.name, " +
                "inventory.OKEIcode, " +
                "inventory.measurement, " +
                "inventory.amount as inventoryAmount, " +
                "debit.debitAmount, " +
                @"printf(""%.2f"", (CAST (inventory.price AS REAL) / 100)) AS price, " +
                @"printf(""%.2f"", ((debit.debitAmount * price) / 100)) AS sum " +
                "FROM inventory LEFT JOIN " +
                "(SELECT inventoryId, sum(amount) AS debitAmount FROM debit GROUP BY inventoryId) AS debit " +
                "ON inventory.id = debit.inventoryId " +
                $"WHERE (inventory.catalogId={p_CatalogId} " +
                catalogIdsStr +
                ");";
        }

        private List<int> GetCatalogIds(int p_Id)
        {
            List<int> catalogIds = new List<int>();
            GetCatalogIds(p_Id, catalogIds);
            return catalogIds;
        }

        private void GetCatalogIds(int p_Id, List<int> p_CatalogIds)
        {
            DataSet dataSetCatalogs = SQLiteManager.GetInstance().Catalogs().ReturnDataSet($"SELECT id FROM catalogs WHERE parent = {p_Id}");
            if (dataSetCatalogs?.Tables[0]?.Rows.Count > 0)
            {
                foreach (DataRow catalogRow in dataSetCatalogs.Tables[0].Rows)
                {
                    int catalogId = Convert.ToInt32(catalogRow["id"]);
                    p_CatalogIds.Add(catalogId);
                    GetCatalogIds(catalogId, p_CatalogIds);
                }
            }
            dataSetCatalogs.Dispose();
            return;
        }

        public void Insert(DateTime p_Date, string p_Document)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["date"] = p_Date;
            values["document"] = InsertFile(p_Document);

            SQLiteManager.GetInstance().Insert(TableName, values);
        }

        public void Remove(int p_ListviewSelectedItemIndex)
        {
            DataSet dataSet = ReturnDataSet();
            object selectedRecordId = dataSet.Tables[0].Rows[p_ListviewSelectedItemIndex]["id"];
            string currentDocument = dataSet.Tables[0].Rows[p_ListviewSelectedItemIndex]["document"].ToString();
            DeleteFile(currentDocument);
            string l_Where = $"id={selectedRecordId}";

            SQLiteManager.GetInstance().Delete(TableName, l_Where);
        }
    }
}
