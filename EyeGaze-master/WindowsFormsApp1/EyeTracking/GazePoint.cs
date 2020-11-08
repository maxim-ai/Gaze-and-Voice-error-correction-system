using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace EyeGaze.EyeTracking
{
    class GazePoint : EyeGazeInterface
    {
        public override Point GetEyeGazePosition()
        {
            Point returnPoint = new Point();
            Point gazePoint = getGaze();
            Point screen = ScreenSize();
            float scale = getWindowScale();

            //Console.WriteLine(lpPoint);

            returnPoint.X = (int)((screen.X * gazePoint.X) / scale);
            returnPoint.Y = (int)((screen.Y * gazePoint.Y) / scale);
            return returnPoint;
        }

        private float getWindowScale()
        {
            float currentDPI = (int)Registry.GetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop\\WindowMetrics", "AppliedDPI", 96);
            float scale = currentDPI / 96;
            return scale;
        }

        public Point ScreenSize()
        {
            var screen = Screen.PrimaryScreen.Bounds;
            Point point = new Point();
            point.X = screen.Width;
            point.Y = screen.Height;
            return point;
        }
    }
}
