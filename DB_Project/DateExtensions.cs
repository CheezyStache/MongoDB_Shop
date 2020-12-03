using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB_Project
{
    public static class DateExtensions
    {
        public static long ConvertToJS(DateTime date)
        {
            long unixTimestamp = (long)(date.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            unixTimestamp = unixTimestamp * 1000;

            return unixTimestamp;
        }

        public static DateTime ConvertFromJS(long timestamp)
        {
            long unixTimestamp = timestamp / 1000;
            var date = new DateTime(1970, 1, 1).Add(TimeSpan.FromSeconds(unixTimestamp));

            return date;
        }
    }
}
