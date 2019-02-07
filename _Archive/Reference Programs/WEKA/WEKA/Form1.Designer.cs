namespace WEKA
{
    partial class Form1
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
            this.directoryTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mlpCheckBox = new System.Windows.Forms.CheckBox();
            this.j48CheckBox = new System.Windows.Forms.CheckBox();
            this.knnCheckBox = new System.Windows.Forms.CheckBox();
            this.buildButton = new System.Windows.Forms.Button();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.directoryDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.outputDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // directoryTextBox
            // 
            this.directoryTextBox.Location = new System.Drawing.Point(59, 8);
            this.directoryTextBox.Name = "directoryTextBox";
            this.directoryTextBox.Size = new System.Drawing.Size(249, 20);
            this.directoryTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Directory:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mlpCheckBox);
            this.panel1.Controls.Add(this.j48CheckBox);
            this.panel1.Controls.Add(this.knnCheckBox);
            this.panel1.Location = new System.Drawing.Point(96, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(169, 35);
            this.panel1.TabIndex = 3;
            // 
            // mlpCheckBox
            // 
            this.mlpCheckBox.AutoSize = true;
            this.mlpCheckBox.Location = new System.Drawing.Point(115, 9);
            this.mlpCheckBox.Name = "mlpCheckBox";
            this.mlpCheckBox.Size = new System.Drawing.Size(48, 17);
            this.mlpCheckBox.TabIndex = 2;
            this.mlpCheckBox.Text = "MLP";
            this.mlpCheckBox.UseVisualStyleBackColor = true;
            // 
            // j48CheckBox
            // 
            this.j48CheckBox.AutoSize = true;
            this.j48CheckBox.Location = new System.Drawing.Point(66, 9);
            this.j48CheckBox.Name = "j48CheckBox";
            this.j48CheckBox.Size = new System.Drawing.Size(43, 17);
            this.j48CheckBox.TabIndex = 1;
            this.j48CheckBox.Text = "J48";
            this.j48CheckBox.UseVisualStyleBackColor = true;
            // 
            // knnCheckBox
            // 
            this.knnCheckBox.AutoSize = true;
            this.knnCheckBox.Location = new System.Drawing.Point(11, 9);
            this.knnCheckBox.Name = "knnCheckBox";
            this.knnCheckBox.Size = new System.Drawing.Size(49, 17);
            this.knnCheckBox.TabIndex = 0;
            this.knnCheckBox.Text = "KNN";
            this.knnCheckBox.UseVisualStyleBackColor = true;
            // 
            // buildButton
            // 
            this.buildButton.Location = new System.Drawing.Point(312, 68);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(75, 23);
            this.buildButton.TabIndex = 4;
            this.buildButton.Text = "Build";
            this.buildButton.UseVisualStyleBackColor = true;
            this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(59, 37);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(249, 20);
            this.outputTextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Output:";
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(312, 35);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 7;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(312, 6);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // directoryDialog
            // 
            this.directoryDialog.HelpRequest += new System.EventHandler(this.directoryDialog_HelpRequest);
            // 
            // outputDialog
            // 
            this.outputDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.outputDialog_FileOk_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 103);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.buildButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.directoryTextBox);
            this.Name = "Form1";
            this.Text = "Brainwaves & Mouse";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox directoryTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox mlpCheckBox;
        private System.Windows.Forms.CheckBox j48CheckBox;
        private System.Windows.Forms.CheckBox knnCheckBox;
        private System.Windows.Forms.Button buildButton;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.FolderBrowserDialog directoryDialog;
        private System.Windows.Forms.SaveFileDialog outputDialog;

    }
}

