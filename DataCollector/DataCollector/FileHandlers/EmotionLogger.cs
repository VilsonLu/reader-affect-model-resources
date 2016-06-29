using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataCollector.FileHandlers {
    class EmotionLogger {
        private StreamWriter writer;
        private Boolean isOpen = false;
        public bool Open { get { return isOpen; } }

        public EmotionLogger(String filename) {
            writer = new StreamWriter(filename);
            writer.AutoFlush = true;
            isOpen = true;
            init();
        }

        private void init() {
            if(isOpen) {
                /*writer.Write("Start time,");
                for(int i = 0; i < values.Count; i++) {
                    writer.Write(values[i].Name + ",");
                }
                //writer.WriteLine("End time");*/
                writer.WriteLine("Start Time,Emotion,Intensity,EndTime");
                writer.Flush();
            }
        }

        public void writeValues(String startTime, String emotion, int intensity, String endTime) {
            if(isOpen) {
                /*writer.Write(startTime + ",");
                for(int i = 0; i < values.Count; i++) {
                    writer.Write(values[i].Value + ",");
                }
                writer.WriteLine(endTime);*/
                writer.WriteLine(startTime + "," + emotion + "," + intensity.ToString() + "," + endTime);
                writer.Flush();
            } else
                MessageBox.Show("Stream is closed!", "Error");
        }

        public void end() {
            writer.Flush();
            writer.Close();
            isOpen = false;
        }
    }
}