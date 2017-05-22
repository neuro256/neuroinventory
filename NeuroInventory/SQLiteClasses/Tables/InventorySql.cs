using System.Data;

namespace NeuroInventory
{
    public class InventorySql : TableSql<InventorySql>
    {
        public InventorySql()
        {
            m_CommandDataSet = "SELECT id, " +
                "(SELECT name FROM providers WHERE providers.id = inventory.providerId)," +
                "strftime('%d.%m.%Y', DATE(date))," +
                "invoice," +
                "name," +
                "OKEIcode," +
                "measurement," +
                "amount," +
                "CAST ((price) AS REAL)," +
                "CAST ((amount*price) AS REAL)," +
                "released" +
                " FROM inventory"; // TODO : изменить запрос
            m_TableName = "inventory";
        }

        public void Remove(int p_ListviewSelectedItemIndex)
        {
            DataSet dataSet = ReturnDataSet();
            object selectedRecordId = dataSet.Tables[0].Rows[p_ListviewSelectedItemIndex]["id"];
            string l_Where = $"id={selectedRecordId}";

            SQLiteManager.GetInstance().Delete(m_TableName, l_Where);
        }
    }
}
