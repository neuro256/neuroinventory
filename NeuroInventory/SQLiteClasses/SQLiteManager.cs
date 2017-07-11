using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuroInventory
{
    public class SQLiteSettingsManager : SQLiteManager
    {
        private static readonly SQLiteSettingsManager instance = new SQLiteSettingsManager();

        public static new SQLiteSettingsManager GetInstance()
        {
            return instance;
        }

        public MeasurementSql Measurement()
        {
            return MeasurementSql.GetInstance();
        }

        public UserSql User()
        {
            return UserSql.GetInstance();
        }

        public RecentsSql Recents()
        {
            return RecentsSql.GetInstance();
        }

        public override bool TestConnection()
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public override void CreateTables()
        {
            CreateTablesAsync().GetAwaiter();
        }

        public override async Task CreateTablesAsync()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.SetPassword("76cT8dbr");
                    await connection.OpenAsync();

                    using (SQLiteTransaction transaction = connection.BeginTransaction())
                    {
                        using (SQLiteCommand command = new SQLiteCommand(connection))
                        {
                            // Создание таблицы "Единицы измерения"
                            command.CommandText = "CREATE TABLE IF NOT EXISTS measurement (" +
                                "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                                "codeOKEI TEXT NOT NULL, " +
                                "name TEXT NOT NULL, " +
                                "symbol TEXT NOT NULL, " +
                                "decimalPlaces INTEGER NOT NULL);";
                            await command.ExecuteNonQueryAsync();

                            // Заполнение таблицы "Единицы измерения
                            command.CommandText = "INSERT INTO measurement (codeOKEI, name, symbol, decimalPlaces) VALUES ('003', 'Миллиметр', 'мм', 0);";
                            await command.ExecuteNonQueryAsync();
                            command.CommandText = "INSERT INTO measurement (codeOKEI, name, symbol, decimalPlaces) VALUES ('004', 'Сантиметр', 'см', 2);";
                            await command.ExecuteNonQueryAsync();
                            command.CommandText = "INSERT INTO measurement (codeOKEI, name, symbol, decimalPlaces) VALUES ('006', 'Метр', 'м', 2);";
                            await command.ExecuteNonQueryAsync();
                            command.CommandText = "INSERT INTO measurement (codeOKEI, name, symbol, decimalPlaces) VALUES ('050', 'Квадратный миллиметр', 'мм2', 0);";
                            await command.ExecuteNonQueryAsync();
                            command.CommandText = "INSERT INTO measurement (codeOKEI, name, symbol, decimalPlaces) VALUES ('051', 'Квадратный сантиметр', 'см2', 2);";
                            await command.ExecuteNonQueryAsync();
                            command.CommandText = "INSERT INTO measurement (codeOKEI, name, symbol, decimalPlaces) VALUES ('055', 'Квадратный метр', 'м2', 2);";
                            await command.ExecuteNonQueryAsync();
                            command.CommandText = "INSERT INTO measurement (codeOKEI, name, symbol, decimalPlaces) VALUES ('110', 'Кубический миллиметр', 'мм3', 0);";
                            await command.ExecuteNonQueryAsync();
                            command.CommandText = "INSERT INTO measurement (codeOKEI, name, symbol, decimalPlaces) VALUES ('111', 'Кубический сантиметр', 'см3', 2);";
                            await command.ExecuteNonQueryAsync();
                            command.CommandText = "INSERT INTO measurement (codeOKEI, name, symbol, decimalPlaces) VALUES ('112', 'Литр', 'л', 3);";
                            await command.ExecuteNonQueryAsync();
                            command.CommandText = "INSERT INTO measurement (codeOKEI, name, symbol, decimalPlaces) VALUES ('163', 'Грамм', 'г', 0);";
                            await command.ExecuteNonQueryAsync();
                            command.CommandText = "INSERT INTO measurement (codeOKEI, name, symbol, decimalPlaces) VALUES ('166', 'Килограмм', 'кг', 3);";
                            await command.ExecuteNonQueryAsync();
                            command.CommandText = "INSERT INTO measurement (codeOKEI, name, symbol, decimalPlaces) VALUES ('168', 'Тонна', 'т', 3);";
                            await command.ExecuteNonQueryAsync();
                            command.CommandText = "INSERT INTO measurement (codeOKEI, name, symbol, decimalPlaces) VALUES ('018', 'Погонный метр', 'пог.м', 2);";
                            await command.ExecuteNonQueryAsync();
                            command.CommandText = "INSERT INTO measurement (codeOKEI, name, symbol, decimalPlaces) VALUES ('643', 'Единица', 'ед', 0);";
                            await command.ExecuteNonQueryAsync();
                            command.CommandText = "INSERT INTO measurement (codeOKEI, name, symbol, decimalPlaces) VALUES ('778', 'Упаковка', 'упак', 0);";
                            await command.ExecuteNonQueryAsync();
                            command.CommandText = "INSERT INTO measurement (codeOKEI, name, symbol, decimalPlaces) VALUES ('796', 'Штука', 'шт', 0);";
                            await command.ExecuteNonQueryAsync();
                            command.CommandText = "INSERT INTO measurement (codeOKEI, name, symbol, decimalPlaces) VALUES ('625', 'Лист', 'л.', 0);";
                            await command.ExecuteNonQueryAsync();

                            // Создание таблицы "Пользователь"
                            command.CommandText = "CREATE TABLE IF NOT EXISTS user (" +
                                "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                                "login TEXT NOT NULL, " +
                                "password TEXT NOT NULL);";
                            await command.ExecuteNonQueryAsync();

                            // Вставка суперпользователя
                            command.CommandText = "INSERT INTO user (login, password) VALUES ('admin', 'admin');";
                            await command.ExecuteNonQueryAsync();

                            command.CommandText = "CREATE TABLE IF NOT EXISTS recents (" +
                                "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                                "path TEXT NOT NULL);";
                            await command.ExecuteNonQueryAsync();

                            transaction.Commit();
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public new int ReturnLastInsertId(string p_TableName)
        {
            return ReturnLastInsertIdAsync(p_TableName).GetAwaiter().GetResult();
        }

        public async Task<int> ReturnLastInsertIdAsync(string p_TableName)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand($"SELECT MAX(id) FROM {p_TableName};", connection))
                    {
                        await connection.OpenAsync();
                        object lastInsertId = await command.ExecuteScalarAsync();
                        connection.Close();
                        return Convert.ToInt32(lastInsertId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
    }

    public class SQLiteManager
    {
        /// <summary>
        /// Потокобезопасная реализация синглтона
        /// </summary>
        private static readonly SQLiteManager instance = new SQLiteManager();

        private string m_DatabaseName = null;
        private string m_Password = null;

        private bool m_IsCreated = false;
        private bool m_IsOpened = false;


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
                return $"DataSource={databaseName}; foreign keys=true; Version=3; Password={Password};";
            }
        }

        public string Password { get => m_Password; set => m_Password = value; }
        public bool IsCreated { get => m_IsCreated; set => m_IsCreated = value; }
        public bool IsOpened { get => m_IsOpened; set => m_IsOpened = value; }

        public static SQLiteManager GetInstance()
        {
            return instance;
        }

        #endregion

        /// <summary>
        /// Проверка пути и мени базы данных на пустоту
        /// </summary>
        /// <returns>True если имя непустое, иначе False</returns>
        protected bool DatabaseNameExist()
        {
            return !String.IsNullOrEmpty(databaseName);
        }

        /// <summary>
        /// Проверка соединения с базой данных
        /// </summary>
        /// <returns>True если есть соединение, иначе False</returns>
        public virtual bool TestConnection()
        {
            try
            {
                bool connectionSuccess = true;

                if (!String.IsNullOrEmpty(connectionString) && DatabaseNameExist())
                {
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();

                        object catalogTable = CommandExecuteScalar("SELECT name FROM sqlite_master WHERE type='table' AND name='catalogs'");
                        if (catalogTable == null)
                        {
                            connectionSuccess = false;
                        }

                        object inventoryTable = CommandExecuteScalar("SELECT name FROM sqlite_master WHERE type='table' AND name='inventory'");
                        if (inventoryTable == null)
                        {
                            connectionSuccess = false;
                        }

                        object demandTable = CommandExecuteScalar("SELECT name FROM sqlite_master WHERE type='table' AND name='demand'");
                        if (demandTable == null)
                        {
                            connectionSuccess = false;
                        }

                        object demandReportTable = CommandExecuteScalar("SELECT name FROM sqlite_master WHERE type='table' AND name='demandReport'");
                        if (demandReportTable == null)
                        {
                            connectionSuccess = false;
                        }

                        object debitTable = CommandExecuteScalar("SELECT name FROM sqlite_master WHERE type='table' AND name='debit'");
                        if (debitTable == null)
                        {
                            connectionSuccess = false;
                        }

                        object debitReportTable = CommandExecuteScalar("SELECT name FROM sqlite_master WHERE type='table' AND name='debitReport'");
                        if (debitReportTable == null)
                        {
                            connectionSuccess = false;
                        }

                        object employeesTable = CommandExecuteScalar("SELECT name FROM sqlite_master WHERE type='table' AND name='employees'");
                        if (employeesTable == null)
                        {
                            connectionSuccess = false;
                        }

                        object providersTable = CommandExecuteScalar("SELECT name FROM sqlite_master WHERE type='table' AND name='providers'");
                        if (providersTable == null)
                        {
                            connectionSuccess = false;
                        }

                        connection.Close();
                    }
                    return connectionSuccess;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
            try
            {
                m_DatabaseName = p_DatabaseName;
                SQLiteConnection.CreateFile(p_DatabaseName);
                IsCreated = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public virtual void CreateTables()
        {
            CreateTablesAsync().GetAwaiter();
        }

        public virtual async Task CreateTablesAsync()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SQLiteTransaction transaction = connection.BeginTransaction())
                    {
                        using (SQLiteCommand command = new SQLiteCommand(connection))
                        {
                            // Создание таблицы "Каталоги"
                            command.CommandText = "CREATE TABLE IF NOT EXISTS catalogs (" +
                                "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                                "type INTEGER NOT NULL, " +
                                "parent INTEGER, " +
                                "name NVARCHAR(80) NOT NULL);";
                            await command.ExecuteNonQueryAsync();

                            // Создание таблицы "Требования"
                            command.CommandText = "CREATE TABLE IF NOT EXISTS demand (" +
                                "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                                "inventoryId INTEGER, " +
                                "employeeId INTEGER, " +
                                "reportId INTEGER, " +
                                "amount REAL NOT NULL, " +
                                "date DATETIME, " +
                                "FOREIGN KEY(reportId) REFERENCES demandReport(id) ON DELETE SET NULL, " +
                                "FOREIGN KEY(inventoryId) REFERENCES inventory(id) ON DELETE CASCADE, " +
                                "FOREIGN KEY(employeeId) REFERENCES employees(id) ON DELETE SET NULL);";
                            await command.ExecuteNonQueryAsync();

                            // Создание таблицы "Отчет требование"
                            command.CommandText = "CREATE TABLE IF NOT EXISTS demandReport (" +
                                "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                                "employeeId INTEGER, " +
                                "date DATETIME, " +
                                "document NVARCHAR(80), " +
                                "FOREIGN KEY(employeeId) REFERENCES employees(id) ON DELETE SET NULL);";
                            await command.ExecuteNonQueryAsync();

                            // Создание таблицы "Списания"
                            command.CommandText = "CREATE TABLE IF NOT EXISTS debit (" +
                                "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                                "inventoryId INTEGER, " +
                                "amount REAL NOT NULL, " +
                                "date DATETIME, " +
                                "FOREIGN KEY (inventoryId) REFERENCES inventory(id) ON DELETE CASCADE);";
                            await command.ExecuteNonQueryAsync();

                            // Создание таблицы "Отчет списания"
                            command.CommandText = "CREATE TABLE IF NOT EXISTS debitReport (" +
                                "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                                "date DATETIME, " +
                                "document NVARCHAR(80));";
                            await command.ExecuteNonQueryAsync();

                            // Создание таблицы "ТМЦ"
                            command.CommandText = "CREATE TABLE IF NOT EXISTS inventory (" +
                                "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                                "catalogId INTEGER, " +
                                "providerId INTEGER, " +
                                "date DATETIME NOT NULL, " +
                                "invoice NVARCHAR(80), " +
                                "invoiceCode INTEGER DEFAULT 0, " +
                                "name NVARCHAR(45) NOT NULL, " +
                                "OKEIcode NVARCHAR(5), " +
                                "measurement NVARCHAR(20), " +
                                "amount REAL, " +
                                "price INTEGER, " +
                                "FOREIGN KEY (catalogId) REFERENCES catalogs(id) ON DELETE CASCADE, " +
                                "FOREIGN KEY (providerId) REFERENCES providers(id) ON DELETE SET NULL);";
                            await command.ExecuteNonQueryAsync();

                            // Создание таблицы "Работники"
                            command.CommandText = "CREATE TABLE IF NOT EXISTS employees (" +
                                "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                                "surename NVARCHAR(45) NOT NULL, " +
                                "firstname NVARCHAR(45) NOT NULL, " +
                                "lastname NVARCHAR(45) NOT NULL, " +
                                "post NVARCHAR(45), " +
                                "department NVARCHAR(45));";
                            await command.ExecuteNonQueryAsync();

                            // Создание таблицы "Поставщики"
                            command.CommandText = "CREATE TABLE IF NOT EXISTS providers (" +
                                "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                                "name NVARCHAR(45) NOT NULL, " +
                                "address NVARCHAR(50), " +
                                "phone NVARCHAR(20), " +
                                "mail NVARCHAR(45), " +
                                "document NVARCHAR(80));";
                            await command.ExecuteNonQueryAsync();

                            // Создание таблицы "Накладная"
                            //command.CommandText = "CREATE TABLE IF NOT EXISTS invoices (" +
                            //    "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                            //    "reference NVARCHAR(80) NOT NULL, " +
                            //    "code INTEGER, " +
                            //    "date DATETIME);";

                            // Вставка корневого каталого 
                            command.CommandText = $"INSERT INTO catalogs (type, parent, name) VALUES (0, null, '{Definitions.DB_ROOT_CATALOG}');";
                            await command.ExecuteNonQueryAsync();

                            // Создание индекса
                            command.CommandText = "CREATE INDEX InventoryIdIndex ON Debit (inventoryId);";
                            await command.ExecuteNonQueryAsync();

                            transaction.Commit();
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateDatabase()
        {
            if (!CheckIfColumnExists("inventory", "invoiceCode"))
            {
                AlterTableAddColumn("inventory", "invoiceCode", "INTEGER DEFAULT 0");
            }
        }

        public void AlterTableAddColumn(string p_TableName, string p_ColumnName, string p_Params)
        {
            AlterTableAddColumnAsync(p_TableName, p_ColumnName, p_Params).GetAwaiter();
        }

        private async Task AlterTableAddColumnAsync(string p_TableName, string p_ColumnName, string p_Params)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = $"ALTER TABLE {p_TableName} ADD COLUMN {p_ColumnName} {p_Params};";
                        await command.ExecuteNonQueryAsync();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool CheckIfColumnExists(string p_TableName, string p_ColumnName)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        // Создание таблицы "Каталоги"
                        command.CommandText = $"PRAGMA table_info({p_TableName})";

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            int nameIndex = reader.GetOrdinal("Name");
                            while (reader.Read())
                            {
                                if (reader.GetString(nameIndex).Equals(p_ColumnName))
                                {
                                    connection.Close();
                                    return true;
                                }
                            }
                        }
                    }

                    connection.Close();
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void CommandExecuteNonQuery(string p_Command)
        {
            CommandExecuteNonQueryAsync(p_Command).GetAwaiter();
        }

        /// <summary>
        /// Выполнение команды SQL
        /// </summary>
        /// <param name="p_Command"></param>
        private async Task CommandExecuteNonQueryAsync(string p_Command)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(p_Command, connection))
                    {
                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public object CommandExecuteScalar(string p_Command)
        {
            return CommandExecuteScalarAsync(p_Command).GetAwaiter().GetResult();
        }

        private async Task<object> CommandExecuteScalarAsync(string p_Command)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(p_Command, connection))
                    {
                        await connection.OpenAsync();
                        object l_object = await command.ExecuteScalarAsync();
                        connection.Close();
                        return l_object;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public SQLiteDataReader CommandExecuteReader(string p_Command)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public DataSet ReturnDataSet(string p_Command)
        {
            return ReturnDataSetAsync(p_Command).GetAwaiter().GetResult();
        }

        private async Task<DataSet> ReturnDataSetAsync(string p_Command)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (DataSet dataSet = new DataSet())
                    {
                        await connection.OpenAsync();
                        SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(p_Command, connection);
                        dataAdapter.Fill(dataSet);
                        connection.Close();
                        return dataSet;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public bool Insert(string p_TableName, Dictionary<string, object> p_Data)
        {
            return InsertAsync(p_TableName, p_Data).GetAwaiter().GetResult();
        }

        private async Task<bool> InsertAsync(string p_TableName, Dictionary<string, object> p_Data)
        {
            try
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
                        await connection.OpenAsync();

                        foreach (KeyValuePair<string, object> pair in p_Data)
                        {
                            command.Parameters.AddWithValue($"@{pair.Key}", pair.Value);
                        }

                        await command.ExecuteNonQueryAsync();
                        connection.Close();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public int ReturnLastInsertId(string p_TableName)
        {
            return ReturnLastInsertIdAsync(p_TableName).GetAwaiter().GetResult();
        }

        private async Task<int> ReturnLastInsertIdAsync(string p_TableName)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand($"SELECT MAX(id) FROM {p_TableName};", connection))
                    {
                        await connection.OpenAsync();
                        object lastInsertId = await command.ExecuteScalarAsync();
                        connection.Close();
                        return Convert.ToInt32(lastInsertId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public int ReturnRecordsCount(string p_TableName)
        {
            return ReturnRecordsCountAsync(p_TableName).GetAwaiter().GetResult();
        }

        private async Task<int> ReturnRecordsCountAsync(string p_TableName)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand($"SELECT COUNT(*) FROM {p_TableName};", connection))
                    {
                        await connection.OpenAsync();
                        object lastInsertId = await command.ExecuteScalarAsync();
                        connection.Close();
                        return Convert.ToInt32(lastInsertId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public bool Update(string p_TableName, Dictionary<string, object> p_Data, string p_Where)
        {
            return UpdateAsync(p_TableName, p_Data, p_Where).GetAwaiter().GetResult();
        }

        private async Task<bool> UpdateAsync(string p_TableName, Dictionary<string, object> p_Data, string p_Where)
        {
            try
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
                            await connection.OpenAsync();

                            foreach (KeyValuePair<string, object> pair in p_Data)
                            {
                                command.Parameters.AddWithValue(pair.Key, pair.Value);
                            }

                            await command.ExecuteNonQueryAsync();
                            connection.Close();
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool Delete(string p_TableName, string p_Where)
        {
            return DeleteAsync(p_TableName, p_Where).GetAwaiter().GetResult();
        }

        private async Task<bool> DeleteAsync(string p_TableName, string p_Where)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand($"DELETE FROM {p_TableName} WHERE {p_Where};", connection))
                    {
                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();
                        connection.Close();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
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

        public CatalogsSql Catalogs()
        {
            return CatalogsSql.GetInstance();
        }

        public DemandReportSql DemandReport()
        {
            return DemandReportSql.GetInstance();
        }

        public DebitReportSql DebitReport()
        {
            return DebitReportSql.GetInstance();
        }

        public ReleasedSql Released()
        {
            return ReleasedSql.GetInstance();
        }
    }
}
