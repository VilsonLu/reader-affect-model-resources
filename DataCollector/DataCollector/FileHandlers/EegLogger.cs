using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector.FileHandlers {
    public class EegLogger : ILogger {
        private string header = "TIMESTAMP, AF3, T7, Pz, T8, AF4";
        private String filename;

        public EegLogger(String filename) {
            this.filename = filename;
            Initialize();
        }

        public void Initialize() {
            StreamWriter writer = new StreamWriter(filename, false);
            writer.WriteLine(header);
            writer.Close();
        }

        /// <summary>
        /// TIMESTAMP, AF3, T7, Pz, T8, AF4
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
