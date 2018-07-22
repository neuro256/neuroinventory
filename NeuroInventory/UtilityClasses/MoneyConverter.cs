using System;
using System.Globalization;

namespace NeuroInventory
{
    public static class MoneyConverter
    {
        public static string ToString(object obj)
        {
            return String.Format("{0:C}", CultureInfo.GetCultureInfo("ru-RU"), obj);
        }

        public static string ToString(decimal value)
        {
            return String.Format("{0:C}", CultureInfo.GetCultureInfo("ru-RU"), value);
        }

        public static decimal ToCurrency(object obj)
        {
            return Convert.ToDecimal(obj, CultureInfo.InvariantCulture);
        }

        public static decimal ToCurrency(string str)
        {
            return Decimal.Parse(str, NumberStyles.Currency, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Умножение и конвертирование в decimal двух объектов
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static decimal Multiply(object value1, object value2)
        {
            return Convert.ToDecimal(value1, CultureInfo.InvariantCulture) * Convert.ToDecimal(value2, CultureInfo.InvariantCulture);
        }

        public static decimal Multiply(decimal value1, decimal value2)
        {
            return value1 * value2;
        }
    }
}
