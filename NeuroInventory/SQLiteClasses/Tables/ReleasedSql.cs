using System;
using System.Data;
using System.Globalization;

namespace NeuroInventory
{
    public class ReleasedSql : TableSql
    {
        public ReleasedSql()
        {
            CommandDataSet = String.Empty;
            TableName = "demand";
            PrimaryKey = "demandId";
            SetCommandSet();
        }

        public void SetCommandSet()
        {
            CommandDataSet = "SELECT inventory.id, " +
                "demand.id as demandId, " +
                "strftime('%d.%m.%Y', DATE(inventory.date)) AS ordate," +
                "strftime('%d.%m.%Y', DATE(demand.date)) AS mydate," +
                "inventory.invoiceCodeStr, " +
                "strftime('%d.%m.%Y', DATE(inventory.invoiceDate)) AS invoiceDate," + 
                "inventory.name, " +
                "inventory.OKEIcode, " +
                "inventory.measurement, " +
                "(SELECT surename || ' ' || firstname || ' ' || lastname" +
                " FROM employees WHERE employees.id = demand.employeeId) AS employee, " +
                "demand.amount, " +
                @"printf(""%.2f"", (CAST (inventory.price AS REAL) / 100)) AS price, " +
                @"printf(""%.2f"", ((demand.amount * price) / 100)) AS sum, " +
                "demandReport.document, " +
                "demand.amount - sum(debit.amount) as balance " +
                $"FROM inventory INNER JOIN demand ON demand.inventoryId = inventory.id " +
                $"LEFT JOIN demandReport ON demand.reportId = demandReport.id " +
                "LEFT JOIN debit ON debit.demandId = demand.id " + 
                $" GROUP BY demand.id" +
                $" ORDER BY DATE(demand.date) ASC";
        }

        public void CancelDemand(int p_SelectedItemId)
        {
            DataRow dataRow = ReturnDataSet().Tables[0].Rows.Find(p_SelectedItemId);
            string l_Where = $"id={p_SelectedItemId}";
            // Перемещение требования-накладной в другую папку 
            object reportId = SQLiteManager.GetInstance().Demand().GetReportId(p_SelectedItemId); 
            string currentDocument = dataRow["document"].ToString();
            if (reportId != null && !reportId.Equals(DBNull.Value))
            {
                SQLiteManager.GetInstance().DemandReport().Rollback(reportId, currentDocument);
            }
            // Перемещение списания в другую папку 
            reportId = SQLiteManager.GetInstance().Debit().GetReportIdByDemandId(p_SelectedItemId);
            if (reportId != null && !reportId.Equals(DBNull.Value))
            {
                currentDocument = SQLiteManager.GetInstance().DebitReport().ReturnDocumentById(reportId);
                SQLiteManager.GetInstance().DebitReport().Rollback(reportId, currentDocument);
            }

            SQLiteManager.GetInstance().Delete(TableName, l_Where);
        }

        public void CancelDebit(int p_SelectedItemId)
        {
            DataRow dataRow = ReturnDataSet().Tables[0].Rows.Find(p_SelectedItemId);
            // Перемещение списания в другую папку 
            object reportId = SQLiteManager.GetInstance().Debit().GetReportIdByDemandId(p_SelectedItemId);
            if (reportId != null && !reportId.Equals(DBNull.Value))
            {
                string currentDocument = SQLiteManager.GetInstance().DebitReport().ReturnDocumentById(reportId);
                SQLiteManager.GetInstance().DebitReport().Rollback(reportId, currentDocument);               
            }
            SQLiteManager.GetInstance().Debit().RemoveByDemandId(p_SelectedItemId);
        }
    }
}
