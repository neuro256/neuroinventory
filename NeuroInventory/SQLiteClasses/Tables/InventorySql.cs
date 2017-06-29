using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace NeuroInventory
{
    public class InventorySql : TableSql<InventorySql>
    {
        private string m_CommandDataSetNotFiltered;
        private int m_SelectedCatalogId;
        private List<int> m_SelectedCatalogIds;

        private string CommandDataSetNotFiltered { get => m_CommandDataSetNotFiltered; set => m_CommandDataSetNotFiltered = value; }
        private int SelectedCatalogId { get => m_SelectedCatalogId; set => m_SelectedCatalogId = value; }
        public List<int> SelectedCatalogIds { get => m_SelectedCatalogIds; set => m_SelectedCatalogIds = value; }

        public InventorySql()
        {
            CommandDataSet = "SELECT inventory.id, " +
                "inventory.catalogId, " +
                "(SELECT name FROM providers WHERE providers.id = inventory.providerId) AS providerId," + // Отображение имени поставщика вместо идентификатора
                "strftime('%d.%m.%Y', DATE(inventory.date)) AS date," +
                "inventory.invoice," +
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
            SetTargetPath(@"Документы\Накладные");
        }

        public void SetCommandDataSet(int p_Id)
        {
            CommandDataSet = "SELECT inventory.id, " +
                "inventory.catalogId, " +
                "(SELECT name FROM providers WHERE providers.id = inventory.providerId) AS providerId," + // Отображение имени поставщика вместо идентификатора
                "strftime('%d.%m.%Y', DATE(inventory.date)) AS date," +
                "inventory.invoice," +
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
            CommandDataSet = "SELECT inventory.id, " +
                "inventory.catalogId, " +
                "(SELECT name FROM providers WHERE providers.id = inventory.providerId) AS providerId," + // Отображение имени поставщика вместо идентификатора
                "strftime('%d.%m.%Y', DATE(inventory.date)) AS date," +
                "inventory.invoice," +
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

        public void Filter(object p_Provider, DateTime p_Date, string p_Invoice, string p_Name, string p_OKEIcode, string p_Measurement, object p_Amount, object p_Price)
        {
            string catalogIdsStr = String.Empty;
            foreach (var id in SelectedCatalogIds)
            {
                catalogIdsStr += $" inventory.catalogId={id} OR";
            }
            catalogIdsStr = catalogIdsStr.Substring(0, catalogIdsStr.Length - 2);

            string l_DateStr = p_Date.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            string l_Name = $" AND inventory.name like '%{p_Name}%'";
            string l_Provider = p_Provider != null ? $" AND inventory.providerId={p_Provider}" : String.Empty;
            string l_Date = !DateTime.Equals(p_Date, DateTime.MaxValue) ? $" AND inventory.date=Datetime('{l_DateStr}')" : String.Empty;
            string l_Invoice = !String.IsNullOrEmpty(p_Invoice) ? $" AND invoice LIKE '%{p_Invoice}%'" : $" AND (invoice LIKE '%{p_Invoice}%' OR invoice IS NULL)";
            string l_OKEIcode = !String.IsNullOrEmpty(p_OKEIcode) ? $" AND OKEIcode LIKE '%{p_OKEIcode}%'" : $" AND (OKEIcode LIKE '%{p_OKEIcode}%' OR OKEIcode IS NULL)";
            string l_Measurement = !String.IsNullOrEmpty(p_Measurement) ? $" AND measurement LIKE '%{p_Measurement}%'" : $" AND (measurement LIKE '%{p_Measurement}%' OR measurement IS NULL)";
            string l_Amount = p_Amount != null ? $" AND (inventory.amount={p_Amount})" : String.Empty;
            l_Amount = l_Amount.Replace(",", ".");
            string l_Price = p_Price != null ? $" AND (inventory.price={Convert.ToInt32(Convert.ToDecimal(p_Price) * 100)})" : String.Empty;

            CommandDataSet = "SELECT inventory.id, " +
                "(SELECT name FROM providers WHERE providers.id = inventory.providerId) AS providerId," + // Отображение имени поставщика вместо идентификатора
                "strftime('%d.%m.%Y', DATE(inventory.date)) AS date," +
                "inventory.invoice," +
                "inventory.name," +
                "inventory.OKEIcode," +
                "inventory.measurement," +
                "inventory.amount," +
                @"printf(""%.2f"", (CAST (inventory.price AS REAL) / 100)) AS price," +
                @"printf(""%.2f"", ((inventory.amount * price) / 100)) AS sum," +
                "(inventory.amount - SUM(demand.amount)) AS balance " +
                $"FROM inventory LEFT JOIN demand ON demand.inventoryId = inventory.id WHERE ({catalogIdsStr}) " +
                l_Name +
                l_Provider +
                l_Date +
                l_Invoice + 
                l_OKEIcode +
                l_Measurement +
                l_Amount +
                l_Price + 
                $" GROUP BY inventory.id;";
        }

        public void ClearFilter()
        {
            CommandDataSet = CommandDataSetNotFiltered;
        }

        public void Remove(int p_ListviewSelectedItemIndex)
        {
            DataSet dataSet = ReturnDataSet();
            object selectedRecordId = dataSet.Tables[0].Rows[p_ListviewSelectedItemIndex]["id"];
            string currentDocument = dataSet.Tables[0].Rows[p_ListviewSelectedItemIndex]["invoice"].ToString();
            DeleteFile(currentDocument);
            string l_Where = $"id={selectedRecordId}";

            SQLiteManager.GetInstance().Delete(TableName, l_Where);
        }

        public void Update(object p_Id, int p_CatalogId, object p_Provider, DateTime p_Date, string p_Name, string p_OKEIcode, string p_Measurement, decimal p_Amount, decimal p_Price, string p_SelectedDocument, string p_CurrentDocument)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["catalogId"] = p_CatalogId;
            values["providerId"] = p_Provider;
            values["date"] = p_Date;
            values["name"] = p_Name;
            values["OKEIcode"] = !String.IsNullOrEmpty(p_OKEIcode) ? (object)p_OKEIcode : DBNull.Value;
            values["measurement"] = !String.IsNullOrEmpty(p_Measurement) ? (object)p_Measurement : DBNull.Value;
            values["amount"] = p_Amount;
            values["price"] = p_Price * 100;
            values["invoice"] = UpdateFile(p_SelectedDocument, p_CurrentDocument);

            string l_Where = $"id={p_Id}";

            SQLiteManager.GetInstance().Update(TableName, values, l_Where);
        }

        public void Update(object p_Id, int p_CatalogId)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["catalogId"] = p_CatalogId;

            string l_Where = $"id={p_Id}";

            SQLiteManager.GetInstance().Update(TableName, values, l_Where);
        }

        public void Insert(int p_CatalogId, object p_Provider, DateTime p_Date, string p_Name, string p_OKEIcode, string p_Measurement, decimal p_Amount, decimal p_Price, string p_SelectedDocument)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["catalogId"] = p_CatalogId;
            values["providerId"] = p_Provider;
            values["date"] = p_Date;
            values["name"] = p_Name;
            values["OKEIcode"] = !String.IsNullOrEmpty(p_OKEIcode) ? (object)p_OKEIcode : DBNull.Value;
            values["measurement"] = !String.IsNullOrEmpty(p_Measurement) ? (object)p_Measurement : DBNull.Value;
            values["amount"] = p_Amount;
            values["price"] = p_Price * 100;
            values["invoice"] = InsertFile(p_SelectedDocument);

            SQLiteManager.GetInstance().Insert(TableName, values);
        }

        public int GetCatalogId(int p_Id)
        {
            return Convert.ToInt32(SQLiteManager.GetInstance().CommandExecuteScalar($"SELECT catalogId FROM inventory WHERE id={p_Id}"));
        }
    }
}
