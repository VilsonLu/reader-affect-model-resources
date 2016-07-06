using DataCollector.FileHandlers;
using System;
using System.Drawing;
using System.Windows.Forms;
using DataCollector.Models;
using DataCollector.App;
using System.Threading;

namespace DataCollector.Views {
    public partial class MainFrame : Form {
        private static AnnotatorFrame annotator;
        private static EmotivLogger emotivLog;
        private static String user = "TINTIN";
        private static Stories selectedStory;
        private Thread thdEmotivLogger;
        private static int clickCtr;

        /// <summary>
        /// Creates an instance of the MainFrame.
        /// </summary>
        public MainFrame() {
            //user = new PromptFrame().ShowPromptFrame();
            InitializeComponent();
            cbStoryList.SelectedIndex = 0;
            GetStory();
            clickCtr = 0;
            Visible = true;
        }

        #region STORY LIST COMBOBOX ACTION
        private void cbStoryList_SelectedIndexChanged(object sender, EventArgs e) {
            GetStory();
        }

        /// <summary>
        /// Gets the corresponding Stories enum based on the index of cbStoryList.
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
        }
        #endregion

        #region START/STOP BUTTON ACTION
        private void tBtnRecord_Click(object sender, EventArgs e) {
            clickCtr++;
            if(clickCtr % 2 == 0) {
                annotator.CloseLogger();
                StopEegComponent();
            } else {
                CreateOutputFiles();
                Reset();

                // Story-related
                LoadStory();

                // Emotiv-related
                StartEegComponent();
            }
        }

        /// <summary>
        /// Resets the class to its initial state.
        /// </summary>
        private void Reset() {
            Story.Reset();
            StoryNavigator.Reset();
            lblCurr.TextAlign = ContentAlignment.TopLeft;
            btnNext.Enabled = true;

            lblProgress0.Visible = false;
            lblProgress1.Visible = false;
            lblProgress2.Visible = false;
            lblProgress3.Visible = false;

            emotivLog.Reset();
        }

        /// <summary>
        /// Creates the output files.
        /// </summary>
        private void CreateOutputFiles() {
            // Create directory if it does not exists
            System.IO.Directory.CreateDirectory("./Results/");

            String template = "./Results/" + user + "_" + selectedStory.ToString() + "_" + Utilities.GetTimestamp() + "_";

            String outputEegFilename =  template + "EegData.csv";
            emotivLog = new EmotivLogger(outputEegFilename);

            String outputEmoAnnoFilename = template + "EmoAnno.csv";
            annotator = new AnnotatorFrame(this, outputEmoAnnoFilename);
        }

        /// <summary>
        /// Loads the story to the MainFrame.
        /// </summary>
        private void LoadStory() {
            try {
                StoryXmlParser.ParseFile(selectedStory);
                lblStatus.Text = "'" + Story.Title + "' is loaded";
                UpdateSegments();
            } catch(Exception ex) {
                MessageBox.Show("Story XML file does not exist.", "ERROR!");
                lblStatus.Text = "Error in loading story XML";
            }
        }

        /// <summary>
        /// Starts the EEG recording.
        /// </summary>
        private void StartEegComponent() {
            tBtnRecord.Image = Properties.Resources.IMG_Stop;
            tBtnRecord.Text = "Stop";
            lblEegStatus.Text = "EEG is recording";
            lblEegStatus.ForeColor = Color.Green;

            // Create the thread object. This does not start the thread.
            thdEmotivLogger = new Thread(emotivLog.StartRecording);
            // Start the worker thread.
            thdEmotivLogger.Start();
            Console.WriteLine("main thread: Starting worker thread...");
        }

        /// <summary>
        /// Stops the EEG recording.
        /// </summary>
        private void StopEegComponent() {
            tBtnRecord.Image = Properties.Resources.IMG_Play;
            tBtnRecord.Text = "Start";
            lblEegStatus.Text = "EEG is not recording";
            lblEegStatus.ForeColor = Color.Red;

            // Request that the worker thread stop itself:
            emotivLog.StopRecording();

            // Use the Join method to block the current thread until the object's thread terminates.
            thdEmotivLogger.Join();
            Console.WriteLine("main thread: Worker thread has terminated.");
        }
        #endregion

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
                //ShowAnnotatorFrame();
                UpdateSegments();
            }
        }

        /// <summary>
        /// Shows the AnnotatorFrame.
        /// </summary>
        private void ShowAnnotatorFrame() {
            annotator.ShowAnnotatorFrame();
        }

        /// <summary>
        /// Updates the story segments displayed on the screen.
        /// </summary>
        private void UpdateSegments() {
            String current = "";
            String previous = "";

            StoryNavigator.Next();

            if(StoryNavigator.IsFirstSegment()) {
                current = StoryNavigator.ParagraphBuilder(Story.SegmentList[StoryNavigator.segCurr].PartList);
                previous = "'" + Story.Title + "' by " + Story.Author;

                lblPrev.TextAlign = ContentAlignment.BottomCenter;
                lblProgress0.Visible = true;
                lblProgress1.Visible = true;
                lblProgress2.Visible = true;
                lblProgress3.Visible = true;
                lblProgress1.Text = Story.SegmentList[StoryNavigator.segCurr].Id.ToString();
                lblProgress3.Text = Story.SegmentList.Count.ToString();
            } else if(StoryNavigator.IsLastSegment()) {
                current = "THE END";
                previous = StoryNavigator.ParagraphBuilder(Story.SegmentList[StoryNavigator.segPrev].PartList);

                lblCurr.TextAlign = ContentAlignment.TopCenter;
                lblProgress0.Visible = false;
                lblProgress1.Visible = false;
                lblProgress2.Visible = false;
                lblProgress3.Visible = false;
                btnNext.Enabled = false;
                lblStatus.Text = "End of '" + Story.Title + "' reached";

                clickCtr++;
                StopEegComponent();
            } else {
                current = StoryNavigator.ParagraphBuilder(Story.SegmentList[StoryNavigator.segCurr].PartList);
                previous = StoryNavigator.ParagraphBuilder(Story.SegmentList[StoryNavigator.segPrev].PartList);

                lblPrev.TextAlign = ContentAlignment.BottomLeft;
                lblProgress1.Text = Story.SegmentList[StoryNavigator.segCurr].Id.ToString();
            }

            lblCurr.Text = current;
            lblPrev.Text = previous;
        }
        #endregion
    }

}