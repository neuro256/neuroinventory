using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace NeuroInventory
{
    public class SQLiteManager
    {
        /// <summary>
        /// Потокобезопасная реализация синглтона
        /// </summary>
        private static readonly SQLiteManager instance = new SQLiteManager();

        private string m_DatabaseName = null;

        #region INTERFACE

        public string databaseName
        {
            get
            {
                return m_DatabaseName;
            }
            set
            {
                m_DatabaseName = value;
            }
        }

        public string connectionString
        {
            get
            {
                return $"DataSource={m_DatabaseName}; foreign keys=true; Version=3;";
            }
        }

        public static SQLiteManager GetInstance()
        {
            return instance;
        }

        #endregion

        /// <summary>
        /// Проверка пути и мени базы данных на пустоту
        /// </summary>
        /// <returns>True если имя непустое, иначе False</returns>
        private bool DatabaseNameExist()
        {
            return !String.IsNullOrEmpty(m_DatabaseName);
        }

        /// <summary>
        /// Проверка соединения с базой данных
        /// </summary>
        /// <returns>True если есть соединение, иначе False</returns>
        public bool TestConnection()
        {
            try
            {
                if (!String.IsNullOrEmpty(connectionString) && DatabaseNameExist())
                {
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();
                        connection.Close();
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Создание файла базы данных по заданному пути. 
        /// Файл не будет создан до первого обращения к БД. 
        /// </summary>
        /// <param name="p_DatabaseName">Путь к базе данных и ее имя</param>
        /// <returns>True если база данных создана. False если БД уже существует.</returns>
        public void CreateDatabase(string p_DatabaseName)
        {
            m_DatabaseName = p_DatabaseName;
            SQLiteConnection.CreateFile(p_DatabaseName);
        }

        public void CreateTables()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        // Создание таблицы "Каталоги"
                        command.CommandText = "CREATE TABLE IF NOT EXISTS catalogs (" +
                            "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                            "parent NVARCHAR(80), " +
                            "name NVARCHAR(80) NOT NULL);";
                        command.ExecuteNonQuery();

                        // Создание таблицы "Требования"
                        command.CommandText = "CREATE TABLE IF NOT EXISTS demand (" +
                            "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                            "inventoryId INTEGER, " +
                            "employeeId INTEGER, " +
                            "amount REAL NOT NULL, " +
                            "date DATETIME, " +
                            "document NVARCHAR(80), " +
                            "FOREIGN KEY(inventoryId) REFERENCES inventory(id) ON DELETE CASCADE, " +
                            "FOREIGN KEY(employeeId) REFERENCES employees(id) ON DELETE SET NULL);";
                        command.ExecuteNonQuery();

                        // Создание таблицы "Списания"
                        command.CommandText = "CREATE TABLE IF NOT EXISTS debit (" +
                            "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                            "inventoryId INTEGER, " +
                            "amount REAL NOT NULL, " +
                            "date DATETIME, " +
                            "document NVARCHAR(80), " +
                            "FOREIGN KEY (inventoryId) REFERENCES inventory(id) ON DELETE CASCADE);";
                        command.ExecuteNonQuery();

                        // Создание таблицы "ТМЦ"
                        command.CommandText = "CREATE TABLE IF NOT EXISTS inventory (" +
                            "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                            "catalogId INTEGER, " +
                            "providerId INTEGER, " +
                            "date DATETIME NOT NULL, " +
                            "invoice NVARCHAR(80), " +
                            "name NVARCHAR(45) NOT NULL, " +
                            "OKEIcode NVARCHAR(45), " +
                            "measurement NVARCHAR(20), " +
                            "amount REAL, " +
                            "price INTEGER, " +
                            "FOREIGN KEY (catalogId) REFERENCES catalogs(id) ON DELETE CASCADE, " +
                            "FOREIGN KEY (providerId) REFERENCES providers(id) ON DELETE SET NULL);";
                        command.ExecuteNonQuery();

                        // Создание таблицы "Работники"
                        command.CommandText = "CREATE TABLE IF NOT EXISTS employees (" +
                            "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                            "surename NVARCHAR(45) NOT NULL, " +
                            "firstname NVARCHAR(45) NOT NULL, " +
                            "lastname NVARCHAR(45) NOT NULL, " +
                            "post NVARCHAR(45), " +
                            "department NVARCHAR(45));";
                        command.ExecuteNonQuery();

                        // Создание таблицы "Поставщики"
                        command.CommandText = "CREATE TABLE IF NOT EXISTS providers (" +
                            "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                            "name NVARCHAR(45) NOT NULL, " +
                            "address NVARCHAR(50), " +
                            "phone NVARCHAR(20), " +
                            "mail NVARCHAR(45), " +
                            "document NVARCHAR(80));";
                        command.ExecuteNonQuery();

                        // Вставка корневого каталого 
                        command.CommandText = "INSERT INTO catalogs (parent, name) VALUES (null, 'Каталоги');";
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Выполнение команды SQL
        /// </summary>
        /// <param name="p_Command"></param>
        public void CommandExecuteNonQuery(string p_Command)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(p_Command, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public object CommandExecuteScalar(string p_Command)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(p_Command, connection))
                {
                    connection.Open();
                    object l_object = command.ExecuteScalar();
                    connection.Close();
                    return l_object;
                }
            }
        }

        public SQLiteDataReader CommandExecuteReader(string p_Command)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(p_Command, connection))
                {
                    connection.Open();
                    SQLiteDataReader reader = command.ExecuteReader();
                    connection.Close();
                    return reader;
                }
            }
        }

        public DataSet ReturnDataSet(string p_Command)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (DataSet dataSet = new DataSet())
                {
                    SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(p_Command, connection);
                    dataAdapter.Fill(dataSet);
                    return dataSet;
                }
            }
        }

        public bool Insert(string p_TableName, Dictionary<string, object> p_Data)
        {
            string columns = string.Empty;
            string values = string.Empty;
            foreach (KeyValuePair<string, object> pair in p_Data)
            {
                columns += $"{pair.Key},";
                values += $"@{pair.Key},";
            }
            columns = columns.Substring(0, columns.Length - 1);
            values = values.Substring(0, values.Length - 1);
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand($"INSERT INTO {p_TableName} ({columns}) VALUES ({values});", connection))
                {
                    connection.Open();

                    foreach (KeyValuePair<string, object> pair in p_Data)
                    {
                        command.Parameters.AddWithValue($"@{pair.Key}", pair.Value);
                    }

                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
            }
        }

        public bool Update(string p_TableName, Dictionary<string, object> p_Data, string p_Where)
        {
            string values = string.Empty;
            if (p_Data.Count >= 1)
            {
                foreach (KeyValuePair<string, object> pair in p_Data)
                {
                    values += $"{pair.Key} = :{pair.Key},";
                }
                // Удаляем лишнюю запятую
                values = values.Substring(0, values.Length - 1);

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand($"UPDATE {p_TableName} SET {values} WHERE {p_Where};", connection))
                    {
                        connection.Open();

                        foreach (KeyValuePair<string, object> pair in p_Data)
                        {
                            command.Parameters.AddWithValue(pair.Key, pair.Value);
                        }
                        
                        command.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Delete(string p_TableName, string p_Where)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand($"DELETE FROM {p_TableName} WHERE {p_Where};", connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
            }
        }

        public EmployeesSql Employees()
        {
            return EmployeesSql.GetInstance();
        }

        public ProvidersSql Providers()
        {
            return ProvidersSql.GetInstance();
        }

        public InventorySql Inventory()
        {
            return InventorySql.GetInstance();
        }

        public DemandSql Demand()
        {
            return DemandSql.GetInstance();
        }

        public DebitSql Debit()
        {
            return DebitSql.GetInstance();
        }
    }
}
