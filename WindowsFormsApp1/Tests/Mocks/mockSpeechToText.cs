using EyeGaze.SpeechToText;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeGaze.Tests.Mocks
{
    class mockSpeechToText : InterfaceSpeechToText
    {
        string word = "";
        int count = 0;
        int countListen = 0;
        public void connect(string key, string word)
        {
            this.word = word;
            if (key == "badAuthentication")
                throw new WrongAuthenticationException("wrong authentication");
            else if (key == "badConnection" && count == 0)
            {
                count++;
                throw new ConnectionFailedException("connection failed");
            }
            return;
        }

        public void disconnect()
        {
            return;
        }

        public string listen()
        {
            if (countListen == 0)
                countListen++;
            else if (countListen == 1 && word == "move")
            {
                countListen++;
                return "change";
            }
            else if (countListen > 0)
            {
                countListen++;
                return "";
            }
            return word;
        }
    }
}
