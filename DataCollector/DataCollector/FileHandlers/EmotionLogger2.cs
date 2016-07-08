using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataCollector.FileHandlers {
    public class EmotionLogger2 {
        private StreamWriter writer;
        private string header = "START_TIME, EMOTION, INTENSITY, END_TIME";

        /// <summary>
        /// Creates an instance of the EmotionLogger and corresponding output file.
        /// </summary>
        /// <param name="filename"></param>
        public EmotionLogger2(String filename) {
            writer = new StreamWriter(filename);
            writer.AutoFlush = true;
            writer.WriteLine(header);
        }

        /// <summary>
        /// Appends the paramerter values to the EmotionAnnotation.csv file.
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="emotion"></param>
        /// <param name="intensity"></param>
        /// <param name="endTime"></param>
        public void LogValues(String startTime, String emotion, int intensity, String endTime) {
            writer.WriteLine(startTime + "," + emotion + "," + intensity.ToString() + "," + endTime);
        }

        /// <summary>
        /// Closes the writer.
        /// </summary>
        public void Close() {
            writer.Flush();
            writer.Close();
        }
    }
}