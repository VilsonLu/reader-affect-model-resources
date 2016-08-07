using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Preprocessing.Mouse
{
    /// <summary>
    /// This class computes the distance traveled by the mouse per second and stores it to a new file
    /// </summary>
    class Movement
    {
        private StreamReader read;
        private StreamWriter write;
        private static DateTime currentTime;

        /// <summary>
        /// Constructor. Processes after instantiation 
        /// </summary>
        /// <param name="source">Mouse frequency log full name</param>
        /// <param name="output">Output file full name</param>
        public Movement(String source, String output)
        {
            read = new StreamReader(source);
            write = new StreamWriter(output);
            doProcessing();
        }

        public void doProcessing()
        {
            int prev_x = -100;
            int prev_y = -100;
            int distance = 0;
            DateTime previousTime = new DateTime(1970, 1, 1);

            if (!read.EndOfStream)
                write.WriteLine("Time, Distance");
            while (!read.EndOfStream)
            {
                String readline = read.ReadLine();
                String[] coords = readline.Split('=');
                String[] x  = coords[1].Split(',');
                String[] y = coords[2].Split('}');

                //x and y coordinates of the new line 
                int x_coord = Int32.Parse(x[0]);
                int y_coord = Int32.Parse(y[0]);

                /*
                String[] time = readline.Split(' ');
                time[5] = time[5].Remove(time[5].Length - 1);   
                 //time and date of the new line
                currentTime = time[4] + " " + time[5];
                */
                String time = readline.Split('{')[0].Trim();
                time = time.Remove(time.Length - 1);
                currentTime = TimeDateMethods.StringtoDateTime(time);
                

                if (previousTime.Equals(new DateTime(1970,1,1)) && prev_x == -100 && prev_y == -100)        //first iteration
                {
                    previousTime = currentTime;
                    prev_x = x_coord;
                    prev_y = y_coord;
                }
                else if (currentTime.Equals(previousTime))                                                  //equal
                {
                    distance += getDistance(x_coord, y_coord, prev_x, prev_y);
                    prev_x = x_coord;
                    prev_y = y_coord;
                }
                else                                                                                        //time change
                {                                                
                    int newDistance = 0;
                    if (previousTime.AddSeconds(1) == currentTime)
                    {                       
                        //distance += getDistance(x_coord, y_coord, prev_x, prev_y);
                        //Console.WriteLine("went in! "+distance);
                        newDistance = getDistance(x_coord, y_coord, prev_x, prev_y);
                    }

                    if (distance != 0)
                    {
                        write.WriteLine(previousTime + ", " + distance); //Console.WriteLine(distance);
                    }

                    //reset values
                    distance = newDistance;
                    previousTime = currentTime;
                    prev_x = x_coord;
                    prev_y = y_coord;
                }
                
                //DateTime dt = DateTime.Parse(time[4] + " " + time[5]);
                //double stamp = (dt - new DateTime(1, 1, 1)).TotalMilliseconds;
                //write.WriteLine(dt.ToLongTimeString() + " : " + x_coord + "," + y_coord);
            }
            //for last second (EOF does not have a new time to compare with, so it won't meet the last condition
            if (distance != 0)
            {
                write.WriteLine(previousTime + " , " + distance);
            }
            read.Close();
            write.Close();
        }

        /// <summary>
        /// Computes the Eucledian distance of 2 points
        /// </summary>
        /// <param name="x1">X value of first point</param>
        /// <param name="y1">Y value of first point</param>
        /// <param name="x2">X value of second point</param>
        /// <param name="y2">Y value of second point</param>
        /// <returns></returns>
        public static int getDistance(int x1, int y1, int x2, int y2)
        {
            double temp = Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
            int result = 0;
            if (temp < 1 && temp != 0)
            {
                //Console.WriteLine("ZERO"+currentTime + " " + result);
                result = 1;
            }
            else
            {
                result = (int)Math.Floor(temp);
                //Console.WriteLine(currentTime + " " + result);
            }
            //Console.WriteLine(currentTime + " (" + x1 + "," + y1 + ")" + "(" + x2 + "," + y2 + ") : "+result);
            return result;
        }
    }
}
