using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Observatory.EmotionAnnotation
{
    class LogWriter
    {
        private List<TrackBar> values;
        private StreamWriter writer;
        private bool isOpen = false;

        public bool Open { get { return isOpen; } }

        public LogWriter(List<TrackBar> values, String filename)
        {
            this.values = values;
            writer = new StreamWriter(filename);
            writer.AutoFlush = true;
            isOpen = true;
            init();
        }

        private void init()
        {
            if (Open)
            {
                writer.Write("Start time,");
                for (int i = 0; i < values.Count; i++)
                {
                    writer.Write(values[i].Name+",");
                }
                writer.WriteLine("End time");
                writer.Flush();
            }
        }

        public void writeValues(String startTime, String endTime)
        {
            if (Open)
            {
                writer.Write(startTime + ",");
                for (int i = 0; i < values.Count; i++)
                {
                    writer.Write(values[i].Value + ",");
                }
                writer.WriteLine(endTime);
                writer.Flush();
            }
            else
                Console.WriteLine("Stream is closed!");
        }

        public void end()
        {
            writer.Flush();
            writer.Close();
            isOpen = false;
        }
    }
}
