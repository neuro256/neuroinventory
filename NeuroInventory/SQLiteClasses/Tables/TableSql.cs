using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuroInventory
{
    //Абстрактный класс для работы с таблицами 
    //Для каждой таблицы SQL создается отдельный класс-наследник
    public abstract class TableSql<T> where T : new()
    {
        private static T instance;
        protected string _commandDataSet; //Команда для создания набора
        protected string _connectionStr;//Строка для подключения 
        public string _tableName; //Название таблицы

        static public T GetInstance()
        {
            if(instance == null)
            {
                instance = new T();
            }
            return instance;
        }

        public string connectionString
        {
            get
            {
                _connectionStr = SQLiteManager.GetInstance().connectionString;
                return _connectionStr;
            }
        }

        /// <summary>
        /// Метод возвращает dataSet таблицы 
        /// </summary>
        /// <returns></returns>
        public virtual DataSet ReturnDataSet()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteDataAdapter myAdapter = new SQLiteDataAdapter(_commandDataSet, connection))
                {
                    using (DataSet dataSet = new DataSet())
                    {
                        connection.Open();
                        try
                        {
                            myAdapter.Fill(dataSet, _tableName);
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
