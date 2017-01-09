using System.Windows.Forms;

namespace DataCollector.Views
{
    partial class MainFrame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrame));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblProgress0 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblProgress1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblProgress2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblProgress3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnGetBaseline = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblTime = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cbStoryList = new System.Windows.Forms.ToolStripComboBox();
            this.tBtnRecord = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblEegRecording = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lblCameraRecording = new System.Windows.Forms.ToolStripLabel();
            this.lblPrev = new System.Windows.Forms.Label();
            this.lblSpace = new System.Windows.Forms.Label();
            this.lblCurr = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.flowLayoutPanel1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.btnNext);
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(4);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(802, 995);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(802, 1045);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblProgress0,
            this.lblProgress1,
            this.lblProgress2,
            this.lblProgress3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(802, 25);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(116, 20);
            this.lblStatus.Text = "No story loaded";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProgress0
            // 
            this.lblProgress0.Name = "lblProgress0";
            this.lblProgress0.Size = new System.Drawing.Size(80, 20);
            this.lblProgress0.Text = "|  Segment";
            this.lblProgress0.Visible = false;
            // 
            // lblProgress1
            // 
            this.lblProgress1.Name = "lblProgress1";
            this.lblProgress1.Size = new System.Drawing.Size(18, 20);
            this.lblProgress1.Text = "#";
            this.lblProgress1.Visible = false;
            // 
            // lblProgress2
            // 
            this.lblProgress2.Name = "lblProgress2";
            this.lblProgress2.Size = new System.Drawing.Size(23, 20);
            this.lblProgress2.Text = "of";
            this.lblProgress2.Visible = false;
            // 
            // lblProgress3
            // 
            this.lblProgress3.Name = "lblProgress3";
            this.lblProgress3.Size = new System.Drawing.Size(18, 20);
            this.lblProgress3.Text = "#";
            this.lblProgress3.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.toolStrip1);
            this.flowLayoutPanel1.Controls.Add(this.lblPrev);
            this.flowLayoutPanel1.Controls.Add(this.lblSpace);
            this.flowLayoutPanel1.Controls.Add(this.lblCurr);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(802, 951);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGetBaseline,
            this.toolStripSeparator1,
            this.lblTime,
            this.toolStripSeparator2,
            this.cbStoryList,
            this.tBtnRecord,
            this.toolStripSeparator3,
            this.lblEegRecording,
            this.toolStripSeparator4,
            this.lblCameraRecording});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(700, 47);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnGetBaseline
            // 
            this.btnGetBaseline.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetBaseline.Image = global::DataCollector.Properties.Resources.IMG_Baseline;
            this.btnGetBaseline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGetBaseline.Name = "btnGetBaseline";
            this.btnGetBaseline.Size = new System.Drawing.Size(68, 44);
            this.btnGetBaseline.Text = "Baseline";
            this.btnGetBaseline.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGetBaseline.Click += new System.EventHandler(this.btnGetBaseline_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 47);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = false;
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(73, 44);
            this.lblTime.Text = "(00m:00s)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 47);
            // 
            // cbStoryList
            // 
            this.cbStoryList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStoryList.DropDownWidth = 200;
            this.cbStoryList.Items.AddRange(new object[] {
            "Test",
            "Man from the South",
            "The Fisherman and the Jinni",
            "The Veldt"});
            this.cbStoryList.Name = "cbStoryList";
            this.cbStoryList.Size = new System.Drawing.Size(160, 47);
            this.cbStoryList.SelectedIndexChanged += new System.EventHandler(this.cbStoryList_SelectedIndexChanged);
            // 
            // tBtnRecord
            // 
            this.tBtnRecord.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBtnRecord.Image = global::DataCollector.Properties.Resources.IMG_Play;
            this.tBtnRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tBtnRecord.Name = "tBtnRecord";
            this.tBtnRecord.Size = new System.Drawing.Size(44, 44);
            this.tBtnRecord.Text = "Start";
            this.tBtnRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tBtnRecord.Click += new System.EventHandler(this.tBtnRecord_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 47);
            // 
            // lblEegRecording
            // 
            this.lblEegRecording.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEegRecording.ForeColor = System.Drawing.Color.Red;
            this.lblEegRecording.Name = "lblEegRecording";
            this.lblEegRecording.Size = new System.Drawing.Size(150, 44);
            this.lblEegRecording.Text = "EEG is not recording";
            this.lblEegRecording.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 47);
            // 
            // lblCameraRecording
            // 
            this.lblCameraRecording.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCameraRecording.ForeColor = System.Drawing.Color.Red;
            this.lblCameraRecording.Name = "lblCameraRecording";
            this.lblCameraRecording.Size = new System.Drawing.Size(176, 44);
            this.lblCameraRecording.Text = "Camera is not recording";
            this.lblCameraRecording.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPrev
            // 
            this.lblPrev.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrev.AutoSize = true;
            this.lblPrev.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrev.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblPrev.Location = new System.Drawing.Point(4, 78);
            this.lblPrev.Margin = new System.Windows.Forms.Padding(4, 31, 4, 0);
            this.lblPrev.Name = "lblPrev";
            this.lblPrev.Size = new System.Drawing.Size(792, 22);
            this.lblPrev.TabIndex = 0;
            this.lblPrev.Text = "Previous Segment";
            this.lblPrev.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblSpace
            // 
            this.lblSpace.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpace.Location = new System.Drawing.Point(0, 112);
            this.lblSpace.Margin = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.lblSpace.Name = "lblSpace";
            this.lblSpace.Size = new System.Drawing.Size(800, 2);
            this.lblSpace.TabIndex = 1;
            this.lblSpace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurr
            // 
            this.lblCurr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurr.AutoSize = true;
            this.lblCurr.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurr.Location = new System.Drawing.Point(4, 126);
            this.lblCurr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurr.Name = "lblCurr";
            this.lblCurr.Size = new System.Drawing.Size(792, 34);
            this.lblCurr.TabIndex = 2;
            this.lblCurr.Text = "Current Segment";
            // 
            // btnNext
            // 
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(0, 951);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(802, 44);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 1045);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainFrame";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reader Affect Model   |   Data Collector";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFrame_FormClosed);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox cbStoryList;
        private System.Windows.Forms.Label lblPrev;
        private System.Windows.Forms.Label lblSpace;
        private System.Windows.Forms.Label lblCurr;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ToolStripStatusLabel lblProgress0;
        private System.Windows.Forms.ToolStripStatusLabel lblProgress1;
        private System.Windows.Forms.ToolStripStatusLabel lblProgress2;
        private System.Windows.Forms.ToolStripStatusLabel lblProgress3;
        private ToolStripLabel lblEegRecording;
        private ToolStripButton tBtnRecord;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnGetBaseline;
        private ToolStripLabel lblTime;
        private Timer timer;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripLabel lblCameraRecording;
    }
}

