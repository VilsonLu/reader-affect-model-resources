using DataCollector.FileHandlers;
using DataCollector.Views;
using Emotiv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataCollector.App {
    class EmotivConnector {
        #region Emotiv-related Variables
        /// <summary>
        /// Access to the EDK is via the EmoEngine
        /// </summary>
        EmoEngine engine;
        /// <summary>
        /// Used to uniquely identify a user's headset.
        /// </summary>
        int userID;
        #endregion
        #region Threading-related Variables
        /// <summary>
        /// Flag for telling the thread to begin terminating.
        /// Volatile is used as hint to the compiler that this data member will be accessed by multiple threads.
        /// </summary>
        private volatile bool _shouldStop;
        /// <summary>
        /// Delay for Thread.Sleep(delay).
        /// </summary>
        int delay = 10;
        #endregion
        #region EmotivLogger-related Variables
        EmotivLogger log;
        String filename;
        #endregion
        MainFrame frame;
        

        public EmotivConnector(MainFrame frame, String filename) {
            this.frame = frame;
            this.filename = filename;

            userID = -1;

            // Create an instance of the EmoEngine
            Console.WriteLine("CREATE ENGINE");
            engine = EmoEngine.Instance;

            // Add the event handlers
            engine.UserAdded += new EmoEngine.UserAddedEventHandler(engine_UserAdded_Event);
            engine.EmoStateUpdated += new EmoEngine.EmoStateUpdatedEventHandler(engine_EmoStateUpdated);
            engine.EmoEngineConnected += new EmoEngine.EmoEngineConnectedEventHandler(engine_Connected_Event);
            engine.EmoEngineDisconnected += new EmoEngine.EmoEngineDisconnectedEventHandler(engine_Disconnected_Event);
        }

        #region Emotiv Event Handlers
        private void engine_UserAdded_Event(object sender, EmoEngineEventArgs e) {
            Console.WriteLine("User Added Event has occured");

            // Record the user
            userID = (int)e.userId;

            // Enable data aquisition for this user.
            engine.DataAcquisitionEnable((uint)userID, true);

            // Ask for up to 1 second of buffered data
            engine.EE_DataSetBufferSizeInSec(1);
        }

        private void engine_EmoStateUpdated(object sender, EmoStateUpdatedEventArgs e) {
            EmoState es = e.emoState;

            // Get info from UserID 0
            if(e.userId != 0)
                return;

            Int32 chargeLevel = 0;
            Int32 maxChargeLevel = 0;
            es.GetBatteryChargeLevel(out chargeLevel, out maxChargeLevel);
            frame.UpdateEegBatteryStatus("(Battery: " + chargeLevel + "/" + maxChargeLevel + ")");
        }

        private void engine_Connected_Event(object sender, EmoEngineEventArgs e) {
            // Update the UI
            Console.WriteLine("STATUS CONNECT");
        }

        private void engine_Disconnected_Event(object sender, EmoEngineEventArgs e) {
            // Update the UI
            Console.WriteLine("STATUS DISCONNECT");
        }
        #endregion

        public void Reset() {
            _shouldStop = false;
            userID = -1;

            // connect to EmoEngine.
            Console.WriteLine("CONNECT");
            engine.Connect();

            // create a header for our output file
            log = new EmotivLogger(filename);
        }

        /// <summary>
        /// Logs the values captured from the device to the output CSV file.
        /// </summary>
        public void Record() {
            // Handle any waiting events
            engine.ProcessEvents();

            // If the user has not yet connected, do not proceed
            if((int)userID == -1)
                return;

            Dictionary<EdkDll.EE_DataChannel_t, double[]> data = engine.GetData((uint)userID);

            if(data == null) {
                return;
            }

            int _bufferSize = data[EdkDll.EE_DataChannel_t.ES_TIMESTAMP].Length;

            // Write the data to a file
            Console.WriteLine("Writing " + _bufferSize.ToString() + " sample of data ");
            for(int i = 0; i < _bufferSize; i++)
                log.Log(Utilities.GetCsvTimestamp(), data[EdkDll.EE_DataChannel_t.AF3][i], data[EdkDll.EE_DataChannel_t.T7][i], data[EdkDll.EE_DataChannel_t.O1][i], data[EdkDll.EE_DataChannel_t.T8][i], data[EdkDll.EE_DataChannel_t.AF4][i]);
        }

        #region Threading Methods
        /// <summary>
        /// Prompts the tool to start capturing data from the device. Will keep on recording until _shouldStop changes values.
        /// </summary>
        public void StartRecording() {
            while(!_shouldStop) {
                //Console.WriteLine("worker thread: working...");
                Record();
                Thread.Sleep(delay);
            }
            Console.WriteLine("DISCONNECT");
            engine.Disconnect();
        }

        /// <summary>
        /// Prompts the tool stop capturing data from the device. Changes the value of the _shouldStop flag.
        /// </summary>
        public void StopRecording() {
            _shouldStop = true;
        }
        #endregion
    }
}
