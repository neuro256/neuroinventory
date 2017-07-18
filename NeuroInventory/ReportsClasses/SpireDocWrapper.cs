using Spire.Doc;
using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;

namespace NeuroInventory
{
    public class SpireDocWrapper : IReportWrapper
    {
        private string m_TemplateSourcePath = @"Templates\templateDemand.doc";
        private string m_DestinationPath;
        private DataSet m_DataSet;
        private Dictionary<string, object> m_AdditionalData;

        public SpireDocWrapper(ReportData p_ReportData)
        {
            m_DestinationPath = p_ReportData.DestinationPath;
            m_DataSet = p_ReportData.DemandDataSet;
            m_AdditionalData = p_ReportData.AdditionalData;
        }

        public bool CreateReport()
        {
            try
            {
                Document document = new Document();
                document.LoadFromFile(m_TemplateSourcePath, FileFormat.Doc);

                string[] fieldNames = new string[m_AdditionalData.Count];
                string[] fieldValues = new string[m_AdditionalData.Count];
                int counter = 0;

                foreach (KeyValuePair<string, object> pair in m_AdditionalData)
                {
                    fieldNames[counter] = pair.Key;
                    fieldValues[counter] = pair.Value.ToString();
                    counter++;
                }

                List<DictionaryEntry> list = new List<DictionaryEntry>
                {
                    new DictionaryEntry("DemandReport", String.Empty)
                };

                document.MailMerge.ClearFields = true;

                document.MailMerge.ExecuteWidthNestedRegion(m_DataSet, list);

                document.MailMerge.Execute(fieldNames, fieldValues);

                document.SaveToFile(m_DestinationPath, FileFormat.Doc);
                DocumentViewer(m_DestinationPath);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return false;
            }
        }

        public void DocumentViewer(string p_FileName)
        {
            try
            {
                NeuroFile.OpenFile(p_FileName);
            }
            catch { }
        }
    }
}
