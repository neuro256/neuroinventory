using System.Collections.Generic;
using System.Data;

namespace NeuroInventory
{
    public class ReportData
    {
        private string m_DestinationPath;
        private DataSet m_DemandDataSet;
        private DataSet m_DebitDataSet;
        private DataSet m_InvoiceDataSet;
        private Dictionary<string, object> m_AdditionalData;

        public string DestinationPath { get => m_DestinationPath; set => m_DestinationPath = value; }
        public DataSet DebitDataSet { get => m_DebitDataSet; set => m_DebitDataSet = value; }
        public DataSet InvoiceDataSet { get => m_InvoiceDataSet; set => m_InvoiceDataSet = value; }
        public Dictionary<string, object> AdditionalData { get => m_AdditionalData; set => m_AdditionalData = value; }
        public DataSet DemandDataSet { get => m_DemandDataSet; set => m_DemandDataSet = value; }
    }
}
