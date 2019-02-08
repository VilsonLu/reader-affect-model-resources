using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Preprocessing.Brainwaves
{
    class EmotionAnnotation
    {
        private StreamReader emotion;
        private StreamReader eeg;
        private StreamWriter write;
        private int duration_index = 1;

        public EmotionAnnotation(String emotionSource, String eegSource, String output)
        {
            emotion = new StreamReader(emotionSource);
            eeg = new StreamReader(eegSource);
            write = new StreamWriter(output);
            doProcessing();
        }

        public void doProcessing()
        {
            //add columns
            List<String> columns = new List<String>();
            if(!eeg.EndOfStream)
            {
                String[] eegcolumns = eeg.ReadLine().Split(',');
                for (int i = 0; i < eegcolumns.Length; i++)
                {
                    columns.Add(eegcolumns.ElementAt(i));
                }
            }
            if(!emotion.EndOfStream)
            {
                String[] emotioncolumns = emotion.ReadLine().Split(',');
                for (int i = 1; i < emotioncolumns.Length; i++)         //dont include time column
                {
                    columns.Add(emotioncolumns.ElementAt(i));
                }
            }
            StringMethods.writeColumns(columns, write);
            //map the two files
            //String[] emo;
            int minutes;          
            int seconds;
            int time;


            String[] emotiv = eeg.ReadLine().Split(',');
            int timestamp = (int)Math.Floor(Double.Parse(emotiv[22]));
            
            while (!eeg.EndOfStream && !emotion.EndOfStream)                            //read manual annotation csv
            {
                
                String[] emo = emotion.ReadLine().Split(',');                           //writeValues(emo, false);
                minutes = (int)Math.Floor(Double.Parse(emo[0]) / 100) * 60;             //get hundreds position
                seconds = Int32.Parse(emo[0]) % 100;
                time = minutes + seconds;

                while (time != timestamp)
                {
                    emotiv = eeg.ReadLine().Split(',');
                    timestamp = (int)Math.Floor(Double.Parse(emotiv[duration_index]));
                }
                while(time == timestamp && !emotion.EndOfStream)
                {
                    StringMethods.writeValues(emotiv,write,false);
                    StringMethods.writeValues(emo, write, true);
                    emotiv = eeg.ReadLine().Split(',');
                    timestamp = (int)Math.Floor(Double.Parse(emotiv[22]));
                }
            }
           
            emotion.Close();
            eeg.Close();
            write.Close();
        }

        
    }
}
