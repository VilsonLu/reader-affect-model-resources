using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector.FileHandlers {
    /// <summary>
    /// Data structure for the 'Story,' which is a list of all the segments.
    /// </summary>
    static class Story {
        static public List<Segment> segmentList { get; set; }
        static public String title { get; set; }
        static public String author { get; set; }
        static Story() {
            segmentList = new List<Segment>();
            title = "";
            author = "";
        }

        /// <summary>
        /// Checks if segmentList is empty.
        /// </summary>
        /// <returns>TRUE if segmentList is empty, else FALSE.</returns>
        static public Boolean IsEmpty() {
            if(segmentList.Any())
                return false;
            else
                return true;
        }

        /// <summary>
        /// Resets the Story data structure.
        /// </summary>
        static public void Reset() {
            segmentList.Clear();
            title = "";
            author = "";
        }
    }

    /// <summary>
    /// Data structure for the 'Segment,' which is a list of all the parts in a particular segment.
    /// </summary>
    public class Segment {
        public int id { get; set; }
        public List<String> partList { get; set; }

        public Segment(int segmentCtr) {
            id = segmentCtr;
            partList = new List<String>();
        }
    }
}
