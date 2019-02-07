using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Preprocessing
{
    class FilterColumns
    {
        private StreamReader source;
        private StreamWriter destination;
        private int[] columns;
        private bool removeColumns = false;

        public FilterColumns(String source, String destination, int[] columns, bool removeColumns)
        {
            this.source = new StreamReader(source);
            this.destination = new StreamWriter(destination);
            this.columns = columns;
            this.removeColumns = removeColumns;
            doProcessing();
        }

        public FilterColumns(String source, String destination, int[] columns) : this(source, destination, columns, false)
        {
            
        }

        public void doProcessing()
        {
            if(removeColumns && !source.EndOfStream)
            {
                source.ReadLine();                              //skip first line
            }

            while(!source.EndOfStream)
            {
                StringMethods.writeValues(filter(source.ReadLine()),destination, true);
            }
        }

        public String[] filter(String line)
        {
            String[] temp = line.Split(',');
            String[] ret = new String[columns.Length];
            for (int i = 0; i < columns.Length; i++)
            {
                ret[i] = temp[columns[i]];
            }
            return ret;
        }
    }
}
