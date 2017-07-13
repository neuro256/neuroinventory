using System.Collections.Generic;
using System.Data;

namespace NeuroInventory
{
    public interface IReportWrapper
    {
        bool CreateReport();
        void DocumentViewer(string p_FileName);
    }
}
