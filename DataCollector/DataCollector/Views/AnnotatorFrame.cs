using DataCollector.App;
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
        public static String filename;
        private double startTime;
        private double endTime;
        private String selectedEmotion;
        private int intensity;

        public AnnotatorFrame(Form parent, String user, String story) {
            InitializeComponent();
            this.parent = parent;
            filename = ConfigIniParser.GetResultsPath() + user + "_EmoAnno_" + story + "_" + Utilities.GetTimestamp() + ".csv";
            log = new EmotionLogger(filename);
        }

        public void ShowAnnotatorFrame() {
            startTime = (DateTime.Now.ToLocalTime() - new DateTime(1970, 1, 1).ToLocalTime()).TotalMilliseconds;
            parent.Enabled = false;
            ShowDialog();
        }

        private void btnSubmit_Click(object sender, EventArgs e) {
            intensity = trackBar1.Value;
            endTime = (DateTime.Now.ToLocalTime() - new DateTime(1970, 1, 1).ToLocalTime()).TotalMilliseconds;
            log.writeValues(startTime.ToString(), selectedEmotion, intensity, endTime.ToString());
            CloseAnnotatorFrame();
        }

        private void CloseAnnotatorFrame() {
            Visible = false;
            parent.Enabled = true;
        }

        /// <summary>
        /// Gets the corresponing value of the selected RadioButton.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
