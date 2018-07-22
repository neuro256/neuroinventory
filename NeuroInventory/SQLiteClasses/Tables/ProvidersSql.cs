using System;
using System.Collections.Generic;
using System.Data;

namespace NeuroInventory
{
    public class ProvidersSql : TableSql
    {
        public ProvidersSql()
        {
            CommandDataSet = "SELECT providers.id as id, " +
                "providers.name, " +
                "providers.address, " +
                "providers.phone, " +
                "providers.mail, " +
                "providers.inn, " +
                "providers.document " +
                "FROM providers ORDER BY name ASC";
            TableName = "providers";
            PrimaryKey = "id";
            SetTargetPath(@"Документы\Поставщики");
        }

        public void Insert(string p_Name, string p_Address, string p_Phone, string p_Mail, string p_INN, string p_Document)
        {
            Dictionary<string, object> values = new Dictionary<string, object>
            {
                ["name"] = p_Name,
                ["address"] = !String.IsNullOrEmpty(p_Address) ? (object)p_Address : DBNull.Value,
                ["phone"] = !String.IsNullOrEmpty(p_Phone) ? (object)p_Phone : DBNull.Value,
                ["mail"] = !String.IsNullOrEmpty(p_Mail) ? (object)p_Mail : DBNull.Value,
                ["inn"] = !String.IsNullOrEmpty(p_INN) ? (object)p_INN : DBNull.Value,
                ["document"] = InsertFile(p_Document)
            };

            SQLiteManager.GetInstance().Insert(TableName, values);
        }

        public void Update(object p_Id, string p_Name, string p_Address, string p_Phone, string p_Mail, string p_INN, string p_SelectedDocument, string p_CurrentDocument)
        {
            Dictionary<string, object> values = new Dictionary<string, object>
            {
                ["name"] = p_Name,
                ["address"] = !String.IsNullOrEmpty(p_Address) ? (object)p_Address : DBNull.Value,
                ["phone"] = !String.IsNullOrEmpty(p_Phone) ? (object)p_Phone : DBNull.Value,
                ["mail"] = !String.IsNullOrEmpty(p_Mail) ? (object)p_Mail : DBNull.Value,
                ["inn"] = !String.IsNullOrEmpty(p_INN) ? (object)p_INN : DBNull.Value,
                ["document"] = UpdateFile(p_SelectedDocument, p_CurrentDocument)
            };

            string l_Where = $"id={p_Id}";

            SQLiteManager.GetInstance().Update(TableName, values, l_Where);
        }

        public void Remove(int p_SelectedItemId)
        {
            DataRow dataRow = ReturnDataSet().Tables[0].Rows.Find(p_SelectedItemId);
            string currentDocument = dataRow["document"].ToString();
            DeleteFile(currentDocument);
            string l_Where = $"id={p_SelectedItemId}";

            SQLiteManager.GetInstance().Delete(TableName, l_Where);
        }
    }
}
