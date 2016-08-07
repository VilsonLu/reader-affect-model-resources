using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmoEegMerger {
    public class LogMerger {
        /// <summary>
        /// START_TIME, END_TIME, SEGMENT, PLEASANTNESS, ATTENTION, SENSITIVITY, APPTITUDE, IS_STRIKING, FROM_EVALUATIVE, FROM_NARRATIVE, FROM_AESTHETIC, FROM_OTHERS
        /// </summary>
        private StreamReader emoAnno;
        /// <summary>
        /// TIMESTAMP, AF3, T7, Pz, T8, AF4
        /// </summary>
        private StreamReader eegAnno;
        /// <summary>
        /// TIMESTAMP, AF3, T7, Pz, T8, AF4, SEGMENT, PLEASANTNESS, ATTENTION, SENSITIVITY, APPTITUDE, IS_STRIKING, FROM_EVALUATIVE, FROM_NARRATIVE, FROM_AESTHETIC, FROM_OTHERS
        /// </summary>
        private StreamWriter mergedLog;

        public LogMerger(String emoAnnoPath, String eegAnnoPath) {
            String file = Path.GetFileName(eegAnnoPath);
            IEnumerable<string> words = file.Split('_').Take(3);
            String filename = "";
            foreach(String word in words)
                filename += word + "_";

            emoAnno = new StreamReader(emoAnnoPath);
            eegAnno = new StreamReader(eegAnnoPath);
            CreateOutputFile(filename);
            MergeLogFiles();
        }

        /// <summary>
        /// Creates the output file and writes the header.
        /// </summary>
        /// <param name="filename"></param>
        private void CreateOutputFile(String filename) {
            String output = "./Results/" + filename +"MergedEmoEeg.csv";
            mergedLog = new StreamWriter(output);
            if(!eegAnno.EndOfStream)
                mergedLog.Write(eegAnno.ReadLine());
            if(!emoAnno.EndOfStream) {
                String[] line = emoAnno.ReadLine().Split(',');
                mergedLog.WriteLine(","+valuesToString(line.Skip(2).ToArray()));
            }
            Console.WriteLine("CREATED "+output);
        }

        private void MergeLogFiles() {
            List<String> timeStart = new List<String>();
            List<String> timeEnd = new List<String>();
            List<String> content = new List<String>();

            while(!emoAnno.EndOfStream) {
                String line = emoAnno.ReadLine();
                String[] templine = line.Split(',');
                timeStart.Add(templine[0]);
                timeEnd.Add(templine[1]);
                content.Add(valuesToString(templine.Skip(2).ToArray()));
            }

            while(!eegAnno.EndOfStream) {
                String line = eegAnno.ReadLine();
                String[] templine = line.Split(',');
                DateTime time = Utilities.UNIXTimetoDateTime(Double.Parse(templine[0]));
                int index = getIndex(time, timeStart);

                if(index != -1) {
                    bool beforeEND_equalEND = time.CompareTo(Utilities.UNIXTimetoDateTime(Double.Parse(timeEnd[index]))) == 0 || time.CompareTo(Utilities.UNIXTimetoDateTime(Double.Parse(timeEnd[index]))) == -1;
                    bool afterSTART_equalStTART = time.CompareTo(Utilities.UNIXTimetoDateTime(Double.Parse(timeStart[index]))) == 0 || time.CompareTo(Utilities.UNIXTimetoDateTime(Double.Parse(timeStart[index]))) == 1;
                    if(beforeEND_equalEND && afterSTART_equalStTART) {

                    } else {
                        mergedLog.WriteLine(line + content[index]);
                    }
                }
            }

            CloseStreams();
        }

        private int getIndex(DateTime time, List<String> contextTime) {
            /*int count = contextTime.Count - 1;
            for(int i = count; i >= 0; i--) {
                if(time.CompareTo(Utilities.UNIXTimetoDateTime(Double.Parse(contextTime[i]))) == 1) {
                    return i;
                }
            }*/
            int i = 0;
            foreach (String t in contextTime) {
                if(time.CompareTo(Utilities.UNIXTimetoDateTime(Double.Parse(contextTime[i]))) == 1)
                    return i;
                i++;
            }
            return -1;
        }

        /// <summary>
        /// Closes the file streams.
        /// </summary>
        private void CloseStreams() {
            Console.WriteLine("CLOSE STREAMS");
            mergedLog.Close();
            emoAnno.Close();
            eegAnno.Close();
        }

        /// <summary>
        /// Converts the array of values to a single String for the output CSV file.
        /// </summary>
        /// <returns></returns>
        private String valuesToString(String[] values) {
            String line = "";

            foreach(String val in values)
                line += val + ",";

            return line;
        }
    }
}
