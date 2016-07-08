using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector.FileHandlers {
    public class EmotionLogger : ILogger {
        private string header = "START_TIME, EMOTION, INTENSITY, END_TIME";
        private StreamWriter writer;

        public EmotionLogger(String filename) {
            Initialize(filename);
        }

        public void Initialize(String filename) {
            writer = new StreamWriter(filename);
            writer.AutoFlush = true;
            writer.WriteLine(header);
        }

        /// <summary>
        /// START_TIME, STORY, SEGMENT, EMOTION, INTENSITY, END_TIME
        /// </summary>
        /// <param name="data"></param>
        public void Log(params object[] data) {
            foreach(object d in data)
                writer.Write(d.ToString() + ",");
            writer.WriteLine("");
        }

        public void CloseLogger() {
            writer.Flush();
            writer.Close();
        }
    }
}
