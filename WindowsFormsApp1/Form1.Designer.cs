using EyeGaze;

namespace WindowsFormsApp1
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
            this.speechToTextCombox = new System.Windows.Forms.ComboBox();
            this.openFileTextBox = new System.Windows.Forms.TextBox();
            this.WorkspaceText = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.keyLabel = new System.Windows.Forms.TextBox();
            this.keyInfoLabel = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelHome = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.spellCheckerComboBox = new System.Windows.Forms.ComboBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.panelCredentials = new System.Windows.Forms.Panel();
            this.keyInfoText = new System.Windows.Forms.TextBox();
            this.keyText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.helpButton = new System.Windows.Forms.Button();
            this.crerdentialsButton = new System.Windows.Forms.Button();
            this.homebutton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelHome.SuspendLayout();
            this.panelCredentials.SuspendLayout();
            this.SuspendLayout();
            // 
            // speechToTextCombox
            // 
            this.speechToTextCombox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(237)))));
            this.speechToTextCombox.FormattingEnabled = true;
            this.speechToTextCombox.Items.AddRange(new object[] {
            "Microsoft Azure Cloud (Recommended)",
            "IBM Watson Cloud",
            "System Lib (Offline)"});
            this.speechToTextCombox.Location = new System.Drawing.Point(11, 115);
            this.speechToTextCombox.Margin = new System.Windows.Forms.Padding(2);
            this.speechToTextCombox.Name = "speechToTextCombox";
            this.speechToTextCombox.Size = new System.Drawing.Size(252, 21);
            this.speechToTextCombox.TabIndex = 8;
            this.speechToTextCombox.SelectedIndexChanged += new System.EventHandler(this.speechToTextCombox_SelectedIndexChanged);
            // 
            // openFileTextBox
            // 
            this.openFileTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(75)))), ((int)(((byte)(115)))));
            this.openFileTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.openFileTextBox.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openFileTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(237)))));
            this.openFileTextBox.Location = new System.Drawing.Point(11, 46);
            this.openFileTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.openFileTextBox.Name = "openFileTextBox";
            this.openFileTextBox.Size = new System.Drawing.Size(162, 17);
            this.openFileTextBox.TabIndex = 5;
            this.openFileTextBox.Text = "File";
            this.openFileTextBox.TextChanged += new System.EventHandler(this.openFileTextBox_TextChanged);
            // 
            // WorkspaceText
            // 
            this.WorkspaceText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(237)))));
            this.WorkspaceText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WorkspaceText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WorkspaceText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.WorkspaceText.Location = new System.Drawing.Point(11, 65);
            this.WorkspaceText.Margin = new System.Windows.Forms.Padding(2);
            this.WorkspaceText.Name = "WorkspaceText";
            this.WorkspaceText.ReadOnly = true;
            this.WorkspaceText.Size = new System.Drawing.Size(252, 20);
            this.WorkspaceText.TabIndex = 6;
            this.WorkspaceText.TextChanged += new System.EventHandler(this.WorkspaceText_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(75)))), ((int)(((byte)(115)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(237)))));
            this.textBox2.Location = new System.Drawing.Point(11, 93);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(136, 17);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "Speech To Text";
            // 
            // keyLabel
            // 
            this.keyLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(75)))), ((int)(((byte)(115)))));
            this.keyLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.keyLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(237)))));
            this.keyLabel.Location = new System.Drawing.Point(11, 46);
            this.keyLabel.Margin = new System.Windows.Forms.Padding(2);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(120, 17);
            this.keyLabel.TabIndex = 11;
            this.keyLabel.Text = "Subscription Key";
            // 
            // keyInfoLabel
            // 
            this.keyInfoLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(75)))), ((int)(((byte)(115)))));
            this.keyInfoLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.keyInfoLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyInfoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(237)))));
            this.keyInfoLabel.Location = new System.Drawing.Point(11, 116);
            this.keyInfoLabel.Margin = new System.Windows.Forms.Padding(2);
            this.keyInfoLabel.Name = "keyInfoLabel";
            this.keyInfoLabel.Size = new System.Drawing.Size(77, 17);
            this.keyInfoLabel.TabIndex = 13;
            this.keyInfoLabel.Text = "Region";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(237)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 378);
            this.panel1.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EyeGaze.Properties.Resources.fixover_logo;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(16, 50);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(260, 274);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelHome
            // 
            this.panelHome.Controls.Add(this.textBox1);
            this.panelHome.Controls.Add(this.spellCheckerComboBox);
            this.panelHome.Controls.Add(this.browseButton);
            this.panelHome.Controls.Add(this.openFileTextBox);
            this.panelHome.Controls.Add(this.WorkspaceText);
            this.panelHome.Controls.Add(this.textBox2);
            this.panelHome.Controls.Add(this.speechToTextCombox);
            this.panelHome.Location = new System.Drawing.Point(289, 72);
            this.panelHome.Margin = new System.Windows.Forms.Padding(2);
            this.panelHome.Name = "panelHome";
            this.panelHome.Size = new System.Drawing.Size(280, 204);
            this.panelHome.TabIndex = 15;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(75)))), ((int)(((byte)(115)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(237)))));
            this.textBox1.Location = new System.Drawing.Point(11, 146);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(136, 17);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "Spell Checker";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // spellCheckerComboBox
            // 
            this.spellCheckerComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "Word (Recommended)",
            "NHunspell"});
            this.spellCheckerComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(237)))));
            this.spellCheckerComboBox.FormattingEnabled = true;
            this.spellCheckerComboBox.Items.AddRange(new object[] {
            "Microsoft Word (Recommended)",
            "NHunspell"});
            this.spellCheckerComboBox.Location = new System.Drawing.Point(12, 165);
            this.spellCheckerComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.spellCheckerComboBox.Name = "spellCheckerComboBox";
            this.spellCheckerComboBox.Size = new System.Drawing.Size(252, 21);
            this.spellCheckerComboBox.TabIndex = 10;
            // 
            // browseButton
            // 
            this.browseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(237)))), ((int)(((byte)(230)))));
            this.browseButton.FlatAppearance.BorderSize = 0;
            this.browseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.browseButton.Image = global::EyeGaze.Properties.Resources.icons8_search_24;
            this.browseButton.Location = new System.Drawing.Point(233, 66);
            this.browseButton.Margin = new System.Windows.Forms.Padding(0);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(29, 17);
            this.browseButton.TabIndex = 4;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = false;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // runButton
            // 
            this.runButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(237)))));
            this.runButton.FlatAppearance.BorderSize = 0;
            this.runButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(75)))), ((int)(((byte)(115)))));
            this.runButton.Location = new System.Drawing.Point(456, 323);
            this.runButton.Margin = new System.Windows.Forms.Padding(2);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(95, 29);
            this.runButton.TabIndex = 10;
            this.runButton.Text = "START";
            this.runButton.UseVisualStyleBackColor = false;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // panelCredentials
            // 
            this.panelCredentials.Controls.Add(this.keyInfoText);
            this.panelCredentials.Controls.Add(this.keyText);
            this.panelCredentials.Controls.Add(this.keyLabel);
            this.panelCredentials.Controls.Add(this.keyInfoLabel);
            this.panelCredentials.Location = new System.Drawing.Point(289, 73);
            this.panelCredentials.Margin = new System.Windows.Forms.Padding(2);
            this.panelCredentials.Name = "panelCredentials";
            this.panelCredentials.Size = new System.Drawing.Size(280, 204);
            this.panelCredentials.TabIndex = 16;
            // 
            // keyInfoText
            // 
            this.keyInfoText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(237)))));
            this.keyInfoText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyInfoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyInfoText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.keyInfoText.Location = new System.Drawing.Point(11, 137);
            this.keyInfoText.Margin = new System.Windows.Forms.Padding(2);
            this.keyInfoText.Name = "keyInfoText";
            this.keyInfoText.ReadOnly = true;
            this.keyInfoText.Size = new System.Drawing.Size(252, 20);
            this.keyInfoText.TabIndex = 14;
            // 
            // keyText
            // 
            this.keyText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(237)))));
            this.keyText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.keyText.Location = new System.Drawing.Point(11, 65);
            this.keyText.Margin = new System.Windows.Forms.Padding(2);
            this.keyText.Name = "keyText";
            this.keyText.Size = new System.Drawing.Size(252, 20);
            this.keyText.TabIndex = 10;
            this.keyText.TextChanged += new System.EventHandler(this.keyText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(237)))));
            this.label1.Location = new System.Drawing.Point(339, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = "|";
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(75)))), ((int)(((byte)(115)))));
            this.helpButton.FlatAppearance.BorderSize = 0;
            this.helpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpButton.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(237)))));
            this.helpButton.Image = global::EyeGaze.Properties.Resources.question2;
            this.helpButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.helpButton.Location = new System.Drawing.Point(514, 0);
            this.helpButton.Margin = new System.Windows.Forms.Padding(0);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(38, 47);
            this.helpButton.TabIndex = 20;
            this.helpButton.Text = "Help";
            this.helpButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // crerdentialsButton
            // 
            this.crerdentialsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(75)))), ((int)(((byte)(115)))));
            this.crerdentialsButton.FlatAppearance.BorderSize = 0;
            this.crerdentialsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.crerdentialsButton.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crerdentialsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(237)))));
            this.crerdentialsButton.Image = global::EyeGaze.Properties.Resources.icons8_key_24;
            this.crerdentialsButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.crerdentialsButton.Location = new System.Drawing.Point(346, 3);
            this.crerdentialsButton.Margin = new System.Windows.Forms.Padding(0);
            this.crerdentialsButton.Name = "crerdentialsButton";
            this.crerdentialsButton.Size = new System.Drawing.Size(79, 44);
            this.crerdentialsButton.TabIndex = 18;
            this.crerdentialsButton.Text = "Credentials";
            this.crerdentialsButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.crerdentialsButton.UseVisualStyleBackColor = false;
            this.crerdentialsButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // homebutton
            // 
            this.homebutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(75)))), ((int)(((byte)(115)))));
            this.homebutton.FlatAppearance.BorderSize = 0;
            this.homebutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homebutton.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homebutton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(237)))));
            this.homebutton.Image = global::EyeGaze.Properties.Resources.home1;
            this.homebutton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.homebutton.Location = new System.Drawing.Point(289, 3);
            this.homebutton.Margin = new System.Windows.Forms.Padding(0);
            this.homebutton.Name = "homebutton";
            this.homebutton.Size = new System.Drawing.Size(56, 44);
            this.homebutton.TabIndex = 17;
            this.homebutton.Text = "Home";
            this.homebutton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.homebutton.UseVisualStyleBackColor = false;
            this.homebutton.Click += new System.EventHandler(this.homebutton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(75)))), ((int)(((byte)(115)))));
            this.ClientSize = new System.Drawing.Size(568, 378);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.crerdentialsButton);
            this.Controls.Add(this.homebutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelHome);
            this.Controls.Add(this.panelCredentials);
            this.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelHome.ResumeLayout(false);
            this.panelHome.PerformLayout();
            this.panelCredentials.ResumeLayout(false);
            this.panelCredentials.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

    
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox openFileTextBox;
        private System.Windows.Forms.TextBox WorkspaceText;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox keyLabel;
        private System.Windows.Forms.TextBox keyInfoLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelHome;
        private System.Windows.Forms.Panel panelCredentials;
        private System.Windows.Forms.Button homebutton;
        private System.Windows.Forms.Button crerdentialsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox keyText;
        private System.Windows.Forms.TextBox keyInfoText;
        private System.Windows.Forms.ComboBox speechToTextCombox;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox spellCheckerComboBox;
        private System.Windows.Forms.Button helpButton;
    }
}

