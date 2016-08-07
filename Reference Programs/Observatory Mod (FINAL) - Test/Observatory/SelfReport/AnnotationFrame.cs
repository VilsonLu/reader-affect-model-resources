using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Observatory.SelfReport
{
    public partial class AnnotationFrame : Form
    {
        public AnnotationFrame(Pair[] components)
        {
            InitializeComponent();
            int num
        }
    }

    public class Pair
    {
        private String name;
        private int max = 100;
        private int min = 0;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public int MaxValue
        {
            get { return max;}
            set { max = value; }
        }

        public int MinValue
        {
            get { return min; }
            set { min = value; }
        }

        public Pair(String name, int max, int min)
        {
            Name = name;
            MaxValue = max;
            MinValue = min;
        }
    }
}
