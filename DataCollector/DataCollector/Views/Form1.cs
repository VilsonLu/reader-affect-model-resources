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
    public partial class Form1 : Form {
        private Boolean isStriking = false;
        public Form1() {
            InitializeComponent();
        }

        private void btnStrikeYes_Click(object sender, EventArgs e) {
            btnStrikeYes.Enabled = false;
            btnStrikeYes.BackColor = Color.Green;
            btnStrikeNo.Enabled = true;
            btnStrikeNo.BackColor = SystemColors.Control;
            isStriking = true;
        }

        private void btnStrikeNo_Click(object sender, EventArgs e) {
            btnStrikeYes.Enabled = true;
            btnStrikeYes.BackColor = SystemColors.Control;
            btnStrikeNo.Enabled = false;
            btnStrikeNo.BackColor = Color.Red;
            isStriking = false;
        }
    }
}
