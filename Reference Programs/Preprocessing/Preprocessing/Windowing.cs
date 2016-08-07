using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Preprocessing
{
    class Windowing
    {
        StreamReader eeg;
        StreamWriter write;
        String source;
        String destinationPath;
        String columnHeaders;
        List<Interval> startTimeList = new List<Interval>();
        int skipTime = 5;
        
        int interval;
        bool isEven;

        //skip first 5 seconds
        public Windowing(String eeg, String destinationPath, int interval, bool isEven)
        {
            source = eeg;
            this.eeg = new StreamReader(eeg);
            this.destinationPath = destinationPath;
            this.interval = interval;
            this.isEven = isEven;
            init();
            doSkip(skipTime);
            doProcessing();
        }

        private void init()
        {
            if (!eeg.EndOfStream)
            {
                columnHeaders = eeg.ReadLine(); 
            }
            else
            {
                columnHeaders = "";
            }
        }

        private void doProcessing()
        {
            DateTime current = new DateTime();
            DateTime endTime = new DateTime() ;
            DateTime startTime = new DateTime();

            bool writeToFile = false;
            int count;
            if (isEven)//even
                count = 0;
            else//odd = skip 1 second 
            {
                count = 1;
                //skip(1);
            }

            while (!eeg.EndOfStream)
            {
                if (!eeg.EndOfStream)                   //create new file
                {
                    int name = (count * interval);
                    if (!isEven)
                        name++;

                    write = new StreamWriter(name + ".csv"); Console.WriteLine("create file {0}", count);
                    write.WriteLine(columnHeaders);     //write column headers
                    String line = eeg.ReadLine();
                    String[] temp = line.Split(',');
                    current = TimeDateMethods.toDateTime(line);
                    startTime = TimeDateMethods.toDateTime(line);
                    endTime = startTime.AddSeconds(interval);
                    writeToFile = true;
                    count++;
                    startTimeList.Add(new Interval(startTime, endTime));
                }

                while (!eeg.EndOfStream && writeToFile) //append created file
                {
                    String line = eeg.ReadLine();
                    String[] temp = line.Split(',');
                    current = TimeDateMethods.toDateTime(line);

                    bool equalEndTime = current.CompareTo(endTime) == 0;
                    bool beforeEndTime = current.CompareTo(endTime) == -1;
                    bool equalStartTime = current.CompareTo(startTime) == 0;
                    bool afterStartTime = current.CompareTo(startTime) == 1;

                    if ((equalEndTime || beforeEndTime) && (equalStartTime || afterStartTime))
                    {
                        write.WriteLine(line);
                    }
                    else
                    {
                        writeToFile = false;
                    }
                }
                write.Close();
            }
            eeg.Close();
            
            doOdd();
            Console.WriteLine("Finished reading file");
        }
        
        private void doOdd()
        {
            
            //DirectoryInfo di = new DirectoryInfo(destinationPath);
            //IEnumerable<FileInfo> files = di.EnumerateFiles("*.csv");
            //FileInfo[] fileList = files.ToArray();
            //StreamReader eegOdd = new StreamReader(source);
            eeg = new StreamReader(source);
            doSkip(skipTime);
            DateTime current;
            DateTime oddStartTime;
            DateTime oddEndTime;

            if (!eeg.EndOfStream)
            {
                //skip column header
            }
            for (int i = 0; i < startTimeList.Count && !eeg.EndOfStream; i++)
            {
                bool writeToFile = true;
                bool skip = true;
                oddStartTime = startTimeList[i].StartTime.AddSeconds(1);
                oddEndTime = startTimeList[i].EndTime.AddSeconds(1);

                //if not within: traverse until current matches start time
                while (!eeg.EndOfStream && skip)
                {
                    String line = eeg.ReadLine();
                    String[] temp = line.Split(',');
                    current = TimeDateMethods.toDateTime(line);
                    
                    write = new StreamWriter((i*2+1)+".csv");

                    bool equalEndTime = current.CompareTo(oddEndTime) == 0;
                    bool beforeEndTime = current.CompareTo(oddEndTime) == -1;
                    bool equalStartTime = current.CompareTo(oddStartTime) == 0;
                    bool afterStartTime = current.CompareTo(oddStartTime) == 1;

                    if (equalStartTime || equalEndTime || (afterStartTime && beforeEndTime))    //equal startTime or equal endTime or within startTime and endTime
                    {
                        skip = false;
                    }

                    //if within
                    while (!eeg.EndOfStream && writeToFile)
                    {
                        String newline = eeg.ReadLine();
                        String[] newtemp = line.Split(',');
                        current = TimeDateMethods.toDateTime(newline);

                        equalEndTime = current.CompareTo(oddEndTime) == 0;
                        beforeEndTime = current.CompareTo(oddEndTime) == -1;
                        equalStartTime = current.CompareTo(oddStartTime) == 0;
                        afterStartTime = current.CompareTo(oddStartTime) == 1;

                        if (equalStartTime || equalEndTime || (afterStartTime && beforeEndTime))
                        {
                            write.WriteLine(newline);
                        }
                        else
                            writeToFile = false;
                    }
                    write.Close();
                }
            }
        }

        public void doSkip(int remove)
        {
            int changes = 0;
            String previous = "";

            //DateTime previousTime = new DateTime(;
            while (changes < remove && !eeg.EndOfStream)
            {
                String line = eeg.ReadLine();
                String current = line.Split(',')[1];

                if (!current.Equals(previous))
                {
                    previous = current;
                    changes++;
                }
            }
        }

    }
    /*
    class Interval
    {
        private DateTime start;
        private DateTime end;

        public DateTime StartTime { get { return start; } set { start = value; } }
        public DateTime EndTime { get { return end; } set { end = value; } }
        public Interval(DateTime s, DateTime e)
        {
            start = s;
            end = e;
        }
    }
     * */
}
