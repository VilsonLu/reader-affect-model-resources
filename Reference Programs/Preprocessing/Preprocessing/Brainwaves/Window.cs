using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Preprocessing.Brainwaves
{
    class Window
    {
        private StreamReader eeg;
        //private StreamWriter write;
        private String destinationPath;
        private int interval = 2;               //default inteval should be <= 60
        private int remove = 5;
        private String column;
        private bool isOdd;

        public Window(String eeg, String destinationPath, int interval, int remove, bool odd)
        {
            this.eeg = new StreamReader(eeg);
            //this.write = new StreamWriter(write);
            this.destinationPath = destinationPath;
            this.interval = interval%60;
            this.remove = remove;
            this.isOdd = odd;
            doProcessing();
        }

        public void init()
        {
            if (!eeg.EndOfStream)
            {
                column = eeg.ReadLine();
            }
            
        }

        public void doProcessing()
        {
            init();
            removeFirst();
            //int changes = 0;
            //String time = "";
            //DateTime previous = new DateTime(1970, 1, 1);
            DateTime startTime = new DateTime(1970, 1, 1);
            DateTime endTime = new DateTime(1970, 1, 1);
            TimeSpan INTERVAL = new TimeSpan(0, 0, interval);
            int counter = 0;

            while (!eeg.EndOfStream)
            {
                String line = eeg.ReadLine();                                           //read line from file
                String[] temp = line.Split(',');                                        //split line (comma)
                DateTime current = TimeDateMethods.toDateTime(line);                    //get timestamp of line
                startTime = current;                                                    //set startTime
                endTime = startTime.AddSeconds(interval+1);                             //set end time based on interval
                int name = (counter*interval);
                if (isOdd)
                    name++;
                StreamWriter write = new StreamWriter(destinationPath +name+".csv");
                
                //while current is not equal to end time, current is before end time and current is after start time
                
                bool equalEndTime = current.CompareTo(endTime) == 0;
                bool beforeEndTime = current.CompareTo(endTime) == -1;

                bool afterStartTime = current.CompareTo(startTime) == 1; //Console.WriteLine("equal: " + current.CompareTo(startTime));
                bool equalStartTime = current.CompareTo(startTime) == 0; //Console.WriteLine("0 equal: " + equalStartTime);
                
                while (!equalEndTime && beforeEndTime && (afterStartTime || equalStartTime) && !eeg.EndOfStream)
                {
                    write.WriteLine(line);

                    line = eeg.ReadLine();
                    temp = line.Split(',');
                    current = TimeDateMethods.toDateTime(line);
                    equalEndTime = current.CompareTo(endTime) == 0;
                    beforeEndTime = current.CompareTo(endTime) == -1;
                    afterStartTime = current.CompareTo(startTime) == 1; 
                    equalStartTime = current.CompareTo(startTime) == 0;
                }
                write.Close();
                counter++;
              

                /*
                if (previous == new DateTime(1970,1,1))                                   //first iteration
                {
                    startTime = current;
                    endTime = current.AddSeconds(interval);
                }
                else if (current.CompareTo(endTime) == 1)                                  //is equal
                {
                    
                }
                */
                
                //ts.
                //else if(current.
                //previous = current;
                /*
                int time = previous.AddSeconds(1).CompareTo(current);   //get 1 second after; 
                if(time == 0)                                           //if current time is just after 1 second
                {

                }
                else if (time != 0)                                     //if time not next
                {
                    
                }
                 * */
            }
        }

        
        
        public void removeFirst()
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
}
