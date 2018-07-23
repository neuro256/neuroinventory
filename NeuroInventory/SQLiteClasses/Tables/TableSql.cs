using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace NeuroInventory
{
    //Абстрактный класс для работы с таблицами 
    //Для каждой таблицы SQL создается отдельный класс-наследник
    public abstract class TableSql
    {
        private string m_CommandDataSet; //Команда для создания набора
        protected string m_ConnectionStr;//Строка для подключения 
        private string m_TableName; //Название таблицы
        private string m_PrimaryKey; // Первичный ключ таблицы 
        private string m_TargetPath; // Путь к сохраняемым файлам

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
        protected string PrimaryKey { get => m_PrimaryKey; set => m_PrimaryKey = value; }
        public string TargetPath { get => m_TargetPath; set => m_TargetPath = value; }

        public void SetTargetPath(string p_Path)
        {
            TargetPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), GetApplicationName, Path.GetFileNameWithoutExtension(SQLiteManager.GetInstance().databaseName), p_Path);
        }

        public string GetTargetPath(string p_Path)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), GetApplicationName, Path.GetFileNameWithoutExtension(SQLiteManager.GetInstance().databaseName), p_Path);
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
                                // Set primary key
                                dataSet.Tables[0].Columns[PrimaryKey].Unique = true;
                                dataSet.Tables[0].PrimaryKey = new DataColumn[] { dataSet.Tables[0].Columns[PrimaryKey] };
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
                                // Set primary key
                                dataSet.Tables[0].Columns[PrimaryKey].Unique = true;
                                dataSet.Tables[0].PrimaryKey = new DataColumn[] { dataSet.Tables[0].Columns[PrimaryKey] };
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

        public int ReturnLastInsertId()
        {
            return SQLiteManager.GetInstance().ReturnLastInsertId(TableName);
        }

        public int ReturnRecordsCount()
        {
            return SQLiteManager.GetInstance().ReturnRecordsCount(TableName);
        }

        /// <summary>
        /// Проверка на то, был ли изменен файл-документа в окне редактора
        /// </summary>
        /// <param name="p_SelectedDocument"></param>
        /// <param name="p_CurrentDocument"></param>
        /// <returns></returns>
        public bool IsDocumentUpdated(string p_SelectedDocument, string p_CurrentDocument)
        {
            return NeuroFile.IsDocumentUpdated(p_SelectedDocument, p_CurrentDocument);
        }

        public string CopyFile(string p_FileName)
        {
            return NeuroFile.CopyFile(p_FileName, TargetPath);
        }

        public void DeleteFile(string p_FileName)
        {
            NeuroFile.DeleteFile(p_FileName);
        }

        public object UpdateFile(string p_SelectedDocument, string p_CurrentDocument)
        {
            return NeuroFile.UpdateFile(p_SelectedDocument, p_CurrentDocument, TargetPath);
        }

        public object InsertFile(string p_SelectedDocument)
        {
            return NeuroFile.InsertFile(p_SelectedDocument, TargetPath);
        }

        public object CreateFileName(string p_FilenamePrefix, string p_FilenameBody, string p_FileExt)
        {
            return NeuroFile.CreateFileName(p_FilenamePrefix, p_FilenameBody, p_FileExt, TargetPath);
        }

        public object GetFileName(string p_Fullname)
        {
            return NeuroFile.GetFileName(p_Fullname);
        }

        public string MoveFile(string p_SourcePath, string p_TargetPath)
        {
            return NeuroFile.MoveFile(p_SourcePath, p_TargetPath);
        }

        private string GetApplicationName
        {
            get
            {
                return "Учет ТМЦ";
            }
        }
    }
}
