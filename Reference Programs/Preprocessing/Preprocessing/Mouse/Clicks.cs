using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Preprocessing.Mouse
{
    class Clicks
    {
        private StreamReader clicks;
        private StreamReader eeg;
        private StreamWriter write;

        public Clicks(String clicksSource, String eegSource, String writeOutput)
        {
            clicks = new StreamReader(clicksSource);
            eeg = new StreamReader(eegSource);
            write = new StreamWriter(writeOutput);
        }

        public void doProcessing()
        {
            //write column headers
            StringMethods.writeColumns(StringMethods.getColumnLabels(eeg, clicks), write);

            String duration = "";
            String time = "";
            String button = "";
            String[] writeline = new String[3];                                                         //time, button, duration
            //map clicks to eeg time
            while (!clicks.EndOfStream)
            {
                String line = clicks.ReadLine();
                if (line.StartsWith("Duration:"))
                {
                    duration = line.Split(' ')[1];                                                      //click duration (in milliseconds)
                    writeline[0] = time;
                    writeline[1] = button;
                    writeline[2] = duration;




                    StringMethods.writeValues(writeline, write, true);                                    //write

                    //reset variables for possible inconsistencies in the file
                    time = ""; button = ""; duration = "";
                }
                else
                {                                                                                       //found new instance of click
                    duration = "";                                                                      //reset duration
                    String[] temp = line.Split(' ');
                    time = temp[4];                                                                     //time
                    button = temp[7] + temp[8];                                                         //button
                }
            }


        }

    }
}
