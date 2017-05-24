using System;
using System.Collections.Generic;
using System.Data;

namespace NeuroInventory
{
    public class InventorySql : TableSql<InventorySql>
    {
        public InventorySql()
        {
            m_CommandDataSet = "SELECT inventory.id, " +
                "(SELECT name FROM providers WHERE providers.id = inventory.providerId) AS providerId," + // Отображение имени поставщика вместо идентификатора
                "strftime('%d.%m.%Y', DATE(inventory.date)) AS date," +
                "inventory.invoice," +
                "inventory.name," +
                "inventory.OKEIcode," +
                "inventory.measurement," +
                "inventory.amount," +
                "CAST (inventory.price AS REAL) / 100 AS price," +
                "CAST ((inventory.amount * inventory.price) AS REAL) AS sum," +
                "(inventory.amount - SUM(debit.amount)) AS balance " +
                "FROM inventory LEFT JOIN debit ON debit.inventoryId = inventory.id GROUP BY inventory.id;";
            m_TableName = "inventory";
            SetTargetPath(@"documents\inventory");
        }

        public void Remove(int p_ListviewSelectedItemIndex)
        {
            DataSet dataSet = ReturnDataSet();
            object selectedRecordId = dataSet.Tables[0].Rows[p_ListviewSelectedItemIndex]["id"];
            string l_Where = $"id={selectedRecordId}";

            SQLiteManager.GetInstance().Delete(m_TableName, l_Where);
        }

        public void Update(object p_Id, object p_Provider, DateTime p_Date, string p_Name, string p_OKEIcode, string p_Measurement, decimal p_Amount, decimal p_Price, string p_SelectedDocument, string p_CurrentDocument)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["providerId"] = p_Provider;
            values["date"] = p_Date;
            values["name"] = p_Name;
            values["OKEIcode"] = !String.IsNullOrEmpty(p_OKEIcode) ? (object)p_OKEIcode : DBNull.Value;
            values["measurement"] = !String.IsNullOrEmpty(p_Measurement) ? (object)p_Measurement : DBNull.Value;
            values["amount"] = p_Amount;
            values["price"] = p_Price * 100;

            // Обновление выбранного файла-документа. 
            if (!String.IsNullOrEmpty(p_SelectedDocument))
            {
                if (IsDocumentUpdated(p_SelectedDocument, p_CurrentDocument)) // файл изменен
                {
                    // Удаляем старый файл
                    DeleteFile(p_CurrentDocument);
                    // Копируем новый файл
                    values["invoice"] = CopyFile(p_SelectedDocument);
                }
                else
                {
                    values["invoice"] = p_CurrentDocument;
                }
            }
            else
            {
                values["invoice"] = DBNull.Value;
                // Удаляем старый файл
                DeleteFile(p_CurrentDocument);
            }

            string l_Where = $"id={p_Id}";

            SQLiteManager.GetInstance().Update(m_TableName, values, l_Where);
        }

        public void Insert(object p_Provider, DateTime p_Date, string p_Name, string p_OKEIcode, string p_Measurement, decimal p_Amount, decimal p_Price, string p_SelectedDocument)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["providerId"] = p_Provider;
            values["date"] = p_Date;
            values["name"] = p_Name;
            values["OKEIcode"] = !String.IsNullOrEmpty(p_OKEIcode) ? (object)p_OKEIcode : DBNull.Value;
            values["measurement"] = !String.IsNullOrEmpty(p_Measurement) ? (object)p_Measurement : DBNull.Value;
            values["amount"] = p_Amount;
            values["price"] = p_Price * 100;

            // Копирование выбранного файла-документа в целевую папку приложения
            if (!String.IsNullOrEmpty(p_SelectedDocument))
            {
                values["invoice"] = CopyFile(p_SelectedDocument);
            }
            else
            {
                values["invoice"] = DBNull.Value;
            }

            // TODO: 
            values["catalogId"] = 1;

            SQLiteManager.GetInstance().Insert(m_TableName, values);
        }
    }
}
