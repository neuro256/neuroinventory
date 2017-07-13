using GemBox.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace NeuroInventory
{
    public class GemboxXlsWrapper : IReportWrapper
    {
        private string m_TemplateSourcePath = @"Templates\templateDebit.xls";

        public string TemplateSourcePath { get => m_TemplateSourcePath; set => m_TemplateSourcePath = value; }

        private string m_DestinationPath;
        private DataSet m_DebitDataSet;
        private DataSet m_InvoiceDataSet;
        private Dictionary<string, object> m_AdditionalData;

        public GemboxXlsWrapper(string p_DestinationPath, DataSet p_DebitDataSet, DataSet p_InvoiceDataSet, Dictionary<string, object> p_AdditionalData)
        {
            m_DestinationPath = p_DestinationPath;
            m_DebitDataSet = p_DebitDataSet;
            m_InvoiceDataSet = p_InvoiceDataSet;
            m_AdditionalData = p_AdditionalData;
        }

        public bool CreateReport()
        {
            try
            {
                SpreadsheetInfo.SetLicense("ERDC-HMNA-Q3HP-01TI");

                ExcelFile ef = ExcelFile.Load(m_TemplateSourcePath);

                ExcelWorksheet ws = ef.Worksheets[0];

                // Find cells with placeholder text and set their values.
                int row, column;

                // fill parameter
                foreach (KeyValuePair<string, object> param in m_AdditionalData)
                {
                    if (ws.Cells.FindText($"[{param.Key}]", true, true, out row, out column))
                    {
                        ws.Cells[row, column].Value = param.Value;
                    }
                }

                if (ws.Cells.FindText("[InvoiceReport]", true, true, out row, out column))
                {
                    ws.Rows.InsertCopy(row + 1, m_InvoiceDataSet.Tables[0].Rows.Count - 1, ws.Rows[row]);
                    int i = 0;
                    foreach (DataRow dataRow in m_InvoiceDataSet.Tables[0].Rows)
                    {
                        ExcelRow currentRow = ws.Rows[row + i];
                        currentRow.Cells["A"].SetValue(Convert.ToInt32(dataRow["number"]));
                        currentRow.Cells["B"].SetValue(Convert.ToString(dataRow["date_entrance"]));
                        currentRow.Cells["D"].SetValue(Convert.ToString(dataRow["date_debit"]));
                        currentRow.Cells["J"].SetValue(Convert.ToInt32(dataRow["invoice_code"]));
                        i++;
                    }
                }

                if (ws.Cells.FindText("[DebitReport]", true, true, out row, out column))
                {
                    ws.Rows.InsertCopy(row + 1, m_DebitDataSet.Tables[0].Rows.Count - 1, ws.Rows[row]);
                    int i = 0;
                    foreach (DataRow dataRow in m_DebitDataSet.Tables[0].Rows)
                    {
                        ExcelRow currentRow = ws.Rows[row + i];
                        currentRow.Cells["A"].SetValue(Convert.ToInt32(dataRow["number"]));
                        currentRow.Cells["B"].SetValue(Convert.ToString(dataRow["name"]));
                        currentRow.Cells["J"].SetValue(Convert.ToString(dataRow["measurement"]));
                        currentRow.Cells["L"].SetValue(Convert.ToString(dataRow["OKEIcode"]));
                        currentRow.Cells["M"].SetValue(Convert.ToString(dataRow["amount"]));
                        currentRow.Cells["X"].SetValue(Convert.ToString(dataRow["price"]));
                        currentRow.Cells["Z"].SetValue(Convert.ToString(dataRow["sum"]));
                        i++;
                    }
                }

                // how this work?
                // Calculate formulas in worksheet.
                //ws.Calculate();

                ef.Save(m_DestinationPath);

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
                NeuroFile.GetInstance().OpenFile(p_FileName);
            }
            catch { }
        }
    }
}
