using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace NeuroInventory
{
    public class SpireXlsWrapper : ISpireReportWrapper
    {
        private string m_TemplateSourcePath = @"templateDebit.xls";

        public string TemplateSourcePath { get => m_TemplateSourcePath; set => m_TemplateSourcePath = value; }

        public bool CreateReport(string p_DestinationPath, DataSet p_DataSet, Dictionary<string, object> p_AdditionalData)
        {
            try
            {
                Workbook book = new Workbook();
                book.LoadFromFile(TemplateSourcePath);

                Worksheet sheet = book.Worksheets[0];

                DataTable dataTable = p_DataSet.Tables[0];

                // fill DataTable
                book.MarkerDesigner.AddDataTable("DebitReport", dataTable);
                // fill parameter
                foreach(KeyValuePair<string, object> param in p_AdditionalData)
                {
                    book.MarkerDesigner.AddParameter(param.Key, param.Value);
                }

                // AutoFit
                sheet.AllocatedRange.AutoFitRows();
                sheet.AllocatedRange.AutoFitColumns();

                // save to file
                book.SaveToFile(p_DestinationPath);
                DocumentViewer(p_DestinationPath);

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

                return false;
            }
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
