using DataCollector.FileHandlers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DataCollector.FileHandlers {
    public static class StoryXmlParser {
        /// <summary>
        /// Returns the resulting Story data structure of the XML file.
        /// </summary>
        /// <param name="xmlPath">Path where the XML file is located.</param>
        public static void ParseFile(String xmlPath) {
            XmlDocument xmlStory = new XmlDocument();
            List<Segment> parsedStory = new List<Segment>();
            int segmentCtr = 0;

            // Load the XML path
            xmlStory.Load(xmlPath);

            XmlAttributeCollection storyAttributes = xmlStory.SelectSingleNode("/story").Attributes;
            Story.title = storyAttributes["title"].Value;
            Story.author = storyAttributes["author"].Value;

            // Get all the 'segment' nodes
            XmlNodeList segmentNodeList = xmlStory.SelectNodes("/story/segment");
            foreach(XmlNode segment in segmentNodeList) {
                Segment tempSegment = new Segment(segmentCtr);

                // Get all the 'part' nodes in the 'segment'
                XmlNodeList partNodeList = segment.SelectNodes("part");
                foreach(XmlNode part in partNodeList) {
                    String PartSentence;
                    PartSentence = part.InnerText;
                    tempSegment.partList.Add(PartSentence);
                }

                segmentCtr++;
                parsedStory.Add(tempSegment);
            }

            Story.segmentList = parsedStory;
        }
    }
}
