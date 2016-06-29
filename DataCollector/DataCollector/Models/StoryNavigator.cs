using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector.FileHandlers {
    static class StoryNavigator {
        //Story story;
        /// <summary>
        /// Index of the previous story segment.
        /// </summary>
        static public int segPrev { get; set; }
        /// <summary>
        /// Index of the current story segment.
        /// </summary>
        static public int segCurr { get; set; }

        static StoryNavigator() {
            Reset();
        }
        
        /// <summary>
        /// Increments the index number of the current and previous story segments.
        /// </summary>
        public static void Next() {
            segPrev++;
            segCurr++;
            Console.Write("prev: " + segPrev);
            Console.Write("curr: " + segCurr);
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

            //Console.Write("HELLO: " + paragraph);
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
