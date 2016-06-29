using DataCollector.FileHandlers;
using DataCollector.Views;
using System;
using System.Drawing;
using System.Windows.Forms;
using DataCollector.Models;

namespace DataCollector {
    public partial class MainFrame : Form {
        private static AnnotatorFrame annotator;
        private static String storyPath;

        public MainFrame() {
            InitializeComponent();
            annotator = new AnnotatorFrame(this);
            cbStoryList.SelectedIndex = 0;
            GetStory();
            Visible = true;
        }

        #region NEXT BUTTON ACTION
        /// <summary>
        /// Action when user clicks 'Next'. Opens the AnnotatorFrame before proceeding to the next story segment.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e) {
            if(Story.IsEmpty()) {
                MessageBox.Show("Please load story first.", "ERROR!");
            } else {
                ShowAnnotatorFrame();
                UpdateSegments();
            }
        }

        private void ShowAnnotatorFrame() {
            annotator.show();
        }

        /// <summary>
        /// Updates the story segments displayed on the screen.
        /// </summary>
        private void UpdateSegments() {
            String current = "";
            String previous = "";
            Boolean currValid = false;
            Boolean prevValid = false;

            StoryNavigator.Next();

            try {
                current = StoryNavigator.ParagraphBuilder(Story.SegmentList[StoryNavigator.segCurr].PartList);
                currValid = true;
            } catch(ArgumentOutOfRangeException ex) {
                currValid = false;
            }

            try {
                previous = StoryNavigator.ParagraphBuilder(Story.SegmentList[StoryNavigator.segPrev].PartList);
                prevValid = true;
            } catch(ArgumentOutOfRangeException ex) {
                prevValid = false;
            }

            if(currValid && prevValid) { // both are valid
                lblCurr.Text = current;
                lblPrev.TextAlign = ContentAlignment.BottomLeft;
                lblPrev.Text = previous;
            } else if(currValid && !prevValid) { // first segment
                lblCurr.Text = current;
                lblPrev.TextAlign = ContentAlignment.BottomCenter;
                lblPrev.Text = "'"+Story.Title+"' by "+Story.Author;
            } else { // last segment
                lblCurr.TextAlign = ContentAlignment.TopCenter;
                lblCurr.Text = "THE END";
                lblPrev.Text = previous;
                btnNext.Enabled = false;
                lblStatus.Text = "End of '"+Story.Title+"' reached";
            }
        }
        #endregion

        #region LOAD BUTTON ACTION
        private void tBtnLoad_Click(object sender, EventArgs e) {
            Reset();
            try {
                StoryXmlParser.ParseFile(storyPath);
                lblStatus.Text = "'" + Story.Title + "' is loaded";
                UpdateSegments();
            } catch (Exception ex) {
                MessageBox.Show("Story XML file does not exist.", "ERROR!");
                lblStatus.Text = "Error in loading story XML";
            }
        }

        private void Reset() {
            Story.Reset();
            StoryNavigator.Reset();
            lblCurr.TextAlign = ContentAlignment.TopLeft;
            btnNext.Enabled = true;
        }
        #endregion

        #region STORY LIST COMBOBOX ACTION
        private void cbStoryList_SelectedIndexChanged(object sender, EventArgs e) {
            GetStory();
        }

        /// <summary>
        /// Gives the path of the selected story based on the index of cbStoryList.
        /// </summary>
        private void GetStory() {
            switch(cbStoryList.SelectedIndex) {
                case 0:
                    storyPath = ConfigIniParser.GetSelectedStoryPath(Stories.TEST);
                    break;
                case 1:
                    storyPath = ConfigIniParser.GetSelectedStoryPath(Stories.S1);
                    break;
                case 2:
                    storyPath = ConfigIniParser.GetSelectedStoryPath(Stories.S2);
                    break;
                case 3:
                    storyPath = ConfigIniParser.GetSelectedStoryPath(Stories.S3);
                    break;
            }
        }
        #endregion
    }

}