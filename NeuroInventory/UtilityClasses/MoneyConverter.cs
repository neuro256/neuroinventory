using System;
using System.Globalization;

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

            if (obj is int i)
                return i;

            if (obj is long l)
                return l;

            if (obj is double d)
                return Convert.ToDecimal(d);

            if (obj is float f)
                return Convert.ToDecimal(f);

            string str = obj.ToString()?.Trim();

            if (String.IsNullOrWhiteSpace(str))
                return 0m;

            // Убираем символ валюты
            str = str.Replace("₽", "").Trim();

            decimal result;

            // Сначала пробуем ru-RU
            if (Decimal.TryParse(
                    str,
                    NumberStyles.Any,
                    RuCulture,
                    out result))
            {
                return result;
            }

            // Потом invariant
            if (Decimal.TryParse(
                    str,
                    NumberStyles.Any,
                    InvariantCulture,
                    out result))
            {
                return result;
            }

            // Последняя попытка:
            // заменяем точку на запятую
            str = str.Replace(".", ",");

            if (Decimal.TryParse(
                    str,
                    NumberStyles.Any,
                    RuCulture,
                    out result))
            {
                return result;
            }

            throw new FormatException(
                $"Не удалось преобразовать значение '{obj}' в decimal");
        }

        public static decimal Multiply(object value1, object value2)
        {
            return ToCurrency(value1) * ToCurrency(value2);
        }
    }
}
