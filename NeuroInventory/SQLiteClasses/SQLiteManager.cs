using System;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuroInventory
{
    public sealed class SQLiteManager : SQLManagerBase<SQLiteManager>
    {
        private static EmployeesSql m_EmployeeSql = null;
        private static ProvidersSql m_ProviderSql = null;
        private static InventorySql m_InventorySql = null;
        private static DemandSql m_DemandSql = null;
        private static DebitSql m_DebitSql = null;
        private static CatalogsSql m_CatalogSql = null;
        private static DemandReportSql m_DemandReportSql = null;
        private static DebitReportSql m_DebitReportSql = null;
        private static ReleasedSql m_ReleasedSql = null;

        /// <summary>
        /// Проверка соединения с базой данных
        /// </summary>
        /// <returns>True если есть соединение, иначе False</returns>
        public override bool TestConnection()
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

        public override void CreateTables()
        {
            CreateTablesAsync().GetAwaiter();
        }

        private async Task CreateTablesAsync()
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
                                "demandId INTEGER, " + 
                                "amount REAL NOT NULL, " +
                                "date DATETIME, " +
                                "FOREIGN KEY (demandId) REFERENCES demand(id) ON DELETE CASCADE, " +
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
                                "invoiceCode NVARCHAR(30), " +
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
                                "inn NVARCHAR(12), " +  
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
            //if (!CheckIfColumnExists("inventory", "invoiceCode"))
            //{
            //   AlterTableAddColumn("inventory", "invoiceCode", "INTEGER DEFAULT 0");
            //}
            if(!CheckIfColumnExists("inventory", "invoiceCodeStr"))
            {
                AlterTableAddColumn("inventory", "invoiceCodeStr", "NVARCHAR(30)");
                CopyColumn("inventory", "invoiceCode", "invoiceCodeStr");
            }
            if(!CheckIfColumnExists("debit", "demandId"))
            {
                AlterTableAddColumn("debit", "demandId", "INTEGER");
            }
            if(!CheckIfColumnExists("providers", "inn"))
            {
                AlterTableAddColumn("providers", "inn", "NVARCHAR(12)");
            }
        }

        public EmployeesSql Employees()
        {
            if (m_EmployeeSql == null)
                m_EmployeeSql = new EmployeesSql();
            return m_EmployeeSql;
        }

        public ProvidersSql Providers()
        {
            if (m_ProviderSql == null)
                m_ProviderSql = new ProvidersSql();
            return m_ProviderSql;
        }

        public InventorySql Inventory()
        {
            if (m_InventorySql == null)
                m_InventorySql = new InventorySql();
            return m_InventorySql;
        }

        public DemandSql Demand()
        {
            if (m_DemandSql == null)
                m_DemandSql = new DemandSql();
            return m_DemandSql;
        }

        public DebitSql Debit()
        {
            if (m_DebitSql == null)
                m_DebitSql = new DebitSql();
            return m_DebitSql;
        }

        public CatalogsSql Catalogs()
        {
            if (m_CatalogSql == null)
                m_CatalogSql = new CatalogsSql();
            return m_CatalogSql;
        }

        public DemandReportSql DemandReport()
        {
            if (m_DemandReportSql == null)
                m_DemandReportSql = new DemandReportSql();
            return m_DemandReportSql;
        }

        public DebitReportSql DebitReport()
        {
            if (m_DebitReportSql == null)
                m_DebitReportSql = new DebitReportSql();
            return m_DebitReportSql;
        }

        public ReleasedSql Released()
        {
            if (m_ReleasedSql == null)
                m_ReleasedSql = new ReleasedSql();
            return m_ReleasedSql;
        }
    }
}
