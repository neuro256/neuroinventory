using System.Data;

namespace NeuroInventory
{
    public class InventorySql : TableSql<InventorySql>
    {
        public InventorySql()
        {
            m_CommandDataSet = "SELECT * FROM inventory"; // TODO : изменить запрос
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
