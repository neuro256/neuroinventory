using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace NeuroInventory
{
    public class InventorySql : TableSql<InventorySql>
    {
        string m_TargetPath;

        public InventorySql()
        {
            m_CommandDataSet = "SELECT id, " +
                "(SELECT name FROM providers WHERE providers.id = inventory.providerId) AS providerId," +
                "strftime('%d.%m.%Y', DATE(date)) AS date," +
                "invoice," +
                "name," +
                "OKEIcode," +
                "measurement," +
                "amount," +
                "CAST ((price) AS REAL) AS price," +
                "CAST ((amount*price) AS REAL) AS sum," +
                "released" +
                " FROM inventory"; // TODO : изменить запрос
            m_TableName = "inventory";
            m_TargetPath = @"documents\inventory";
        }

        public void Remove(int p_ListviewSelectedItemIndex)
        {
            DataSet dataSet = ReturnDataSet();
            object selectedRecordId = dataSet.Tables[0].Rows[p_ListviewSelectedItemIndex]["id"];
            string l_Where = $"id={selectedRecordId}";

            SQLiteManager.GetInstance().Delete(m_TableName, l_Where);
        }

        public void Update(object p_Id, object p_Provider, DateTime p_Date, string p_Name, string p_OKEIcode, string p_Measurement, decimal p_Amount, decimal p_Price, decimal p_Released, string p_SelectedDocument, string p_CurrentDocument)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["providerId"] = p_Provider;
            values["date"] = p_Date;
            values["name"] = p_Name;
            values["OKEIcode"] = !String.IsNullOrEmpty(p_OKEIcode) ? (object)p_OKEIcode : DBNull.Value;
            values["measurement"] = !String.IsNullOrEmpty(p_Measurement) ? (object)p_Measurement : DBNull.Value;
            values["amount"] = p_Amount;
            values["price"] = p_Price;
            values["released"] = p_Released;

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

        public void Insert(object p_Provider, DateTime p_Date, string p_Name, string p_OKEIcode, string p_Measurement, decimal p_Amount, decimal p_Price, decimal p_Released, string p_SelectedDocument)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["providerId"] = p_Provider;
            values["date"] = p_Date;
            values["name"] = p_Name;
            values["OKEIcode"] = !String.IsNullOrEmpty(p_OKEIcode) ? (object)p_OKEIcode : DBNull.Value;
            values["measurement"] = !String.IsNullOrEmpty(p_Measurement) ? (object)p_Measurement : DBNull.Value;
            values["amount"] = p_Amount;
            values["price"] = p_Price;
            values["released"] = p_Released;

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

        /// <summary>
        /// Проверка на то, был ли изменен файл-документа в окне редактора
        /// </summary>
        /// <param name="p_SelectedDocument"></param>
        /// <param name="p_CurrentDocument"></param>
        /// <returns></returns>
        private bool IsDocumentUpdated(string p_SelectedDocument, string p_CurrentDocument)
        {
            bool documentUpdated = false;
            if (!String.IsNullOrEmpty(p_SelectedDocument) && String.Compare(p_SelectedDocument, p_CurrentDocument) != 0)
                documentUpdated = true;
            return documentUpdated;
        }

        private string CopyFile(string p_FileName)
        {
            string fileName = Path.GetFileName(p_FileName);
            string sourceFile = p_FileName;
            string destFile = Path.Combine(m_TargetPath, fileName);
            if (!Directory.Exists(m_TargetPath))
            {
                Directory.CreateDirectory(m_TargetPath);
            }
            File.Copy(sourceFile, destFile, true);
            return destFile;
        }

        private void DeleteFile(string p_FileName)
        {
            if (File.Exists(p_FileName))
            {
                File.Delete(p_FileName);
            }
        }
    }
}
