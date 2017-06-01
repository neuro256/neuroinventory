using Spire.Doc;
using Spire.Doc.Documents;
using System;
using System.Drawing;
using System.Linq;

namespace NeuroInventory
{
    public class SpireDocWrapper
    {
        struct table2
        {
#pragma warning disable CS0169 // Поле "SpireDocWrapper.table2.date" никогда не используется.
            DateTime date; // Дата составления
#pragma warning restore CS0169 // Поле "SpireDocWrapper.table2.date" никогда не используется.
#pragma warning disable CS0169 // Поле "SpireDocWrapper.table2.operationTypeCode" никогда не используется.
            string operationTypeCode; // Код вида операции
#pragma warning restore CS0169 // Поле "SpireDocWrapper.table2.operationTypeCode" никогда не используется.
#pragma warning disable CS0169 // Поле "SpireDocWrapper.table2.senderUnit" никогда не используется.
            string senderUnit; // Отправитель: структурное подразделение
#pragma warning restore CS0169 // Поле "SpireDocWrapper.table2.senderUnit" никогда не используется.
#pragma warning disable CS0169 // Поле "SpireDocWrapper.table2.senderActivity" никогда не используется.
            string senderActivity; // Отправитель: вид деятельности
#pragma warning restore CS0169 // Поле "SpireDocWrapper.table2.senderActivity" никогда не используется.
#pragma warning disable CS0169 // Поле "SpireDocWrapper.table2.receiverUnit" никогда не используется.
            string receiverUnit; // Получатель: структурное подразделение
#pragma warning restore CS0169 // Поле "SpireDocWrapper.table2.receiverUnit" никогда не используется.
#pragma warning disable CS0169 // Поле "SpireDocWrapper.table2.receiverActivity" никогда не используется.
            string receiverActivity; // Получатель: вид деятельности
#pragma warning restore CS0169 // Поле "SpireDocWrapper.table2.receiverActivity" никогда не используется.
#pragma warning disable CS0169 // Поле "SpireDocWrapper.table2.account" никогда не используется.
            decimal account; // Корреспондирующий счет: счет, субсчет
#pragma warning restore CS0169 // Поле "SpireDocWrapper.table2.account" никогда не используется.
#pragma warning disable CS0169 // Поле "SpireDocWrapper.table2.accountingCode" никогда не используется.
            string accountingCode; // Корреспондирующий счет: код аналитического учета
#pragma warning restore CS0169 // Поле "SpireDocWrapper.table2.accountingCode" никогда не используется.
#pragma warning disable CS0169 // Поле "SpireDocWrapper.table2.accountingUnit" никогда не используется.
            string accountingUnit; // Учетная единица выпуска продукции (работ, услуг)
#pragma warning restore CS0169 // Поле "SpireDocWrapper.table2.accountingUnit" никогда не используется.
        }

        struct table3
        {
#pragma warning disable CS0169 // Поле "SpireDocWrapper.table3.accountingCode" никогда не используется.
            string accountingCode; // 
#pragma warning restore CS0169 // Поле "SpireDocWrapper.table3.accountingCode" никогда не используется.
#pragma warning disable CS0169 // Поле "SpireDocWrapper.table3.accountingUnit" никогда не используется.
            string accountingUnit;
#pragma warning restore CS0169 // Поле "SpireDocWrapper.table3.accountingUnit" никогда не используется.
#pragma warning disable CS0169 // Поле "SpireDocWrapper.table3.name" никогда не используется.
            string name;
#pragma warning restore CS0169 // Поле "SpireDocWrapper.table3.name" никогда не используется.
#pragma warning disable CS0169 // Поле "SpireDocWrapper.table3.number" никогда не используется.
            string number;
#pragma warning restore CS0169 // Поле "SpireDocWrapper.table3.number" никогда не используется.
#pragma warning disable CS0169 // Поле "SpireDocWrapper.table3.measurementCode" никогда не используется.
            string measurementCode;
#pragma warning restore CS0169 // Поле "SpireDocWrapper.table3.measurementCode" никогда не используется.
#pragma warning disable CS0169 // Поле "SpireDocWrapper.table3.measurementName" никогда не используется.
            string measurementName;
#pragma warning restore CS0169 // Поле "SpireDocWrapper.table3.measurementName" никогда не используется.
#pragma warning disable CS0169 // Поле "SpireDocWrapper.table3.amountDemand" никогда не используется.
            decimal amountDemand;
#pragma warning restore CS0169 // Поле "SpireDocWrapper.table3.amountDemand" никогда не используется.
#pragma warning disable CS0169 // Поле "SpireDocWrapper.table3.amountDebit" никогда не используется.
            decimal amountDebit;
#pragma warning restore CS0169 // Поле "SpireDocWrapper.table3.amountDebit" никогда не используется.
#pragma warning disable CS0169 // Поле "SpireDocWrapper.table3.price" никогда не используется.
            decimal price;
#pragma warning restore CS0169 // Поле "SpireDocWrapper.table3.price" никогда не используется.
#pragma warning disable CS0169 // Поле "SpireDocWrapper.table3.sum" никогда не используется.
            decimal sum;
#pragma warning restore CS0169 // Поле "SpireDocWrapper.table3.sum" никогда не используется.
#pragma warning disable CS0169 // Поле "SpireDocWrapper.table3.serialNumber" никогда не используется.
            string serialNumber;
#pragma warning restore CS0169 // Поле "SpireDocWrapper.table3.serialNumber" никогда не используется.
        }

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
