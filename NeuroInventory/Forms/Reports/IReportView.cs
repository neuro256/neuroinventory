using System.Data;

namespace NeuroInventory
{
    public interface IReportView
    {
        void InitControls();
        void ShowTable();
        DataSet ReturnDataSet();
        void CreateReport();
    }
}
