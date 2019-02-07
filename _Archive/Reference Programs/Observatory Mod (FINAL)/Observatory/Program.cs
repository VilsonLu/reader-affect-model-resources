using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

namespace Observatory
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                /*          Process[] p = Process.GetProcesses();
                            foreach (Process b in p)
                            {
                                if (b.ProcessName.Equals("EmotivDataManager"))
                                {
                                    b.ProcessorAffinity = (IntPtr)1;
                                }
                            }*/
                Application.Run(new Observatory());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n" + e.StackTrace);
            }
        }
    }
}
