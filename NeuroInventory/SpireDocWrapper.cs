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

        private void Run()
        {
            Document document = new Document(m_TemplateSourcePath);
            document.LoadFromFile(m_TemplateSourcePath, FileFormat.Doc);
            document.Replace("ПБР-Гидро", "PBR-Gydro", false, true);
            //doc.SaveToFile("Result.pdf", FileFormat.PDF);
            Section section = document.Sections[0];
            Table originalTable = (Table)section.Tables[1];
            string[] newRow = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            AddRowInTable(originalTable, newRow);

            //Table cloneTable = originalTable.Clone();

            //string[] newRow = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            //TableRow lastRow = cloneTable.Rows[cloneTable.Rows.Count - 1];
            //lastRow.RowFormat.BackColor = Color.Gray;

            //for(int i = 0; i < lastRow.Cells.Count; i++)
            //{
            //    lastRow.Cells[i].Paragraphs[0].Text = newRow[i];
            //}

            //section.Tables.Add(cloneTable);

            document.SaveToFile("Result.doc", FileFormat.Doc);

            System.Diagnostics.Process.Start("Result.doc");
        }

        private void AddRowInTable(Table p_Table, string[] p_RowData)
        {
            TableRow newRow = p_Table.AddRow(true, p_RowData.Length);

            for (int i = 0; i < newRow.Cells.Count; i++)
            {
                newRow.Cells[i].AddParagraph().AppendText(p_RowData[i]);
            }
        }

        public void CreateReport(string p_DestinationPath, DataSet p_DataSetDemandReport, Dictionary<string, string> p_FieldsData)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WordDocViewer(string p_FileName)
        {
            try
            {
                System.Diagnostics.Process.Start(p_FileName);
            }
            catch { }
        }
    }
}
