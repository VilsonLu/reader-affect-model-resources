using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Observatory.EmotionAnnotation
{
    public partial class Annotation_2 : Form
    {
        public List<Label> label;
        private double start_time;
        private Form parent;
        private LogWriter log;
        public static String filename = "EmotionAnnotation.csv";
        private List<TrackBar> trackbars;

        public Annotation_2(Form parent, List<Label> l)
        {
            InitializeComponent();
            this.parent = parent;
            label = l;
            init();
            trackbars = new List<TrackBar>();
            trackbars.Add(emo1Bar);
            trackbars.Add(emo2Bar);
            trackbars.Add(Difficulty);
            log = new LogWriter(trackbars, filename);
        }

        private void init()
        {
            if (label.Count == 2)
            {
                emo1Bar.Minimum = label[0].Min;
                emo1Bar.Maximum = label[0].Max;
                emo1Bar.TickFrequency = label[0].Interval;
                emo1Bar.Name = label[0].Name;
                emo1Label.Text = label[0].Name;


                emo2Bar.Minimum = label[1].Min;
                emo2Bar.Maximum = label[1].Max;
                emo2Bar.TickFrequency = label[1].Interval;
                emo2Bar.Name = label[1].Name;
                emo2Label.Text = label[1].Name;
            }
            else
                Console.WriteLine("ERROR!");
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            double end_time = (DateTime.Now.ToLocalTime() - new DateTime(1970, 1, 1).ToLocalTime()).TotalMilliseconds;
            log.writeValues(start_time.ToString(), end_time.ToString());
            close();
        }

        private void close()
        {
            this.Visible = false;
            parent.Enabled = true;
        }

        public void show()
        {
            start_time = (DateTime.Now.ToLocalTime() - new DateTime(1970, 1, 1).ToLocalTime()).TotalMilliseconds;
            parent.Enabled = false;
            for (int i = 0; i < trackbars.Count; i++)
            {
                trackbars[i].Value = (int)(trackbars[i].Maximum / 2);
                if (trackbars[i].Maximum % 2 == 1) //for odd numbers
                    trackbars[i].Value++;
            }
            this.Visible = true;
        }

    }
}
