using DataCollector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector.App {
    public static class StoryNavigator {
        /// <summary>
        /// Index of the previous story segment.
        /// </summary>
        public static int segPrev { get; set; }
        /// <summary>
        /// Index of the current story segment.
        /// </summary>
        public static int segCurr { get; set; }

        /// <summary>
        /// Creates an instance of the StoryNavigator.
        /// </summary>
        static StoryNavigator() {
            Reset();
        }
        
        /// <summary>
        /// Increments the index number of the current and previous story segments.
        /// </summary>
        public static void Next() {
            segPrev++;
            segCurr++;
        }

        /// <summary>
        /// Checks if it is the first story segment.
        /// </summary>
        /// <returns>TRUE if it is the first segment, else FALSE.</returns>
        public static Boolean IsFirstSegment() {
            if(segCurr == 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks if it is the last story segment.
        /// </summary>
        /// <returns>TRUE if it is the last segment, else FALSE.</returns>
        public static Boolean IsLastSegment() {
            if(segCurr == Story.SegmentList.Count)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks if it is the last story segment.
        /// </summary>
        /// <returns>TRUE if it is the last segment, else FALSE.</returns>
        public static Boolean IsLastSegmentIndexBased() {
            if(segCurr == (Story.SegmentList.Count-1))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Builds the segment given a list of its parts.
        /// </summary>
        /// <param name="sentenceList">List of the parts within the segment.</param>
        /// <returns>String representation of the segment with indentation.</returns>
        public static String ParagraphBuilder(List<String> sentenceList) {
            String paragraph = "";
            String indent = "     ";

            foreach(String sen in sentenceList) {
                paragraph += indent + sen + "\n";
            }
        
            return paragraph;
        }

        /// <summary>
        /// Resets the current and previous indices.
        /// </summary>
        public static void Reset() {
            segPrev = -2;
            segCurr = -1;
        }
    }
}
