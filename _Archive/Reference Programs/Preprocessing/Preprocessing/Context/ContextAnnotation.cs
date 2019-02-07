using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Preprocessing.Context
{
    class ContextAnnotation
    {
        private StreamReader context;
        private StreamReader eeg;
        private StreamWriter write;

        public ContextAnnotation(String contextSource, String eegSource, String destination)
        {
            context = new StreamReader(contextSource);
            eeg = new StreamReader(eegSource);
            write = new StreamWriter(destination);
            doProcessing();
        }

        public void doProcessing()
        {
            List<String> columns = new List<String>();

            //read first row (column labels)
            if (!eeg.EndOfStream)
            {
                String[] eegcolumns = eeg.ReadLine().Split(',');
                for (int i = 0; i < eegcolumns.Length; i++)
                {
                    columns.Add(eegcolumns.ElementAt(i));
                }
            }
            if (!context.EndOfStream)
            {
                String[] contextcolumns = context.ReadLine().Split(',');
                for (int i = 1; i < contextcolumns.Length; i++)         //dont include time column
                {
                    columns.Add(contextcolumns.ElementAt(i));
                }
            }
            StringMethods.writeColumns(columns, write);


            while(!context.EndOfStream && !eeg.EndOfStream)
            {
                
                String[] line = context.ReadLine().Split(',');
                String[] time = line[0].Split('-');
                String[] start = time[0].Split(':');
                String[] end;
                String[] emotiv = eeg.ReadLine().Split(',');
                int timestamp = (int)Math.Floor(Double.Parse(emotiv[22]));

                    //convert to duration in int format
                    int start_time = (Int32.Parse(start[0]) * 60) + Int32.Parse(start[1].Trim());
                    int end_time = 0;

                    if (time.Length > 1)
                    {
                        end = time[1].Split(':');
                        end_time = (Int32.Parse(end[0]) * 60) + Int32.Parse(end[1].Trim());
                    }

                    if (end_time == 0)                                                                  //if action does not reach a second
                    {
                        end_time = start_time;
                    }

                    while (start_time != timestamp)
                    {
                        emotiv = eeg.ReadLine().Split(',');
                        timestamp = (int)Math.Floor(Double.Parse(emotiv[22]));
                    }
                    while (timestamp <= end_time)
                    {
                        StringMethods.writeValues(emotiv, write, false);
                        
                    }
                    //Console.WriteLine("START TIME: {0}, END TIME: {1} CONTEXT: {2}", start_time, end_time, line[1]);
                    eeg.Close();
                    context.Close();
                    write.Close();
                
            }

        }

    }
}
