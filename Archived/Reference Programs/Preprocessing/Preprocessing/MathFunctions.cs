using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Preprocessing
{
    class MathFunctions
    {
        public static double[] toZero(double[] d)
        {
            for (int i = 0; i < d.Length; i++)
            {
                d[i] = 0;
            }

            return d;
        }



        public static double[] getAverage(double[] values, int count)
        {
            for (int i = 2; i < values.Length; i++)                 //index 1 and 2 are not to be averaged
            {

                values[i] = values[i] / count;
            }
            return values;
        }

        public static double[] add(String[] line, double[] values)
        {

            if (line.Length == values.Length)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] += Double.Parse(line[i].Trim());
                }
                return values;
            }

            else return null; 
            
        }

        public static double[] add(String[] line, double[] values, int[] exceptions)
        {
            
                for (int i = 0; i < values.Length; i++)
                {
                    if(!Contains(exceptions, i))
                        values[i] += Double.Parse(line[i].Trim());
                }
                return values;     
        }

        public static bool Contains(int[] arr, int num)
        {
            bool ret = false;
            foreach (int n in arr)
            {
                if (n == num)
                    ret = true;
            }
            return ret;
        }
   
 

        
    }
}
