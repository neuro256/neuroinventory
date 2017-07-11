using System;
using System.Data;
using System.Globalization;

namespace NeuroInventory
{
    public class ReleasedSql : TableSql<ReleasedSql>
    {
        private string m_CommandDataSetNotFiltered;

        private string CommandDataSetNotFiltered { get => m_CommandDataSetNotFiltered; set => m_CommandDataSetNotFiltered = value; }

        public ReleasedSql()
        {
            CommandDataSet = String.Empty;
            TableName = "demand";
            SetCommandSet();
            CommandDataSetNotFiltered = CommandDataSet;
        }

        public void SetCommandSet()
        {
            CommandDataSet = "SELECT inventory.id, " +
                "demand.id as demandId, " +
                "strftime('%d.%m.%Y', DATE(demand.date)) AS mydate," +
                "inventory.invoiceCode, " +
                "inventory.name, " +
                "inventory.OKEIcode, " +
                "inventory.measurement, " +
                "(SELECT surename || ' ' || firstname || ' ' || lastname" +
                " FROM employees WHERE employees.id = demand.employeeId) AS employee, " +
                "demand.amount, " +
                @"printf(""%.2f"", (CAST (inventory.price AS REAL) / 100)) AS price, " +
                @"printf(""%.2f"", ((demand.amount * price) / 100)) AS sum, " +
                "demandReport.document " +
                //"sum(debit.amount) " +
                $"FROM inventory INNER JOIN demand ON demand.inventoryId = inventory.id " +
                $"LEFT JOIN demandReport ON demand.reportId = demandReport.id " +
                //"LEFT JOIN debit ON debit.inventoryId = inventory.id " + 
                $" GROUP BY demand.id" +
                $" ORDER BY DATE(demand.date) ASC";
        }

        public void Remove(int p_ListviewSelectedItemIndex)
        {
            DataSet dataSet = ReturnDataSet();
            object selectedRecordId = dataSet.Tables[0].Rows[p_ListviewSelectedItemIndex]["demandId"];
            string l_Where = $"id={selectedRecordId}";

            SQLiteManager.GetInstance().Delete(TableName, l_Where);
        }

        public void Filter(DateTime p_Date, string p_Employee, string p_Name, string p_OKEIcode, string p_Measurement, object p_Amount, object p_Price)
        {
            string l_DateStr = p_Date.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            string l_Date = !DateTime.Equals(p_Date, DateTime.MaxValue) ? $" AND demand.date=Datetime('{l_DateStr}')" : String.Empty;
            string l_Name = $" inventory.name like '%{p_Name}%'";
            string l_OKEIcode = !String.IsNullOrEmpty(p_OKEIcode) ? $" AND OKEIcode LIKE '%{p_OKEIcode}%'" : $" AND (OKEIcode LIKE '%{p_OKEIcode}%' OR OKEIcode IS NULL)";
            string l_Measurement = !String.IsNullOrEmpty(p_Measurement) ? $" AND measurement LIKE '%{p_Measurement}%'" : $" AND (measurement LIKE '%{p_Measurement}%' OR measurement IS NULL)";
            string l_Amount = p_Amount != null ? $" AND (demand.amount={p_Amount})" : String.Empty;
            l_Amount = l_Amount.Replace(",", ".");
            string l_Price = p_Price != null ? $" AND (inventory.price={Convert.ToInt32(Convert.ToDecimal(p_Price) * 100)})" : String.Empty;
            string l_Employee = !String.IsNullOrEmpty(p_Employee) ? $" AND demand.employeeId = (SELECT id FROM employees WHERE surename like '%{p_Employee}%' " +
                $"OR firstname like '%{p_Employee}%' " +
                $"OR lastname like '%{p_Employee}%') " : String.Empty;

            CommandDataSet = "SELECT inventory.id, " +
                "demand.id as demandId, " +
                "strftime('%d.%m.%Y', DATE(demand.date)) AS mydate," +
                "inventory.invoiceCode, " +
                "inventory.name, " +
                "inventory.OKEIcode, " +
                "inventory.measurement, " +
                "(SELECT surename || ' ' || firstname || ' ' || lastname" +
                " FROM employees WHERE employees.id = demand.employeeId) AS employee, " +
                "demand.amount, " +
                @"printf(""%.2f"", (CAST (inventory.price AS REAL) / 100)) AS price, " +
                @"printf(""%.2f"", ((demand.amount * price) / 100)) AS sum, " +
                "demandReport.document " +
                //"sum(debit.amount) " +
                $" FROM inventory INNER JOIN demand ON demand.inventoryId = inventory.id " +
                $" LEFT JOIN demandReport ON demand.reportId = demandReport.id " +
                //" LEFT JOIN debit ON debit.inventoryId = inventory.id " +
                $" WHERE " +
                l_Name +
                l_Date +
                l_OKEIcode +
                l_Measurement +
                l_Amount +
                l_Price +
                l_Employee +
                $" GROUP BY demand.id" +
                $" ORDER BY DATE(demand.date) ASC";
        }

        public void ClearFilter()
        {
            CommandDataSet = CommandDataSetNotFiltered;
        }

        public int ReturnLastInsertId()
        {
            return SQLiteManager.GetInstance().ReturnLastInsertId(TableName);
        }
    }
}
