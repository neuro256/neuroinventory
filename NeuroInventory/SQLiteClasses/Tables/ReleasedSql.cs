using System;

namespace NeuroInventory
{
    public class ReleasedSql : TableSql<ReleasedSql>
    {
        public ReleasedSql()
        {
            CommandDataSet = String.Empty;
            TableName = "released";
        }

        public void SetCommandSet()
        {
            CommandDataSet = "SELECT inventory.id, " +
                "inventory.date, " +
                "inventory.name, " +
                "inventory.OKEIcode, " +
                "inventory.measurement, " +
                "(SELECT surename || ' ' || firstname || ' ' || lastname" +
                " FROM employees WHERE employees.id = demand.employeeId) AS employee, " +
                "demand.amount, " +
                @"printf(""%.2f"", (CAST (inventory.price AS REAL) / 100)) AS price, " +
                @"printf(""%.2f"", ((inventory.amount * price) / 100)) AS sum " +
                $"FROM inventory LEFT JOIN demand ON demand.inventoryId = inventory.id";
        }
    }
}
