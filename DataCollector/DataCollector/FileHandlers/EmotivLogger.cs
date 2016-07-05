using DataCollector.App;
using Emotiv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataCollector.FileHandlers {
    public class EmotivLogger {
        /// <summary>
        /// Access to the EDK is via the EmoEngine
        /// </summary>
        EmoEngine engine;
        /// <summary>
        /// Flag for telling the thread to begin terminating.
        /// Volatile is used as hint to the compiler that this data member will be accessed by multiple threads.
        /// </summary>
        private volatile bool _shouldStop;
        /// <summary>
        /// Used to uniquely identify a user's headset.
        /// </summary>
        int userID;
        /// <summary>
        /// Output file of the EmotivLogger.
        /// </summary>
        string filename;
        /// <summary>
        /// Delay for Thread.Sleep(delay).
        /// </summary>
        int delay = 10;
        int battery = 0;
        string header = "TIMESTAMP, BATTERY_LEVEL, AF3, T7, Pz, T8, AF4";

        /// <summary>
        /// Creates an instance of the EmotivLogger.
        /// </summary>
        /// <param name="filename"></param>
        public EmotivLogger(String filename) {
            this.filename = filename;

            Console.WriteLine("CREATE ENGINE");
            engine = EmoEngine.Instance;
            engine.UserAdded += new EmoEngine.UserAddedEventHandler(engine_UserAdded_Event);
            engine.EmoStateUpdated += new EmoEngine.EmoStateUpdatedEventHandler(engine_EmoStateUpdated);
        }

        #region Emotiv Event Handlers
        void engine_UserAdded_Event(object sender, EmoEngineEventArgs e) {
            Console.WriteLine("User Added Event has occured");

            // record the user 
            userID = (int)e.userId;

            // enable data aquisition for this user.
            engine.DataAcquisitionEnable((uint)userID, true);

            // ask for up to 1 second of buffered data
            engine.EE_DataSetBufferSizeInSec(1);

        }

        void engine_EmoStateUpdated(object sender, EmoStateUpdatedEventArgs e) {
            EmoState es = e.emoState;

            // Get info from UserID 0
            if(e.userId != 0)
                return;

            Int32 chargeLevel = 0;
            Int32 maxChargeLevel = 0;
            es.GetBatteryChargeLevel(out chargeLevel, out maxChargeLevel);
            battery = chargeLevel;
        }
        #endregion

        /// <summary>
        /// Resets the class to its initial state.
        /// </summary>
        public void Reset() {
            _shouldStop = false;
            userID = -1;

            // connect to EmoEngine.
            Console.WriteLine("CONNECT");
            engine.Connect();

            // create a header for our output file
            WriteHeader();
        }

        /// <summary>
        /// Creates the output CSV file and writes the header.
        /// </summary>
        private void WriteHeader() {
            TextWriter file = new StreamWriter(filename, false);
            file.WriteLine(header);
            file.Close();
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

            Console.WriteLine("Writing " + _bufferSize.ToString() + " sample of data ");

            // Write the data to a file
            TextWriter file = new StreamWriter(filename, true);

            for(int i = 0; i < _bufferSize; i++) {
                // now write the data
                //file.Write(data[EdkDll.EE_DataChannel_t.TIMESTAMP][i] + ",");
                file.Write(Utilities.GetCsvTimestamp());
                file.Write(battery + ",");
                file.Write(data[EdkDll.EE_DataChannel_t.AF3][i] + ",");
                file.Write(data[EdkDll.EE_DataChannel_t.T7][i] + ",");
                file.Write(data[EdkDll.EE_DataChannel_t.O1][i] + ",");
                file.Write(data[EdkDll.EE_DataChannel_t.T8][i] + ",");
                file.WriteLine(data[EdkDll.EE_DataChannel_t.AF4][i]);
            }
            file.Close();
        }

        #region Threading Methods
        /// <summary>
        /// Prompts the tool to start capturing data from the device. Will keep on recording until _shouldStop changes values.
        /// </summary>
        public void StartRecording() {
            while(!_shouldStop) {
                Console.WriteLine("worker thread: working...");
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
