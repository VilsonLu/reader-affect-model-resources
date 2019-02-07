using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Preprocessing
{
    /// <summary>
    /// This class provides functions for conversion to different Time formats
    /// </summary>
    class TimeDateMethods
    {
        /// <summary>
        /// Convert UNIX Time to DateTime object
        /// </summary>
        /// <param name="tempTime"></param>
        /// <returns>Returns a DateTime object with a date: January 1, 1970</returns>
        public static DateTime UNIXTimetoDateTime(double tempTime)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(tempTime).ToLocalTime();
        }

        public static DateTime StringtoDateTime(String dateTime)
        {
            return Convert.ToDateTime(dateTime);
        }

        /// <summary>
        /// Converts a timestamp String to DateTime
        /// </summary>
        /// <param name="year">Integer representation of the year</param>
        /// <param name="month">Integer representation of the month</param>
        /// <param name="day">Integer representation of the day</param>
        /// <param name="timestamp">String timestamp with format: hh:mm:ss AM/PM</param>
        /// <returns></returns>
        public static DateTime toDateTime(int year, int month, int day, String timestamp)
        {
            String[] templine = timestamp.Split(',')[1].Split(':');
            int h = Int16.Parse(templine[0].Trim());
            int m = Int16.Parse(templine[1]);
            int s = Int16.Parse(templine[2].Split(' ')[0]);         //Remove AM/PM
            return new DateTime(year, month, day, h, m, s);
        }

        /// <summary>
        /// Converts a timestamp String to DateTime
        /// Date is set to January 1, 2011
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static DateTime toDateTime(String timestamp)
        {
            return toDateTime(2011, 1, 1, timestamp);
        }


        public static DateTime stringToDateTime(int year, int month, int day, String time)
        {
            String[] templine = time.Split(':');
            int h = Int16.Parse(templine[0].Trim());
            int m = Int16.Parse(templine[1]);
            int s = Int16.Parse(templine[2].Split(' ')[0]);
            return new DateTime(year, month, day, h, m, s);
        }

        public static DateTime stringToDateTime(String time)
        {
            return stringToDateTime(2011, 1, 1, time);
        }
    }
}
