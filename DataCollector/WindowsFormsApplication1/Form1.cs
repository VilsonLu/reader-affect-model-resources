using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Video.FFMPEG;
using AForge.Video.VFW;

namespace WindowsFormsApplication1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        //Create webcam object
        VideoCaptureDevice videoSource;
        VideoFileWriter FileWriter = new VideoFileWriter();
        TimeSpan tmspStartRecording;

        //AVIWriter FileWriter = new AVIWriter();
        private void Form1_Load(object sender, EventArgs e) {
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
                            Console.WriteLine(i+" "+videoSource.VideoCapabilities[i].FrameSize);
                            if(videoSource.VideoCapabilities[i].FrameSize.Width > Convert.ToInt32(highestSolution.Split(';')[0]))
                                highestSolution = videoSource.VideoCapabilities[i].FrameSize.Width.ToString() + ";" + i.ToString();
                        }
                        //Set the highest resolution as active
                        //videoSource.VideoResolution = videoSource.VideoCapabilities[Convert.ToInt32(highestSolution.Split(';')[1])];
                        videoSource.VideoResolution = videoSource.VideoCapabilities[4];
                    }
                } catch { }

                //Create NewFrame event handler
                //(This one triggers every time a new frame/image is captured
                videoSource.NewFrame += new AForge.Video.NewFrameEventHandler(videoSource_NewFrame);

                //Start recording
                //videoSource.Start();
            }

        }

        void videoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs) {
            //Cast the frame as Bitmap object and don't forget to use ".Clone()" otherwise
            //you'll probably get access violation exceptions
            //pictureBoxVideo.BackgroundImage = (Bitmap)eventArgs.Frame.Clone();
            //FileWriter.WriteVideoFrame((Bitmap)eventArgs.Frame.Clone());

            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            // this will get the elapse time between
            // the current time from the time you start your recording
            TimeSpan elapse = currentTime - tmspStartRecording;
            FileWriter.WriteVideoFrame((Bitmap)eventArgs.Frame.Clone(), elapse);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //Stop and free the webcam object if application is closing
            if(videoSource != null && videoSource.IsRunning) {
                videoSource.SignalToStop();
                videoSource = null;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            int h = videoSource.VideoResolution.FrameSize.Height;
            int w = videoSource.VideoResolution.FrameSize.Width;
            int f = videoSource.VideoResolution.AverageFrameRate;
            FileWriter.Open("test.avi", w, h, f, VideoCodec.MPEG4);
            //Start recording
            tmspStartRecording = DateTime.Now.TimeOfDay;
            videoSource.Start();
        }

        private void button2_Click(object sender, EventArgs e) {
            if(videoSource != null && videoSource.IsRunning) {
                videoSource.SignalToStop();
                videoSource = null;
            }
            FileWriter.Close();
        }
    }
}