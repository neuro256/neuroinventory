using BrightIdeasSoftware;
using System;
using System.Collections;
using System.Globalization;
using System.Windows.Forms;

namespace NeuroInventory
{
    public class NeuroDateComparer : IComparer
    {
        private OLVColumn oLVColumn;
        private SortOrder order;

        public NeuroDateComparer(OLVColumn oLVColumn, SortOrder order)
        {
            this.oLVColumn = oLVColumn;
            this.order = order;
        }

        public int Compare(OLVListItem x, OLVListItem y)
        {
            string xValue = this.oLVColumn.GetStringValue(x.RowObject);
            string yValue = this.oLVColumn.GetStringValue(y.RowObject);

            return 0;
        }

        public int Compare(object x, object y)
        {
            int result = 0;
            if (x != null && y != null)
            {
                string xValue = this.oLVColumn.GetStringValue((x as OLVListItem).RowObject);
                string yValue = this.oLVColumn.GetStringValue((y as OLVListItem).RowObject);

                if (String.IsNullOrEmpty(xValue))
                    xValue = DateTime.MinValue.ToShortDateString();
                if (String.IsNullOrEmpty(yValue))
                    yValue = DateTime.MinValue.ToShortDateString();

                result = DateTime.Compare(DateTime.Parse(xValue), DateTime.Parse(yValue));

                if (this.order == SortOrder.Descending)
                    result = 0 - result;
            }

            return result;
        }
    }

    public class NeuroNumberComparer : IComparer
    {
        private OLVColumn oLVColumn;
        private SortOrder order;

        public NeuroNumberComparer(OLVColumn columnAmount, SortOrder order)
        {
            this.oLVColumn = columnAmount;
            this.order = order;
        }

        public int Compare(object x, object y)
        {
            int result = 0;
            if (x != null && y != null)
            {
                string xValue = this.oLVColumn.GetStringValue((x as OLVListItem).RowObject);
                string yValue = this.oLVColumn.GetStringValue((y as OLVListItem).RowObject);

                if (String.IsNullOrEmpty(xValue))
                    xValue = String.Format("0");
                if (String.IsNullOrEmpty(yValue))
                    yValue = String.Format("0");

                result = Decimal.Compare(Decimal.Parse(xValue, CultureInfo.InvariantCulture), Decimal.Parse(yValue, CultureInfo.InvariantCulture));

                if (this.order == SortOrder.Descending)
                    result = 0 - result;
            }

            return result;
        }
    }

    public class NeuroCurrencyComparer : IComparer
    {
        private OLVColumn oLVColumn;
        private SortOrder order;

        public NeuroCurrencyComparer(OLVColumn columnAmount, SortOrder order)
        {
            this.oLVColumn = columnAmount;
            this.order = order;
        }

        public int Compare(object x, object y)
        {
            int result = 0;
            if (x != null && y != null)
            {
                string xValue = this.oLVColumn.GetStringValue((x as OLVListItem).RowObject);
                string yValue = this.oLVColumn.GetStringValue((y as OLVListItem).RowObject);

                if (String.IsNullOrEmpty(xValue))
                    xValue = String.Format("{0:C}", CultureInfo.GetCultureInfo("ru-RU"), 0);
                if (String.IsNullOrEmpty(yValue))
                    yValue = String.Format("{0:C}", CultureInfo.GetCultureInfo("ru-RU"), 0);

                result = Decimal.Compare(Decimal.Parse(xValue, NumberStyles.Currency, CultureInfo.GetCultureInfo("ru-RU")), Decimal.Parse(yValue, NumberStyles.Currency, CultureInfo.GetCultureInfo("ru-RU")));

                if (this.order == SortOrder.Descending)
                    result = 0 - result;
            }

            return result;
        }
    }
}
