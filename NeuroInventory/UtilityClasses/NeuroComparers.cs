using BrightIdeasSoftware;
using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace NeuroInventory
{
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
                string xValue = this.oLVColumn.AspectGetter((x as OLVListItem).RowObject)?.ToString() ?? string.Empty;
                string yValue = this.oLVColumn.AspectGetter((y as OLVListItem).RowObject)?.ToString() ?? string.Empty;

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
            if (x == null || y == null)
                return 0;

            var rowX = (x as OLVListItem)?.RowObject as DataRowView;
            var rowY = (y as OLVListItem)?.RowObject as DataRowView;

            object rawX = rowX?[this.oLVColumn.AspectName];
            object rawY = rowY?[this.oLVColumn.AspectName];

            decimal xVal = ParseDecimal(rawX);
            decimal yVal = ParseDecimal(rawY);

            int result = decimal.Compare(xVal, yVal);

            return this.order == SortOrder.Descending
                ? -result
                : result;
        }

        private decimal ParseDecimal(object value)
        {
            if (value == null || value == DBNull.Value)
                return 0m;

            if (value is decimal d)
                return d;

            string s = value.ToString();

            if (decimal.TryParse(
                s,
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out decimal result))
            {
                return result;
            }

            if (decimal.TryParse(
                s,
                NumberStyles.Any,
                CultureInfo.CurrentCulture,
                out result))
            {
                return result;
            }

            return 0m;
        }
    }
}
