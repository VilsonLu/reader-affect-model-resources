using DataCollector.FileHandlers;
using DataCollector.FileHandlers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector.Controller {
    public class Driver {
        MainFrame frame;
        
        public Driver() {
            frame = new MainFrame();

            /*Story.segmentList = XmlParser.ParseFile("../../Resources/test.xml");
            foreach (Segment seg in Story.segmentList) {
                foreach (String sen in seg.sentenceList) {
                    Console.WriteLine("{0}: {1}", seg.id, sen);
                }
            }

            String temp = Story.ParagraphBuilder(Story.segmentList[1].sentenceList);
            Console.Write("Paragraph:\n"+temp);*/
        }
    }
}
