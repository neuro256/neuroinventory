using System;
using System.IO;
using System.Windows.Forms;

namespace NeuroInventory
{
    public static class NeuroFile
    {
        public static void OpenFileInExplorer(string p_SelectedDocument)
        {
            try
            {
                if (File.Exists(p_SelectedDocument))
                {
                    System.Diagnostics.Process.Start("explorer.exe", "/select, \"" + p_SelectedDocument + "\"");
                }
            }
            catch { }
        }

        public static void OpenFile(string p_SelectedDocument)
        {
            try
            {
                if (File.Exists(p_SelectedDocument))
                {
                    System.Diagnostics.Process.Start(p_SelectedDocument);
                }
            }
            catch { }
        }

        /// <summary>
        /// Проверка на то, был ли изменен файл-документа в окне редактора
        /// </summary>
        /// <param name="p_SelectedDocument"></param>
        /// <param name="p_CurrentDocument"></param>
        /// <returns></returns>
        public static bool IsDocumentUpdated(string p_SelectedDocument, string p_CurrentDocument)
        {
            if (!String.IsNullOrEmpty(p_SelectedDocument) && String.Compare(p_SelectedDocument, p_CurrentDocument) != 0)
                return true;
            return false;
        }

        public static string CopyFile(string p_FileName, string p_TargetPath)
        {
            try
            {
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(p_FileName);
                string fileExt = Path.GetExtension(p_FileName);
                string sourceFile = p_FileName;
                string destFile = Path.Combine(p_TargetPath, $"{fileNameWithoutExt}{fileExt}");
                if (!Directory.Exists(p_TargetPath))
                {
                    Directory.CreateDirectory(p_TargetPath);
                }
                File.Copy(sourceFile, destFile, true);
                return destFile;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return String.Empty;
            }
        }

        private static string ComposeAndCreateFileName(string p_FilenamePrefix, string p_FilenameBody, string p_FileExt, string p_TargetPath)
        {
            try
            {
                string destFile = Path.Combine(p_TargetPath, $"{p_FilenamePrefix}_{p_FilenameBody}_{DateTime.Now.ToFileTime()}{p_FileExt}");
                if (!Directory.Exists(p_TargetPath))
                {
                    Directory.CreateDirectory(p_TargetPath);
                }
                //File.Create(destFile); // Не зря же метод переименвоан в CreateFileName
                return destFile;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return String.Empty;
            }
        }

        public static string CopyDataBase(string p_FileName, string p_TargetPath)
        {
            try
            {
                File.Copy(p_FileName, p_TargetPath, true);
                return p_TargetPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return String.Empty;
            }
        }

        public static void DeleteFile(string p_FileName)
        {
            try
            {
                if (File.Exists(p_FileName))
                {
                    File.Delete(p_FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static object UpdateFile(string p_SelectedDocument, string p_CurrentDocument, string p_TargetPath)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return DBNull.Value;
            }
        }

        public static object GetFileName(string p_Fullname)
        {
            return Path.GetFileName(p_Fullname);
        }

        public static object InsertFile(string p_SelectedDocument, string p_TargetPath)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return DBNull.Value;
            }
        }

        public static object CreateFileName(string p_FilenamePrefix, string p_FilenameBody, string p_FileExt, string p_TargetPath)
        {
            try
            {
                // Копирование выбранного файла-документа в целевую папку приложения
                if (p_FilenamePrefix != null)
                {
                    return ComposeAndCreateFileName(p_FilenamePrefix, p_FilenameBody, p_FileExt, p_TargetPath);
                }
                else
                {
                    return DBNull.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return DBNull.Value;
            }
        }

        public static string MoveFile(string p_SourcePath, string p_TargetPath)
        {
            try
            {
                if (!File.Exists(p_SourcePath))
                    return String.Empty;

                string sourcePathWithoitFileName = Path.GetDirectoryName(p_SourcePath);
                // Перемещать файл только если изменился целевой путь
                if (IsDocumentUpdated(sourcePathWithoitFileName, p_TargetPath))
                {
                    string destFile = CopyFile(p_SourcePath, p_TargetPath);
                    File.Delete(p_SourcePath);
                    return destFile;
                }
                else
                {
                    return String.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return String.Empty;
            }
        }
    }
}
