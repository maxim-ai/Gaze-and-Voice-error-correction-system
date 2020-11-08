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
    class mockMouseMove : EyeGazeInterface
    {
        public override System.Drawing.Point GetEyeGazePosition()
        {

            object start = 668;
            object end = 668;
            Application application = new Application();
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var copyCombinedPathTestWordInstance = Path.Combine(outPutDirectory, "..\\..\\..\\Tests\\WordTextEditorInstances\\template.docx");
            string copyRelativePathTestWordInstance = new Uri(copyCombinedPathTestWordInstance).LocalPath;
            Document document = application.Documents.Open(copyRelativePathTestWordInstance);
            Window window = application.ActiveWindow;
            application.Visible = true;

            Range rng = document.Range(ref start, ref end);
            int left, top, width, height;
            window.GetPoint(out left, out top, out width, out height, rng);

            document.Close();
            application.Quit(false);

            System.Drawing.Point point = new System.Drawing.Point(left, top);
            return point;
        }
    }
}
