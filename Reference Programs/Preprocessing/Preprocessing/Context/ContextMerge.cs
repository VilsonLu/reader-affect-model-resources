using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Preprocessing.Context
{
    /// <summary>
    /// Class for merging the distilled context file
    /// </summary>
    class ContextMerge
    {
        private StreamWriter write;
        private StreamReader context;
        private StreamReader eeg;

        /// <summary>
        /// Does the merging after instantiation
        /// </summary>
        /// <param name="eeg">Full name of the eeg file</param>
        /// <param name="context">Full name of context file</param>
        /// <param name="output">Full name of the output file</param>
        public ContextMerge(String eeg, String context, String output)
        {
            this.eeg = new StreamReader(eeg);
            this.context = new StreamReader(context);
            this.write = new StreamWriter(output);
            doProcessing();
        }


        private void init()
        {
            if (!eeg.EndOfStream)
            {
                write.Write(eeg.ReadLine());
            }

            if (!context.EndOfStream)
            {
                write.WriteLine(","+context.ReadLine().Split(',')[1]);
            }
        }

        private int getIndex(String eegLine, List<String> contextTime)
        {
            DateTime eeg = TimeDateMethods.toDateTime(eegLine);
            int count = contextTime.Count-1;
            for (int i = count; i >= 0 ; i--)
            {
                if (eeg.CompareTo(TimeDateMethods.stringToDateTime(contextTime[i])) == 1)
                {
                    return i;
                }
            }
            return -1;
        }

        private void doProcessing()
        {
            init();
            List<String> timestamps = new List<String>();
            List<String> rows = new List<String>();

            while (!context.EndOfStream)                                        //add to list
            {                
                String line = context.ReadLine();
                String[] templine = line.Split(',');
                String time = templine[0];

                if(!timestamps.Contains(time))
                {
                    timestamps.Add(time);
                    rows.Add(templine[1]);
                }
            }
            
            while (!eeg.EndOfStream)
            {
                String line = eeg.ReadLine();
                String[] templine = line.Split(',');
                String time = templine[1];
                
                int index = getIndex(line, timestamps);
                if (index != -1)
                {
                    //Console.WriteLine("EEG: {0}\tCONTEXT: {1} : {2} ", time, timestamps[index],rows[index]);
                    write.WriteLine(line + "," + rows[index]);
                }
            }

            eeg.Close();
            context.Close();
            write.Close();
        }


    }

    
}
