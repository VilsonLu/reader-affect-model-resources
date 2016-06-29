using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector.App {
    public static class Utilities {
        public static String GetTimestamp() {
            return DateTime.Now.ToString("yyyyMMdd.HHmmss");
        }
    }
}
