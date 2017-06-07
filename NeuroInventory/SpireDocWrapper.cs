using Spire.Doc;
using Spire.Doc.Documents;
using System;
using System.Drawing;
using System.Linq;

namespace NeuroInventory
{
    public class SpireDocWrapper
    {
        private static string m_TemplateSourcePath = @"templateDemand.doc";

        public static string TemplateSourcePath
        {
            get
            {
                return m_TemplateSourcePath;
            }
            private set
            {
                m_TemplateSourcePath = value;
            }
        }

        public void Run()
        {
            Document doc = new Document();
            doc.LoadFromFile(TemplateSourcePath, FileFormat.Doc);
            doc.Replace("ПБР-Гидро", "PBR-Gydro", false, true);
            //doc.SaveToFile("Result.pdf", FileFormat.PDF);
            Section section = doc.Sections[0];
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

            doc.SaveToFile("Result.doc", FileFormat.Doc);

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

        public void CreateReport(string p_DestinationPath)
        {

        }
    }
}
