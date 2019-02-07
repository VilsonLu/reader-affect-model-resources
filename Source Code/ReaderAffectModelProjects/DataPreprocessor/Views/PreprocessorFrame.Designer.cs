namespace DataPreprocessor.Views {
    partial class PreprocessorFrame {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmoAnno = new System.Windows.Forms.TextBox();
            this.btnBrowseEmoAnno = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEegAnno = new System.Windows.Forms.TextBox();
            this.btnBrowseEegAnno = new System.Windows.Forms.Button();
            this.btnMerge = new System.Windows.Forms.Button();
            this.browseEmoLog = new System.Windows.Forms.OpenFileDialog();
            this.browseEegLog = new System.Windows.Forms.OpenFileDialog();
            this.lblSpace = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWindowLog = new System.Windows.Forms.TextBox();
            this.btnBrowseWindow = new System.Windows.Forms.Button();
            this.btnWindow = new System.Windows.Forms.Button();
            this.browseSegmentLog = new System.Windows.Forms.OpenFileDialog();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSegmentLog = new System.Windows.Forms.TextBox();
            this.btnBrowseSegmentLog = new System.Windows.Forms.Button();
            this.btnSegment = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.browseWindowLog = new System.Windows.Forms.FolderBrowserDialog();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.txtEmoAnno);
            this.flowLayoutPanel1.Controls.Add(this.btnBrowseEmoAnno);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(538, 44);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.MinimumSize = new System.Drawing.Size(100, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Emotion Log";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmoAnno
            // 
            this.txtEmoAnno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmoAnno.Location = new System.Drawing.Point(109, 3);
            this.txtEmoAnno.Name = "txtEmoAnno";
            this.txtEmoAnno.Size = new System.Drawing.Size(342, 22);
            this.txtEmoAnno.TabIndex = 1;
            // 
            // btnBrowseEmoAnno
            // 
            this.btnBrowseEmoAnno.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBrowseEmoAnno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseEmoAnno.Location = new System.Drawing.Point(457, 3);
            this.btnBrowseEmoAnno.MinimumSize = new System.Drawing.Size(0, 30);
            this.btnBrowseEmoAnno.Name = "btnBrowseEmoAnno";
            this.btnBrowseEmoAnno.Size = new System.Drawing.Size(75, 30);
            this.btnBrowseEmoAnno.TabIndex = 2;
            this.btnBrowseEmoAnno.Text = "Browse";
            this.btnBrowseEmoAnno.UseVisualStyleBackColor = true;
            this.btnBrowseEmoAnno.Click += new System.EventHandler(this.btnBrowseEmoAnno_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.txtEegAnno);
            this.flowLayoutPanel2.Controls.Add(this.btnBrowseEegAnno);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(12, 62);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(538, 44);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.MinimumSize = new System.Drawing.Size(100, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 36);
            this.label2.TabIndex = 0;
            this.label2.Text = "EEG Log";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEegAnno
            // 
            this.txtEegAnno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEegAnno.Location = new System.Drawing.Point(109, 3);
            this.txtEegAnno.Name = "txtEegAnno";
            this.txtEegAnno.Size = new System.Drawing.Size(342, 22);
            this.txtEegAnno.TabIndex = 1;
            // 
            // btnBrowseEegAnno
            // 
            this.btnBrowseEegAnno.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBrowseEegAnno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseEegAnno.Location = new System.Drawing.Point(457, 3);
            this.btnBrowseEegAnno.MinimumSize = new System.Drawing.Size(0, 30);
            this.btnBrowseEegAnno.Name = "btnBrowseEegAnno";
            this.btnBrowseEegAnno.Size = new System.Drawing.Size(75, 30);
            this.btnBrowseEegAnno.TabIndex = 2;
            this.btnBrowseEegAnno.Text = "Browse";
            this.btnBrowseEegAnno.UseVisualStyleBackColor = true;
            this.btnBrowseEegAnno.Click += new System.EventHandler(this.btnBrowseEegAnno_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMerge.Location = new System.Drawing.Point(167, 112);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(222, 35);
            this.btnMerge.TabIndex = 4;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // browseEmoLog
            // 
            this.browseEmoLog.Title = "Reader Affect Model   |   Select Emotion Log...";
            this.browseEmoLog.FileOk += new System.ComponentModel.CancelEventHandler(this.browseEegAnno_FileOk);
            // 
            // browseEegLog
            // 
            this.browseEegLog.Title = "Reader Affect Model   |   Select EEG Log...";
            this.browseEegLog.FileOk += new System.ComponentModel.CancelEventHandler(this.browseEegLog_FileOk);
            // 
            // lblSpace
            // 
            this.lblSpace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpace.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpace.Location = new System.Drawing.Point(12, 177);
            this.lblSpace.Margin = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.lblSpace.Name = "lblSpace";
            this.lblSpace.Size = new System.Drawing.Size(541, 2);
            this.lblSpace.TabIndex = 5;
            this.lblSpace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel3.Controls.Add(this.label3);
            this.flowLayoutPanel3.Controls.Add(this.txtWindowLog);
            this.flowLayoutPanel3.Controls.Add(this.btnBrowseWindow);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(12, 350);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(538, 44);
            this.flowLayoutPanel3.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.MinimumSize = new System.Drawing.Size(100, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 36);
            this.label3.TabIndex = 0;
            this.label3.Text = "Log";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWindowLog
            // 
            this.txtWindowLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWindowLog.Location = new System.Drawing.Point(109, 3);
            this.txtWindowLog.Name = "txtWindowLog";
            this.txtWindowLog.Size = new System.Drawing.Size(342, 22);
            this.txtWindowLog.TabIndex = 1;
            // 
            // btnBrowseWindow
            // 
            this.btnBrowseWindow.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBrowseWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseWindow.Location = new System.Drawing.Point(457, 3);
            this.btnBrowseWindow.MinimumSize = new System.Drawing.Size(0, 30);
            this.btnBrowseWindow.Name = "btnBrowseWindow";
            this.btnBrowseWindow.Size = new System.Drawing.Size(75, 30);
            this.btnBrowseWindow.TabIndex = 2;
            this.btnBrowseWindow.Text = "Browse";
            this.btnBrowseWindow.UseVisualStyleBackColor = true;
            this.btnBrowseWindow.Click += new System.EventHandler(this.btnBrowseWindow_Click);
            // 
            // btnWindow
            // 
            this.btnWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWindow.Location = new System.Drawing.Point(161, 400);
            this.btnWindow.Name = "btnWindow";
            this.btnWindow.Size = new System.Drawing.Size(222, 35);
            this.btnWindow.TabIndex = 6;
            this.btnWindow.Text = "Window";
            this.btnWindow.UseVisualStyleBackColor = true;
            this.btnWindow.Click += new System.EventHandler(this.btnWindow_Click);
            // 
            // browseSegmentLog
            // 
            this.browseSegmentLog.Title = "Reader Affect Model   |   Select Merged Log...";
            this.browseSegmentLog.FileOk += new System.ComponentModel.CancelEventHandler(this.browseMergedLog_FileOk);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel4.Controls.Add(this.label4);
            this.flowLayoutPanel4.Controls.Add(this.txtSegmentLog);
            this.flowLayoutPanel4.Controls.Add(this.btnBrowseSegmentLog);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(11, 202);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(538, 44);
            this.flowLayoutPanel4.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.MinimumSize = new System.Drawing.Size(100, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 36);
            this.label4.TabIndex = 0;
            this.label4.Text = "Merged Log";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSegmentLog
            // 
            this.txtSegmentLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSegmentLog.Location = new System.Drawing.Point(109, 3);
            this.txtSegmentLog.Name = "txtSegmentLog";
            this.txtSegmentLog.Size = new System.Drawing.Size(342, 22);
            this.txtSegmentLog.TabIndex = 1;
            // 
            // btnBrowseSegmentLog
            // 
            this.btnBrowseSegmentLog.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBrowseSegmentLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseSegmentLog.Location = new System.Drawing.Point(457, 3);
            this.btnBrowseSegmentLog.MinimumSize = new System.Drawing.Size(0, 30);
            this.btnBrowseSegmentLog.Name = "btnBrowseSegmentLog";
            this.btnBrowseSegmentLog.Size = new System.Drawing.Size(75, 30);
            this.btnBrowseSegmentLog.TabIndex = 2;
            this.btnBrowseSegmentLog.Text = "Browse";
            this.btnBrowseSegmentLog.UseVisualStyleBackColor = true;
            this.btnBrowseSegmentLog.Click += new System.EventHandler(this.btnBrowseSegmentLog_Click);
            // 
            // btnSegment
            // 
            this.btnSegment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSegment.Location = new System.Drawing.Point(160, 252);
            this.btnSegment.Name = "btnSegment";
            this.btnSegment.Size = new System.Drawing.Size(222, 35);
            this.btnSegment.TabIndex = 8;
            this.btnSegment.Text = "Segment";
            this.btnSegment.UseVisualStyleBackColor = true;
            this.btnSegment.Click += new System.EventHandler(this.btnSegment_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 321);
            this.label5.Margin = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(541, 2);
            this.label5.TabIndex = 9;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // browseWindowLog
            // 
            this.browseWindowLog.Description = "Reader Affect Model   |   Select Segment Folder...";
            this.browseWindowLog.SelectedPath = "C:\\Users\\ERDT\\Documents\\GitHub\\ReaderAffectModelRepo\\ReaderAffectModelProjects\\Da" +
    "taPreprocessor\\bin\\Debug\\Results\\JULES_TV";
            this.browseWindowLog.ShowNewFolderButton = false;
            // 
            // PreprocessorFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 469);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.flowLayoutPanel4);
            this.Controls.Add(this.btnSegment);
            this.Controls.Add(this.lblSpace);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.btnWindow);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Name = "PreprocessorFrame";
            this.Text = "Reader Affect Model   |   Data Preprocessor";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmoAnno;
        private System.Windows.Forms.Button btnBrowseEmoAnno;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEegAnno;
        private System.Windows.Forms.Button btnBrowseEegAnno;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.OpenFileDialog browseEmoLog;
        private System.Windows.Forms.OpenFileDialog browseEegLog;
        private System.Windows.Forms.Label lblSpace;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtWindowLog;
        private System.Windows.Forms.Button btnBrowseWindow;
        private System.Windows.Forms.Button btnWindow;
        private System.Windows.Forms.OpenFileDialog browseSegmentLog;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSegmentLog;
        private System.Windows.Forms.Button btnBrowseSegmentLog;
        private System.Windows.Forms.Button btnSegment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FolderBrowserDialog browseWindowLog;
    }
}

