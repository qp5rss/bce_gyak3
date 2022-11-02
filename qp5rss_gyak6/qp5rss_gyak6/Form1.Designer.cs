namespace qp5rss_gyak6
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
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.createTimer = new System.Windows.Forms.Timer(this.components);
            this.conveyorTimer = new System.Windows.Forms.Timer(this.components);
            this.btnCar = new System.Windows.Forms.Button();
            this.btnBall = new System.Windows.Forms.Button();
            this.lblCmNext = new System.Windows.Forms.Label();
            this.btnPresent = new System.Windows.Forms.Button();
            this.btnColour = new System.Windows.Forms.Button();
            this.btnFirstColour = new System.Windows.Forms.Button();
            this.btnSecondColour = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.btnSecondColour);
            this.mainPanel.Controls.Add(this.btnFirstColour);
            this.mainPanel.Controls.Add(this.btnPresent);
            this.mainPanel.Controls.Add(this.btnColour);
            this.mainPanel.Controls.Add(this.lblCmNext);
            this.mainPanel.Controls.Add(this.btnBall);
            this.mainPanel.Controls.Add(this.btnCar);
            this.mainPanel.Location = new System.Drawing.Point(0, 12);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1000, 426);
            this.mainPanel.TabIndex = 0;
            // 
            // createTimer
            // 
            this.createTimer.Enabled = true;
            this.createTimer.Interval = 3000;
            this.createTimer.Tick += new System.EventHandler(this.createTimer_Tick);
            // 
            // conveyorTimer
            // 
            this.conveyorTimer.Enabled = true;
            this.conveyorTimer.Interval = 10;
            this.conveyorTimer.Tick += new System.EventHandler(this.conveyorTimer_Tick);
            // 
            // btnCar
            // 
            this.btnCar.Location = new System.Drawing.Point(3, 400);
            this.btnCar.Name = "btnCar";
            this.btnCar.Size = new System.Drawing.Size(75, 23);
            this.btnCar.TabIndex = 0;
            this.btnCar.Text = "CAR";
            this.btnCar.UseVisualStyleBackColor = true;
            this.btnCar.Click += new System.EventHandler(this.btnCar_Click);
            // 
            // btnBall
            // 
            this.btnBall.Location = new System.Drawing.Point(84, 400);
            this.btnBall.Name = "btnBall";
            this.btnBall.Size = new System.Drawing.Size(75, 23);
            this.btnBall.TabIndex = 1;
            this.btnBall.Text = "BALL";
            this.btnBall.UseVisualStyleBackColor = true;
            this.btnBall.Click += new System.EventHandler(this.btnBall_Click);
            // 
            // lblCmNext
            // 
            this.lblCmNext.AutoSize = true;
            this.lblCmNext.Location = new System.Drawing.Point(10, 68);
            this.lblCmNext.Name = "lblCmNext";
            this.lblCmNext.Size = new System.Drawing.Size(68, 13);
            this.lblCmNext.TabIndex = 2;
            this.lblCmNext.Text = "Coming next:";
            // 
            // btnPresent
            // 
            this.btnPresent.Location = new System.Drawing.Point(165, 400);
            this.btnPresent.Name = "btnPresent";
            this.btnPresent.Size = new System.Drawing.Size(75, 23);
            this.btnPresent.TabIndex = 4;
            this.btnPresent.Text = "PRESENT";
            this.btnPresent.UseVisualStyleBackColor = true;
            this.btnPresent.Click += new System.EventHandler(this.btnPresent_Click);
            // 
            // btnColour
            // 
            this.btnColour.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnColour.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnColour.Location = new System.Drawing.Point(943, 400);
            this.btnColour.Name = "btnColour";
            this.btnColour.Size = new System.Drawing.Size(29, 23);
            this.btnColour.TabIndex = 3;
            this.btnColour.UseVisualStyleBackColor = false;
            this.btnColour.Click += new System.EventHandler(this.btnColour_Click);
            // 
            // btnFirstColour
            // 
            this.btnFirstColour.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnFirstColour.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFirstColour.Location = new System.Drawing.Point(246, 400);
            this.btnFirstColour.Name = "btnFirstColour";
            this.btnFirstColour.Size = new System.Drawing.Size(29, 23);
            this.btnFirstColour.TabIndex = 5;
            this.btnFirstColour.UseVisualStyleBackColor = false;
            this.btnFirstColour.Click += new System.EventHandler(this.btnFirstColour_Click);
            // 
            // btnSecondColour
            // 
            this.btnSecondColour.BackColor = System.Drawing.Color.Tomato;
            this.btnSecondColour.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSecondColour.Location = new System.Drawing.Point(281, 400);
            this.btnSecondColour.Name = "btnSecondColour";
            this.btnSecondColour.Size = new System.Drawing.Size(29, 23);
            this.btnSecondColour.TabIndex = 6;
            this.btnSecondColour.UseVisualStyleBackColor = false;
            this.btnSecondColour.Click += new System.EventHandler(this.btnSecondColour_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 450);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Timer createTimer;
        private System.Windows.Forms.Timer conveyorTimer;
        private System.Windows.Forms.Button btnBall;
        private System.Windows.Forms.Button btnCar;
        private System.Windows.Forms.Label lblCmNext;
        private System.Windows.Forms.Button btnPresent;
        private System.Windows.Forms.Button btnSecondColour;
        private System.Windows.Forms.Button btnFirstColour;
        private System.Windows.Forms.Button btnColour;
    }
}

