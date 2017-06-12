using System;
using System.IO;

namespace NeuroInventory
{
    public sealed class NeuroFile
    {
        private static readonly NeuroFile instance = new NeuroFile();

        public static NeuroFile GetInstance()
        {
            return instance;
        }

        public void OpenFileInExplorer(string p_SelectedDocument)
        {
            if (File.Exists(p_SelectedDocument))
            {
                System.Diagnostics.Process.Start("explorer.exe", "/select, \"" + p_SelectedDocument + "\"");
            }
        }

        public void OpenFile(string p_SelectedDocument)
        {
            if (File.Exists(p_SelectedDocument))
            {
                System.Diagnostics.Process.Start(p_SelectedDocument);
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
            if (!String.IsNullOrEmpty(p_SelectedDocument) && String.Compare(p_SelectedDocument, p_CurrentDocument) != 0)
                return true;
            return false;
        }

        public string CopyFile(string p_FileName, string p_TargetPath)
        {
            string fileName = Path.GetFileName(p_FileName);
            string sourceFile = p_FileName;
            string destFile = Path.Combine(p_TargetPath, fileName);
            if (!Directory.Exists(p_TargetPath))
            {
                Directory.CreateDirectory(p_TargetPath);
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

        public object UpdateFile(string p_SelectedDocument, string p_CurrentDocument, string p_TargetPath)
        {
            // Обновление выбранного файла-документа. 
            if (!String.IsNullOrEmpty(p_SelectedDocument))
            {
                if (IsDocumentUpdated(p_SelectedDocument, p_CurrentDocument)) // файл изменен
                {
                    // Удаляем старый файл
                    DeleteFile(p_CurrentDocument);
                    // Копируем новый файл
                    return CopyFile(p_SelectedDocument, p_TargetPath);
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

        public object InsertFile(string p_SelectedDocument, string p_TargetPath)
        {
            // Копирование выбранного файла-документа в целевую папку приложения
            if (!String.IsNullOrEmpty(p_SelectedDocument))
            {
                return CopyFile(p_SelectedDocument, p_TargetPath);
            }
            else
            {
                return DBNull.Value;
            }
        }
    }
}
