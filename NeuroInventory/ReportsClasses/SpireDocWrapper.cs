using Spire.Doc;
using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;

namespace NeuroInventory
{
    public class SpireDocWrapper : ISpireReportWrapper
    {
        private string m_TemplateSourcePath = @"Templates\templateDemand.doc";

        public bool CreateReport(string p_DestinationPath, DataSet p_DataSet, Dictionary<string, object> p_AdditionalData)
        {
            try
            {
                Document document = new Document();
                document.LoadFromFile(m_TemplateSourcePath, FileFormat.Doc);

                string[] fieldNames = new string[p_AdditionalData.Count];
                string[] fieldValues = new string[p_AdditionalData.Count];
                int counter = 0;

                foreach (KeyValuePair<string, object> pair in p_AdditionalData)
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

                document.MailMerge.ExecuteWidthNestedRegion(p_DataSet, list);

                document.MailMerge.Execute(fieldNames, fieldValues);

                document.SaveToFile(p_DestinationPath, FileFormat.Doc);
                DocumentViewer(p_DestinationPath);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return false;
            }
        }

        public bool CreateReport(string p_DestinationPath, DataSet p_DataSet, DataSet p_SecondDataSet, Dictionary<string, object> p_AdditionalData)
        {
            throw new NotImplementedException();
        }

        public void DocumentViewer(string p_FileName)
        {
            try
            {
                NeuroFile.GetInstance().OpenFile(p_FileName);
            }
            catch { }
        }
    }
}
