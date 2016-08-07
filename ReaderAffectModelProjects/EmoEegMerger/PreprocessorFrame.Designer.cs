namespace EmoEegMerger {
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
            this.txtMergedLog = new System.Windows.Forms.TextBox();
            this.btnBrowseMergedLog = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.browseMergedLog = new System.Windows.Forms.OpenFileDialog();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
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
            this.browseEmoLog.Title = "Select Emotion Log...";
            this.browseEmoLog.FileOk += new System.ComponentModel.CancelEventHandler(this.browseEegAnno_FileOk);
            // 
            // browseEegLog
            // 
            this.browseEegLog.Title = "Select EEG Log...";
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
            this.lblSpace.Size = new System.Drawing.Size(541, 1);
            this.lblSpace.TabIndex = 5;
            this.lblSpace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel3.Controls.Add(this.label3);
            this.flowLayoutPanel3.Controls.Add(this.txtMergedLog);
            this.flowLayoutPanel3.Controls.Add(this.btnBrowseMergedLog);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(18, 196);
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
            this.label3.Text = "Merged Log";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMergedLog
            // 
            this.txtMergedLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMergedLog.Location = new System.Drawing.Point(109, 3);
            this.txtMergedLog.Name = "txtMergedLog";
            this.txtMergedLog.Size = new System.Drawing.Size(342, 22);
            this.txtMergedLog.TabIndex = 1;
            // 
            // btnBrowseMergedLog
            // 
            this.btnBrowseMergedLog.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBrowseMergedLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseMergedLog.Location = new System.Drawing.Point(457, 3);
            this.btnBrowseMergedLog.MinimumSize = new System.Drawing.Size(0, 30);
            this.btnBrowseMergedLog.Name = "btnBrowseMergedLog";
            this.btnBrowseMergedLog.Size = new System.Drawing.Size(75, 30);
            this.btnBrowseMergedLog.TabIndex = 2;
            this.btnBrowseMergedLog.Text = "Browse";
            this.btnBrowseMergedLog.UseVisualStyleBackColor = true;
            this.btnBrowseMergedLog.Click += new System.EventHandler(this.btnBrowseMergedLog_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.Location = new System.Drawing.Point(167, 246);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(222, 35);
            this.btnProcess.TabIndex = 6;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // browseMergedLog
            // 
            this.browseMergedLog.FileOk += new System.ComponentModel.CancelEventHandler(this.browseMergedLog_FileOk);
            // 
            // MergerFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 308);
            this.Controls.Add(this.lblSpace);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Name = "MergerFrame";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
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
        private System.Windows.Forms.TextBox txtMergedLog;
        private System.Windows.Forms.Button btnBrowseMergedLog;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.OpenFileDialog browseMergedLog;
    }
}

