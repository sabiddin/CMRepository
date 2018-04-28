using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Utils
{
    public static class Extentions
    {
        public static DateTime ToDateTime(this string date)
        {
            return Convert.ToDateTime(date);
        }
        public static int ToInt(this string value)
        {
            return Convert.ToInt32(value);
        }
        public static decimal ToDecimal(this string value)
        {
            return Convert.ToDecimal(value);
        }
        public static bool HasValue(this string value)
        {
            return !string.IsNullOrEmpty(value) ? true : false;
        }
    }
}
