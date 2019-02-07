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
        #region EmotionLogger-related
        private EmotionLogger log;
        private String startTime;
        private String endTime;
        private String segment;
        private int intensity_PL;
        private int intensity_AT;
        private int intensity_SE;
        private int intensity_AP;
        private Boolean isStriking;
        private Boolean fromEvaluative;
        private Boolean fromNarrative;
        private Boolean fromAesthetic;
        private Boolean fromOthers;
        #endregion
        private Form parent;

        /// <summary>
        /// Creates an instance of the AnnotatorFrame.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="filename"></param>
        public AnnotatorFrame(Form parent, String filename) {
            this.parent = parent;
            log = new EmotionLogger(filename);
            InitializeComponent();
        }

        /// <summary>
        /// Resets the values to its default state.
        /// </summary>
        private void Reset() {
            intensity_PL = 0;
            intensity_AT = 0;
            intensity_SE = 0;
            intensity_AP = 0;
            isStriking = false;
            fromEvaluative = false;
            fromNarrative = false;
            fromAesthetic = false;
            fromOthers = false;

            // Trackbars
            adpPleasantness.IntensityValue = 0;
            adpAttention.IntensityValue = 0;
            adpSensitivity.IntensityValue = 0;
            adpAptitude.IntensityValue = 0;

            // Yes/No
            btnStrikeYes.Enabled = true;
            btnStrikeYes.BackColor = SystemColors.Control;
            btnStrikeNo.Enabled = false;
            btnStrikeNo.BackColor = Color.Red;
            isStriking = false;

            // CheckListBox
            for(int i = 0; i < chkReaderResponse.Items.Count; i++) {
                chkReaderResponse.SetItemChecked(i, false);
            }
        }

        /// <summary>
        /// Shows the AnnotatorFrame and takes note of the startTime.
        /// </summary>
        public void ShowAnnotatorFrame(String segmentNumber) {
            segment = segmentNumber;
            startTime = Utilities.GetCsvTimestamp().ToString();
            parent.Enabled = false;
            ShowDialog();
        }

        /// <summary>
        /// Hides the AnnotatorFrame.
        /// </summary>
        private void CloseAnnotatorFrame() {
            Reset();
            Close();
            parent.Enabled = true;
        }

        /// <summary>
        /// START_TIME, END_TIME, SEGMENT, PLEASANTNESS, ATTENTION, SENSITIVITY, APPTITUDE,
        /// IS_STRIKING, FROM_EVALUATIVE, FROM_NARRATIVE, FROM_AESTHETIC, FROM_OTHERS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e) {
            endTime = Utilities.GetCsvTimestamp().ToString();
            SetIntensityValues();
            SetReaderResponseValues();
            log.Log(startTime, endTime, segment, intensity_PL, intensity_AT, intensity_SE, intensity_AP, GetBoolValue(isStriking), GetBoolValue(fromEvaluative), GetBoolValue(fromNarrative), GetBoolValue(fromAesthetic), GetBoolValue(fromOthers));
            CloseAnnotatorFrame();
        }

        /// <summary>
        /// Returns 1 if value is TRUE, else returns 0.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private int GetBoolValue(Boolean value) {
            if(value)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// Sets the values from the trackbars.
        /// </summary>
        private void SetIntensityValues() {
            intensity_PL = adpPleasantness.IntensityValue;
            intensity_AT = adpAttention.IntensityValue;
            intensity_SE = adpSensitivity.IntensityValue;
            intensity_AP = adpAptitude.IntensityValue;
        }

        /// <summary>
        /// Sets the values from the checklists.
        /// </summary>
        private void SetReaderResponseValues() {
            fromEvaluative = chkReaderResponse.GetItemChecked(0);
            fromNarrative = chkReaderResponse.GetItemChecked(1);
            fromAesthetic = chkReaderResponse.GetItemChecked(2);
            fromOthers = chkReaderResponse.GetItemChecked(3);
        }

        #region UI CHANGE EVENTS
        private void btnStrikeYes_Click(object sender, EventArgs e) {
            btnStrikeYes.Enabled = false;
            btnStrikeYes.BackColor = Color.Green;
            btnStrikeNo.Enabled = true;
            btnStrikeNo.BackColor = SystemColors.Control;
            isStriking = true;
        }

        private void btnStrikeNo_Click(object sender, EventArgs e) {
            btnStrikeYes.Enabled = true;
            btnStrikeYes.BackColor = SystemColors.Control;
            btnStrikeNo.Enabled = false;
            btnStrikeNo.BackColor = Color.Red;
            isStriking = false;
        }

        private void chkReaderResponse__SelectedIndexChanged(object sender, EventArgs e) {
            chkReaderResponse.ClearSelected();
        }
        #endregion
    }
}
