using DataCollector.FileHandlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataCollector.Views {
    public partial class AnnotatorFrame : Form {
        private Form parent;
        private EmotionLogger log;
        public static String filename = "../../Resources/Results/EmotionAnnotation.csv";
        private double startTime;
        private double endTime;
        private String selectedEmotion;
        private int intensity;

        public AnnotatorFrame(Form parent) {
            InitializeComponent();
            this.parent = parent;
            log = new EmotionLogger(filename);
        }

        public void show() {
            startTime = (DateTime.Now.ToLocalTime() - new DateTime(1970, 1, 1).ToLocalTime()).TotalMilliseconds;
            parent.Enabled = false;
            /*for(int i = 0; i < trackbars.Count; i++) {
                trackbars[i].Value = (int)(trackbars[i].Maximum / 2);
                if(trackbars[i].Maximum % 2 == 1) //for odd numbers
                    trackbars[i].Value++;
            }*/
            this.ShowDialog();
        }


        private void btnSubmit_Click(object sender, EventArgs e) {
            intensity = trackBar1.Value;
            endTime = (DateTime.Now.ToLocalTime() - new DateTime(1970, 1, 1).ToLocalTime()).TotalMilliseconds;
            log.writeValues(startTime.ToString(), selectedEmotion, intensity, endTime.ToString());
            //log.writeValues(start_time.ToString(), end_time.ToString());
            close();
        }

        private void close() {
            //this.Visible = false;
            parent.Enabled = true;
        }

        // Wire all events into this.
        private void AllCheckBoxes_CheckedChanged(Object sender, EventArgs e) {
            // Check of the raiser of the event is a checked Checkbox.
            // Of course we also need to to cast it first.
            if(((RadioButton)sender).Checked) {
                // This is the correct control.
                RadioButton rb = (RadioButton)sender;
                selectedEmotion = rb.Text;
            }
        }
    }
}
