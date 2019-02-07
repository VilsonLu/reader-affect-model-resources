using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Preprocessing.Emotion;
using Preprocessing.Brainwaves;

namespace Preprocessing.Emotion
{
    class EmotionMergeEEGRemove
    {
        private StreamReader eeg;
        private StreamReader emo;
        private StreamWriter output;

        private static int[] columns = EEG1Sec.columns;
        private static int offset = EEG1Sec.offset;

        public EmotionMergeEEGRemove(String eeg, String emo, String output)
        {
            this.eeg = new StreamReader(eeg);
            this.emo = new StreamReader(emo);
            this.output = new StreamWriter(output);
            doProcessing();
        }

        public void init()
        {
            if (!eeg.EndOfStream)
                output.Write(eeg.ReadLine());

            if (!emo.EndOfStream)
            {
                String[] temp = emo.ReadLine().Split(',');
                output.WriteLine("{0},{1},{2},{3},{4}", temp[1], temp[2], temp[3], temp[4], "Difficulty");
            }
        }

        
        public void doProcessing()
        {
            init();
            List<EmotionInstance> lei = new List<EmotionInstance>();

            while (!emo.EndOfStream)
            {
                lei.Add(new EmotionInstance(emo.ReadLine()));
            }

            /*
            String readline = eeg.ReadLine();
            String[] templine = readline.Split(',');
            for (int i = 0; i < lei.Count; i++)
            {
                DateTime current = TimeDateMethods.UNIXTimetoDateTime(Double.Parse(templine[0]));
                //look for when time is equal or before ei[i]
                bool before = lei[i].Timestart.CompareTo(current) == -1;
                bool equal = lei[i].Timestart.CompareTo(current) == 0;
                bool after = lei[i].Timestart.CompareTo(current) == 1;

                while (after && !before && !equal && (lei[i].Timeend.CompareTo(current) == 1 || lei[i].Timeend.CompareTo(current) == 0) && !eeg.EndOfStream)
                {
                    before = lei[i].Timestart.CompareTo(current) == -1;
                    equal = lei[i].Timestart.CompareTo(current) == 0;
                    after = lei[i].Timestart.CompareTo(current) == 1;


                    readline = eeg.ReadLine();
                    templine = readline.Split(',');
                    current = TimeDateMethods.UNIXTimetoDateTime(Double.Parse(templine[0]));
                    //Console.WriteLine("{0} - {1}", templine[1], templine[2]);

                }

                while ((before || equal) && !eeg.EndOfStream)           //while lei[i].Timestart is before current timestamp
                {
                    //write
                    //output.WriteLine(readline + "," + EmotionInstance.removeLast(EmotionInstance.removeFirst(readline, ','), ','));
                    readline = eeg.ReadLine();
                    templine = readline.Split(',');
                    current = TimeDateMethods.UNIXTimetoDateTime(Double.Parse(templine[0]));
                    
                    before = lei[i].Timestart.CompareTo(current) == -1;
                    equal = lei[i].Timestart.CompareTo(current) == 0;
                    after = lei[i].Timestart.CompareTo(current) == 1;

                    if (current.CompareTo(lei[i].Timeend) == 1 || (current.CompareTo(lei[i].Timeend) == 0))
                        i++;
                    else
                        output.WriteLine(readline + "," + lei[i].Write);

                    
                    
                }

            }
            */
            
            /*
            for (int i = 0; i < lei.Count; i++)
            {
                EmotionInstance ei = lei[i];
                DateTime timestamp = TimeDateMethods.UNIXTimetoDateTime(Double.Parse(templine[0]));
                bool testing = ei.Timestart.CompareTo(timestamp) == -1; Console.WriteLine("wewew");
                while (testing && !eeg.EndOfStream) //if ei.Timestart is before current timestamp
                {
                    Console.WriteLine("wa");
                    readline = eeg.ReadLine();
                    templine = readline.Split(',');
                    //output.WriteLine(readline + "," + EmotionInstance.removeLast(EmotionInstance.removeFirst(readline, ','), ','));
                }
                if (ei.Timestart.CompareTo(timestamp) == 0 || (ei.Timestart.CompareTo(timestamp) == 1 && ei.Timeend.CompareTo(timestamp) == -1))
                {
                    i++;
                }
                while (ei.Timestart.CompareTo(timestamp) == 0 || (ei.Timestart.CompareTo(timestamp) == 1 && ei.Timeend.CompareTo(timestamp) == -1) && !eeg.EndOfStream)
                {
                    readline = eeg.ReadLine();
                    templine = readline.Split(',');
                    output.WriteLine(readline + "," + EmotionInstance.removeLast(EmotionInstance.removeFirst(readline, ','), ','));
                }
            }
            */
            
            /*
            for (int i = 0; i < lei.Count && !eeg.EndOfStream; i++)
            {
                EmotionInstance ei = lei[i];
                //double[] summation = new double[columns.Length + offset];
                //summation = MathFunctions.toZero(summation);

                //if time is before the start time
                while (ei.Timestart.CompareTo(TimeDateMethods.UNIXTimetoDateTime(Double.Parse(templine[0]))) == -1 && !eeg.EndOfStream)
                {
                    templine = eeg.ReadLine().Split(',');
                }

                //if time is equal or after the start time and before the end time
                while ((ei.Timestart.CompareTo(TimeDateMethods.UNIXTimetoDateTime(Double.Parse(templine[0]))) == 0 || ei.Timestart.CompareTo(TimeDateMethods.UNIXTimetoDateTime(Double.Parse(templine[0]))) == 1) && ei.Timeend.CompareTo(TimeDateMethods.UNIXTimetoDateTime(Double.Parse(templine[0]))) == -1 && !eeg.EndOfStream)
                {
                    String readline = eeg.ReadLine();
                    templine = readline.Split(',');
                    output.WriteLine(readline+","+EmotionInstance.removeLast(EmotionInstance.removeFirst(readline,','),','));
                }
            }*/
            eeg.Close();
            emo.Close();
            output.Close();
        }
    }


}
