using System;

namespace DotNetUtils
{
    public static class DateUtils
    {
        /// <summary>
        /// Converts from a DateTime value to Unix time value
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long GetUnixTime(DateTime time)
        {
            return (long)time.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }

        /// <summary>
        /// Converts from Unix time value to DateTime object
        /// </summary>
        /// <param name="value">Unix time - measured in seconds</param>
        /// <returns></returns>
        public static DateTime UnixToDateTime(string value)
        {
            long seconds;
            if (long.TryParse(value, out seconds))
            {
                return UnixToDateTime(seconds);
            }
            else
            {
                return new DateTime(1970, 1, 1); // default value
            }
        }

        /// <summary>
        /// Converts from Unix time value to DateTime object
        /// </summary>
        /// <param name="value">Unix time - measured in seconds</param>
        /// <returns></returns>
        public static DateTime UnixToDateTime(long value)
        {
            return (new DateTime(1970, 1, 1)).AddSeconds(value);
        }

        /// <summary>
        /// Add x number of business days to supplied DateTime
        /// </summary>
        /// <param name="value">The date to add</param>
        /// <param name="days">Number of days to add. Must be positive</param>
        /// <returns></returns>
        public static DateTime GetNextDay(DateTime value, int days)
        {
            DateTime retVal = value;
            if (days < 0)
            {
                throw new ArgumentException("Can only add a positive number of days")
            }
            else if (days == 0)
            {
                return retVal;
            }
            else
            {
                if (retVal.DayOfWeek == DayOfWeek.Saturday)
                {
                    retVal.AddDays(2); // Move forward to Monday
                    days -= 1;
                }
                else if (retVal.DayOfWeek == DayOfWeek.Sunday)
                {
                    retVal.AddDays(1); // Move forward to Monday
                    days -= 1;
                }

                retVal.AddDays(days / 5 * 7);
                int extraDays = days % 5;

                if ((int)retVal.DayOfWeek + extraDays > 5)
                {
                    extraDays += 2;
                }

                return retVal.AddDays(extraDays);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static double GetBusinessDays(DateTime startDate, DateTime endDate)
        {
            double businessDays =
                1 + ((endDate - startDate).TotalDays * 5 -
                (startDate.DayOfWeek - endDate.DayOfWeek) * 2) / 7;

            if (endDate.DayOfWeek == DayOfWeek.Saturday) businessDays--;
            if (startDate.DayOfWeek == DayOfWeek.Sunday) businessDays--;

            return businessDays;
        }
    }
}