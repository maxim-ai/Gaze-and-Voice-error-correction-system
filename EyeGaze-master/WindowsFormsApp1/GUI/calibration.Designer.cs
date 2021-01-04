namespace EyeGaze.GUI
{
    partial class calibration
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.calibrationButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // calibrationButton
            // 
            this.calibrationButton.Location = new System.Drawing.Point(40, 37);
            this.calibrationButton.Margin = new System.Windows.Forms.Padding(4);
            this.calibrationButton.Name = "calibrationButton";
            this.calibrationButton.Size = new System.Drawing.Size(103, 54);
            this.calibrationButton.TabIndex = 12;
            this.calibrationButton.Text = "Calibrate Eyes";
            this.calibrationButton.UseVisualStyleBackColor = true;
            // 
            // calibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.calibrationButton);
            this.Name = "calibration";
            this.Size = new System.Drawing.Size(190, 125);
            this.Load += new System.EventHandler(this.calibration_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button calibrationButton;
    }
}
