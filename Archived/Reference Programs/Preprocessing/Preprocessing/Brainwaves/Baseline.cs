using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Preprocessing.Header;


namespace Preprocessing.Brainwaves
{
    class Baseline
    {
        private TextReader read;
        private TextWriter write;


        public Baseline(String source, String destination)
        {
            read = new StreamReader(source);
            write = new StreamWriter(destination);
        }

        private void doProcessing()
        {
            int columnCount = 0;
            int lineCount;
            List<double> store = new List<double>();
            List<double> temp = new List<double>();


            String s = "";
            for (lineCount = 0; (s = read.ReadLine()) != null; lineCount++ )
            {
                String[] line = s.Split(',');
                if (lineCount != 0)
                {
                    for (int i = 0; i < columnCount; i++)
                    {
                        switch (FileFormat.Baseline[i])
                        {
                            case Observatory.IGNORE:

                                break;

                            case Observatory.TIMESTAMP:


                                break;

                            case Observatory.PROCESS:

                                break;
                        }
                    }

                }
                else
                {
                    columnCount = line.Length;
                    writeColumn(line);
                }
            }
            read.Close();
            write.Close();
        }

        private void writeColumn(String[] columnLabels)
        {
            for (int x = 0; x < columnLabels.Length; x++)
            {
                if (x != 0)
                    write.Write("," + columnLabels.ElementAt(x));
                else
                    write.Write(columnLabels.ElementAt(x));
            }
            write.Write("\n");
        }

        private void writeValues(double[] values)
        {
            for (int x = 0; x < values.Length; x++)
            {
                if (x != 0)
                    write.Write("," + values.ElementAt(x));
                else
                    write.Write(values.ElementAt(x));
            }
        }

    }
}
