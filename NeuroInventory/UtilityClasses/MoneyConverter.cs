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
                    CultureInfo.GetCultureInfo("ru-RU"), out var result))
                    return result;

                // Пробуем Invariant
                if (decimal.TryParse(str, NumberStyles.Number | NumberStyles.AllowCurrencySymbol,
                    CultureInfo.InvariantCulture, out result))
                    return result;

                // Очищаем и пробуем ещё раз
                string cleaned = System.Text.RegularExpressions.Regex.Replace(str, @"[^\d,.\-]", "");
                if (cleaned.Contains(',') && cleaned.Contains('.'))
                    cleaned = cleaned.Replace(".", "");
                else if (cleaned.Contains('.'))
                    cleaned = cleaned.Replace('.', ',');

                if (decimal.TryParse(cleaned, NumberStyles.Number,
                    CultureInfo.GetCultureInfo("ru-RU"), out result))
                    return result;
            }

            try
            {
                return Convert.ToDecimal(obj, CultureInfo.GetCultureInfo("ru-RU"));
            }
            catch
            {
                return 0m;
            }
        }
    }
}
