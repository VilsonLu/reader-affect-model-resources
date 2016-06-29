using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace Observatory.EmotionAnnotation
{
    public class Label
    {
        public String Name { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int Interval { get; set; }

        public Label(String name, int min, int max, int interval)
        {
            Name = name;
            Min = min;
            Max = max;
            Interval = interval;
        }

    }
}
