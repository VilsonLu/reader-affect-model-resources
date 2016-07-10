namespace DataCollector.Views {
    partial class AnnotatorFrame {
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStrikeYes = new System.Windows.Forms.Button();
            this.btnStrikeNo = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.chkReaderResponse = new System.Windows.Forms.CheckedListBox();
            this.adpPleasantness = new DataCollector.Views.EmotionPanel();
            this.adpAttention = new DataCollector.Views.EmotionPanel();
            this.adpSensitivity = new DataCollector.Views.EmotionPanel();
            this.adpAptitude = new DataCollector.Views.EmotionPanel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 404);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.adpPleasantness, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.adpAttention, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.adpSensitivity, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.adpAptitude, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(502, 400);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSubmit, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(512, 661);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(4, 609);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(504, 48);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.tableLayoutPanel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 413);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(506, 44);
            this.panel2.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(502, 40);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel4.Controls.Add(this.btnStrikeYes, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnStrikeNo, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(496, 34);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Did you find the segment \"striking\"?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStrikeYes
            // 
            this.btnStrikeYes.BackColor = System.Drawing.SystemColors.Control;
            this.btnStrikeYes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStrikeYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStrikeYes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStrikeYes.Location = new System.Drawing.Point(347, 0);
            this.btnStrikeYes.Margin = new System.Windows.Forms.Padding(0);
            this.btnStrikeYes.Name = "btnStrikeYes";
            this.btnStrikeYes.Size = new System.Drawing.Size(74, 34);
            this.btnStrikeYes.TabIndex = 2;
            this.btnStrikeYes.Text = "YES";
            this.btnStrikeYes.UseVisualStyleBackColor = false;
            this.btnStrikeYes.Click += new System.EventHandler(this.btnStrikeYes_Click);
            // 
            // btnStrikeNo
            // 
            this.btnStrikeNo.BackColor = System.Drawing.Color.Red;
            this.btnStrikeNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStrikeNo.Enabled = false;
            this.btnStrikeNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStrikeNo.Location = new System.Drawing.Point(421, 0);
            this.btnStrikeNo.Margin = new System.Windows.Forms.Padding(0);
            this.btnStrikeNo.Name = "btnStrikeNo";
            this.btnStrikeNo.Size = new System.Drawing.Size(75, 34);
            this.btnStrikeNo.TabIndex = 5;
            this.btnStrikeNo.Text = "NO";
            this.btnStrikeNo.UseVisualStyleBackColor = false;
            this.btnStrikeNo.Click += new System.EventHandler(this.btnStrikeNo_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.tableLayoutPanel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 463);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(506, 139);
            this.panel3.TabIndex = 6;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.chkReaderResponse, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.44444F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.55556F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(502, 135);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(496, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "Which aspect(s) triggrered the emotion?";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkReaderResponse
            // 
            this.chkReaderResponse.BackColor = System.Drawing.SystemColors.Control;
            this.chkReaderResponse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkReaderResponse.CheckOnClick = true;
            this.chkReaderResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkReaderResponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkReaderResponse.FormattingEnabled = true;
            this.chkReaderResponse.Items.AddRange(new object[] {
            "Overall enjoyment of reading the segment",
            "Character, setting, plot",
            "The way the sentence is structured",
            "Others"});
            this.chkReaderResponse.Location = new System.Drawing.Point(25, 36);
            this.chkReaderResponse.Margin = new System.Windows.Forms.Padding(25, 3, 3, 3);
            this.chkReaderResponse.Name = "chkReaderResponse";
            this.chkReaderResponse.Size = new System.Drawing.Size(474, 96);
            this.chkReaderResponse.TabIndex = 2;
            this.chkReaderResponse.SelectedIndexChanged += new System.EventHandler(this.chkReaderResponse__SelectedIndexChanged);
            // 
            // adpPleasantness
            // 
            this.adpPleasantness.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adpPleasantness.Description = "(How amused are you with the segment?)";
            this.adpPleasantness.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adpPleasantness.Label = "Pleasantness";
            this.adpPleasantness.Location = new System.Drawing.Point(3, 3);
            this.adpPleasantness.Name = "adpPleasantness";
            this.adpPleasantness.NegativeImage = global::DataCollector.Properties.Resources.PL_Neg;
            this.adpPleasantness.PositiveImage = global::DataCollector.Properties.Resources.PL_Pos;
            this.adpPleasantness.Size = new System.Drawing.Size(496, 94);
            this.adpPleasantness.TabIndex = 0;
            // 
            // adpAttention
            // 
            this.adpAttention.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adpAttention.Description = "(How interested are you with the segment?)";
            this.adpAttention.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adpAttention.Label = "Attention";
            this.adpAttention.Location = new System.Drawing.Point(3, 103);
            this.adpAttention.Name = "adpAttention";
            this.adpAttention.NegativeImage = global::DataCollector.Properties.Resources.AT_Neg;
            this.adpAttention.PositiveImage = global::DataCollector.Properties.Resources.AT_Pos;
            this.adpAttention.Size = new System.Drawing.Size(496, 94);
            this.adpAttention.TabIndex = 1;
            // 
            // adpSensitivity
            // 
            this.adpSensitivity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adpSensitivity.Description = "(How comfortable are you with the segment?)";
            this.adpSensitivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adpSensitivity.Label = "Sensitivity";
            this.adpSensitivity.Location = new System.Drawing.Point(3, 203);
            this.adpSensitivity.Name = "adpSensitivity";
            this.adpSensitivity.NegativeImage = global::DataCollector.Properties.Resources.SE_Neg;
            this.adpSensitivity.PositiveImage = global::DataCollector.Properties.Resources.SE_Pos;
            this.adpSensitivity.Size = new System.Drawing.Size(496, 94);
            this.adpSensitivity.TabIndex = 2;
            // 
            // adpAptitude
            // 
            this.adpAptitude.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adpAptitude.Description = "(How did you find the segment?)";
            this.adpAptitude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adpAptitude.Label = "Aptitude";
            this.adpAptitude.Location = new System.Drawing.Point(3, 303);
            this.adpAptitude.Name = "adpAptitude";
            this.adpAptitude.NegativeImage = global::DataCollector.Properties.Resources.AP_Neg;
            this.adpAptitude.PositiveImage = global::DataCollector.Properties.Resources.AP_Pos;
            this.adpAptitude.Size = new System.Drawing.Size(496, 94);
            this.adpAptitude.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 661);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reader Affect Model   |   Emotion Annotator";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private EmotionPanel adpPleasantness;
        private EmotionPanel adpAttention;
        private EmotionPanel adpSensitivity;
        private EmotionPanel adpAptitude;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnStrikeYes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStrikeNo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox chkReaderResponse;
    }
}