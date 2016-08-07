using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector.Models {
    /// <summary>
    /// Data structure for the 'Story,' which is a list of all the segments.
    /// </summary>
    static class Story {
        static public List<Segment> SegmentList { get; set; }
        static public String Title { get; set; }
        static public String Author { get; set; }

        static Story() {
            SegmentList = new List<Segment>();
            Title = "";
            Author = "";
        }

        /// <summary>
        /// Checks if segmentList is empty.
        /// </summary>
        /// <returns>TRUE if segmentList is empty, else FALSE.</returns>
        static public Boolean IsEmpty() {
            if(SegmentList.Any())
                return false;
            else
                return true;
        }

        /// <summary>
        /// Resets the Story data structure.
        /// </summary>
        static public void Reset() {
            SegmentList.Clear();
            Title = "";
            Author = "";
        }
    }

    /// <summary>
    /// Data structure for the 'Segment,' which is a list of all the parts in a particular segment.
    /// </summary>
    public class Segment {
        public int Id { get; set; }
        public List<String> PartList { get; set; }

        public Segment(int segmentCtr) {
            Id = segmentCtr;
            PartList = new List<String>();
        }
    }
}
