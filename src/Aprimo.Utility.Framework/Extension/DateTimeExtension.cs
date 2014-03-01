using System;
using System.Globalization;

namespace Aprimo.Utility.Framework.Extension
{
    public static class DateTimeExtension
    {
        static readonly GregorianCalendar Calendar = new GregorianCalendar();

        /// <summary>
        /// Gets the number of weeks in month.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static int GetNumberOfWeeksInMonth(this DateTime date)
        {
            DateTime lastDateOfMonth = date.GetLastDateOfMonth();
            return lastDateOfMonth.GetWeekOfMonth();
        }

        /// <summary>
        /// Gets the first date of week.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static DateTime GetFirstDateOfWeek(this DateTime date)
        {
            const int MONDAY = 1;
            int currentDay = (int)date.DayOfWeek;
            if (date.DayOfWeek == DayOfWeek.Sunday)
                currentDay = 7;

            int difference = currentDay - MONDAY;
            DateTime firstDateOfWeek = date.AddDays(-difference);
            return firstDateOfWeek;
        }

        /// <summary>
        /// Gets the last date of week.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static DateTime GetLastDateOfWeek(this DateTime date)
        {
            const int SUNDAY = 7;
            int crtDay = (int)date.DayOfWeek;
            if (date.DayOfWeek == DayOfWeek.Sunday)
                crtDay = 7;

            int difference = SUNDAY - crtDay;
            DateTime lastDateOfWeek = date.AddDays(difference);
            return lastDateOfWeek;

        }

        /// <summary>
        /// Gets the first date of next week.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static DateTime GetFirstDateOfNextWeek(this DateTime date)
        {
            DateTime firstDateOfWeek = date.GetFirstDateOfWeek();
            return firstDateOfWeek.AddDays(7);
        }

        /// <summary>
        /// Gets the last date of next week.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static DateTime GetLastDateOfNextWeek(this DateTime date)
        {
            DateTime lastDateOfWeek = date.GetLastDateOfWeek();
            return lastDateOfWeek.AddDays(7);
        }

        /// <summary>
        /// Gets the first date of month.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static DateTime GetFirstDateOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        /// <summary>
        /// Gets the last date of month.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static DateTime GetLastDateOfMonth(this DateTime dateTime)
        {
            return GetFirstDateOfMonth(dateTime).AddMonths(1).Subtract(new TimeSpan(1, 0, 0, 0, 0));
        }

        /// <summary>
        /// Gets the week of month for given date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static int GetWeekOfMonth(this DateTime date)
        {
            DateTime firstDateOfMonth = new DateTime(date.Year, date.Month, 1);
            return date.GetWeekOfYear() - firstDateOfMonth.GetWeekOfYear() + 1;
        }

        /// <summary>
        /// Gets the week of year for given date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static int GetWeekOfYear(this DateTime date)
        {
            return Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }

        /// <summary>
        /// Dayses the in month.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static int DaysInMonth(this DateTime date)
        {
            return date.GetLastDateOfMonth().Day;
        }
    }
}
