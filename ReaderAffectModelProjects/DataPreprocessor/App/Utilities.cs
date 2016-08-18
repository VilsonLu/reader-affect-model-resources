using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPreprocessor.App {
    public static class Utilities {
        /// <summary>
        /// Convert UNIX Time to DateTime object
        /// </summary>
        /// <param name="tempTime"></param>
        /// <returns>Returns a DateTime object with a date: January 1, 1970</returns>
        public static DateTime UNIXTimetoDateTime(double tempTime) {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(tempTime).ToLocalTime();
        }
    }
}
