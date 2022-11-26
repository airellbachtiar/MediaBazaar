using System;

namespace Media_Bazaar_Logic.Parsers
{
    public static class ParserOptions
    {
        public static string DBNullConverter(string val)
        {
            if (val == DBNull.Value.ToString())
            {
                val = null;
            }
            return val;
        }

        public static DateTime? DateTimeConverterFromDBToClass(string date)
        {
            if (date == null || date == "")
            {
                return null;
            }
            return DateTime.Parse(date);
        }

        public static bool? BooleanConverterFromDBToClass(string input)
        {
            if(input == null)
            {
                return null;
            }
            return Convert.ToBoolean(input);
        }
    }
}
