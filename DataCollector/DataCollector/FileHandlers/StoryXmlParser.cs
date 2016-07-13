using DataCollector.App;
using DataCollector.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DataCollector.FileHandlers {
    public static class StoryXmlParser {
        /// <summary>
        /// Returns the resulting Story data structure of the selectedStory.
        /// </summary>
        /// <param name="selectedStory"></param>
        public static void ParseFile(Stories selectedStory) {
            XmlDocument xmlStory = new XmlDocument();
            List<Segment> parsedStory = new List<Segment>();
            int segmentCtr = 1;

            // Load the story
            xmlStory.Load(GetStoryStream(selectedStory));

            // Get the title and the author
            XmlAttributeCollection storyAttributes = xmlStory.SelectSingleNode("/story").Attributes;
            Story.Title = storyAttributes["title"].Value;
            Story.Author = storyAttributes["author"].Value;

            // Get all the 'segment' nodes
            XmlNodeList segmentNodeList = xmlStory.SelectNodes("/story/segment");
            foreach(XmlNode segment in segmentNodeList) {
                Segment tempSegment = new Segment(segmentCtr);

                // Get all the 'part' nodes in the 'segment'
                XmlNodeList partNodeList = segment.SelectNodes("part");
                foreach(XmlNode part in partNodeList) {
                    String PartSentence;
                    PartSentence = part.InnerText;
                    tempSegment.PartList.Add(PartSentence);
                }

                segmentCtr++;
                parsedStory.Add(tempSegment);
            }
            Story.SegmentList = parsedStory;
        }

        /// <summary>
        /// Returns the stream of the selected story.
        /// </summary>
        /// <param name="story"></param>
        /// <returns></returns>
        private static Stream GetStoryStream(Stories story) {
            switch(story) {
                case Stories.TEST:
                    return Utilities.GenerateStream(Properties.Resources.Test);
                case Stories.MFTS:
                    return Utilities.GenerateStream(Properties.Resources.ManFromTheSouth);
                case Stories.TFATJ:
                    return Utilities.GenerateStream(Properties.Resources.TheFishermanAndTheJinni);
                case Stories.TV:
                    return Utilities.GenerateStream(Properties.Resources.TheVeldt);
                default:
                    return Utilities.GenerateStream(Properties.Resources.Test);
            }
        }
    }
}
