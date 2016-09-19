using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPreprocessor.App {
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
        /// <summary>
        /// Data structure counterpart of emoAnno
        /// </summary>
        private List<Interval> intervalList;

        public LogMerger(String emoAnnoPath, String eegAnnoPath) {
            String file = Path.GetFileName(eegAnnoPath);
            IEnumerable<string> words = file.Split('_').Take(2);
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
            String savePath = "./Results/" + filename.Remove(filename.Length-1) + "/01 MergedEmoEeg/";
            Directory.CreateDirectory(savePath);
            String output = savePath+filename+"MergedEmoEeg.csv";
            mergedLog = new StreamWriter(output);
            if(!eegAnno.EndOfStream)
                mergedLog.Write(eegAnno.ReadLine());
            if(!emoAnno.EndOfStream) {
                String[] line = emoAnno.ReadLine().Split(',');
                mergedLog.WriteLine(","+valuesToString(line.Skip(2).ToArray()));
            }
            Console.WriteLine("CREATED "+output);
        }

        /// <summary>
        /// Merges the EEG and Emotion Annotation logs by appending the emotion annotation to the correct EEG timestamp and removing the interval which the annotataion occured.
        /// </summary>
        private void MergeLogFiles() {
            intervalList = new List<Interval>();

            // For each line in emoAnno, create an Interval instance and append it to the intervalList
            while(!emoAnno.EndOfStream) {
                Interval tempInterval = new Interval();
                String line = emoAnno.ReadLine();
                String[] templine = line.Split(',');
                tempInterval.csvStart = templine[0];
                tempInterval.dtStart = Utilities.UNIXTimetoDateTime(Double.Parse(templine[0]));
                tempInterval.csvEnd = templine[1];
                tempInterval.dtEnd = Utilities.UNIXTimetoDateTime(Double.Parse(templine[1]));
                tempInterval.content = valuesToString(templine.Skip(2).ToArray());
                intervalList.Add(tempInterval);
            }

            // For each line in eegAnno, find the nearest Interval it belongs to. Write the data in mergedLog if instance is before the Interval.
            while(!eegAnno.EndOfStream) {
                String line = eegAnno.ReadLine();
                String[] templine = line.Split(',');
                DateTime time = Utilities.UNIXTimetoDateTime(Double.Parse(templine[0]));
                int index = getIndex(time);

                if(index != -1) {
                    bool beforeEND_equalEND = time.CompareTo(intervalList[index].dtEnd) <= 0;
                    bool afterSTART_equalStTART = time.CompareTo(intervalList[index].dtStart) >= 0;
                                            
                    if(beforeEND_equalEND && afterSTART_equalStTART) {
                        // do nothing
                    } else {
                        mergedLog.WriteLine(line + intervalList[index].content);
                    }
                }
            }

            CloseStreams();
        }

        /// <summary>
        /// Gets the index of the nearest Interval the time belongs to.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private int getIndex(DateTime time) {
            for(int i = intervalList.Count-1; i >=0; i--) {
                if(time.CompareTo(intervalList[i].dtStart) == 1)
                    return i;
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
