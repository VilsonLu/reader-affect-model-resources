namespace Observatory
{
    partial class Main
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.REPORT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer
            // 
            //this.timer.Enabled = true;
            //this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // REPORT
            // 
            this.REPORT.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.REPORT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.REPORT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.REPORT.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.REPORT.Location = new System.Drawing.Point(0, 0);
            this.REPORT.Name = "REPORT";
            this.REPORT.Size = new System.Drawing.Size(200, 80);
            this.REPORT.TabIndex = 0;
            this.REPORT.Text = "REPORT";
            this.REPORT.UseVisualStyleBackColor = false;
            this.REPORT.Click += new System.EventHandler(this.REPORT_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 80);
            this.Controls.Add(this.REPORT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button REPORT;
    }
}

