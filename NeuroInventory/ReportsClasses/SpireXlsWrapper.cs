using Spire.Xls;

namespace NeuroInventory
{
    public class SpireXlsWrapper
    {
        private string m_TemplateSourcePath = @"templateDebit.xls";

        public bool CreateReport()
        {
            Workbook book = new Workbook();
            
            return true;
        }
    }
}
