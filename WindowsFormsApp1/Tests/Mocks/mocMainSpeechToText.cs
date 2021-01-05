using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeechToTextClass = EyeGaze.SpeechToText.SpeechToText;

namespace EyeGaze.Tests.Mocks
{
    class mocMainSpeechToText : SpeechToTextClass
    {
        public mocMainSpeechToText(string bk) : base(bk)
        {
        }
        public override void switchToSystemLib()
        {

        }

    }
}
