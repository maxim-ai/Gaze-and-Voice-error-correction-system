using EyeGaze.EyeTracking;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EyeGaze.Tests.Mocks
{
    class mockMouseReplaceAll : EyeGazeInterface
    {
        public override System.Drawing.Point GetEyeGazePosition()
        {
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            return point;
        }
    }
}
