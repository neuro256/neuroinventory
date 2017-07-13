using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuroInventory
{
    public abstract class SQLManagerBase<T> where T : new ()
    {
        private static T instance;

        public static T GetInstance()
        {
            if(instance == null)
            {
                instance = new T();
            }
            return instance;
        }

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

        protected bool CheckIfColumnExists(string p_TableName, string p_ColumnName)
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

        /// <summary>
        /// Проверка соединения с базой данных
        /// </summary>
        /// <returns>True если есть соединение, иначе False</returns>
        public abstract bool TestConnection();
        public abstract void CreateTables();
    }
}
