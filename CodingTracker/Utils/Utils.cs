using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker.Utils
{
    internal class Utils
    {
        private const string DATE_FORMAT = "dd-MM-yyyy HH:mm:ss";  
        public int GetDifferenceBetweenDatesInHours(string date1, string date2)
        {
            DateTime firstDate = DateTime.ParseExact(date1, DATE_FORMAT, CultureInfo.InvariantCulture);
            DateTime secondDate = DateTime.ParseExact(date2, DATE_FORMAT, CultureInfo.InvariantCulture);

            var diffOfDates = secondDate - firstDate;

            return diffOfDates.Hours;
        }

        public static int GetWeekOfMonth(DateTime date)
        {
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            int firstOfMonth = (new DateTime(date.Year, date.Month, 1)).DayOfWeek.GetHashCode();

            int weekOfMonth = (date.Day + firstOfMonth - 1) / 7 + 1;
            if (weekOfMonth == 5 && date.Day + firstOfMonth > daysInMonth)
            {
                weekOfMonth = 4;
            }

            return weekOfMonth;
        }


    }
}
