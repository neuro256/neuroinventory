using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace NeuroInventory
{
    public class DemandReportSql : TableSql<DemandReportSql>
    {
        public DemandReportSql()
        {
            CommandDataSet = String.Empty;
            TableName = "demandReport";
            SetTargetPath(@"Документы\Требования");
        }

        public void SetCommandDataSet()
        {
            CommandDataSet = "SELECT id, " +
                "(SELECT surename || ' ' || firstname || ' ' || lastname" +
                " FROM employees WHERE employees.id = demandReport.employeeId) AS employeeId, " +
                "strftime('%d.%m.%Y', DATE(date)) AS date, " +
                "document " + 
                "FROM demandReport";
        }

        public void SetCommandDataSet(int p_EmployeeId, int p_CatalogId)
        {
            List<int> catalogIds = GetCatalogIds(p_CatalogId);
            string catalogIdsStr = String.Empty;

            foreach(int cId in catalogIds)
            {
                catalogIdsStr += $"OR inventory.catalogId={cId} ";
            }

            CommandDataSet = "SELECT inventory.id, " +
                "inventory.name," +
                "inventory.OKEIcode," +
                "inventory.measurement," +
                "inventory.amount," +
                @"printf(""%.2f"", (CAST (inventory.price AS REAL) / 100)) AS price," +
                @"printf(""%.2f"", ((inventory.amount * price) / 100)) AS sum," +
                "(SELECT surename || ' ' || firstname || ' ' || lastname" +
                " FROM employees WHERE employees.id = demand.employeeId) AS employee, " +
                "(SELECT post FROM employees WHERE employees.id = demand.employeeId) AS post, " +
                "demand.amount, " +
                "strftime('%d.%m.%Y', DATE(demand.date)) AS date " +
                $"FROM inventory LEFT JOIN demand ON demand.inventoryId = inventory.id WHERE demand.employeeId = {p_EmployeeId} " +
                $"AND (inventory.catalogId={p_CatalogId} " +
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataSetCatalogs.Dispose();
            }
        }

        public void Insert(int p_EmployeeId, DateTime p_Date, string p_Document)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["employeeId"] = p_EmployeeId;
            values["date"] = p_Date;
            values["document"] = p_Document;// InsertFile(p_Document);

            SQLiteManager.GetInstance().Insert(TableName, values);
        }

        public void Update(object p_Id, int p_EmployeeId, DateTime p_Date, string p_SelectedDocument, string p_CurrentDocument)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["employeeId"] = p_EmployeeId;
            values["date"] = p_Date;
            values["document"] = UpdateFile(p_SelectedDocument, p_CurrentDocument);

            string l_Where = $"id={p_Id}";

            SQLiteManager.GetInstance().Update(TableName, values, l_Where);
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

        public int ReturnLastInsertId()
        {
            return SQLiteManager.GetInstance().ReturnLastInsertId(TableName);
        }

        public int ReturnRecordsCount()
        {
            return SQLiteManager.GetInstance().ReturnRecordsCount(TableName);
        }
    }
}
