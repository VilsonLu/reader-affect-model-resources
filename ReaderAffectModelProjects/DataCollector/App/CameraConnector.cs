using AForge.Video.DirectShow;
using AForge.Video.FFMPEG;
using DataCollector.FileHandlers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector.App {
    public class CameraConnector {
        private VideoCaptureDevice videoSource;
        private VideoFileWriter videoWriter;
        private TimeSpan tmspStartRecording;

        /// <summary>
        /// Creates an instance of CameraConnector.
        /// </summary>
        public CameraConnector() {
            //List all available video sources. (That can be webcams as well as tv cards, etc)
            FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            //Check if atleast one video source is available
            if(videosources != null) {
                //For example use first video device. You may check if this is your webcam.
                videoSource = new VideoCaptureDevice(videosources[0].MonikerString);

                try {
                    //Check if the video device provides a list of supported resolutions
                    if(videoSource.VideoCapabilities.Length > 0) {
                        string highestSolution = "0;0";
                        //Search for the highest resolution
                        for(int i = 0; i < videoSource.VideoCapabilities.Length; i++) {
                            Console.WriteLine(i + " " + videoSource.VideoCapabilities[i].FrameSize);
                            if(videoSource.VideoCapabilities[i].FrameSize.Width > Convert.ToInt32(highestSolution.Split(';')[0]))
                                highestSolution = videoSource.VideoCapabilities[i].FrameSize.Width.ToString() + ";" + i.ToString();
                        }
                        //Set the highest resolution as active
                        //videoSource.VideoResolution = videoSource.VideoCapabilities[Convert.ToInt32(highestSolution.Split(';')[1])];

                        // Set resolution to [4] {Width=640, Height=360}
                        videoSource.VideoResolution = videoSource.VideoCapabilities[4];
                    }
                } catch { }

                //Create NewFrame event handler
                //This one triggers every time a new frame/image is captured
                videoSource.NewFrame += new AForge.Video.NewFrameEventHandler(videoSource_NewFrame);
            }
        }

        private void videoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs) {
            // This will get the elapse time between the current time from the time you start your recording
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            TimeSpan elapse = currentTime - tmspStartRecording;

            //Cast the frame as Bitmap object and don't forget to use ".Clone()" otherwise you'll probably get access violation exceptions
            videoWriter.WriteVideoFrame((Bitmap)eventArgs.Frame.Clone(), elapse);
        }

        /// <summary>
        /// Creates and opens the video file stream.
        /// </summary>
        /// <param name="filename"></param>
        public void CreateOutputFile(String filename) {
            int h = videoSource.VideoResolution.FrameSize.Height;
            int w = videoSource.VideoResolution.FrameSize.Width;
            int f = videoSource.VideoResolution.AverageFrameRate;

            videoWriter = new VideoFileWriter();
            videoWriter.Open(filename, w, h, f, VideoCodec.MPEG4);
        }

        /// <summary>
        /// Starts the camera recording.
        /// </summary>
        public void StartRecording() {
            tmspStartRecording = DateTime.Now.TimeOfDay;
            videoSource.Start();
        }

        /// <summary>
        /// Stops the camrea recording and closes the video file stream.
        /// </summary>
        public void StopRecording() {
            //Stop and free the webcam object.
            videoSource.SignalToStop();

            // Close the video file stream.
            videoWriter.Close();
        }

        /// <summary>
        /// Closes the CameraConnector.
        /// </summary>
        public void CloseConnector() {
            if(videoSource.IsRunning)
                StopRecording();

            videoSource = null;
        }
    }
}
