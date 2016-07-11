using DataCollector.App;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector.FileHandlers {
    static class ProgramLogger {
        private static StreamWriter writer;
        private static String filename;

        public static void Initialize() {
            String ts = Utilities.GetTimestamp();
            filename = "./Logs/ProgramLog_" + ts + ".log";
            writer = new StreamWriter(filename, false);
            writer.WriteLine("PROGRAM LOG FOR RUN-"+ts);
            writer.Close();
        }

        public static void Log(String text) {
            writer = new StreamWriter(filename, true);
            writer.WriteLine(text);
            writer.Close();
        }
    }
}
