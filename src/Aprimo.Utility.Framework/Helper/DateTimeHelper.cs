using System;
using System.Globalization;

namespace Aprimo.Utility.Framework.Helper
{
    /// <summary>
    /// DateTime Helper
    /// </summary>
    public static class DateTimeHelper
    {
        /// <summary>
        /// Reference Date
        /// </summary>
        private static readonly DateTime ReferenceDate = new DateTime(1967, 01, 01);

        /// <summary>
        /// Indian Time Zone
        /// </summary>
        private static readonly TimeZoneInfo IndianZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

        /// <summary>
        /// Converts a date to an int based on 1967/01/01
        /// </summary>
        /// <param name="value">Date to convert</param>
        /// <returns>Int representation of the date</returns>
        public static int ConvertToInt(this DateTime value)
        {
            return (value - ReferenceDate).Days + 1;
        }

        /// <summary>
        /// Converts an int to a date based on 1967/01/01
        /// </summary>
        /// <param name="value">Int to convert</param>
        /// <returns>Date representation of the int</returns>
        public static DateTime ConvertToDateTime(this int value)
        {
            return ReferenceDate.AddDays(value - 1);
        }

        /// <summary>
        /// Gets the name of the month.
        /// </summary>
        /// <param name="monthNumber">The month number.</param>
        /// <returns></returns>
        public static string GetMonthName(int monthNumber)
        {
            return StringHelper.ToUpperFirst(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthNumber));
        }

        /// <summary>
        /// Convert a nullable DateTime value to a short datetime string
        /// </summary>
        /// <param name="date">Date</param>
        /// <returns>string in format "dd/MM/yyyy" or empty if null datetime</returns>
        public static string ConvertNullableDateToShortDateString(DateTime? date)
        {
            if (date.HasValue)
            {
                return date.Value.ToString("dd/MM/yyyy");
            }
            return String.Empty;
        }

