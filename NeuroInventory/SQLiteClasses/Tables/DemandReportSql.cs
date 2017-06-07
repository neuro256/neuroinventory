using System;
using System.Collections.Generic;
using System.Data;

namespace NeuroInventory
{
    public class DemandReportSql : TableSql<DemandReportSql>
    {
        public DemandReportSql()
        {
            CommandDataSet = String.Empty;
            TableName = "demandReport";
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
                "(CAST (inventory.price AS REAL) / 100) AS price, " +
                "(inventory.amount * price) / 100 AS sum, " +
                "(SELECT surename || ' ' || firstname || ' ' || lastname" +
                " FROM employees WHERE employees.id = demand.employeeId) AS employeeId, " +
                "demand.amount, " +
                "strftime('%d.%m.%Y', DATE(demand.date)) AS date " +
                $"FROM inventory LEFT JOIN demand ON demand.inventoryId = inventory.id WHERE demand.employeeId = {p_EmployeeId} " +
                $"AND (inventory.catalogId={p_CatalogId} " +
                catalogIdsStr +
                $");";
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
            if(dataSetCatalogs?.Tables[0]?.Rows.Count > 0)
            {
                foreach(DataRow catalogRow in dataSetCatalogs.Tables[0].Rows)
                {
                    int catalogId = Convert.ToInt32(catalogRow["id"]);
                    p_CatalogIds.Add(catalogId);
                    GetCatalogIds(catalogId, p_CatalogIds);
                }
            }
            dataSetCatalogs.Dispose();
            return;
        }
    }
}
