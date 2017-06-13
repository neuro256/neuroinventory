using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace NeuroInventory
{
    public class SpireXlsWrapper
    {
        private string m_TemplateSourcePath = @"templateDebit.xls";

        public string TemplateSourcePath { get => m_TemplateSourcePath; set => m_TemplateSourcePath = value; }

        public bool CreateReport(string p_DestinationPath, DataSet p_DataSetDebitReport, Dictionary<string, string> p_FieldsData)
        {
            try
            {
                Workbook book = new Workbook();
                book.LoadFromFile(TemplateSourcePath);

                Worksheet sheet = book.Worksheets[0];

                DataTable dataTable = (DataTable)p_DataSetDebitReport.Tables[0];

                // fill DataTable
                book.MarkerDesigner.AddDataTable("DebitReport", dataTable);
                // fill parameter
                foreach(KeyValuePair<string, string> param in p_FieldsData)
                {
                    book.MarkerDesigner.AddParameter(param.Key, param.Value);
                }

                // AutoFit
                sheet.AllocatedRange.AutoFitRows();
                sheet.AllocatedRange.AutoFitColumns();

                // save to file
                book.SaveToFile(p_DestinationPath);
                ExcelDocViewer(p_DestinationPath);

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

                return false;
            }
        }

        private void ExcelDocViewer(string fileName)
        {
            try
            {
                NeuroFile.GetInstance().OpenFile(fileName);
            }
            catch { }
        }
    }
}
