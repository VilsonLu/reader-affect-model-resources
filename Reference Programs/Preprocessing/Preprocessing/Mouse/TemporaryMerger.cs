using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace Preprocessing.Mouse
{
    class TemporaryMerger
    {
        private StreamReader mouseandcontext;
        private StreamReader frequency;
        private StreamWriter destination;

        public TemporaryMerger(String mc, String f, String dest)
        {
            mouseandcontext = new StreamReader(mc);
            frequency = new StreamReader(f);
            destination = new StreamWriter(dest);
            doProcessing();
            //doProcessing1("3:19:52 PM", "3:19:52");
        }

        public void doProcessing1(String s1, String s2)
        {
            if (s1.Contains(s2))
            {
                Console.WriteLine("waaa");
            }
        }

        public void close()
        {
            mouseandcontext.Close();
            frequency.Close();
            destination.Close();
        }

        public void doProcessing()
        {
            //get and write column labels of mouse and context
            if (!mouseandcontext.EndOfStream)
            {
                String columns = mouseandcontext.ReadLine();
                Console.WriteLine(columns);
                destination.WriteLine(columns);
            }
            //skip first row(column)
            frequency.ReadLine();

            String ftime = "";
            String fcount = "";
            String mctime = "";


            //brute force approach
            Dictionary<String, String> d = new Dictionary<String, String>();
            while (!frequency.EndOfStream)
            {
                String f = frequency.ReadLine();
                String[] freq = f.Split(',');
                d.Add(freq[0].Split(' ')[0], freq[1]);
                //d.Add("waa", "waa");
            }

            while (!mouseandcontext.EndOfStream)
            {
                String line = mouseandcontext.ReadLine();

                if (line != null)
                {
                    String[] mc = line.Split(',');
                    mctime = mc[0].Trim();
                    String count = "";
                    if (d.ContainsKey(mctime))
                    {
                        count = d[mctime].Trim();
                        int index = line.IndexOf(',');
                        line = line.Insert(index + 1, count);
                        
                    }
                    else
                    {
                        int index = line.IndexOf(',');
                        line = line.Insert(index + 1, "0");
                        
                    }
                    
                    Console.WriteLine(line);
                    destination.WriteLine(line);
                }
            }
            
            /*
            while (!frequency.EndOfStream && !mouseandcontext.EndOfStream)
            {
                String[] f;
                String mc = "";
                int index = -1;
                f = frequency.ReadLine().Split(',');                //f[0] = time, f[1] frequency count
                
                ftime = f[0];
                fcount = f[1];
                Console.WriteLine("ftime: " + ftime);
                Console.WriteLine("fcount: " + fcount);

                while (!ftime.Contains(mctime) || mctime.Equals(""))
                {
                    mc = mouseandcontext.ReadLine();
                    Console.WriteLine("mc: " + mc);
                    if (mc != null)
                    {
                        mctime = mc.Split(',')[0];
                        Console.WriteLine("mctime: " + mctime);
                        index = mc.IndexOf(',');
                        
                    }
                    else
                        break;
                }
                if (ftime.Contains(mctime))
                {
                    Console.WriteLine("waaa");
                    mc.Insert(index + 1, fcount);
                    destination.WriteLine(mc);
                }
            }*/
            /*
            int index = 0;
            while (!frequency.EndOfStream || !mouseandcontext.EndOfStream)
            {
                String mc = mouseandcontext.ReadLine();
                mctime = mc.Split(',')[0];
                Console.WriteLine("mctime: " + mctime);
                while (!ftime.Equals(mctime) && !frequency.EndOfStream)
                {
                    String freq = frequency.ReadLine();
                    if (freq != null)
                    {
                        String[] f = freq.Split(',');
                        ftime = f[0].Split(' ')[0];
                        fcount = f[1];
                        Console.WriteLine("ftime: " + ftime);
                        Console.WriteLine("fcount: " + fcount);
                        if (ftime.Equals(mctime))
                        {
                            index = mc.IndexOf(',');
                            mc.Insert(index, fcount);
                            destination.WriteLine(mc);
                        }
                            
                    }
                    else
                        break;
                    
                }
                if (ftime.Equals(mctime))
                {
                    index = mc.IndexOf(',');
                    mc.Insert(index, fcount);
                }
            }*/
            close();
        }
    }
}
