using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace NeuroInventory
{
    public class RecentsSql : TableSql
    {
        public new string connectionString
        {
            get
            {
                m_ConnectionStr = SQLiteSettingsManager.GetInstance().connectionString;
                return m_ConnectionStr;
            }
        }

        public RecentsSql()
        {
            CommandDataSet = "SELECT * FROM recents GROUP BY path ORDER BY id DESC LIMIT 10";
            TableName = "recents";
        }

        public void Insert(string p_Path)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["path"] = p_Path;

            SQLiteSettingsManager.GetInstance().Insert(TableName, values);
        }

        public void Remove(int p_Id)
        {
            string l_Where = $"id={p_Id}";

            SQLiteSettingsManager.GetInstance().Delete(TableName, l_Where);
        }

        public int ReturnCount()
        {
            return Convert.ToInt32(SQLiteSettingsManager.GetInstance().CommandExecuteScalar("SELECT COUNT(id) FROM recents"));
        }

        /// <summary>
        /// Метод возвращает dataSet таблицы 
        /// </summary>
        /// <returns></returns>
        public override DataSet ReturnDataSet()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteDataAdapter myAdapter = new SQLiteDataAdapter(CommandDataSet, connection))
                {
                    using (DataSet dataSet = new DataSet())
                    {
                        connection.Open();
                        try
                        {
                            myAdapter.Fill(dataSet, TableName);
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show(exc.Message);
                        }
                        finally
                        {
                            connection.Close();
                            myAdapter.Dispose();
                        }
                        return dataSet;
                    }
                }
            }
        }
    }
}
