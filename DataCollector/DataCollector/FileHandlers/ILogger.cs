using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector.FileHandlers {
    interface ILogger {
        /// <summary>
        /// Initializes the Writer and the corresponding output file.
        /// </summary>
        void Initialize();
        /// <summary>
        /// Logs the data to the output file.
        /// </summary>
        /// <param name="data"></param>
        void Log(params Object[] data);
    }
}
