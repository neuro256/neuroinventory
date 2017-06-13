using Spire.Doc;
using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;

namespace NeuroInventory
{
    public class SpireDocWrapper
    {
        private string m_TemplateSourcePath = @"templateDemand.doc";

        public bool CreateReport(string p_DestinationPath, DataSet p_DataSetDemandReport, Dictionary<string, string> p_FieldsData)
        {
            try
            {
                Document document = new Document();
                document.LoadFromFile(m_TemplateSourcePath, FileFormat.Doc);

                string[] fieldNames = new string[p_FieldsData.Count];
                string[] fieldValues = new string[p_FieldsData.Count];
                int counter = 0;

                foreach (KeyValuePair<string, string> pair in p_FieldsData)
                {
                    fieldNames[counter] = pair.Key;
                    fieldValues[counter] = pair.Value;
                    counter++;
                }

                List<DictionaryEntry> list = new List<DictionaryEntry>
                {
                    new DictionaryEntry("DemandReport", String.Empty)
                };

                document.MailMerge.ClearFields = true;

                document.MailMerge.ExecuteWidthNestedRegion(p_DataSetDemandReport, list);

                document.MailMerge.Execute(fieldNames, fieldValues);

                document.SaveToFile(p_DestinationPath, FileFormat.Doc);
                WordDocViewer(p_DestinationPath);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return false;
            }
        }

        private void WordDocViewer(string p_FileName)
        {
            try
            {
                NeuroFile.GetInstance().OpenFile(p_FileName);
            }
            catch { }
        }
    }
}
