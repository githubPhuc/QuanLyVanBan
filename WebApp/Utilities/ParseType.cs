using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolsApp.Utilities
{
    public static class ParseType
    {
        public static int TryParseInt(string val)
        {
            try
            {
                int result;
                int.TryParse(val, out result);
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public static long TryParseLong(string val)
        {
            long result;
            long.TryParse(val, out result);
            return result;
        }

        public static float TryParseFloat(string val)
        {
            float result;
            float.TryParse(val, out result);
            return result;
        }

        public static DateTime TryParseDateTime(string val)
        {
            DateTime result;
            DateTime.TryParse(val, out result);
            return result;
        }

        public static double TryParseDouble(string val)
        {
            double result;
            double.TryParse(val, out result);
            return result;
        }

        public static bool TryParseBolean(string val)
        {
            bool result;
            bool.TryParse(val, out result);
            return result;
        }
    }
}