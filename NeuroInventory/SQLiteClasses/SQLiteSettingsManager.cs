using System;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuroInventory
{
    public sealed class SQLiteSettingsManager : SQLManagerBase<SQLiteSettingsManager>
    {
        private static MeasurementSql m_MeasurementSql = null;
        private static UserSql m_UserSql = null;
        private static RecentsSql m_RecentsSql = null;

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

        private async Task CreateTablesAsync()
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

        public MeasurementSql Measurement()
        {
            if (m_MeasurementSql == null)
                m_MeasurementSql = new MeasurementSql();
            return m_MeasurementSql;
        }

        public UserSql User()
        {
            if (m_UserSql == null)
                m_UserSql = new UserSql();
            return m_UserSql;
        }

        public RecentsSql Recents()
        {
            if (m_RecentsSql == null)
                m_RecentsSql = new RecentsSql();
            return m_RecentsSql;
        }
    }
}
