using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Preprocessing.Context
{
    class ContextAnnotationMOD
    {
        private int duration_index = 1;
        private StreamReader context;
        private StreamReader eeg;
        private StreamWriter write;

        public ContextAnnotationMOD(String contextSource, String eegSource, String destination)
        {
            context = new StreamReader(contextSource);
            eeg = new StreamReader(eegSource);
            write = new StreamWriter(destination);
            doProcessing();
        }



        public void doProcessing()
        {
            List<String> columns = new List<String>();
            //Console.WriteLine("entered do processing");

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
                String con = context.ReadLine();
                if (String.IsNullOrEmpty(con))
                {
                    //Console.WriteLine("waa");
                    break;
                }
                else
                {
                    String[] line = con.Split(',');
                    String[] time = line[0].Split('-');
                    String[] start = time[0].Split(':');
                    String[] end;
                    String[] emotiv = eeg.ReadLine().Split(',');
                    //Console.WriteLine(start);
                    int timestamp = (int)Math.Floor(Double.Parse(emotiv[duration_index]));

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

                    //search for matching timestamp
                    if(timestamp == start_time)
                        StringMethods.writeValues(emotiv, write, true);

                    while ((!(start_time < timestamp && end_time > timestamp)) && (!context.EndOfStream || !eeg.EndOfStream))
                    {
                        emotiv = eeg.ReadLine().Split(',');
                        timestamp = (int)Math.Floor(Double.Parse(emotiv[duration_index]));

                        if (timestamp == start_time)
                        {
                            emotiv = StringMethods.addToLast(emotiv, line[1]);
                            if (line.Length > 2)
                                emotiv = StringMethods.addToLast(emotiv, line[2]);
                            StringMethods.writeValues(emotiv, write, true);
                        }
                        if(timestamp == end_time+1)
                            StringMethods.writeValues(emotiv, write, true);
                    }

                    while ((timestamp <= end_time && start_time <= timestamp) && (!context.EndOfStream || !eeg.EndOfStream))
                    {
                        emotiv = StringMethods.addToLast(emotiv, line[1]);

                        if (line.Length > 2)
                            emotiv = StringMethods.addToLast(emotiv, line[2]);

                        StringMethods.writeValues(emotiv, write, true);// Console.WriteLine("WRITE" + emotiv[1]);                                      //only one instance
                        
                        emotiv = eeg.ReadLine().Split(',');
                        timestamp = (int)Math.Floor(Double.Parse(emotiv[duration_index]));
                    }

                    if (timestamp == end_time + 1)
                    {
                        emotiv = StringMethods.addToLast(emotiv, line[1]);

                        if (line.Length > 2)
                            emotiv = StringMethods.addToLast(emotiv, line[2]);

                        StringMethods.writeValues(emotiv, write, true); //Console.WriteLine("WRITE" + emotiv[1]);           
                    }

                
                    //Console.WriteLine("START TIME: {0}, END TIME: {1} CONTEXT: {2}", start_time, end_time, line[1]);             
                }
            }
            
            eeg.Close();
            context.Close();
            write.Close();
        }
    }
}
