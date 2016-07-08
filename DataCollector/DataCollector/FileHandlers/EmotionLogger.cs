using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector.FileHandlers {
    public class EmotionLogger : ILogger {
        private string header = "START_TIME, EMOTION, INTENSITY, END_TIME";
        private String filename;

        public EmotionLogger(String filename) {
            ProgramLogger.Log("[EmotionLogger()] Created EmotionLogger instance");
            this.filename = filename;
            Initialize();
        }

        public void Initialize() {
            StreamWriter writer = new StreamWriter(filename, false);
            writer.WriteLine(header);
            writer.Close();
        }

        /// <summary>
        /// START_TIME, STORY, SEGMENT, EMOTION, INTENSITY, END_TIME
        /// </summary>
        /// <param name="data"></param>
        public void Log(params object[] data) {
            StreamWriter writer = new StreamWriter(filename, true);

            foreach(object d in data)
                writer.Write(d.ToString() + ",");
            writer.WriteLine("");

            writer.Close();
        }
    }
}
