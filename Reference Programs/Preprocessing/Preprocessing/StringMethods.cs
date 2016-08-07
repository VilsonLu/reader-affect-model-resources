using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Preprocessing
{
    /// <summary>
    /// This class provides functions that involve String processing
    /// </summary>
    class StringMethods
    {
        public static List<String> getColumnLabels(StreamReader source1, StreamReader source2)
        {
            List<String> results = new List<String>();

            if (!source1.EndOfStream)
            {
                String[] eegcolumns = source1.ReadLine().Split(',');
                for (int i = 0; i < eegcolumns.Length; i++)
                {
                    results.Add(eegcolumns.ElementAt(i));
                }
            }
            if (!source2.EndOfStream)
            {
                String[] contextcolumns = source2.ReadLine().Split(',');
                for (int i = 1; i < contextcolumns.Length; i++)         //dont include time column
                {
                    results.Add(contextcolumns.ElementAt(i));
                }
            }

               return results;
        }

        public static List<String> getColumns(StreamReader source1, StreamReader source2, int[] source1Ignore, int[] source2Ignore)
        {
            List<String> results = new List<String>();
            String[] s1 = source1.ReadLine().Split(',');
            String[] s2 = source2.ReadLine().Split(',');

            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 0; j < source1Ignore.Length; j++)
                {
                    if (source1Ignore[j] != i)
                    {
                        results.Add(s1[i]);
                        break;
                    }
                }
            }

            for (int i = 0; i < s2.Length; i++)
            {
                for (int j = 0; j < source2Ignore.Length; j++)
                {
                    if (source2Ignore[j] != i)
                    {
                        results.Add(s2[i]);
                        break;
                    }
                }
            }
            return results;
        }

        /// <summary>
        /// Writes the column headers for a file
        /// </summary>
        /// <param name="columnLabels">A list of column labels in String format</param>
        /// <param name="write">An instantiated StreamWriter to be used for writing the columns</param>
        public static void writeColumns(List<String> columnLabels, StreamWriter write)
        {
            for (int x = 0; x < columnLabels.Count; x++)
            {
                if (x != 0)
                    write.Write("," + columnLabels.ElementAt(x));
                else
                    write.Write(columnLabels.ElementAt(x));
            }
            write.Write("\n");
        }

        public static void writeValues(String[] values, StreamWriter write, bool newline)
        {
            for (int x = 0; x < values.Length; x++)
            {
                if (x != 0)
                    write.Write("," + values.ElementAt(x));
                else
                    write.Write(values.ElementAt(x));
            }
            if (newline)
            { 
                write.Write("\n"); 
            }
        }

        /// <summary>
        /// Add the String to the end of the Array.
        /// </summary>
        /// <param name="container">The array to which the new String will be added</param>
        /// <param name="word">The String to be added to the array</param>
        /// <returns>An array of String that is one element bigger than the original array</returns>
        public static String[] addToLast(String[] container, String word)
        {
            String[] ret = new String[container.Length + 1];
            for (int i = 0; i < container.Length; i++)
            {
                ret[i] = container[i];
            }
            ret[container.Length] = word;
            return ret;
        }

        /// <summary>
        /// Convert an array to a List of String
        /// </summary>
        /// <param name="arr">The array to be converted</param>
        /// <returns>A list representation of the array</returns>
        public static List<String> toList(String[] arr)
        {
            List<String> list = new List<String>();
            foreach (String s in arr)
            {
                list.Add(s);
            }
            return list;
        }
               
    }
}
