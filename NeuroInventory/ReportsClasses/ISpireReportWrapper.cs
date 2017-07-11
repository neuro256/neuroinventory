using System.Collections.Generic;
using System.Data;

namespace NeuroInventory
{
    public interface ISpireReportWrapper
    {
        bool CreateReport(string p_DestinationPath, DataSet p_DataSet, Dictionary<string, object> p_AdditionalData);
        bool CreateReport(string p_DestinationPath, DataSet p_DataSet, DataSet p_SecondDataSet, Dictionary<string, object> p_AdditionalData);
        void DocumentViewer(string p_FileName);
    }
}
