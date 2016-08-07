using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Preprocessing.Emotion
{
    class EmotionInstance
    {
        private DateTime timestart;

        public DateTime Timestart
        {
            get { return timestart; }
            set { timestart = value; }
        }
        private DateTime timeend;

        public DateTime Timeend
        {
            get { return timeend; }
            set { timeend = value; }
        }
        private int confidence;

        public int Confidence
        {
            get { return confidence; }
            set { confidence = value; }
        }
        private int excitement;

        public int Excitement
        {
            get { return excitement; }
            set { excitement = value; }
        }
        private int frustration;

        public int Frustration
        {
            get { return frustration; }
            set { frustration = value; }
        }
        private int interest;

        public int Interest
        {
            get { return interest; }
            set { interest = value; }
        }

        private String write;

        public String Write
        {
            get { return Confidence +","+ Excitement +","+ Frustration +","+ Interest; }
        }

        //parameter is one row from the self-report csv file
        public EmotionInstance(String instance)
        {
            String[] line = instance.Split(',');

            timestart = TimeDateMethods.UNIXTimetoDateTime(Double.Parse(line[0]));
            timeend = TimeDateMethods.UNIXTimetoDateTime(Double.Parse(line[6]));
            confidence = Int32.Parse(line[1]);
            excitement = Int32.Parse(line[2]);
            frustration = Int32.Parse(line[3]);
            interest = Int32.Parse(line[4]);
        }

        //get the substric after the first instance of the character c
        public static String removeFirst(String input, char c)
        {
            int indexOf = input.IndexOf(c);
            return input.Substring(indexOf+1);
        }

        public static String removeLast(String input, char c)
        {
            int indexOf = input.LastIndexOf(c);
            return input.Substring(0, indexOf);
        }
    }
}
