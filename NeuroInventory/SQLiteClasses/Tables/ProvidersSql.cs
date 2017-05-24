using System;
using System.Collections.Generic;
using System.Data;

namespace NeuroInventory
{
    public class ProvidersSql : TableSql<ProvidersSql>
    {
        public ProvidersSql()
        {
            m_CommandDataSet = "SELECT * FROM providers";
            m_TableName = "providers";
            SetTargetPath(@"documents\providers");
        }

        public void Insert(string p_Name, string p_Address, string p_Phone, string p_Mail, string p_Document)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["name"] = p_Name;
            values["address"] = !String.IsNullOrEmpty(p_Address) ? (object) p_Address : DBNull.Value;
            values["phone"] = !String.IsNullOrEmpty(p_Phone) ? (object)p_Phone : DBNull.Value;
            values["mail"] = !String.IsNullOrEmpty(p_Mail) ? (object)p_Mail : DBNull.Value;

            // Копирование выбранного файла-документа в целевую папку приложения
            if (!String.IsNullOrEmpty(p_Document))
            {
                values["document"] = CopyFile(p_Document);
            }
            else
            {
                values["document"] = DBNull.Value;
            }

            SQLiteManager.GetInstance().Insert(m_TableName, values);
        }

        public void Update(object p_Id, string p_Name, string p_Address, string p_Phone, string p_Mail, string p_SelectedDocument, string p_CurrentDocument)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["name"] = p_Name;
            values["address"] = !String.IsNullOrEmpty(p_Address) ? (object)p_Address : DBNull.Value;
            values["phone"] = !String.IsNullOrEmpty(p_Phone) ? (object)p_Phone : DBNull.Value;
            values["mail"] = !String.IsNullOrEmpty(p_Mail) ? (object)p_Mail : DBNull.Value;

            // Обновление выбранного файла-документа. 
            if (!String.IsNullOrEmpty(p_SelectedDocument))
            {
                if (IsDocumentUpdated(p_SelectedDocument, p_CurrentDocument)) // файл изменен
                {
                    // Удаляем старый файл
                    DeleteFile(p_CurrentDocument);
                    // Копируем новый файл
                    values["document"] = CopyFile(p_SelectedDocument);
                }
                else
                {
                    values["document"] = p_CurrentDocument;
                }
            }
            else
            {
                values["document"] = DBNull.Value;
                // Удаляем старый файл
                DeleteFile(p_CurrentDocument);
            }

            string l_Where = $"id={p_Id}";

            SQLiteManager.GetInstance().Update(m_TableName, values, l_Where);
        }

        public void Remove(int p_ListviewSelectedItemIndex)
        {
            DataSet dataSet = ReturnDataSet();
            object selectedRecordId = dataSet.Tables[0].Rows[p_ListviewSelectedItemIndex]["id"];
            string currentDocument = dataSet.Tables[0].Rows[p_ListviewSelectedItemIndex]["document"].ToString();
            DeleteFile(currentDocument);
            string l_Where = $"id={selectedRecordId}";

            SQLiteManager.GetInstance().Delete(m_TableName, l_Where);
        }
    }
}
