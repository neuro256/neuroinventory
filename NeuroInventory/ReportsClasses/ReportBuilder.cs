using System;
using System.Collections.Generic;
using System.Data;

namespace NeuroInventory
{
    public abstract class ReportBuilder
    {
        public abstract void AddDestinationPath(string path);
        public abstract void AddAdditionalData(Dictionary<string, object> data);
        public virtual void AddDemandDataSet(DataSet demandDataset) { }
        public virtual void AddDebitDataSet(DataSet debitDataset) { }
        public virtual void AddInvoiceDataSet(DataSet invoiceDataSet) { }
        public abstract ReportData Build();
    }

    public class GemboxReportBuilder : ReportBuilder
    {
        ReportData reportData = new ReportData();

        public override void AddAdditionalData(Dictionary<string, object> data)
        {
            reportData.AdditionalData = data;
        }

        public override void AddDestinationPath(string path)
        {
            reportData.DestinationPath = path;
        }

        public override ReportData Build()
        {
            return reportData;
        }

        public override void AddDebitDataSet(DataSet debitDataset)
        {
            reportData.DebitDataSet = debitDataset;
        }

        public override void AddInvoiceDataSet(DataSet invoiceDataSet)
        {
            reportData.InvoiceDataSet = invoiceDataSet;
        }
    }

    public class SpireReportBuilder : ReportBuilder
    {
        ReportData reportData = new ReportData();

        public override void AddAdditionalData(Dictionary<string, object> data)
        {
            reportData.AdditionalData = data;
        }

        public override void AddDestinationPath(string path)
        {
            reportData.DestinationPath = path;
        }

        public override ReportData Build()
        {
            return reportData;
        }

        public override void AddDemandDataSet(DataSet demandDataset)
        {
            reportData.DemandDataSet = demandDataset;
        }
    }
}
