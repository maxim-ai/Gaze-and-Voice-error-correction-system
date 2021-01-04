using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace EyeGaze.GUI
{

    public partial class calibration : UserControl
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // height of ellipse
           int nHeightEllipse // width of ellipse
        );
        public calibration()
        {
            InitializeComponent();
            calibrationButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, calibrationButton.Width, calibrationButton.Height, 70, 70));
            calibrationButton.TabStop = false;
            calibrationButton.FlatStyle = FlatStyle.Flat;
            calibrationButton.FlatAppearance.BorderSize = 0;
        }

        private void calibration_Load(object sender, EventArgs e)
        {
            
        }
    }
}
