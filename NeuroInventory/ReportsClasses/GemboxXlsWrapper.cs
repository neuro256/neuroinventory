using GemBox.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace NeuroInventory
{
    public class GemboxXlsWrapper : ISpireReportWrapper
    {
        private string m_TemplateSourcePath = @"Templates\templateDebit.xls";

        public string TemplateSourcePath { get => m_TemplateSourcePath; set => m_TemplateSourcePath = value; }

        public bool CreateReport(string p_DestinationPath, DataSet p_DataSet, Dictionary<string, object> p_AdditionalData)
        {
            try
            {
                SpreadsheetInfo.SetLicense("ERDC-HMNA-Q3HP-01TI");

                ExcelFile ef = ExcelFile.Load(m_TemplateSourcePath);

                ExcelWorksheet ws = ef.Worksheets[0];

                // Find cells with placeholder text and set their values.
                int row, column;

                // fill parameter
                foreach (KeyValuePair<string, object> param in p_AdditionalData)
                {
                    if (ws.Cells.FindText($"[{param.Key}]", true, true, out row, out column))
                    {
                        ws.Cells[row, column].Value = param.Value;
                    }
                }

                if (ws.Cells.FindText("[DebitReport]", true, true, out row, out column))
                {
                    ws.Rows.InsertCopy(row + 1, p_DataSet.Tables[0].Rows.Count - 1, ws.Rows[row]);
                    int i = 0;
                    foreach (DataRow dataRow in p_DataSet.Tables[0].Rows)
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

                ef.Save(p_DestinationPath);

                DocumentViewer(p_DestinationPath);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return false;
            }
        }

        public bool CreateReport(string p_DestinationPath, DataSet p_DebitDataSet, DataSet p_InvoiceDataSet, Dictionary<string, object> p_AdditionalData)
        {
            try
            {
                SpreadsheetInfo.SetLicense("ERDC-HMNA-Q3HP-01TI");

                ExcelFile ef = ExcelFile.Load(m_TemplateSourcePath);

                ExcelWorksheet ws = ef.Worksheets[0];

                // Find cells with placeholder text and set their values.
                int row, column;

                // fill parameter
                foreach (KeyValuePair<string, object> param in p_AdditionalData)
                {
                    if (ws.Cells.FindText($"[{param.Key}]", true, true, out row, out column))
                    {
                        ws.Cells[row, column].Value = param.Value;
                    }
                }

                if (ws.Cells.FindText("[InvoiceReport]", true, true, out row, out column))
                {
                    ws.Rows.InsertCopy(row + 1, p_InvoiceDataSet.Tables[0].Rows.Count - 1, ws.Rows[row]);
                    int i = 0;
                    foreach (DataRow dataRow in p_InvoiceDataSet.Tables[0].Rows)
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
                    ws.Rows.InsertCopy(row + 1, p_DebitDataSet.Tables[0].Rows.Count - 1, ws.Rows[row]);
                    int i = 0;
                    foreach (DataRow dataRow in p_DebitDataSet.Tables[0].Rows)
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

                ef.Save(p_DestinationPath);

                DocumentViewer(p_DestinationPath);

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
