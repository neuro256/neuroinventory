using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace NeuroInventory
{
    public class MeasurementSql : TableSql<MeasurementSql>
    {
        public new string connectionString
        {
            get
            {
                m_ConnectionStr = SQLiteSettingsManager.GetInstance().connectionString;
                return m_ConnectionStr;
            }
        }

        public MeasurementSql()
        {
            m_CommandDataSet = "SELECT * FROM measurement";
            m_TableName = "measurement";
        }

        public void Insert(decimal p_OKEIcode, string p_Name, string p_Symbol, decimal p_DecimalPlaces)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["codeOKEI"] = p_OKEIcode;
            values["name"] = p_Name;
            values["symbol"] = p_Symbol;
            values["decimalPlaces"] = p_DecimalPlaces;

            SQLiteSettingsManager.GetInstance().Insert(m_TableName, values);
        }

        public void Update(object p_Id, decimal p_OKEIcode, string p_Name, string p_Symbol, decimal p_DecimalPlaces)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            values["codeOKEI"] = p_OKEIcode;
            values["name"] = p_Name;
            values["symbol"] = p_Symbol;
            values["decimalPlaces"] = p_DecimalPlaces;

            string l_Where = $"id={p_Id}";

            SQLiteSettingsManager.GetInstance().Update(m_TableName, values, l_Where);
        }

        public void Remove(int p_ListviewSelectedItemIndex)
        {
            DataSet dataSet = ReturnDataSet();
            object selectedRecordId = dataSet.Tables[0].Rows[p_ListviewSelectedItemIndex]["id"];
            string l_Where = $"id={selectedRecordId}";

            SQLiteSettingsManager.GetInstance().Delete(m_TableName, l_Where);
        }

        /// <summary>
        /// Метод возвращает dataSet таблицы 
        /// </summary>
        /// <returns></returns>
        public override DataSet ReturnDataSet()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteDataAdapter myAdapter = new SQLiteDataAdapter(m_CommandDataSet, connection))
                {
                    using (DataSet dataSet = new DataSet())
                    {
                        connection.Open();
                        try
                        {
                            myAdapter.Fill(dataSet, m_TableName);
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

        public string GetOKEIByName(string p_Name)
        {
            return SQLiteSettingsManager.GetInstance().CommandExecuteScalar($"SELECT codeOKEI FROM measurement where name='{p_Name}';").ToString();
        }

        public int GetDecimalPlacesByName(string p_Name)
        {
            return Convert.ToInt32(SQLiteSettingsManager.GetInstance().CommandExecuteScalar($"SELECT decimalPlaces FROM measurement where name='{p_Name}';"));
        }
    }
}
