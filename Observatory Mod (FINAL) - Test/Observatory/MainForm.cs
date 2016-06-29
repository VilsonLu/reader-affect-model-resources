using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;
using Observatory.EmotionAnnotation;


namespace Observatory
{
    public partial class Main : Form
    {
        //private EmotionAnnotation.Annotation_2 ae;
        private EmotionAnnotation.Annotation_3 ae;
        private Int32 interval = 5 * 1000;                                     // 1000 ms = 1 sec
        private String filename = "self-report.csv";
        private bool popUp = false;
        public static StreamWriter write;


        public Main()
        {
            InitializeComponent();
            //Add emotion Values
            List<EmotionAnnotation.Label> emotions = new List<EmotionAnnotation.Label>();
            emotions.Add(new EmotionAnnotation.Label("Confused", 0, 100, 1));
            emotions.Add(new EmotionAnnotation.Label("Bored", 0, 100, 1));
            emotions.Add(new EmotionAnnotation.Label("Frustrated", 0, 100, 1));
            //ae = new EmotionAnnotation.Annotation_2(this, emotions);
            ae = new EmotionAnnotation.Annotation_3(this, emotions);
            this.Visible = true;
           
        }

        private void REPORT_Click(object sender, EventArgs e)
        {
            ae.show();
        }

        private void resetTimer()
        {
            timer.Stop();
            timer.Start();
        }

        /*
        private void timer_Tick(object sender, EventArgs e)
        {
            SystemSounds.Beep.Play();
            timer.Stop();
            ae.show();
        }
         * */
    }
}
