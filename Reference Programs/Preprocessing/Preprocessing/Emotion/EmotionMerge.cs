using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Preprocessing.Emotion
{
    /// <summary>
    /// This class merges the EEG log with the emotion log
    /// </summary>
    class EmotionMerge
    {
        StreamReader eeg;
        StreamReader emotion;
        StreamWriter write;

        /// <summary>
        /// Constructor. Merges after instantiation.
        /// </summary>
        /// <param name="eeg">Source of EEG file</param>
        /// <param name="emotion">Source of emotion log</param>
        /// <param name="write">Output file</param>
        public EmotionMerge(String eeg, String emotion, String write)
        {
            this.eeg = new StreamReader(eeg);
            this.emotion = new StreamReader(emotion);
            this.write = new StreamWriter(write);
            doProcessing();
        }

        private void init()
        {
            if (!eeg.EndOfStream)
            {
                write.Write(eeg.ReadLine());
            }

            if (!emotion.EndOfStream)
            {
                //still unsure on what to write
                String line = emotion.ReadLine();
                
                write.WriteLine(valuesToString(line.Split(',')));
            }
        }

        public int getIndex(String eegLine, List<String> contextTime)
        {

            DateTime eeg = TimeDateMethods.UNIXTimetoDateTime(Double.Parse(eegLine.Split(',')[0]));//TimeDateMethods.toDateTime(eegLine);
            int count = contextTime.Count - 1;
            for (int i = count; i >= 0; i--)
            {
                if (eeg.CompareTo(TimeDateMethods.UNIXTimetoDateTime(Double.Parse(contextTime[i]))) == 1)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// This function converts to String the values in the middle of an Array
        /// </summary>
        /// <returns></returns>
        private String valuesToString(String[] vals)
        {
            String ret = ",";
            for (int i = 1; i < vals.Length - 2; i++) // skip first and last element
            {
                ret += vals[i] + ",";
            }
            Console.WriteLine("before: {0}", ret);
            ret += vals[vals.Length - 2]; Console.WriteLine("vals.length-3 : {0}", vals[vals.Length - 2]);
            Console.WriteLine("before: {0}", ret);
            return ret;
        }

        private void doProcessing()
        {
            init();
            //add to List
            List<String> timestart = new List<String>();
            List<String> timeend = new List<String>();
            List<String> contents = new List<String>();
            while (!emotion.EndOfStream)
            {
                String readline = emotion.ReadLine();
                String[] templine = readline.Split(',');
                timestart.Add(templine[0]);
                timeend.Add(templine[templine.Length - 1]); //timeend.Add(templine[6]);
                contents.Add(valuesToString(templine));
                //contents.Add(templine[1]+","+templine[2]+","+templine[3]+","+templine[4]+","+templine[5]);
            }

            while (!eeg.EndOfStream)
            {
                String line = eeg.ReadLine();
                String[] templine = line.Split(',');
                DateTime time = TimeDateMethods.UNIXTimetoDateTime(Double.Parse(templine[0]));
                int index = getIndex(line, timestart);
                
                if (index != -1)
                {
                    
                    bool beforeEND_equalEND = time.CompareTo(TimeDateMethods.UNIXTimetoDateTime(Double.Parse(timeend[index]))) == 0 || time.CompareTo(TimeDateMethods.UNIXTimetoDateTime(Double.Parse(timeend[index]))) == -1;
                    bool afterSTART_equalStTART = time.CompareTo(TimeDateMethods.UNIXTimetoDateTime(Double.Parse(timestart[index]))) == 0 || time.CompareTo(TimeDateMethods.UNIXTimetoDateTime(Double.Parse(timestart[index]))) == 1;
                    //Console.WriteLine("EEG: {0}\tCONTEXT: {1} : {2} ", time, timestamps[index],rows[index]);
                    if (beforeEND_equalEND && afterSTART_equalStTART)
                    {
                        
                    }
                    else
                    {
                        write.WriteLine(line + contents[index]);
                    }
                }
            }

            write.Close();
            eeg.Close();
            emotion.Close();
        }
    }
}
