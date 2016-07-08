using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector.FileHandlers {
    class ProgramLogger : ILogger {
        private static StreamWriter writer;
        private static Boolean isOpen = false;
        public ProgramLogger() {

        }

        public void Initialize(string filename) {
            throw new NotImplementedException();
        }

        public void Log(params object[] data) {
            throw new NotImplementedException();
        }

        public void CloseLogger() {
            throw new NotImplementedException();
        }
    }
}
