using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataCollector.Views {
    public partial class PromptFrame : Form {
        public String Input { get; set; }

        public PromptFrame() {
            InitializeComponent();
        }

        /// <summary>
        /// Returns the input of the user.
        /// </summary>
        /// <param name="caption">The title for the PromptFrame.</param>
        /// <returns></returns>
        public String ShowPromptFrame(String caption) {
            Text = caption;
            if(ShowDialog() == DialogResult.OK)
                return txtPrompt.Text;
            else
                return "";
        }

        /// <summary>
        /// Returns the input of the user.
        /// </summary>
        /// <returns></returns>
        public String ShowPromptFrame() {
            if(ShowDialog() == DialogResult.OK)
                return txtPrompt.Text;
            else
                return "";
        }
    }
}
