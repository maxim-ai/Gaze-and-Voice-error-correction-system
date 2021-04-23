namespace EyeGaze
{
    partial class ExperimentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExperimentForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.SUSlbl = new System.Windows.Forms.Label();
            this.SUSbtn = new System.Windows.Forms.Button();
            this.videoBtn = new System.Windows.Forms.Button();
            this.hepButton = new System.Windows.Forms.Button();
            this.IdBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.exp2Btn = new System.Windows.Forms.Button();
            this.exp1Btn = new System.Windows.Forms.Button();
            this.pilotBtn = new System.Windows.Forms.Button();
            this.ID_LBL = new System.Windows.Forms.Label();
            this.IdTxtBox = new System.Windows.Forms.TextBox();
            this.finishBtn = new System.Windows.Forms.Button();
            this.Exp2_LBL = new System.Windows.Forms.Label();
            this.Exp1_LBL = new System.Windows.Forms.Label();
            this.Pilot_LBL = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.SUSlbl);
            this.panel1.Controls.Add(this.SUSbtn);
            this.panel1.Controls.Add(this.videoBtn);
            this.panel1.Controls.Add(this.hepButton);
            this.panel1.Controls.Add(this.IdBtn);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.CloseBtn);
            this.panel1.Controls.Add(this.exp2Btn);
            this.panel1.Controls.Add(this.exp1Btn);
            this.panel1.Controls.Add(this.pilotBtn);
            this.panel1.Controls.Add(this.ID_LBL);
            this.panel1.Controls.Add(this.IdTxtBox);
            this.panel1.Controls.Add(this.finishBtn);
            this.panel1.Controls.Add(this.Exp2_LBL);
            this.panel1.Controls.Add(this.Exp1_LBL);
            this.panel1.Controls.Add(this.Pilot_LBL);
            this.panel1.Location = new System.Drawing.Point(-3, -2);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 626);
            this.panel1.TabIndex = 0;
            // 
            // SUSlbl
            // 
            this.SUSlbl.AutoSize = true;
            this.SUSlbl.BackColor = System.Drawing.Color.Transparent;
            this.SUSlbl.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SUSlbl.ForeColor = System.Drawing.Color.MistyRose;
            this.SUSlbl.Location = new System.Drawing.Point(441, 459);
            this.SUSlbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SUSlbl.Name = "SUSlbl";
            this.SUSlbl.Size = new System.Drawing.Size(104, 23);
            this.SUSlbl.TabIndex = 21;
            this.SUSlbl.Text = "Fill Survey";
            this.SUSlbl.Visible = false;
            // 
            // SUSbtn
            // 
            this.SUSbtn.BackColor = System.Drawing.Color.Transparent;
            this.SUSbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SUSbtn.FlatAppearance.BorderSize = 0;
            this.SUSbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SUSbtn.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SUSbtn.ForeColor = System.Drawing.Color.SteelBlue;
            this.SUSbtn.Image = ((System.Drawing.Image)(resources.GetObject("SUSbtn.Image")));
            this.SUSbtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SUSbtn.Location = new System.Drawing.Point(447, 489);
            this.SUSbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SUSbtn.Name = "SUSbtn";
            this.SUSbtn.Size = new System.Drawing.Size(91, 79);
            this.SUSbtn.TabIndex = 20;
            this.SUSbtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SUSbtn.UseVisualStyleBackColor = false;
            this.SUSbtn.Visible = false;
            this.SUSbtn.Click += new System.EventHandler(this.SUSbtn_Click);
            // 
            // videoBtn
            // 
            this.videoBtn.BackColor = System.Drawing.Color.Transparent;
            this.videoBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.videoBtn.FlatAppearance.BorderSize = 0;
            this.videoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.videoBtn.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoBtn.ForeColor = System.Drawing.Color.SteelBlue;
            this.videoBtn.Image = ((System.Drawing.Image)(resources.GetObject("videoBtn.Image")));
            this.videoBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.videoBtn.Location = new System.Drawing.Point(49, 103);
            this.videoBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.videoBtn.Name = "videoBtn";
            this.videoBtn.Size = new System.Drawing.Size(91, 79);
            this.videoBtn.TabIndex = 19;
            this.videoBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.videoBtn.UseVisualStyleBackColor = false;
            this.videoBtn.Click += new System.EventHandler(this.videoBtn_Click);
            // 
            // hepButton
            // 
            this.hepButton.BackColor = System.Drawing.Color.Transparent;
            this.hepButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hepButton.FlatAppearance.BorderSize = 0;
            this.hepButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hepButton.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hepButton.ForeColor = System.Drawing.Color.SteelBlue;
            this.hepButton.Image = ((System.Drawing.Image)(resources.GetObject("hepButton.Image")));
            this.hepButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.hepButton.Location = new System.Drawing.Point(49, 17);
            this.hepButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.hepButton.Name = "hepButton";
            this.hepButton.Size = new System.Drawing.Size(91, 79);
            this.hepButton.TabIndex = 18;
            this.hepButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.hepButton.UseVisualStyleBackColor = false;
            this.hepButton.Click += new System.EventHandler(this.hepButton_Click);
            // 
            // IdBtn
            // 
            this.IdBtn.BackColor = System.Drawing.Color.Transparent;
            this.IdBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IdBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IdBtn.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdBtn.ForeColor = System.Drawing.Color.MistyRose;
            this.IdBtn.Location = new System.Drawing.Point(443, 306);
            this.IdBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.IdBtn.Name = "IdBtn";
            this.IdBtn.Size = new System.Drawing.Size(100, 50);
            this.IdBtn.TabIndex = 16;
            this.IdBtn.Text = "Set";
            this.IdBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.IdBtn.UseVisualStyleBackColor = false;
            this.IdBtn.Click += new System.EventHandler(this.IdBtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(197, 17);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(632, 198);
            this.panel2.TabIndex = 15;
            // 
            // CloseBtn
            // 
            this.CloseBtn.BackColor = System.Drawing.Color.Transparent;
            this.CloseBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CloseBtn.BackgroundImage")));
            this.CloseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseBtn.ForeColor = System.Drawing.Color.SteelBlue;
            this.CloseBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CloseBtn.Location = new System.Drawing.Point(928, 4);
            this.CloseBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(91, 69);
            this.CloseBtn.TabIndex = 14;
            this.CloseBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CloseBtn.UseVisualStyleBackColor = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // exp2Btn
            // 
            this.exp2Btn.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.exp2Btn.BackColor = System.Drawing.Color.Transparent;
            this.exp2Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exp2Btn.FlatAppearance.BorderSize = 0;
            this.exp2Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exp2Btn.Image = ((System.Drawing.Image)(resources.GetObject("exp2Btn.Image")));
            this.exp2Btn.Location = new System.Drawing.Point(656, 389);
            this.exp2Btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.exp2Btn.Name = "exp2Btn";
            this.exp2Btn.Size = new System.Drawing.Size(65, 62);
            this.exp2Btn.TabIndex = 13;
            this.exp2Btn.UseVisualStyleBackColor = false;
            this.exp2Btn.Visible = false;
            this.exp2Btn.Click += new System.EventHandler(this.exp2Btn_Click);
            // 
            // exp1Btn
            // 
            this.exp1Btn.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.exp1Btn.BackColor = System.Drawing.Color.Transparent;
            this.exp1Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exp1Btn.FlatAppearance.BorderSize = 0;
            this.exp1Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exp1Btn.Image = ((System.Drawing.Image)(resources.GetObject("exp1Btn.Image")));
            this.exp1Btn.Location = new System.Drawing.Point(275, 388);
            this.exp1Btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.exp1Btn.Name = "exp1Btn";
            this.exp1Btn.Size = new System.Drawing.Size(65, 63);
            this.exp1Btn.TabIndex = 12;
            this.exp1Btn.UseVisualStyleBackColor = false;
            this.exp1Btn.Visible = false;
            this.exp1Btn.Click += new System.EventHandler(this.exp1Btn_Click);
            // 
            // pilotBtn
            // 
            this.pilotBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.pilotBtn.BackColor = System.Drawing.Color.Transparent;
            this.pilotBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pilotBtn.FlatAppearance.BorderSize = 0;
            this.pilotBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pilotBtn.Image = ((System.Drawing.Image)(resources.GetObject("pilotBtn.Image")));
            this.pilotBtn.Location = new System.Drawing.Point(456, 364);
            this.pilotBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pilotBtn.Name = "pilotBtn";
            this.pilotBtn.Size = new System.Drawing.Size(65, 59);
            this.pilotBtn.TabIndex = 11;
            this.pilotBtn.UseVisualStyleBackColor = false;
            this.pilotBtn.Visible = false;
            this.pilotBtn.Click += new System.EventHandler(this.pilotBtn_Click);
            // 
            // ID_LBL
            // 
            this.ID_LBL.AutoSize = true;
            this.ID_LBL.BackColor = System.Drawing.Color.Transparent;
            this.ID_LBL.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_LBL.ForeColor = System.Drawing.Color.MistyRose;
            this.ID_LBL.Location = new System.Drawing.Point(451, 224);
            this.ID_LBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ID_LBL.Name = "ID_LBL";
            this.ID_LBL.Size = new System.Drawing.Size(87, 23);
            this.ID_LBL.TabIndex = 10;
            this.ID_LBL.Text = "Insert ID";
            // 
            // IdTxtBox
            // 
            this.IdTxtBox.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdTxtBox.Location = new System.Drawing.Point(293, 254);
            this.IdTxtBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.IdTxtBox.Name = "IdTxtBox";
            this.IdTxtBox.Size = new System.Drawing.Size(427, 30);
            this.IdTxtBox.TabIndex = 9;
            // 
            // finishBtn
            // 
            this.finishBtn.BackColor = System.Drawing.Color.Transparent;
            this.finishBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.finishBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.finishBtn.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finishBtn.ForeColor = System.Drawing.Color.MistyRose;
            this.finishBtn.Location = new System.Drawing.Point(443, 537);
            this.finishBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.finishBtn.Name = "finishBtn";
            this.finishBtn.Size = new System.Drawing.Size(100, 50);
            this.finishBtn.TabIndex = 7;
            this.finishBtn.Text = "Finish";
            this.finishBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.finishBtn.UseVisualStyleBackColor = false;
            this.finishBtn.Visible = false;
            this.finishBtn.Click += new System.EventHandler(this.finishBtn_Click);
            // 
            // Exp2_LBL
            // 
            this.Exp2_LBL.AutoSize = true;
            this.Exp2_LBL.BackColor = System.Drawing.Color.Transparent;
            this.Exp2_LBL.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exp2_LBL.ForeColor = System.Drawing.Color.MistyRose;
            this.Exp2_LBL.Location = new System.Drawing.Point(552, 347);
            this.Exp2_LBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Exp2_LBL.Name = "Exp2_LBL";
            this.Exp2_LBL.Size = new System.Drawing.Size(270, 23);
            this.Exp2_LBL.TabIndex = 3;
            this.Exp2_LBL.Text = "Start Experiment Number 2";
            this.Exp2_LBL.Visible = false;
            // 
            // Exp1_LBL
            // 
            this.Exp1_LBL.AutoSize = true;
            this.Exp1_LBL.BackColor = System.Drawing.Color.Transparent;
            this.Exp1_LBL.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exp1_LBL.ForeColor = System.Drawing.Color.MistyRose;
            this.Exp1_LBL.Location = new System.Drawing.Point(153, 347);
            this.Exp1_LBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Exp1_LBL.Name = "Exp1_LBL";
            this.Exp1_LBL.Size = new System.Drawing.Size(270, 23);
            this.Exp1_LBL.TabIndex = 2;
            this.Exp1_LBL.Text = "Start Experiment Number 1";
            this.Exp1_LBL.Visible = false;
            // 
            // Pilot_LBL
            // 
            this.Pilot_LBL.AutoSize = true;
            this.Pilot_LBL.BackColor = System.Drawing.Color.Transparent;
            this.Pilot_LBL.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pilot_LBL.ForeColor = System.Drawing.Color.MistyRose;
            this.Pilot_LBL.Location = new System.Drawing.Point(437, 335);
            this.Pilot_LBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Pilot_LBL.Name = "Pilot_LBL";
            this.Pilot_LBL.Size = new System.Drawing.Size(100, 23);
            this.Pilot_LBL.TabIndex = 0;
            this.Pilot_LBL.Text = "Start Pilot";
            this.Pilot_LBL.Visible = false;
            // 
            // ExperimentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1024, 628);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ExperimentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExperimentForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Exp2_LBL;
        private System.Windows.Forms.Label Exp1_LBL;
        private System.Windows.Forms.Label Pilot_LBL;
        private System.Windows.Forms.TextBox IdTxtBox;
        private System.Windows.Forms.Button finishBtn;
        private System.Windows.Forms.Label ID_LBL;
        private System.Windows.Forms.Button exp2Btn;
        private System.Windows.Forms.Button exp1Btn;
        private System.Windows.Forms.Button pilotBtn;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button IdBtn;
        private System.Windows.Forms.Button hepButton;
        private System.Windows.Forms.Label SUSlbl;
        private System.Windows.Forms.Button SUSbtn;
        private System.Windows.Forms.Button videoBtn;
    }
}