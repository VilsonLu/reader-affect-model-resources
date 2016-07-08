using DataCollector.FileHandlers;
using System;
using System.Drawing;
using System.Windows.Forms;
using DataCollector.Models;
using DataCollector.App;
using System.Threading;

namespace DataCollector.Views {
    public partial class MainFrame : Form {
        #region Story-related Variables
        private static AnnotatorFrame annotator;
        #endregion
        #region Emotiv-related Variables
        private static EmotivConnector connector;
        private Thread thdEmotivConnector;
        #endregion
        private static String user = "TINTIN";
        private static Stories selectedStory;
        private static int clickCtr;        

        /// <summary>
        /// Creates an instance of the MainFrame.
        /// </summary>
        public MainFrame() {
            ProgramLogger.Log("[MainFrame()] Created MainFrame instance");
            //user = new PromptFrame().ShowPromptFrame();
            ProgramLogger.Log("[MainFrame()] user = " + user);
            InitializeComponent();
            cbStoryList.SelectedIndex = 0;
            GetStory();
            clickCtr = 0;
        }

        /*public void UpdateEegBatteryStatus(String newText) {
            if(this.InvokeRequired)
                this.Invoke(new MethodInvoker(delegate () {
                    lblEegCharge.Text = newText;
                }));
            else {
                lblEegCharge.Text = newText;
            }
        }*/

        #region STORY LIST COMBOBOX ACTION
        private void cbStoryList_SelectedIndexChanged(object sender, EventArgs e) {
            ProgramLogger.Log("[MainFrame.cbStoryList_SelectedIndexChanged()] Selected index change event");
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

            ProgramLogger.Log("[MainFrame.GetStory()] selectedStory = " + selectedStory.ToString());
        }
        #endregion

        #region START/STOP BUTTON ACTION
        private void tBtnRecord_Click(object sender, EventArgs e) {
            ProgramLogger.Log("[MainFrame.tBtnRecord_Click()] btnRecord click event");

            clickCtr++;
            if(clickCtr % 2 == 0) {
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
            ProgramLogger.Log("[MainFrame.Reset()] Reset Story");
            Story.Reset();

            ProgramLogger.Log("[MainFrame.Reset()] Reset StoryNavigator");
            StoryNavigator.Reset();

            ProgramLogger.Log("[MainFrame.Reset()] UI components");
            lblCurr.TextAlign = ContentAlignment.TopLeft;
            btnNext.Enabled = true;
            lblProgress0.Visible = false;
            lblProgress1.Visible = false;
            lblProgress2.Visible = false;
            lblProgress3.Visible = false;

            ProgramLogger.Log("[MainFrame.Reset()] Reset EmotivConnector");
            connector.Reset();
        }

        /// <summary>
        /// Creates the output files.
        /// </summary>
        private void CreateOutputFiles() {
            String template = "./Results/" + user + "_" + selectedStory.ToString() + "_" + Utilities.GetTimestamp() + "_";

            ProgramLogger.Log("[MainFrame.CreateOutputFiles()] Created EegData.csv");
            String outputEegFilename =  template + "EegData.csv";
            connector = new EmotivConnector(this, outputEegFilename);

            ProgramLogger.Log("[MainFrame.CreateOutputFiles()] Created EmoAnno.csv");
            String outputEmoAnnoFilename = template + "EmoAnno.csv";
            annotator = new AnnotatorFrame(this, outputEmoAnnoFilename);
        }

        /// <summary>
        /// Loads the story to the MainFrame.
        /// </summary>
        private void LoadStory() {
            try {
                ProgramLogger.Log("[MainFrame.LoadStory()] Parsing "+selectedStory.ToString()+".xml");
                StoryXmlParser.ParseFile(selectedStory);
                lblStatus.Text = "'" + Story.Title + "' is loaded";
                UpdateSegments();
            } catch(Exception e) {
                ProgramLogger.Log("[ERROR] in [MainFrame.LoadStory()] "+e.Message);
                MessageBox.Show("Story XML file does not exist.", "ERROR!");
                lblStatus.Text = "Error in loading story XML";
            }
        }

        /// <summary>
        /// Starts the EEG recording.
        /// </summary>
        private void StartEegComponent() {
            ProgramLogger.Log("[MainFrame.StartEegComponent()] Starts the EEG Components");
            tBtnRecord.Image = Properties.Resources.IMG_Stop;
            tBtnRecord.Text = "Stop";
            lblEegRecording.Text = "EEG is recording";
            lblEegRecording.ForeColor = Color.Green;

            // Create the thread object. This does not start the thread.
            thdEmotivConnector = new Thread(connector.StartRecording);
            // Start the worker thread.
            ProgramLogger.Log("[MainFrame.StartEegComponent()] Starting thread for EmotivConnector");
            thdEmotivConnector.Start();
            Console.WriteLine("main thread: Starting worker thread...");
        }

        /// <summary>
        /// Stops the EEG recording.
        /// </summary>
        private void StopEegComponent() {
            ProgramLogger.Log("[MainFrame.StopEegComponent()] Stops the EEG Component");
            tBtnRecord.Image = Properties.Resources.IMG_Play;
            tBtnRecord.Text = "Start";
            lblEegRecording.Text = "EEG is not recording";
            lblEegRecording.ForeColor = Color.Red;

            // Request that the worker thread stop itself:
            connector.StopRecording();

            // Use the Join method to block the current thread until the object's thread terminates.
            ProgramLogger.Log("[MainFrame.StopEegComponent()] Stopping thread for EmotivConnector");
            thdEmotivConnector.Join();
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
            ProgramLogger.Log("[MainFrame.btnNext_Click()] btnNext click event");
            if(Story.IsEmpty()) {
                MessageBox.Show("Please load story first.", "ERROR!");
            } else {
                ShowAnnotatorFrame();
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

                ProgramLogger.Log("[MainFrame.UpdateSegments()] First segment");
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
                ProgramLogger.Log("[MainFrame.UpdateSegments()] Last segment");
            } else {
                current = StoryNavigator.ParagraphBuilder(Story.SegmentList[StoryNavigator.segCurr].PartList);
                previous = StoryNavigator.ParagraphBuilder(Story.SegmentList[StoryNavigator.segPrev].PartList);

                lblPrev.TextAlign = ContentAlignment.BottomLeft;
                lblProgress1.Text = Story.SegmentList[StoryNavigator.segCurr].Id.ToString();

                ProgramLogger.Log("[MainFrame.UpdateSegments()] Current segment = "+ StoryNavigator.segCurr+"; Previous segment = "+ StoryNavigator.segPrev);
            }

            lblCurr.Text = current;
            lblPrev.Text = previous;
        }
        #endregion
    }

}