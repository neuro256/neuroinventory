using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace NeuroInventory
{
    public class DebitReportSql : TableSql
    {
        public DebitReportSql()
        {
            CommandDataSet = String.Empty;
            TableName = "debitReport";
            PrimaryKey = "id";
            SetTargetPath(@"Документы\Списания");
        }

        public void SetCommandDataSet()
        {
            CommandDataSet = "SELECT id, " +
                "strftime('%d.%m.%Y', DATE(date)) AS date, " +
                "document " +
                "FROM debitReport";
        }

        public void SetCommandDataSetLeft(int p_CatalogId)
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

        public void SetCommandDataSetInner(int p_CatalogId)
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
                "FROM inventory INNER JOIN " +
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

        public void Rollback(object reportId, string currentDocument)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            string l_FileName = NeuroFile.GetFileName(currentDocument).ToString();
            string l_DestFileName = MoveFile(currentDocument, GetTargetPath(Definitions.DEBIT_ROLLBACK_PATH)).ToString();

            if (!String.IsNullOrEmpty(l_DestFileName))
            {
                values["document"] = l_DestFileName;
                string l_Where = $"id={reportId}";
                SQLiteManager.GetInstance().Update(TableName, values, l_Where);
            }
        }

        public string ReturnDocumentById(object reportId)
        {
            return (string) SQLiteManager.GetInstance().CommandExecuteScalar($"select document from debitReport where id = {reportId}");
        }

        public object GetReportIdByDemandId(object selectedRecordId)
        {
            return SQLiteManager.GetInstance().CommandExecuteScalar($"select reportId from debit where demandId = {selectedRecordId}");
        }

        private void GetCatalogIds(int p_Id, List<int> p_CatalogIds)
        {
            DataSet dataSetCatalogs = SQLiteManager.GetInstance().Catalogs().ReturnDataSet($"SELECT id FROM catalogs WHERE parent = {p_Id}");
            try
            {
                if (dataSetCatalogs?.Tables[0]?.Rows.Count > 0)
                {
                    foreach (DataRow catalogRow in dataSetCatalogs.Tables[0].Rows)
                    {
                        int catalogId = Convert.ToInt32(catalogRow["id"]);
                        p_CatalogIds.Add(catalogId);
                        GetCatalogIds(catalogId, p_CatalogIds);
                    }
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataSetCatalogs.Dispose();
            }
        }

        public void Insert(DateTime p_Date, string p_Document)
        {
            Dictionary<string, object> values = new Dictionary<string, object>
            {
                ["date"] = p_Date,
                ["document"] = p_Document
            };

            SQLiteManager.GetInstance().Insert(TableName, values);
        }

        public void Remove(int p_SelectedId)
        {
            DataRow dataRow = ReturnDataSet().Tables[0].Rows.Find(p_SelectedId);
            string currentDocument = dataRow["document"].ToString();
            DeleteFile(currentDocument);
            string l_Where = $"id={p_SelectedId}";

            SQLiteManager.GetInstance().Delete(TableName, l_Where);
        }
    }
}