        /// <summary>
        /// This method returns the week number 
        /// </summary>
        /// <param name="date">Datetime</param>
        /// <returns>Week number</returns>
        public static int WeekNumber(DateTime date)
        {
            Calendar cal = new GregorianCalendar();
            return cal.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        /// <summary>
        /// This method returns the week number of the month
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Week number of the month</returns>
        public static int WeekNumberOfMonth(DateTime date)
        {
            int weekNumber = WeekNumber(date);
            int firstWeekOfMonthNumber = WeekNumber(new DateTime(date.Year, date.Month, 1));

            return weekNumber - firstWeekOfMonthNumber + 1;
        }

        /// <summary>
        /// Method to calculate no of months between two dates
        /// </summary>
        /// <param name="startDate">The start date</param>
        /// <param name="endDate">The end date</param>
        /// <returns>The number of months</returns>
        public static double MonthDifference(DateTime startDate, DateTime endDate)
        {
            // Time span to set the total time difference
            TimeSpan timeDifference;

            // This if condition to avoid the minus value for Time difference
            if (endDate > startDate)
            {
                timeDifference = endDate.Subtract(startDate).Add(new TimeSpan(1, 0, 0, 0));
            }
            else
            {
                timeDifference = startDate.Subtract(endDate).Add(new TimeSpan(1, 0, 0, 0));
            }

            return (timeDifference.TotalDays / 30.0);
        }

        /// <summary>
        /// Method to calculate no of year between two dates
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>The number of years</returns>
        public static int YearDifference(DateTime startDate, DateTime endDate)
        {
            // This is to set date to "0001/01/01"
            DateTime systemStartDate = new DateTime();

            // Time span to set the total time difference
            TimeSpan timeDifference;

            // This if condition to avoid the minus value for Time difference
            if (endDate > startDate)
            {
                timeDifference = endDate.Subtract(startDate);
            }
            else
            {
                timeDifference = startDate.Subtract(endDate);
            }

            // This is to generate a date from the systemStartDate  
            DateTime generatedDate = systemStartDate.Add(timeDifference);

            // Substract 1 because the systemStartDate is "0001/01/01"
            int noOfYears = generatedDate.Year - 1;

            return noOfYears;
        }

        /// <summary>
        /// This method returns the date in 'ddMM' format.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static String GetDateInMonth(DateTime date)
        {
            return date.ToString("ddMM");
        }

        /// <summary>
        /// This method returns the date in 'ddMMyyyy' format.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static String GetDateInCompleteFormat(DateTime date)
        {
            return date.ToString("ddMMyyyy");
        }

        /// <summary>
        /// Gets the first day of current accounting month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfMonth(int month, int year)
        {
            return new DateTime(year, month, 1);
        }

        /// <summary>
        /// Gets the last day of current accounting month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime GetLastDayOfMonth(int month, int year)
        {
            return new DateTime(year, month, DateTime.DaysInMonth(year, month));
        }

        /// <summary>
        /// Gets the first day of current month.
        /// </summary>
        /// <returns></returns>
        public static DateTime GetFirstDayOfCurrentMonth()
        {
            return new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        }

        /// <summary>
        /// Gets the last day of current month.
        /// </summary>
        /// <returns></returns>
        public static DateTime GetLastDayOfCurrentMonth()
        {
            return new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
        }

        /// <summary>
        /// Gets the last day of month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        public static DateTime GetLastDayOfMonth(DateTime month)
        {
            DateTime lastDayOfCurrentMonth = GetLastDayOfCurrentMonth();

            // TODO Refactor this method if this Exception is thrown.
            if (month > lastDayOfCurrentMonth)
            {
                throw new ApplicationException("This method takes only a date lower than the last day of the current month");
            }

            return new DateTime(DateTime.Today.Year, month.Month,
                DateTime.DaysInMonth(DateTime.Today.Year, month.Month));
        }

        /// <summary>
        /// this method returns the days number of the week
        /// </summary>
        /// <param name="value">enum define in interface.</param>  
        /// <returns>day number</returns>
        public static int NumDayOfWeek(DayOfWeek value)
        {
            switch (value)
            {
                case DayOfWeek.Monday:
                    return 1;
                case DayOfWeek.Tuesday:
                    return 2;
                case DayOfWeek.Wednesday:
                    return 3;
                case DayOfWeek.Thursday:
                    return 4;
                case DayOfWeek.Friday:
                    return 5;
                case DayOfWeek.Saturday:
                    return 6;
                case DayOfWeek.Sunday:
                    return 7;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Gets the four digit year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static int GetFourDigitYear(int year)
        {
            if (year.ToString().Length < 4)
            {
                if (year <= 20)
                {
                    year += 2000;
                }
                else
                {
                    year += 1900;
                }
            }

            return year;
        }

        /// <summary>
        /// Gets the current date.
        /// </summary>
        /// <value>The current date.</value>
        public static DateTime CurrentDate
        {
            get { return DateTime.UtcNow; }
        }

        /// <summary>
        /// Toes the indian standard time.
        /// </summary>
        /// <param name="utcDateTime">The UTC date time.</param>
        /// <returns></returns>
        public static DateTime ToIndianStandardTime(this DateTime utcDateTime)
        {
            //DateTime newTime = TimeZoneInfo.ConvertTime(utcDateTime, TimeZoneInfo.FindSystemTimeZoneById(TimeZoneInfo.GetSystemTimeZones().Where(t => t.StandardName.Contains("India Standard Time")).First().Id));
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, IndianZone);
        }

        /// <summary>
        /// To the nullable short date time.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="inputFormat">The input format.</param>
        /// <returns></returns>
        public static DateTime? ToNullableShortDateTime(this string date, string inputFormat)
        {
            if (!string.IsNullOrEmpty(date))
            {
                DateTime registrationDate;
                string formattedDate = null;
                if(!string.IsNullOrEmpty(inputFormat))
                {
                    if(inputFormat.Equals("dd-MM-yyyy"))
                    {
                        formattedDate = date;
                    }
                    else if(inputFormat.Equals("MM-dd-yyyy"))
                    {
                        string[] dates = date.Split('-');
                        formattedDate = string.Format("{0}-{1}-{2}", dates[1], dates[0], dates[2]);
                    }
                }

                if (DateTime.TryParse(formattedDate, out registrationDate))
                {
                    return registrationDate;
                }
            }

            return null;
        }

        /// <summary>
        /// Toes the short date time.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="inputFormat">The input format.</param>
        /// <returns></returns>
        public static DateTime ToShortDateTime(this string date, string inputFormat)
        {
            return ToNullableShortDateTime(date, inputFormat).GetValueOrDefault();
        }
    }
}
