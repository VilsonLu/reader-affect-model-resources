using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Preprocessing.Brainwaves
{
    class FiveSecondAverage
    {
        private StreamReader eeg;
        private StreamWriter write;
        private int interval;
        private int columnCount;
        private int offset = 2;

        public FiveSecondAverage(String EEGSource, String output, int interval)
        {
            eeg = new StreamReader(EEGSource);
            write = new StreamWriter(output);
            this.interval = interval;
            doProcessing();
        }

        //write column headers
        public void init()
        {
            if (!eeg.EndOfStream)
            {
                String line = eeg.ReadLine();
                columnCount = line.Split(',').Length;
                write.WriteLine(line);
            }
        }



        public void doProcessing()
        {
            init();
            double[] values = new double[columnCount-offset];
            MathFunctions.toZero(values);
            while (!eeg.EndOfStream)
            {
                //String[] line = eeg.ReadLine().Split(',');
                //String[] notTobeAved = {line[0], line[1]};
                //String[] toBeAved = new String[line.Length-notTobeAved.Length-1];
                int i;
                int duration = 0;
                String timestamp = "";
                String context = "";
                String comment = "";
                for (i = 0; i < interval && !eeg.EndOfStream; i++)
                {
                    String[] line = eeg.ReadLine().Split(','); Console.WriteLine("line length: {0}", line.Length);
                    //String[] notTobeAved = { line[0], line[1], line[21], line[22] };
                    int[] exceptions = { 0, 1, 21, 22 };
                    //String[] toBeAved = new String[line.Length - notTobeAved.Length];// = new String[line.Length - notTobeAved.Length - 1];
                    /*for (int a = 0; a < toBeAved.Length && a < line.Length; a++)
                    {
                        
                        toBeAved[a] = line[a + notTobeAved.Length];
                    }*/
                    if(i == 0)
                    {
                        duration = Int32.Parse(line[exceptions[1]]);
                        timestamp = line[exceptions[0]];
                        context = line[exceptions[2]];
                        comment = line[exceptions[3]];
                    }
                    values = MathFunctions.add(line, values, exceptions);
                }

                values = MathFunctions.getAverage(values, i);
                String[] toWrite = new String[2];
                toWrite[0] = timestamp;
                toWrite[1] = duration.ToString() ;
                for(int h = 2; h < values.Length; h++)
                    toWrite = StringMethods.addToLast(toWrite, values[h].ToString());
                toWrite = StringMethods.addToLast(toWrite, context);
                toWrite = StringMethods.addToLast(toWrite, comment);

                StringMethods.writeValues(toWrite, write, true);
            }
            eeg.Close();
            write.Close();
        }
    }
}
