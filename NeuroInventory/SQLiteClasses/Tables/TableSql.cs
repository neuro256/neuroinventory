using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace NeuroInventory
{
    //Абстрактный класс для работы с таблицами 
    //Для каждой таблицы SQL создается отдельный класс-наследник
    public abstract class TableSql<T> where T : new()
    {
        private static T instance;
        private string m_CommandDataSet; //Команда для создания набора
        protected string m_ConnectionStr;//Строка для подключения 
        private string m_TableName; //Название таблицы
        private string m_TargetPath; // Путь к сохраняемым файлам

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
                m_ConnectionStr = SQLiteManager.GetInstance().connectionString;
                return m_ConnectionStr;
            }
        }

        protected string CommandDataSet { get => m_CommandDataSet; set => m_CommandDataSet = value; }
        protected string TableName { get => m_TableName; set => m_TableName = value; }
        public string TargetPath { get => m_TargetPath; set => m_TargetPath = value; }

        public void SetTargetPath(string p_Path)
        {
            TargetPath = Path.Combine(Path.GetDirectoryName(SQLiteManager.GetInstance().databaseName), Path.GetFileNameWithoutExtension(SQLiteManager.GetInstance().databaseName), p_Path);
        }

        /// <summary>
        /// Метод возвращает dataSet таблицы 
        /// </summary>
        /// <returns></returns>
        public virtual DataSet ReturnDataSet()
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

        public virtual DataSet ReturnDataSet(string p_Command)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteDataAdapter myAdapter = new SQLiteDataAdapter(p_Command, connection))
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

        /// <summary>
        /// Проверка на то, был ли изменен файл-документа в окне редактора
        /// </summary>
        /// <param name="p_SelectedDocument"></param>
        /// <param name="p_CurrentDocument"></param>
        /// <returns></returns>
        public bool IsDocumentUpdated(string p_SelectedDocument, string p_CurrentDocument)
        {
            bool documentUpdated = false;
            if (!String.IsNullOrEmpty(p_SelectedDocument) && String.Compare(p_SelectedDocument, p_CurrentDocument) != 0)
                documentUpdated = true;
            return documentUpdated;
        }

        public string CopyFile(string p_FileName)
        {
            string fileName = Path.GetFileName(p_FileName);
            string sourceFile = p_FileName;
            string destFile = Path.Combine(TargetPath, fileName);
            if (!Directory.Exists(TargetPath))
            {
                Directory.CreateDirectory(TargetPath);
            }
            File.Copy(sourceFile, destFile, true);
            return destFile;
        }

        public void DeleteFile(string p_FileName)
        {
            if (File.Exists(p_FileName))
            {
                File.Delete(p_FileName);
            }
        }

        public object UpdateFile(string p_SelectedDocument, string p_CurrentDocument)
        {
            // Обновление выбранного файла-документа. 
            if (!String.IsNullOrEmpty(p_SelectedDocument))
            {
                if (IsDocumentUpdated(p_SelectedDocument, p_CurrentDocument)) // файл изменен
                {
                    // Удаляем старый файл
                    DeleteFile(p_CurrentDocument);
                    // Копируем новый файл
                    return CopyFile(p_SelectedDocument);
                }
                else
                {
                    return p_CurrentDocument;
                }
            }
            else
            {
                // Удаляем старый файл
                DeleteFile(p_CurrentDocument);
                return DBNull.Value;
            }
        }

        public object InsertFile(string p_SelectedDocument)
        {
            // Копирование выбранного файла-документа в целевую папку приложения
            if (!String.IsNullOrEmpty(p_SelectedDocument))
            {
                return CopyFile(p_SelectedDocument);
            }
            else
            {
                return DBNull.Value;
            }
        }
    }
}
