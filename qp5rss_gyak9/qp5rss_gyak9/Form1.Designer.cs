﻿namespace qp5rss_gyak9
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.bBrowse = new System.Windows.Forms.Button();
            this.bStart = new System.Windows.Forms.Button();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.progressIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Záróév:";
            this.label1.UseMnemonic = false;
            // 
            // nudYear
            // 
            this.nudYear.Location = new System.Drawing.Point(62, 16);
            this.nudYear.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.nudYear.Minimum = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.nudYear.Name = "nudYear";
            this.nudYear.Size = new System.Drawing.Size(48, 20);
            this.nudYear.TabIndex = 1;
            this.nudYear.Value = new decimal(new int[] {
            2006,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(128, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Népességfájl:";
            this.label2.UseMnemonic = false;
            // 
            // tbFile
            // 
            this.tbFile.Location = new System.Drawing.Point(205, 15);
            this.tbFile.Name = "tbFile";
            this.tbFile.Size = new System.Drawing.Size(144, 20);
            this.tbFile.TabIndex = 3;
            this.tbFile.Text = "C:\\temp\\nép.csv";
            // 
            // bBrowse
            // 
            this.bBrowse.Location = new System.Drawing.Point(363, 15);
            this.bBrowse.Name = "bBrowse";
            this.bBrowse.Size = new System.Drawing.Size(75, 21);
            this.bBrowse.TabIndex = 4;
            this.bBrowse.Text = "Browse...";
            this.bBrowse.UseVisualStyleBackColor = true;
            this.bBrowse.Click += new System.EventHandler(this.bBrowse_Click);
            // 
            // bStart
            // 
            this.bStart.Enabled = false;
            this.bStart.Location = new System.Drawing.Point(442, 15);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(75, 21);
            this.bStart.TabIndex = 5;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(15, 42);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(500, 396);
            this.richTextBox.TabIndex = 6;
            this.richTextBox.Text = "";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 444);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(500, 23);
            this.progressBar.TabIndex = 7;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(38, 481);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(122, 13);
            this.progressLabel.TabIndex = 8;
            this.progressLabel.Text = "Jelenleg nem fut feladat.";
            // 
            // progressIcon
            // 
            this.progressIcon.Image = global::qp5rss_gyak9.Properties.Resources.progress_black;
            this.progressIcon.Location = new System.Drawing.Point(15, 478);
            this.progressIcon.Name = "progressIcon";
            this.progressIcon.Size = new System.Drawing.Size(18, 18);
            this.progressIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.progressIcon.TabIndex = 9;
            this.progressIcon.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 505);
            this.Controls.Add(this.progressIcon);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.bBrowse);
            this.Controls.Add(this.tbFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudYear);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Népességnövekedés";
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.Button bBrowse;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.PictureBox progressIcon;
    }
}

