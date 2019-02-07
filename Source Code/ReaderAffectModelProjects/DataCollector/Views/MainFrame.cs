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
        //private static AnnotatorFrame annotator;
        private static AnnotatorFrame2 annotator;
        #endregion
        #region Emotiv-related Variables
        private static EmotivConnector emoConnector;
        private Thread thdEmotivConnector;
        #endregion
        #region Timer-related Variables
        private const int duration = 120; // 10 seconds
        private static int timeLeft = duration;
        #endregion
        #region Camera-related Variables
        private static CameraConnector camConnector;
        #endregion
        private static String user = "TINTIN";
        private static Stories selectedStory;
        private static int clickCtr = 0;
        
        /// <summary>
        /// Creates an instance of the MainFrame.
        /// </summary>
        public MainFrame() {
            //user = new PromptFrame().ShowPromptFrame();
            InitializeComponent();
            InitializeOtherFrameComponents();
            InitializeComponentConnectors();
        }

        /// <summary>
        /// Sets the dynamic UI components.
        /// </summary>
        private void InitializeOtherFrameComponents() {
            Size = new Size(Width, Screen.PrimaryScreen.WorkingArea.Height);
            cbStoryList.SelectedIndex = 0;
            lblTime.Text = Utilities.GetTimerFormat(duration);
            GetStory();
        }

        /// <summary>
        /// Creates instances of the EmotiveConnector and CameraConnector.
        /// </summary>
        private void InitializeComponentConnectors() {
            emoConnector = new EmotivConnector(this);
            camConnector = new CameraConnector();
        }

        private void MainFrame_FormClosed(object sender, FormClosedEventArgs e) {
            camConnector.CloseConnector();
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
            lblTime.Text = Utilities.GetTimerFormat(duration);

            // Create output file
            String filename = "./Results/" + user + "_baseline_" + Utilities.GetTimestamp() + ".csv";
            emoConnector.CreateOutputFile(filename);

            // Start recording
            emoConnector.Connect();
            StartEegComponent();
            StartUiComponents(true);

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
                StopEegComponent();
                StopUiComponents(true);
                MessageBox.Show("Baseline EEG recorded!", "Update");
            }
        }
        #endregion

        #region START/STOP BUTTON ACTION
        private void tBtnRecord_Click(object sender, EventArgs e) {
            clickCtr++;
            if(clickCtr % 2 == 0) { // STOP
                // Emotiv-related
                StopEegComponent();
                // Camera-related
                camConnector.StopRecording();
                // UI-related
                StopUiComponents(false);
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
                StartEegComponent();
                //Camera-related
                camConnector.StartRecording();
                // UI-related
                StartUiComponents(false);
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

            emoConnector.Connect();
        }

        /// <summary>
        /// Creates the output files.
        /// </summary>
        private void CreateOutputFiles() {
            String template = "./Results/" + user + "_" + selectedStory.ToString() + "_" + Utilities.GetTimestamp() + "_";

            // Story-related
            String outputEmoAnnoFilename = template + "EmoAnno.csv";
            //annotator = new AnnotatorFrame(this, outputEmoAnnoFilename);
            annotator = new AnnotatorFrame2(this, outputEmoAnnoFilename);
            // Emotiv-related
            String outputEegFilename =  template + "EegData.csv";
            emoConnector.CreateOutputFile(outputEegFilename);
            // Camera-related
            String outputVideoFilename = template + "Video.mp4";
            camConnector.CreateOutputFile(outputVideoFilename);
        }

        /// <summary>
        /// Loads the story to the MainFrame.
        /// </summary>
        private void LoadStory() {
            try {
                StoryXmlParser.ParseFile(selectedStory);
                lblStatus.Text = "'" + Story.Title + "' is loaded";
                UpdateSegments();
            } catch(Exception e) {
                MessageBox.Show("Story XML file does not exist.", "ERROR!");
                lblStatus.Text = "Error in loading story XML";
            }
        }
        #endregion        

        #region EEG COMPONENTS
        /// <summary>
        /// Starts the EEG recording.
        /// </summary>
        private void StartEegComponent() {
            // Create the thread object. This does not start the thread.
            thdEmotivConnector = new Thread(emoConnector.StartRecording);
            // Start the worker thread.
            thdEmotivConnector.Start();
            Console.WriteLine("main thread: Starting worker thread...");
        }

        /// <summary>
        /// Stops the EEG recording.
        /// </summary>
        private void StopEegComponent() {          
            // Request that the worker thread stop itself:
            emoConnector.StopRecording();

            // Use the Join method to block the current thread until the object's thread terminates.
            thdEmotivConnector.Join();
            Console.WriteLine("main thread: Worker thread has terminated.");
        }
        #endregion

        #region START/STOP UI COMPONENTS
        private void StartUiComponents(Boolean isBaseline) {
            lblEegRecording.Text = "EEG is recording";
            lblEegRecording.ForeColor = Color.Green;
            btnGetBaseline.Enabled = false;
            if(isBaseline) {
                tBtnRecord.Enabled = false;
                cbStoryList.Enabled = false;
                btnNext.Enabled = false;
                lblTime.Font = new Font(lblTime.Font, FontStyle.Bold);
                lblStatus.Text = "Recording baseline EEG";
                lblCameraRecording.Text = "Camera is not recording";
                lblCameraRecording.ForeColor = Color.Red;
            } else {
                tBtnRecord.Image = Properties.Resources.IMG_Stop;
                tBtnRecord.Text = "Stop";
                lblCameraRecording.Text = "Camera is recording";
                lblCameraRecording.ForeColor = Color.Green;
            }
        }

        private void StopUiComponents(Boolean isBaseline) {
            lblEegRecording.Text = "EEG is not recording";
            lblEegRecording.ForeColor = Color.Red;
            lblCameraRecording.Text = "Camera is not recording";
            lblCameraRecording.ForeColor = Color.Red;
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
                ShowAnnotatorFrame();
                UpdateSegments();
            }
        }

        /// <summary>
        /// Shows the AnnotatorFrame.
        /// </summary>
        private void ShowAnnotatorFrame() {
            annotator.ShowAnnotatorFrame(lblProgress1.Text);
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
                camConnector.StopRecording();
                StopUiComponents(false);
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
    }
}