using System;

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
            CommandDataSet = "SELECT inventory.id, " +
                "inventory.name," +
                "inventory.OKEIcode," +
                "inventory.measurement," +
                "inventory.amount," +
                "(CAST (inventory.price AS REAL) / 100) AS price, " +
                "(inventory.amount * price) / 100 AS sum, " +
                "(inventory.amount - SUM(debit.amount)) AS balance, " +
                "(SELECT surename || ' ' || firstname || ' ' || lastname" +
                " FROM employees WHERE employees.id = demand.employeeId) AS employeeId, " +
                "demand.amount, " +
                "strftime('%d.%m.%Y', DATE(demand.date)) AS date " +             
                $"FROM inventory LEFT JOIN demand ON demand.inventoryId = inventory.id WHERE demand.employeeId = {p_EmployeeId} AND inventory.catalogId={p_CatalogId};";
        }
    }
}
