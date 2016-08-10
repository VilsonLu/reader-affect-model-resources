using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmoEegMerger {
    public class Interval {
        public String csvStart { get; set; }
        public String csvEnd { get; set; }
        public DateTime dtStart { get; set; }
        public DateTime dtEnd { get; set; }
        public String content { get; set; }
    }
}
