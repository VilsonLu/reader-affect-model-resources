using DataCollector.FileHandlers;
using DataCollector.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataCollector {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            try {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainFrame());
            } catch (Exception e) {
                MessageBox.Show(e.Message + "\n" + e.StackTrace);
            }
        }
    }
}
