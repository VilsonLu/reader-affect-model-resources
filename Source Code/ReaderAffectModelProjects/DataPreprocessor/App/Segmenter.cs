using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPreprocessor.App {
    public class Segmenter {
        /// <summary>
        /// TIMESTAMP, AF3, T7, Pz, T8, AF4, SEGMENT, PLEASANTNESS, ATTENTION, SENSITIVITY, APPTITUDE, IS_STRIKING, FROM_EVALUATIVE, FROM_NARRATIVE, FROM_AESTHETIC, FROM_OTHERS
        /// </summary>
        private StreamReader mergedLog;
        String savePath = "";

        public Segmenter(String mergedLogPath) {
            // Create savePath
            String file = Path.GetFileName(mergedLogPath);
            String[] words = file.Split('_').Take(2).ToArray();
            savePath = "./Results/" + words[0] + "_" + words[1] + "/02 Segments/";
            Directory.CreateDirectory(savePath);

            mergedLog = new StreamReader(mergedLogPath);
            SegmentLog();
        }

        private void SegmentLog() {
            // Get the header
            String header = "";
            if(!mergedLog.EndOfStream)
                header = mergedLog.ReadLine();

            String currFilename = "";
            int currSegment = 0;

            // While not the end of the file...
            while(!mergedLog.EndOfStream) {
                // Read the line
                String line = mergedLog.ReadLine();
                String[] templine = line.Split(',');

                // Get the lineSegment and compare with currSegment
                int lineSegment = Int16.Parse(templine[6]);
                if(currSegment < lineSegment) {
                    // update currentSegment
                    currSegment++;
                    // create file and append
                    currFilename = CreateOutputFile(header, currSegment, line);

                    Console.WriteLine("Now at segment: "+currSegment);
                } else {
                    // append
                    AppendToFile(currFilename, line);
                }
            }

            Console.WriteLine("DONE SEGMENTING.");
        }

        private String CreateOutputFile(String header, int segment, String line) {
            String file = savePath + "S" + segment+".csv";
            StreamWriter writer = new StreamWriter(file, false);
            writer.WriteLine(header);
            writer.WriteLine(line);
            writer.Close();

            return file;
        }

        private void AppendToFile(String currFilename, String line) {
            StreamWriter writer = new StreamWriter(currFilename, true);
            writer.WriteLine(line);
            writer.Close();
        }
    }
}
