using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Observatory
{
    public partial class AnnotateEmotion : Form
    {
        private StreamWriter write;
        private Form parent;
        private double start_time;
        private Timer timer;

        public AnnotateEmotion(StreamWriter sw, Form p, Timer t)
        {
            InitializeComponent();
            write = sw;
            parent = p;
            timer = t;

            /** COLUMN HEADERS **/
            sw.WriteLine("TIME_START, CONFIDENCE, EXCITEMENT, FRUSTRATION, INTEREST, TIME_END");
        }

        public void resetTimer()
        {
            timer.Stop();
            timer.Start();
        }

        private void setDefaults()
        {
            ConfidenceBar.Value = 50;
            ExcitementBar.Value = 50;
            FrustrationBar.Value = 50;
            InterestBar.Value = 50;
            DifficultyBar.Value = 3;
        }

        public void show()
        {
            start_time = (DateTime.Now.ToLocalTime() - new DateTime(1970, 1, 1).ToLocalTime()).TotalMilliseconds;
            setDefaults();
            parent.Enabled = false;
            this.Visible = true;
        }

        public void close()
        {
            this.Visible = false;
            parent.Enabled = true;
            resetTimer();
            //this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            double end_time = (DateTime.Now.ToLocalTime() - new DateTime(1970, 1, 1).ToLocalTime()).TotalMilliseconds;
            write.WriteLine("{0},{1},{2},{3},{4},{5},{6}",start_time,ConfidenceBar.Value,ExcitementBar.Value,FrustrationBar.Value,InterestBar.Value,DifficultyBar.Value,end_time);
            write.Flush();
            close();
        }
    }
}
