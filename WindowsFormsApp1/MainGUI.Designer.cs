namespace EyeGaze
{
    partial class MainGUI
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
            this.newFileButton = new System.Windows.Forms.Button();
            this.openFileButton = new System.Windows.Forms.Button();
            this.WorkspaceText = new System.Windows.Forms.TextBox();
            this.calibrationButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.speechToTextCombox = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.scLabel = new System.Windows.Forms.Label();
            this.srLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // newFileButton
            // 
            this.newFileButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.newFileButton.ForeColor = System.Drawing.Color.Black;
            this.newFileButton.Location = new System.Drawing.Point(130, 31);
            this.newFileButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.newFileButton.Name = "newFileButton";
            this.newFileButton.Size = new System.Drawing.Size(100, 41);
            this.newFileButton.TabIndex = 0;
            this.newFileButton.Text = "New File";
            this.newFileButton.UseVisualStyleBackColor = false;
            // 
            // openFileButton
            // 
            this.openFileButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.openFileButton.Location = new System.Drawing.Point(287, 30);
            this.openFileButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(100, 43);
            this.openFileButton.TabIndex = 1;
            this.openFileButton.Text = "Open File";
            this.openFileButton.UseVisualStyleBackColor = false;
            // 
            // WorkspaceText
            // 
            this.WorkspaceText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(237)))));
            this.WorkspaceText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WorkspaceText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WorkspaceText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.WorkspaceText.Location = new System.Drawing.Point(92, 89);
            this.WorkspaceText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WorkspaceText.Name = "WorkspaceText";
            this.WorkspaceText.ReadOnly = true;
            this.WorkspaceText.Size = new System.Drawing.Size(335, 23);
            this.WorkspaceText.TabIndex = 7;
            // 
            // calibrationButton
            // 
            this.calibrationButton.Location = new System.Drawing.Point(106, 405);
            this.calibrationButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.calibrationButton.Name = "calibrationButton";
            this.calibrationButton.Size = new System.Drawing.Size(103, 54);
            this.calibrationButton.TabIndex = 11;
            this.calibrationButton.Text = "Calibrate Eyes";
            this.calibrationButton.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(440, 418);
            this.startButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(100, 28);
            this.startButton.TabIndex = 12;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // speechToTextCombox
            // 
            this.speechToTextCombox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(237)))));
            this.speechToTextCombox.FormattingEnabled = true;
            this.speechToTextCombox.Items.AddRange(new object[] {
            "Microsoft Azure Cloud (Recommended)",
            "IBM Watson Cloud",
            "System Lib (Offline)"});
            this.speechToTextCombox.Location = new System.Drawing.Point(37, 79);
            this.speechToTextCombox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.speechToTextCombox.Name = "speechToTextCombox";
            this.speechToTextCombox.Size = new System.Drawing.Size(191, 24);
            this.speechToTextCombox.TabIndex = 9;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(237)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Microsoft Azure Cloud (Recommended)",
            "IBM Watson Cloud",
            "System Lib (Offline)"});
            this.comboBox1.Location = new System.Drawing.Point(304, 79);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(196, 24);
            this.comboBox1.TabIndex = 10;
            // 
            // scLabel
            // 
            this.scLabel.AutoSize = true;
            this.scLabel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.scLabel.Location = new System.Drawing.Point(348, 26);
            this.scLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scLabel.Name = "scLabel";
            this.scLabel.Padding = new System.Windows.Forms.Padding(5);
            this.scLabel.Size = new System.Drawing.Size(101, 27);
            this.scLabel.TabIndex = 3;
            this.scLabel.Text = "spell checker";
            // 
            // srLabel
            // 
            this.srLabel.AutoSize = true;
            this.srLabel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.srLabel.Location = new System.Drawing.Point(55, 26);
            this.srLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.srLabel.Name = "srLabel";
            this.srLabel.Padding = new System.Windows.Forms.Padding(5);
            this.srLabel.Size = new System.Drawing.Size(135, 27);
            this.srLabel.TabIndex = 2;
            this.srLabel.Text = "speech recognizer";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.openFileButton);
            this.panel1.Controls.Add(this.newFileButton);
            this.panel1.Controls.Add(this.WorkspaceText);
            this.panel1.Location = new System.Drawing.Point(67, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(531, 144);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.srLabel);
            this.panel2.Controls.Add(this.scLabel);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.speechToTextCombox);
            this.panel2.Location = new System.Drawing.Point(69, 208);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(529, 132);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Location = new System.Drawing.Point(69, 391);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 100);
            this.panel3.TabIndex = 14;
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(681, 567);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.calibrationButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainGUI";
            this.Text = "MainGUI";
            this.Load += new System.EventHandler(this.MainGUI_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newFileButton;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.TextBox WorkspaceText;
        private System.Windows.Forms.Button calibrationButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.ComboBox speechToTextCombox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label scLabel;
        public System.Windows.Forms.Label srLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}