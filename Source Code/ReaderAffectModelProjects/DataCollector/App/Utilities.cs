using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector.App {
    public static class Utilities {
        /// <summary>
        /// Returns the current timestamp in yyyyMMdd-HHmmss format.
        /// </summary>
        /// <returns></returns>
        public static String GetTimestamp() {
            return DateTime.Now.ToString("yyyyMMdd-HHmmss");
        }

        /// <summary>
        /// Returns the timestamp for the CSV files.
        /// </summary>
        /// <returns></returns>
        public static double GetCsvTimestamp() {
            return (DateTime.Now.ToLocalTime() - new DateTime(1970, 1, 1).ToLocalTime()).TotalMilliseconds;
        }

        /// <summary>
        /// Returns the resulting stream of the input.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Stream GenerateStream(string s) {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;

            return stream;
        }

        /// <summary>
        /// Given the number of seconds, it formats it into 00m:00s counterpart.
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static String GetTimerFormat(int seconds) {
            TimeSpan t = TimeSpan.FromSeconds(seconds);
            return String.Format("({0:D2}m:{1:D2}s)", t.Minutes, t.Seconds);
        }
    }
}
