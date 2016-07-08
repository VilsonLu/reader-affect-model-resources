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
        #region EmotionLogger-related Variables
        private EmotionLogger log;
        private String filename;
        #endregion
        #region EmotionLogger Elements
        private double startTime;
        private double endTime;
        private String selectedEmotion;
        private int intensity;
        #endregion
        private Form parent;       

        public AnnotatorFrame(Form parent, String filename) {
            ProgramLogger.Log("[AnnotatorFrame()] Created AnnotatorFrame instance");
            InitializeComponent();
            this.parent = parent;
            log = new EmotionLogger(filename);
        }

        /// <summary>
        /// Shows the AnnotatorFrame and takes note of the startTime.
        /// </summary>
        public void ShowAnnotatorFrame() {
            startTime = Utilities.GetCsvTimestamp();
            parent.Enabled = false;
            ShowDialog();
        }

        /// <summary>
        /// Takes note of the endTime and the intensity of the selectedEmotion.
        /// Writes the startTime, selectedEmotion, intensity, and endTime to the CSV file.
        /// Event handler for btnSubmit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e) {
            ProgramLogger.Log("[AnnotatorFrame.btnSubmit_Click()] btnSubmit click event");
            intensity = trackBar1.Value;
            endTime = Utilities.GetCsvTimestamp();
            log.Log(startTime, selectedEmotion, intensity, endTime);
            CloseAnnotatorFrame();
        }

        /// <summary>
        /// Hides the AnnotatorFrame.
        /// </summary>
        private void CloseAnnotatorFrame() {
            if(StoryNavigator.IsLastSegmentIndexBased())
                log.CloseLogger();

            Close();
            parent.Enabled = true;

        }

        /// <summary>
        /// Closes the EmotionLogger stream.
        /// </summary>
        public void CloseLogger() {
            log.CloseLogger();
        }

        /// <summary>
        /// Takes note of the selectedEmotion.
        /// Event handler for the radio button group.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllCheckBoxes_CheckedChanged(Object sender, EventArgs e) {
            ProgramLogger.Log("[AnnotatorFrame.AllCheckBoxes_CheckedChanged()] button group change event");

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
