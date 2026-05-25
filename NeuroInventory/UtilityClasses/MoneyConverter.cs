using System;
using System.Globalization;
using System.Linq;

namespace NeuroInventory
{
    public static class MoneyConverter
    {
        private static readonly CultureInfo RuCulture =
            CultureInfo.GetCultureInfo("ru-RU");

        private static readonly CultureInfo InvariantCulture =
            CultureInfo.InvariantCulture;

        public static decimal ToCurrency(object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return 0m;

            if (obj is decimal dec)
                return dec;

            if (obj is string str)
            {
                // Пробуем ru-RU
                if (decimal.TryParse(str, NumberStyles.Number | NumberStyles.AllowCurrencySymbol,
                    RuCulture, out var result))
                    return result;

                // Пробуем Invariant
                if (decimal.TryParse(str, NumberStyles.Number | NumberStyles.AllowCurrencySymbol,
                    InvariantCulture, out result))
                    return result;

                // Очищаем и пробуем ещё раз
                string cleaned = System.Text.RegularExpressions.Regex.Replace(str, @"[^\d,.\-]", "");
                if (cleaned.Contains(',') && cleaned.Contains('.'))
                    cleaned = cleaned.Replace(".", "");
                else if (cleaned.Contains('.'))
                    cleaned = cleaned.Replace('.', ',');

                if (decimal.TryParse(cleaned, NumberStyles.Number,
                    RuCulture, out result))
                    return result;
            }

            try
            {
                return Convert.ToDecimal(obj, RuCulture);
            }
            catch
            {
                return 0m;
            }
        }

        public static decimal GetDecimalValue(object value)
        {
            if (value == null || value == DBNull.Value)
                return 0m;

            if (value is decimal d)
                return d;

            if (value is double dbl)
                return (decimal)dbl;

            if (value is string str)
            {
                return ToCurrency(str);
            }

            return Convert.ToDecimal(value, RuCulture);
        }

        public static string FormatCurrency(decimal value)
        {
            return value.ToString("C", RuCulture);
        }

        public static string FormatNumber(object value, int decimalPlaces)
        {
            decimal amount = GetDecimalValue(value);

            string format =
                decimalPlaces > 0
                    ? "0." + new string('#', decimalPlaces)
                    : "0";

            return amount.ToString(format, RuCulture);
        }

        public static decimal RoundCurrency(decimal value)
        {
            return Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }
    }
}
