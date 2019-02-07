using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Preprocessing.Mouse
{
    /// <summary>
    /// This class merges EEG log with the processed movement file
    /// </summary>
    class MergeMovement
    {
        StreamWriter write;
        StreamReader movement;
        StreamReader eeg;
        /// <summary>
        /// Constructor. Merges after instantiation
        /// </summary>
        /// <param name="eegname">Full name of EEG file</param>
        /// <param name="movementname">Full name of processed movement file</param>
        /// <param name="output">Full name of output file</param>
        public MergeMovement(String eegname, String movementname, String output)
        {
            eeg = new StreamReader(eegname);
            movement = new StreamReader(movementname);
            write = new StreamWriter(output);
            doProcessing();
        }

        private void doProcessing()
        {
            Dictionary<String, String> d = new Dictionary<String, String>();    //hashmap for movement
            String columns = eeg.ReadLine();                                    //read eeg columns

            columns += ",Frequency";                                            //add column for movement
            write.WriteLine(columns);                                           //write column headers
            if (!movement.EndOfStream)
                movement.ReadLine();
            while (!movement.EndOfStream)                                       //add to hashmap values from movement
            {
                String[] s = movement.ReadLine().Split(',');
                String[] temp = s[0].Split(' ');

                String timestamp = temp[1].Trim() + " " + temp[2];
                d.Add(timestamp, s[1]);
            }

            while (!eeg.EndOfStream)                                             //map hashmap to eeg
            {
                String line = eeg.ReadLine();
                String time = line.Split(',')[1];
                if (d.ContainsKey(time))
                    write.WriteLine(line + "," + d[time]);
                else
                    write.WriteLine(line+",0");
            }

            eeg.Close();
            movement.Close();
            write.Close();
        }
    }
}
