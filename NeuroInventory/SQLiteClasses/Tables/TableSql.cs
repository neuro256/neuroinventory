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
            try
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public virtual DataSet ReturnDataSet(string p_Command)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
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
            return NeuroFile.GetInstance().IsDocumentUpdated(p_SelectedDocument, p_CurrentDocument);
        }

        public string CopyFile(string p_FileName)
        {
            return NeuroFile.GetInstance().CopyFile(p_FileName, TargetPath);
        }

        public void DeleteFile(string p_FileName)
        {
            NeuroFile.GetInstance().DeleteFile(p_FileName);
        }

        public object UpdateFile(string p_SelectedDocument, string p_CurrentDocument)
        {
            return NeuroFile.GetInstance().UpdateFile(p_SelectedDocument, p_CurrentDocument, TargetPath);
        }

        public object InsertFile(string p_SelectedDocument)
        {
            return NeuroFile.GetInstance().InsertFile(p_SelectedDocument, TargetPath);
        }
    }
}
