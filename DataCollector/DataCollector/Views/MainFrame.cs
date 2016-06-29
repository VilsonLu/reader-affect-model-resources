using DataCollector.FileHandlers;
using DataCollector.Views;
using System;
using System.Drawing;
using System.Windows.Forms;
using DataCollector.Models;

namespace DataCollector.Views {
    public partial class MainFrame : Form {
        private static AnnotatorFrame annotator;
        private static String storyPath;
        private static string user;
        private static Stories selectedStory;

        public MainFrame() {
            user = new PromptFrame().ShowPromptFrame();
            Console.Write("USER: "+user);
            InitializeComponent();
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
            annotator.ShowAnnotatorFrame();
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
                lblProgress1.Text = Story.SegmentList[StoryNavigator.segCurr].Id.ToString();
            } else if(currValid && !prevValid) { // first segment
                lblCurr.Text = current;
                lblPrev.TextAlign = ContentAlignment.BottomCenter;
                lblPrev.Text = "'"+Story.Title+"' by "+Story.Author;

                lblProgress0.Visible = true;
                lblProgress1.Visible = true;
                lblProgress2.Visible = true;
                lblProgress3.Visible = true;

                lblProgress1.Text = Story.SegmentList[StoryNavigator.segCurr].Id.ToString();
                lblProgress3.Text = Story.SegmentList.Count.ToString();
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
                annotator = new AnnotatorFrame(this, user, selectedStory.ToString());
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

            lblProgress0.Visible = false;
            lblProgress1.Visible = false;
            lblProgress2.Visible = false;
            lblProgress3.Visible = false;
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
                    selectedStory = Stories.TEST;
                    break;
                case 1:
                    selectedStory = Stories.MFTS;
                    break;
                case 2:
                    selectedStory = Stories.TFATJ;
                    break;
                case 3:
                    selectedStory = Stories.TV;
                    break;
            }
            storyPath = ConfigIniParser.GetSelectedStoryPath(selectedStory);
        }
        #endregion
    }

}