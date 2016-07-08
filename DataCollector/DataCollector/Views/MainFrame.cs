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
        #region Timer-related Variables
        private const int duration = 10; // 10 seconds
        private static int timeLeft = duration;
        #endregion
        private static String user = "TINTIN";
        private static Stories selectedStory;
        private static int clickCtr = 0;
        
        /// <summary>
        /// Creates an instance of the MainFrame.
        /// </summary>
        public MainFrame() {
            ProgramLogger.Log("[MainFrame()] Created MainFrame instance");
            //user = new PromptFrame().ShowPromptFrame();
            ProgramLogger.Log("[MainFrame()] user = " + user);
            InitializeComponent();
            InitializeOtherComponents();
            GetStory();
            connector = new EmotivConnector(this);
        }

        private void InitializeOtherComponents() {
            cbStoryList.SelectedIndex = 0;
            lblTime.Text = Utilities.GetTimerFormat(duration);
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

        #region GET BASELINE BUTTON ACTION
        private void btnGetBaseline_Click(object sender, EventArgs e) {
            ProgramLogger.Log("[MainFrame.btnGetBaseline_Click()] Started baseline recording");
            lblTime.Text = Utilities.GetTimerFormat(duration);

            // Create output file
            String filename = "./Results/" + user + "_baseline_" + Utilities.GetTimestamp() + ".csv";
            connector.CreateOutputFile(filename);

            // Start recording
            connector.Connect();
            StartEegComponent(true);

            // Start timer
            timer.Start();
        }
        #endregion

        #region TIMER EVENT
        private void timer_Tick(object sender, EventArgs e) {
            if(timeLeft > 0) {
                timeLeft -= 1;
                lblTime.Text = Utilities.GetTimerFormat(timeLeft);
            } else {
                timer.Stop();
                StopEegComponent(true);
                MessageBox.Show("Baseline EEG recorded!", "Update");
                ProgramLogger.Log("[MainFrame.timer_Tick()] Stop baseline recording");
            }
        }
        #endregion

        #region START/STOP BUTTON ACTION
        private void tBtnRecord_Click(object sender, EventArgs e) {
            ProgramLogger.Log("[MainFrame.tBtnRecord_Click()] btnRecord click event");

            clickCtr++;
            if(clickCtr % 2 == 0) { // STOP
                StopEegComponent(false);
                lblProgress0.Visible = false;
                lblProgress1.Visible = false;
                lblProgress2.Visible = false;
                lblProgress3.Visible = false;
            } else { // START
                CreateOutputFiles();
                Reset();

                // Story-related
                LoadStory();
                // Emotiv-related
                StartEegComponent(false);
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
            connector.Connect();
        }

        /// <summary>
        /// Creates the output files.
        /// </summary>
        private void CreateOutputFiles() {
            String template = "./Results/" + user + "_" + selectedStory.ToString() + "_" + Utilities.GetTimestamp() + "_";

            ProgramLogger.Log("[MainFrame.CreateOutputFiles()] Created EegData.csv");
            String outputEegFilename =  template + "EegData.csv";
            //connector = new EmotivConnector(this, outputEegFilename);
            connector.CreateOutputFile(outputEegFilename);

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
        #endregion        

        #region EEG COMPONENTS
        /// <summary>
        /// Starts the EEG recording.
        /// </summary>
        private void StartEegComponent(Boolean isBaseline) {
            ProgramLogger.Log("[MainFrame.StartEegComponent()] Starts the EEG Components");
            lblEegRecording.Text = "EEG is recording";
            lblEegRecording.ForeColor = Color.Green;
            btnGetBaseline.Enabled = false;
            if(isBaseline) {
                tBtnRecord.Enabled = false;
                cbStoryList.Enabled = false;
                btnNext.Enabled = false;
                lblTime.Font = new Font(lblTime.Font, FontStyle.Bold);
                lblStatus.Text = "Recording baseline EEG";
            } else {
                tBtnRecord.Image = Properties.Resources.IMG_Stop;
                tBtnRecord.Text = "Stop";
            }

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
        private void StopEegComponent(Boolean isBaseline) {
            ProgramLogger.Log("[MainFrame.StopEegComponent()] Stops the EEG Component");
            lblEegRecording.Text = "EEG is not recording";
            lblEegRecording.ForeColor = Color.Red;
            btnGetBaseline.Enabled = true;
            if(isBaseline) {
                tBtnRecord.Enabled = true;
                cbStoryList.Enabled = true;
                btnNext.Enabled = true;
                lblTime.Font = new Font(lblTime.Font, FontStyle.Regular);
                timeLeft = duration;
                lblStatus.Text = "Finished recording baseline EEG";
            } else {
                tBtnRecord.Image = Properties.Resources.IMG_Play;
                tBtnRecord.Text = "Start";
            }

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
                StopEegComponent(false);
                ProgramLogger.Log("[MainFrame.UpdateSegments()] Last segment");
            } else {
                current = StoryNavigator.ParagraphBuilder(Story.SegmentList[StoryNavigator.segCurr].PartList);
                previous = StoryNavigator.ParagraphBuilder(Story.SegmentList[StoryNavigator.segPrev].PartList);

                lblPrev.TextAlign = ContentAlignment.BottomLeft;
                lblProgress1.Text = Story.SegmentList[StoryNavigator.segCurr].Id.ToString();

                ProgramLogger.Log("[MainFrame.UpdateSegments()] Current segment = " + StoryNavigator.segCurr + "; Previous segment = " + StoryNavigator.segPrev);
            }

            lblCurr.Text = current;
            lblPrev.Text = previous;
        }
        #endregion

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
    }

}