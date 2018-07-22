using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace NeuroInventory
{
    public class InventorySql : TableSql
    {
        private string m_CommandDataSetNotFiltered;
        private int m_SelectedCatalogId;
        private List<int> m_SelectedCatalogIds;

        private string CommandDataSetNotFiltered { get => m_CommandDataSetNotFiltered; set => m_CommandDataSetNotFiltered = value; }
        private int SelectedCatalogId { get => m_SelectedCatalogId; set => m_SelectedCatalogId = value; }
        public List<int> SelectedCatalogIds { get => m_SelectedCatalogIds; set => m_SelectedCatalogIds = value; }

        public InventorySql()
        {
            CommandDataSet = "SELECT inventory.id as id, " +
                "(SELECT name FROM providers WHERE providers.id = inventory.providerId) AS providerId," + // Отображение имени поставщика вместо идентификатора
                "strftime('%d.%m.%Y', DATE(inventory.date)) AS date," +
                "inventory.invoice," +
                "inventory.invoiceCodeStr, " +
                "strftime('%d.%m.%Y', DATE(inventory.invoiceDate)) AS invoiceDate, " + 
                "inventory.name," +
                "inventory.OKEIcode," +
                "inventory.measurement," +
                "inventory.amount," +
                @"printf(""%.2f"", (CAST (inventory.price AS REAL) / 100)) AS price," +
                @"printf(""%.2f"", ((inventory.amount * price) / 100)) AS sum," +
                "(inventory.amount - SUM(demand.amount)) AS balance " +
                "FROM inventory LEFT JOIN demand ON demand.inventoryId = inventory.id GROUP BY inventory.id;";
            CommandDataSetNotFiltered = CommandDataSet;
            TableName = "inventory";
            PrimaryKey = "id";
            SetTargetPath(@"Документы\Накладные");
        }

        public void SetCommandDataSet(int p_Id)
        {
            CommandDataSet = "SELECT inventory.id as id, " +
                "(SELECT name FROM providers WHERE providers.id = inventory.providerId) AS providerId," + // Отображение имени поставщика вместо идентификатора
                "strftime('%d.%m.%Y', DATE(inventory.date)) AS date," +
                "inventory.invoice," +
                "inventory.invoiceCodeStr, " +
                "strftime('%d.%m.%Y', DATE(inventory.invoiceDate)) AS invoiceDate, " +
                "inventory.name," +
                "inventory.OKEIcode," +
                "inventory.measurement," +
                "inventory.amount," +
                @"printf(""%.2f"", (CAST (inventory.price AS REAL) / 100)) AS price," +
                @"printf(""%.2f"", ((inventory.amount * price) / 100)) AS sum," +
                "(inventory.amount - SUM(demand.amount)) AS balance " +
                $"FROM inventory LEFT JOIN demand ON demand.inventoryId = inventory.id WHERE inventory.catalogId={p_Id} GROUP BY inventory.id;";
            CommandDataSetNotFiltered = CommandDataSet;
            SelectedCatalogId = p_Id;
        }

        public void SetCommandDataSet(List<int> p_CatalogIds)
        {
            string catalogIdsStr = String.Empty;
            foreach(var id in p_CatalogIds)
            {
                catalogIdsStr += $" inventory.catalogId={id} OR";
            }
            catalogIdsStr = catalogIdsStr.Substring(0, catalogIdsStr.Length - 2);
            CommandDataSet = "SELECT inventory.id as id, " +
                "(SELECT name FROM providers WHERE providers.id = inventory.providerId) AS providerId," + // Отображение имени поставщика вместо идентификатора
                "strftime('%d.%m.%Y', DATE(inventory.date)) AS date," +
                "inventory.invoice," +
                "inventory.invoiceCodeStr, " +
                "strftime('%d.%m.%Y', DATE(inventory.invoiceDate)) AS invoiceDate, " +
                "inventory.name," +
                "inventory.OKEIcode," +
                "inventory.measurement," +
                "inventory.amount," +
                @"printf(""%.2f"", (CAST (inventory.price AS REAL) / 100)) AS price," +
                @"printf(""%.2f"", ((inventory.amount * price) / 100)) AS sum," +
                "(inventory.amount - SUM(demand.amount)) AS balance " +
                $"FROM inventory LEFT JOIN demand ON demand.inventoryId = inventory.id WHERE {catalogIdsStr} GROUP BY inventory.id;";
            CommandDataSetNotFiltered = CommandDataSet;
            SelectedCatalogIds = p_CatalogIds;
        }

        public void Remove(int p_SelectedItemId)
        {
            DataRow dataRow = ReturnDataSet().Tables[0].Rows.Find(p_SelectedItemId);
            if(dataRow != null)
            {
                string currentDocument = dataRow["invoice"].ToString();
                DeleteFile(currentDocument);
                string l_Where = $"id={p_SelectedItemId}";

                SQLiteManager.GetInstance().Delete(TableName, l_Where);
            }            
        }

        public void Update(int p_Id, int p_CatalogId, object p_Provider, DateTime p_Date, string p_InvoiceCodeStr, DateTime p_InvoiceDate, string p_Name, string p_OKEIcode, string p_Measurement, decimal p_Amount, decimal p_Price, string p_SelectedDocument, string p_CurrentDocument)
        {
            Dictionary<string, object> values = new Dictionary<string, object>
            {
                ["catalogId"] = p_CatalogId,
                ["providerId"] = p_Provider,
                ["date"] = p_Date,
                ["invoiceCodeStr"] = !String.IsNullOrEmpty(p_InvoiceCodeStr) ? (object)p_InvoiceCodeStr : DBNull.Value,
                ["invoiceDate"] = p_InvoiceDate,
                ["name"] = p_Name,
                ["OKEIcode"] = !String.IsNullOrEmpty(p_OKEIcode) ? (object)p_OKEIcode : DBNull.Value,
                ["measurement"] = !String.IsNullOrEmpty(p_Measurement) ? (object)p_Measurement : DBNull.Value,
                ["amount"] = p_Amount,
                ["price"] = p_Price * 100,
                ["invoice"] = UpdateFile(p_SelectedDocument, p_CurrentDocument)
            };

            string l_Where = $"id={p_Id}";

            SQLiteManager.GetInstance().Update(TableName, values, l_Where);
        }

        public void Update(int p_Id, int p_CatalogId)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["catalogId"] = p_CatalogId;

            string l_Where = $"id={p_Id}";

            SQLiteManager.GetInstance().Update(TableName, values, l_Where);
        }

        public void Insert(int p_CatalogId, object p_Provider, DateTime p_Date, string p_InvoiceCodeStr, DateTime p_InvoiceDate, string p_Name, string p_OKEIcode, string p_Measurement, decimal p_Amount, decimal p_Price, string p_SelectedDocument)
        {
            Dictionary<string, object> values = new Dictionary<string, object>
            {
                ["catalogId"] = p_CatalogId,
                ["providerId"] = p_Provider,
                ["date"] = p_Date,
                ["invoiceCodeStr"] = !String.IsNullOrEmpty(p_InvoiceCodeStr) ? (object)p_InvoiceCodeStr : DBNull.Value,
                ["invoiceDate"] = p_InvoiceDate,
                ["name"] = p_Name,
                ["OKEIcode"] = !String.IsNullOrEmpty(p_OKEIcode) ? (object)p_OKEIcode : DBNull.Value,
                ["measurement"] = !String.IsNullOrEmpty(p_Measurement) ? (object)p_Measurement : DBNull.Value,
                ["amount"] = p_Amount,
                ["price"] = p_Price * 100,
                ["invoice"] = InsertFile(p_SelectedDocument)
            };

            SQLiteManager.GetInstance().Insert(TableName, values);
        }

        public int GetCatalogId(int p_Id)
        {
            return Convert.ToInt32(SQLiteManager.GetInstance().CommandExecuteScalar($"SELECT catalogId FROM inventory WHERE id={p_Id}"));
        }
    }
}
