namespace Observatory
{
    partial class Observatory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Observatory));
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.lblDelay = new System.Windows.Forms.Label();
            this.txtDelay = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxSource = new System.Windows.Forms.ComboBox();
            this.gbDisplay = new System.Windows.Forms.GroupBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLTExcit = new System.Windows.Forms.TextBox();
            this.cbGraph = new System.Windows.Forms.CheckBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictGraph = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFrustration = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMeditation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEngagement = new System.Windows.Forms.TextBox();
            this.lblExcitement = new System.Windows.Forms.Label();
            this.txtExcitement = new System.Windows.Forms.TextBox();
            this.saveCSV = new System.Windows.Forms.SaveFileDialog();
            this.gbServer = new System.Windows.Forms.GroupBox();
            this.btnSvrLaunch = new System.Windows.Forms.Button();
            this.lblSvrPort = new System.Windows.Forms.Label();
            this.lblSvrIP = new System.Windows.Forms.Label();
            this.txtSvrPort = new System.Windows.Forms.TextBox();
            this.txtSvrIP = new System.Windows.Forms.TextBox();
            this.cbServer = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProfile = new System.Windows.Forms.SaveFileDialog();
            this.openProfile = new System.Windows.Forms.OpenFileDialog();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbScreenCap = new System.Windows.Forms.CheckBox();
            this.cbWebCamCap = new System.Windows.Forms.CheckBox();
            this.cbEmotiv = new System.Windows.Forms.CheckBox();
            this.gbSettings.SuspendLayout();
            this.gbDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictGraph)).BeginInit();
            this.gbServer.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.lblDelay);
            this.gbSettings.Controls.Add(this.txtDelay);
            this.gbSettings.Controls.Add(this.lblPort);
            this.gbSettings.Controls.Add(this.lblIP);
            this.gbSettings.Controls.Add(this.txtPort);
            this.gbSettings.Controls.Add(this.txtIP);
            this.gbSettings.Controls.Add(this.label4);
            this.gbSettings.Controls.Add(this.cbxSource);
            this.gbSettings.Location = new System.Drawing.Point(12, 79);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(564, 67);
            this.gbSettings.TabIndex = 13;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Emotiv - Settings";
            // 
            // lblDelay
            // 
            this.lblDelay.AutoSize = true;
            this.lblDelay.Location = new System.Drawing.Point(404, 30);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDelay.Size = new System.Drawing.Size(53, 13);
            this.lblDelay.TabIndex = 9;
            this.lblDelay.Text = "Delay(ms)";
            // 
            // txtDelay
            // 
            this.txtDelay.Location = new System.Drawing.Point(460, 27);
            this.txtDelay.Name = "txtDelay";
            this.txtDelay.Size = new System.Drawing.Size(30, 20);
            this.txtDelay.TabIndex = 8;
            this.txtDelay.Text = "500";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(479, 33);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(98, 41);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Visible = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(333, 31);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 13);
            this.lblPort.TabIndex = 6;
            this.lblPort.Text = "Port";
            this.lblPort.Visible = false;
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(180, 31);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(58, 13);
            this.lblIP.TabIndex = 5;
            this.lblIP.Text = "IP Address";
            this.lblIP.Visible = false;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(365, 28);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(33, 20);
            this.txtPort.TabIndex = 4;
            this.txtPort.Text = "1726";
            this.txtPort.Visible = false;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(244, 29);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(83, 20);
            this.txtIP.TabIndex = 2;
            this.txtIP.Text = "127.0.0.1";
            this.txtIP.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Source";
            // 
            // cbxSource
            // 
            this.cbxSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSource.FormattingEnabled = true;
            this.cbxSource.Items.AddRange(new object[] {
            "EmoComposer",
            "Emotiv"});
            this.cbxSource.Location = new System.Drawing.Point(53, 27);
            this.cbxSource.Name = "cbxSource";
            this.cbxSource.Size = new System.Drawing.Size(121, 21);
            this.cbxSource.TabIndex = 0;
            this.cbxSource.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // gbDisplay
            // 
            this.gbDisplay.Controls.Add(this.pictureBox5);
            this.gbDisplay.Controls.Add(this.label5);
            this.gbDisplay.Controls.Add(this.txtLTExcit);
            this.gbDisplay.Controls.Add(this.cbGraph);
            this.gbDisplay.Controls.Add(this.pictureBox4);
            this.gbDisplay.Controls.Add(this.pictureBox3);
            this.gbDisplay.Controls.Add(this.pictureBox2);
            this.gbDisplay.Controls.Add(this.pictureBox1);
            this.gbDisplay.Controls.Add(this.pictGraph);
            this.gbDisplay.Controls.Add(this.label3);
            this.gbDisplay.Controls.Add(this.txtFrustration);
            this.gbDisplay.Controls.Add(this.label2);
            this.gbDisplay.Controls.Add(this.txtMeditation);
            this.gbDisplay.Controls.Add(this.label1);
            this.gbDisplay.Controls.Add(this.txtEngagement);
            this.gbDisplay.Controls.Add(this.lblExcitement);
            this.gbDisplay.Controls.Add(this.txtExcitement);
            this.gbDisplay.Enabled = false;
            this.gbDisplay.Location = new System.Drawing.Point(12, 146);
            this.gbDisplay.Name = "gbDisplay";
            this.gbDisplay.Size = new System.Drawing.Size(565, 173);
            this.gbDisplay.TabIndex = 14;
            this.gbDisplay.TabStop = false;
            this.gbDisplay.Text = "Emotiv - Affectiv Data";
            this.gbDisplay.Enter += new System.EventHandler(this.gbDisplay_Enter);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Yellow;
            this.pictureBox5.Location = new System.Drawing.Point(420, 127);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(15, 15);
            this.pictureBox5.TabIndex = 29;
            this.pictureBox5.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(441, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "LT Excit.";
            // 
            // txtLTExcit
            // 
            this.txtLTExcit.Location = new System.Drawing.Point(510, 124);
            this.txtLTExcit.Name = "txtLTExcit";
            this.txtLTExcit.Size = new System.Drawing.Size(37, 20);
            this.txtLTExcit.TabIndex = 27;
            // 
            // cbGraph
            // 
            this.cbGraph.AutoSize = true;
            this.cbGraph.Location = new System.Drawing.Point(420, 150);
            this.cbGraph.Name = "cbGraph";
            this.cbGraph.Size = new System.Drawing.Size(85, 17);
            this.cbGraph.TabIndex = 26;
            this.cbGraph.Text = "Show Graph";
            this.cbGraph.UseVisualStyleBackColor = true;
            this.cbGraph.CheckedChanged += new System.EventHandler(this.cbGraph_CheckedChanged);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Black;
            this.pictureBox4.Location = new System.Drawing.Point(420, 101);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(15, 15);
            this.pictureBox4.TabIndex = 25;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Blue;
            this.pictureBox3.Location = new System.Drawing.Point(420, 75);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(15, 15);
            this.pictureBox3.TabIndex = 24;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Green;
            this.pictureBox2.Location = new System.Drawing.Point(420, 49);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(15, 15);
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(420, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 15);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // pictGraph
            // 
            this.pictGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictGraph.Location = new System.Drawing.Point(9, 16);
            this.pictGraph.Name = "pictGraph";
            this.pictGraph.Size = new System.Drawing.Size(405, 150);
            this.pictGraph.TabIndex = 21;
            this.pictGraph.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(441, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Frustration";
            // 
            // txtFrustration
            // 
            this.txtFrustration.Location = new System.Drawing.Point(510, 98);
            this.txtFrustration.Name = "txtFrustration";
            this.txtFrustration.Size = new System.Drawing.Size(37, 20);
            this.txtFrustration.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(441, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Meditation";
            // 
            // txtMeditation
            // 
            this.txtMeditation.Location = new System.Drawing.Point(510, 72);
            this.txtMeditation.Name = "txtMeditation";
            this.txtMeditation.Size = new System.Drawing.Size(37, 20);
            this.txtMeditation.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(441, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Engagement\r\n";
            // 
            // txtEngagement
            // 
            this.txtEngagement.Location = new System.Drawing.Point(510, 46);
            this.txtEngagement.Name = "txtEngagement";
            this.txtEngagement.Size = new System.Drawing.Size(37, 20);
            this.txtEngagement.TabIndex = 15;
            // 
            // lblExcitement
            // 
            this.lblExcitement.AutoSize = true;
            this.lblExcitement.Location = new System.Drawing.Point(441, 22);
            this.lblExcitement.Name = "lblExcitement";
            this.lblExcitement.Size = new System.Drawing.Size(59, 13);
            this.lblExcitement.TabIndex = 14;
            this.lblExcitement.Text = "Excitement";
            // 
            // txtExcitement
            // 
            this.txtExcitement.Location = new System.Drawing.Point(510, 19);
            this.txtExcitement.Name = "txtExcitement";
            this.txtExcitement.Size = new System.Drawing.Size(37, 20);
            this.txtExcitement.TabIndex = 13;
            // 
            // saveCSV
            // 
            this.saveCSV.DefaultExt = "csv";
            this.saveCSV.Filter = "CSV File | .csv";
            this.saveCSV.FileOk += new System.ComponentModel.CancelEventHandler(this.saveCSV_FileOk);
            // 
            // gbServer
            // 
            this.gbServer.Controls.Add(this.btnSvrLaunch);
            this.gbServer.Controls.Add(this.lblSvrPort);
            this.gbServer.Controls.Add(this.lblSvrIP);
            this.gbServer.Controls.Add(this.txtSvrPort);
            this.gbServer.Controls.Add(this.txtSvrIP);
            this.gbServer.Controls.Add(this.cbServer);
            this.gbServer.Location = new System.Drawing.Point(12, 319);
            this.gbServer.Name = "gbServer";
            this.gbServer.Size = new System.Drawing.Size(565, 57);
            this.gbServer.TabIndex = 15;
            this.gbServer.TabStop = false;
            this.gbServer.Text = "Emotiv Server";
            // 
            // btnSvrLaunch
            // 
            this.btnSvrLaunch.Location = new System.Drawing.Point(383, 20);
            this.btnSvrLaunch.Name = "btnSvrLaunch";
            this.btnSvrLaunch.Size = new System.Drawing.Size(75, 23);
            this.btnSvrLaunch.TabIndex = 12;
            this.btnSvrLaunch.Text = "Start";
            this.btnSvrLaunch.UseVisualStyleBackColor = true;
            this.btnSvrLaunch.Visible = false;
            this.btnSvrLaunch.Click += new System.EventHandler(this.btnSvrLaunch_Click);
            // 
            // lblSvrPort
            // 
            this.lblSvrPort.AutoSize = true;
            this.lblSvrPort.Location = new System.Drawing.Point(306, 26);
            this.lblSvrPort.Name = "lblSvrPort";
            this.lblSvrPort.Size = new System.Drawing.Size(26, 13);
            this.lblSvrPort.TabIndex = 11;
            this.lblSvrPort.Text = "Port";
            this.lblSvrPort.Visible = false;
            // 
            // lblSvrIP
            // 
            this.lblSvrIP.AutoSize = true;
            this.lblSvrIP.Location = new System.Drawing.Point(153, 26);
            this.lblSvrIP.Name = "lblSvrIP";
            this.lblSvrIP.Size = new System.Drawing.Size(58, 13);
            this.lblSvrIP.TabIndex = 10;
            this.lblSvrIP.Text = "IP Address";
            this.lblSvrIP.Visible = false;
            // 
            // txtSvrPort
            // 
            this.txtSvrPort.Location = new System.Drawing.Point(338, 22);
            this.txtSvrPort.Name = "txtSvrPort";
            this.txtSvrPort.Size = new System.Drawing.Size(33, 20);
            this.txtSvrPort.TabIndex = 9;
            this.txtSvrPort.Text = "2222";
            this.txtSvrPort.Visible = false;
            // 
            // txtSvrIP
            // 
            this.txtSvrIP.Location = new System.Drawing.Point(217, 22);
            this.txtSvrIP.Name = "txtSvrIP";
            this.txtSvrIP.Size = new System.Drawing.Size(83, 20);
            this.txtSvrIP.TabIndex = 8;
            this.txtSvrIP.Text = "127.0.0.1";
            this.txtSvrIP.Visible = false;
            // 
            // cbServer
            // 
            this.cbServer.AutoSize = true;
            this.cbServer.Location = new System.Drawing.Point(9, 24);
            this.cbServer.Name = "cbServer";
            this.cbServer.Size = new System.Drawing.Size(91, 17);
            this.cbServer.TabIndex = 0;
            this.cbServer.Text = "Enable server";
            this.cbServer.UseVisualStyleBackColor = true;
            this.cbServer.CheckedChanged += new System.EventHandler(this.cbServer_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(585, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "mainMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Emotiv Data Manager";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbEmotiv);
            this.groupBox1.Controls.Add(this.cbWebCamCap);
            this.groupBox1.Controls.Add(this.cbScreenCap);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 47);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Capture";
            // 
            // cbScreenCap
            // 
            this.cbScreenCap.AutoSize = true;
            this.cbScreenCap.Location = new System.Drawing.Point(73, 19);
            this.cbScreenCap.Name = "cbScreenCap";
            this.cbScreenCap.Size = new System.Drawing.Size(60, 17);
            this.cbScreenCap.TabIndex = 0;
            this.cbScreenCap.Text = "Screen";
            this.cbScreenCap.UseVisualStyleBackColor = true;
            // 
            // cbWebCamCap
            // 
            this.cbWebCamCap.AutoSize = true;
            this.cbWebCamCap.Location = new System.Drawing.Point(139, 19);
            this.cbWebCamCap.Name = "cbWebCamCap";
            this.cbWebCamCap.Size = new System.Drawing.Size(69, 17);
            this.cbWebCamCap.TabIndex = 1;
            this.cbWebCamCap.Text = "Webcam";
            this.cbWebCamCap.UseVisualStyleBackColor = true;
            // 
            // cbEmotiv
            // 
            this.cbEmotiv.AutoSize = true;
            this.cbEmotiv.Location = new System.Drawing.Point(9, 19);
            this.cbEmotiv.Name = "cbEmotiv";
            this.cbEmotiv.Size = new System.Drawing.Size(58, 17);
            this.cbEmotiv.TabIndex = 2;
            this.cbEmotiv.Text = "Emotiv";
            this.cbEmotiv.UseVisualStyleBackColor = true;
            this.cbEmotiv.CheckedChanged += new System.EventHandler(this.cmEmotiv_CheckedChanged);
            // 
            // Observatory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 383);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbServer);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.gbDisplay);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Observatory";
            this.Text = "Observatory";
            this.Load += new System.EventHandler(this.EmotivDataManager_Load);
            this.SizeChanged += new System.EventHandler(this.EmotivDataManager_Resize);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.gbDisplay.ResumeLayout(false);
            this.gbDisplay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictGraph)).EndInit();
            this.gbServer.ResumeLayout(false);
            this.gbServer.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.ComboBox cbxSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbDisplay;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictGraph;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFrustration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMeditation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEngagement;
        private System.Windows.Forms.Label lblExcitement;
        private System.Windows.Forms.TextBox txtExcitement;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.SaveFileDialog saveCSV;
        private System.Windows.Forms.GroupBox gbServer;
        private System.Windows.Forms.CheckBox cbServer;
        private System.Windows.Forms.Button btnSvrLaunch;
        private System.Windows.Forms.Label lblSvrPort;
        private System.Windows.Forms.Label lblSvrIP;
        private System.Windows.Forms.TextBox txtSvrPort;
        private System.Windows.Forms.TextBox txtSvrIP;
        private System.Windows.Forms.CheckBox cbGraph;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveProfile;
        private System.Windows.Forms.OpenFileDialog openProfile;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLTExcit;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.TextBox txtDelay;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbWebCamCap;
        private System.Windows.Forms.CheckBox cbScreenCap;
        private System.Windows.Forms.CheckBox cbEmotiv;
    }
}

