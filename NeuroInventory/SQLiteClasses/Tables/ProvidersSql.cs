using System;
using System.Collections.Generic;
using System.Data;

namespace NeuroInventory
{
    public class ProvidersSql : TableSql<ProvidersSql>
    {
        public ProvidersSql()
        {
            CommandDataSet = "SELECT * FROM providers ORDER BY name ASC";
            TableName = "providers";
            SetTargetPath(@"Документы\Поставщики");
        }

        public void Filter(string p_Name, string p_Address, string p_Phone, string p_Mail, string p_Document)
        {
            string l_Address = !String.IsNullOrEmpty(p_Address) ? $"address like '%{p_Address}%'" : $"(address like '%{p_Address}%' OR address IS NULL)";
            string l_Phone = !String.IsNullOrEmpty(p_Phone) ? $"phone like '%{p_Phone}%'" : $"(phone like '%{p_Phone}%' OR phone IS NULL)";
            string l_Mail = !String.IsNullOrEmpty(p_Mail) ? $"mail like '%{p_Mail}%'" : $"(mail like '%{p_Mail}%' OR mail IS NULL)";
            string l_Document = !String.IsNullOrEmpty(p_Document) ? $"document like '%{p_Document}%'" : $"(document like '%{p_Document}%' OR document IS NULL)";

            CommandDataSet = "SELECT * FROM providers WHERE " +
                $"name like '%{p_Name}%' AND " +
                $"{l_Address} AND " +
                $"{l_Phone} AND " +
                $"{l_Mail} AND " +
                $"{l_Document}" +
                $" ORDER BY name ASC";
        }

        public void ClearFilter()
        {
            CommandDataSet = "SELECT * FROM providers ORDER BY name ASC";
        }

        public void Insert(string p_Name, string p_Address, string p_Phone, string p_Mail, string p_Document)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["name"] = p_Name;
            values["address"] = !String.IsNullOrEmpty(p_Address) ? (object) p_Address : DBNull.Value;
            values["phone"] = !String.IsNullOrEmpty(p_Phone) ? (object)p_Phone : DBNull.Value;
            values["mail"] = !String.IsNullOrEmpty(p_Mail) ? (object)p_Mail : DBNull.Value;
            values["document"] = InsertFile(p_Document);

            SQLiteManager.GetInstance().Insert(TableName, values);
        }

        public void Update(object p_Id, string p_Name, string p_Address, string p_Phone, string p_Mail, string p_SelectedDocument, string p_CurrentDocument)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["name"] = p_Name;
            values["address"] = !String.IsNullOrEmpty(p_Address) ? (object)p_Address : DBNull.Value;
            values["phone"] = !String.IsNullOrEmpty(p_Phone) ? (object)p_Phone : DBNull.Value;
            values["mail"] = !String.IsNullOrEmpty(p_Mail) ? (object)p_Mail : DBNull.Value;
            values["document"] = UpdateFile(p_SelectedDocument, p_CurrentDocument);

            string l_Where = $"id={p_Id}";

            SQLiteManager.GetInstance().Update(TableName, values, l_Where);
        }

        public void Remove(int p_ListviewSelectedItemIndex)
        {
            DataSet dataSet = ReturnDataSet();
            object selectedRecordId = dataSet.Tables[0].Rows[p_ListviewSelectedItemIndex]["id"];
            string currentDocument = dataSet.Tables[0].Rows[p_ListviewSelectedItemIndex]["document"].ToString();
            DeleteFile(currentDocument);
            string l_Where = $"id={selectedRecordId}";

            SQLiteManager.GetInstance().Delete(TableName, l_Where);
        }
    }
}
