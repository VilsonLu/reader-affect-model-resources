using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector.FileHandlers {
    public class EmotivLogger : ILogger {
        private string header = "TIMESTAMP, AF3, T7, Pz, T8, AF4";
        private StreamWriter writer;

        public EmotivLogger(String filename) {
            Initialize(filename);
        }

        public void Initialize(String filename) {
            writer = new StreamWriter(filename);
            writer.AutoFlush = true;
            writer.WriteLine(header);
        }

        /// <summary>
        /// TIMESTAMP, AF3, T7, Pz, T8, AF4
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
