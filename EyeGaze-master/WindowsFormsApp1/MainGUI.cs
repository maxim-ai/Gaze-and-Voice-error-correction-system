using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EyeGaze
{
    public partial class MainGUI : Form
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
        public MainGUI()
        {
            InitializeComponent();
        }

        private void MainGUI_Load(object sender, EventArgs e)
        {
            fixButtonApp(newFileButton,70);
            fixButtonApp(openFileButton,70);
            fixButtonApp(calibrationButton, 70);
            fixLabelApp(srLabel, 20);
            fixLabelApp(scLabel, 20);

        }

        private void fixButtonApp(Button b,int round)
        {
            b.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, b.Width, b.Height, round, round));
            b.TabStop = false;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
        }
        private void fixLabelApp(Label b, int round)
        {
            b.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, b.Width, b.Height, round, round));
            b.TabStop = false;
            b.FlatStyle = FlatStyle.Flat;
            //b.FlatAppearance.BorderSize = 0;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                                      ColorTranslator.FromHtml("#86A0DA"),
                                                                       System.Drawing.ColorTranslator.FromHtml("#0849D6"),
                                                                       45F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void WorkspaceText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
