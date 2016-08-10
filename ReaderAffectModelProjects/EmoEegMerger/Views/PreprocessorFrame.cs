using DataPreprocessor.App;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataPreprocessor.Views {
    public partial class PreprocessorFrame : Form {
        public PreprocessorFrame() {
            InitializeComponent();
            txtEmoAnno.Text = @"C:\Users\ERDT\Documents\DATA\JULES_TV_20160808-124329_EmoAnno.csv";
            txtEegAnno.Text = @"C:\Users\ERDT\Documents\DATA\JULES_TV_20160808-124329_EegData.csv";
        }

        #region LogMerger
        private void btnBrowseEmoAnno_Click(object sender, EventArgs e) {
            browseEmoLog.ShowDialog();
        }

        private void browseEegAnno_FileOk(object sender, CancelEventArgs e) {
            txtEmoAnno.Text = browseEmoLog.FileName;
        }

        private void btnBrowseEegAnno_Click(object sender, EventArgs e) {
            browseEegLog.ShowDialog();
        }

        private void browseEegLog_FileOk(object sender, CancelEventArgs e) {
            txtEegAnno.Text = browseEegLog.FileName;
        }

        private void btnMerge_Click(object sender, EventArgs e) {
            if(File.Exists(txtEmoAnno.Text) && File.Exists(txtEegAnno.Text))
                new LogMerger(txtEmoAnno.Text, txtEegAnno.Text);
        }
        #endregion

        #region Windowing
        private void btnBrowseMergedLog_Click(object sender, EventArgs e) {
            browseMergedLog.ShowDialog();
        }

        private void browseMergedLog_FileOk(object sender, CancelEventArgs e) {
            txtMergedLog.Text = browseMergedLog.FileName;
        }

        private void btnProcess_Click(object sender, EventArgs e) {
            //if(File.Exists(txtMergedLog.Text))
               // new Windowing(txtMergedLog.Text,1,2);
        }
        #endregion
    }
}
