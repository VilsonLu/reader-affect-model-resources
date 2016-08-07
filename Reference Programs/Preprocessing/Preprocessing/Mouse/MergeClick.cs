using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Preprocessing.Mouse
{
    /// <summary>
    /// This class merges EEG log and mouse click log
    /// </summary>
    class MergeClick
    {
        private StreamWriter write;
        private StreamReader click;
        private StreamReader eeg;

        /// <summary>
        /// Constructor. Does processing after instantiated.
        /// </summary>
        /// <param name="eeg">Full name of eeg file</param>
        /// <param name="click">Full name of mouse clicks log</param>
        /// <param name="write">Output file full name</param>
        public MergeClick(String eeg, String click, String write)
        {
            this.eeg = new StreamReader(eeg);
            this.click = new StreamReader(click);
            this.write = new StreamWriter(write);
            doProcessing();
        }

        private void init()
        {
            if (!eeg.EndOfStream)
            {
                write.Write(eeg.ReadLine());
            }
            if (!click.EndOfStream)
            {
                write.WriteLine(",Clicks,Duration");
            }
        }
        
        private void doProcessing()
        {
            init();

            String duration = "";
            String time = "";
            String button = "";

            Dictionary<String, int> clickbutton = new Dictionary<String, int>();
            Dictionary<String, int> clickduration = new Dictionary<String, int>(); 
            String firstline = "";
            String secondline = "";
            String[] store = new String[2];
            bool hasClick = false;
            //add to hashmap
            while (!click.EndOfStream)
            {
                String line = click.ReadLine();
                
                if(line.Contains("Duration") && hasClick)//duration
                {
                    //d.Add(store[0], store[1] + "," + extractDuration(secondline));
                    //secondline = line;
                    if (!clickbutton.ContainsKey(store[0]))
                    {
                        clickbutton.Add(store[0], 1);
                        clickduration.Add(store[0], Int32.Parse(extractDuration(line)));
                    }
                    else
                    {
                        int c = clickbutton[store[0]];
                        int d = clickduration[store[0]];

                        c++;
                        d+= Int32.Parse(extractDuration(line));

                        clickbutton.Remove(store[0]);
                        clickduration.Remove(store[0]);
                        clickbutton.Add(store[0], c);
                        clickduration.Add(store[0], d);
                    }
                    hasClick = false;
                }
                else
                {
                    store = extractClicks(line);
                    hasClick = true;
                }
            }

            //count number of clicks 
            while (!eeg.EndOfStream)
            {
                String line = eeg.ReadLine();
                String[] templine = line.Split(',');
                if (clickbutton.ContainsKey(templine[1]))
                {
                    write.WriteLine(line + "," + clickbutton[templine[1]] + "," + clickduration[templine[1]]);
                }
                else
                {
                    write.WriteLine(line + ",0,0");
                }
            }
            eeg.Close();
            click.Close();
            write.Close();
        }


        private String extractDuration(String line)
        {
            return line.Split(' ')[1].Trim();
        }

        /*
         * result[0] = timestamp
         * result[1] = left or right click
         * */
        private String[] extractClicks(String line)
        {
            String[] temp = line.Split(' ');
            String[] temp2 = line.Split(':');
            String[] result = new String[2];
            result[0] = temp[4] + " " + temp[5].Split(':')[0];
            result[1] = temp2[3].Trim();

            return result;
        }
    }
}
