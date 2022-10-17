using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Smartly.CodingChallenge.Extension
{
    public static class Extensions
    {
        /// <summary>
        ///     Rounds a decimal value to a specified number of fractional digits.
        /// </summary>
        /// <param name="d">A decimal number to be rounded.</param>
        /// <param name="decimals">The number of decimal places in the return value.</param>
        /// <returns>The number nearest to  that contains a number of fractional digits equal to .</returns>
        public static Decimal Round(this Decimal d, Int32 decimals = 2)
        {
            return Math.Round(d, decimals);
        }

        /// <summary>
        ///     Convert  decimal value to a string with N2 format.
        /// </summary>
        /// <param name="d">A decimal number to be convert to string</param>       
        /// <returns>return formatted string value</returns>
        /// 
        public static string ToStringN2(this Decimal d)
        {
            return d.ToString("N2");
        }

      
        /// <summary>
        /// Remove '%' and convert string value into decimal 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal PrecentValue(this string value)
        {
            return Convert.ToDecimal(value.Trim().Replace("%", ""));
        }

        /// <summary>
        /// Convert apyPerid to Formatted pattern 
        /// </summary>
        /// <param name="Month"> string month value</param>
        /// <returns>retrun formated value with start date and end date (ie, 01 May - 31 May)</returns>
        public static string PayPeriodStartEnd(this string Month)
        { 
            int month = DateTime.ParseExact(Month, "MMMM", CultureInfo.InvariantCulture).Month;
            var lastDayOfMonth = DateTime.DaysInMonth(DateTime.Now.Year, month);
            return $"01 {Month} - {lastDayOfMonth} {Month}";
        }

    }
}
