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
    }
}