using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Preprocessing.Header;

namespace Preprocessing
{
    class FileFormat
    {
        public static Observatory[] Observatory = { Header.Observatory.IGNORE, Header.Observatory.TIMESTAMP, Header.Observatory.IGNORE, Header.Observatory.IGNORE, Header.Observatory.IGNORE, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.IGNORE, Header.Observatory.IGNORE, Header.Observatory.IGNORE, Header.Observatory.IGNORE, Header.Observatory.IGNORE, Header.Observatory.IGNORE, Header.Observatory.IGNORE, Header.Observatory.IGNORE, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS };
        public static Observatory[] Baseline = { Header.Observatory.IGNORE, Header.Observatory.IGNORE, Header.Observatory.IGNORE, Header.Observatory.IGNORE, Header.Observatory.IGNORE, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.IGNORE, Header.Observatory.IGNORE, Header.Observatory.TIMESTAMP, Header.Observatory.IGNORE, Header.Observatory.IGNORE, Header.Observatory.IGNORE, Header.Observatory.IGNORE, Header.Observatory.IGNORE, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS, Header.Observatory.PROCESS };
        //public static Observatory[] Clicks = { Header.Observatory.PROCESS, Header.Observatory.};
    }
}
