using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Preprocessing.Brainwaves
{

    class EEG1Sec{
        public static int[] columns = {5,6,7,8,9,10,11,12,13,14,15,16,17,18,27,28,29,30,31};
        //private static int duration = 22;
        private static int time = 0;

        private StreamReader eeg;
        private StreamWriter write;
        public static int offset = 1;

        DateTime previousTime = new DateTime(1970, 1, 1);
        DateTime currentTime;

        public EEG1Sec(String source, String destination)
        {
            eeg = new StreamReader(source);
            write = new StreamWriter(destination);
            doProcessing();
        }

        private void init()
        {
            //write column headers
            List<String> columnlist = new List<String>();
            String[] line = eeg.ReadLine().Split(',');

            //columnlist.Add(line[duration].Trim());
            columnlist.Add(line[time].Trim());
            for (int i = 0; i < columns.Length; i++)
            {
                int index = columns[i];
                columnlist.Add(line[index].Trim());
            }
            StringMethods.writeColumns(columnlist, write);
        }

        public static double[] add(String[] line, double[] values)
        {

            for (int i = 0; i < columns.Length; i++)
            {
                int index = columns[i];
                double val = Double.Parse(line[index]);
                values[i + offset] += val;
            }
            return values;
        }

        private void doProcessing()
        {
            init();
            int count = 0;
            //double currentDuration = 0;
            double tempTime = 0;
            double[] summation = new double[columns.Length + offset];
            String[] line;

            //set to 0
            MathFunctions.toZero(summation);  

            while (!eeg.EndOfStream)
            {
                    //executed per line
                    line = eeg.ReadLine().Split(',');
                    tempTime = Double.Parse(line[time]);
                    //currentDuration = Math.Floor(Double.Parse(line[duration])); 
                    currentTime = TimeDateMethods.UNIXTimetoDateTime(tempTime);
                    //Console.WriteLine(currentTime+" : "+currentDuration);
                    count++;                                                //number of rows for one second
                    if (previousTime.Equals(new DateTime(1970, 1, 1)))      //first iteration
                    {
                        previousTime = currentTime;
                        add(line, summation);
                    }
                    else if ((previousTime.Second == currentTime.Second) && previousTime.Minute == currentTime.Minute)              //time is equal
                    {
                        previousTime = currentTime;
                        add(line, summation);
                    }
                    else
                    {
                        //summation[1] = currentDuration; //Console.WriteLine(count + " CURRENT DURATION: " + previousTime + " SUM: " + summation[2]);
                        summation = MathFunctions.getAverage(summation, count);
                        String[] prewrite = toArrayString(summation);
                        prewrite[0] = previousTime.ToString(); //Console.WriteLine("CURRENT TIME: "+prewrite[0]);
                        StringMethods.writeValues(prewrite, write, true);
                        previousTime = currentTime;
                        MathFunctions.toZero(summation);
                        add(line, summation);
                        count = 0;
                    }                
            }

            summation = MathFunctions.getAverage(summation, count);
            //summation[1] = currentDuration; //Console.WriteLine("CURRENT DURATION: "+currentDuration);
            String[] prewrite1 = toArrayString(summation);
            prewrite1[0] = previousTime.ToString(); //Console.WriteLine("CURRENT TIME: "+prewrite[0]);
            StringMethods.writeValues(prewrite1, write, true);

            eeg.Close();
            write.Close();
            Console.WriteLine("END");
        }

        public String[] toArrayString(double[] values)
        {
            String[] ret = new String[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                ret[i] = values[i].ToString();
            }
            return ret;
        }
    }


    /*
    class EEG1Sec
    {
        StreamReader eeg;
        StreamWriter write;

        private static sealed int[] columns = { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 27, 28, 29, 30, 31 };
        //private static sealed int duration = 22;
        private static sealed int time = 0;
        private static sealed int offset = 1;                   //offset +1 for time value

        public EEG1Sec(String source, String output)
        {
            eeg = new StreamReader(source);
            write = new StreamWriter(output);
        }

        private double[] add(String[] line, double[] values)
        {

            for (int i = 0; i < columns.Length; i++)
            {
                int index = columns[i];
                double val = Double.Parse(line[index]);
                values[i + offset] += val;
            }
            return values;
        }

        public void init()
        {
            String[] firstrow = eeg.ReadLine().Split(',');
            List<String> columnlist = new List<String>();
            columnlist.Add(firstrow[0]);
            for (int i = 0; i < columns.Length; i++)
            {
                int index = columns[i];
                columnlist.Add(firstrow[index].Trim());
            }
            FileMethods.writeColumns(columnlist, write);
        }

        public void doProcessing()
        {
            init();
            String[] line;
            double[] summation = new double[columns.Length + offset];
            String currentTime = "";
            String previousTime = "";

            MathFunctions.toZero(summation);
            while (!eeg.EndOfStream)
            {
                line = eeg.ReadLine().Split(',');
                currentTime = line[time];

                if (previousTime.Equals(""))
                {
                    previousTime = currentTime;

                }
            }
        }
    }*/
}
