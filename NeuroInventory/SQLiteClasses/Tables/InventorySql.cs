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

        private string CommandDataSetNotFiltered { get => m_CommandDataSetNotFiltered; set => m_CommandDataSetNotFiltered = value; }
        private int SelectedCatalogId { get => m_SelectedCatalogId; set => m_SelectedCatalogId = value; }

        public InventorySql()
        {
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
                "(inventory.amount - SUM(debit.amount)) AS balance " +
                "FROM inventory LEFT JOIN debit ON debit.inventoryId = inventory.id GROUP BY inventory.id;";
            CommandDataSetNotFiltered = CommandDataSet;
            TableName = "inventory";
            SetTargetPath(@"documents\inventory");
        }

        public void SetCommandDataSet(int p_Id)
        {
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
                "(inventory.amount - SUM(debit.amount)) AS balance " +
                $"FROM inventory LEFT JOIN debit ON debit.inventoryId = inventory.id WHERE inventory.catalogId={p_Id} GROUP BY inventory.id;";
            CommandDataSetNotFiltered = CommandDataSet;
            SelectedCatalogId = p_Id;
        }

        public void Filter(object p_Provider, DateTime p_Date, string p_Invoice, string p_Name, string p_OKEIcode, string p_Measurement, object p_Amount, object p_Price)
        {
            string l_DateStr = p_Date.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            string l_Name = $" AND inventory.name like '%{p_Name}%'";
            string l_Provider = p_Provider != null ? $" AND inventory.providerId={p_Provider}" : String.Empty;
            string l_Date = !DateTime.Equals(p_Date, DateTime.MaxValue) ? $" AND inventory.date=Datetime('{l_DateStr}')" : String.Empty;
            string l_Invoice = !String.IsNullOrEmpty(p_Invoice) ? $" AND invoice LIKE '%{p_Invoice}%'" : $" AND (invoice LIKE '%{p_Invoice}%' OR invoice IS NULL)";
            string l_OKEIcode = !String.IsNullOrEmpty(p_OKEIcode) ? $" AND OKEIcode LIKE '%{p_OKEIcode}%'" : $" AND (OKEIcode LIKE '%{p_OKEIcode}%' OR OKEIcode IS NULL)";
            string l_Measurement = !String.IsNullOrEmpty(p_Measurement) ? $" AND measurement LIKE '%{p_Measurement}%'" : $" AND (measurement LIKE '%{p_Measurement}%' OR measurement IS NULL)";
            string l_Amount = p_Amount != null ? $" AND (inventory.amount={p_Amount})" : String.Empty;
            string l_Price = p_Price != null ? $" AND (inventory.price={p_Price})" : String.Empty;

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
                "(inventory.amount - SUM(debit.amount)) AS balance " +
                $"FROM inventory LEFT JOIN debit ON debit.inventoryId = inventory.id WHERE inventory.catalogId={SelectedCatalogId}" +
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
    }
}
