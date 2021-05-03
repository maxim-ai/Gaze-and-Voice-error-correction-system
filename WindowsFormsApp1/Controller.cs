using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EyeGaze;
using EyeGaze.Engine;
using EyeGaze.SpeechToText;

namespace EyeGaze
{
    public class Controller
    {
        public EngineMain engineMain;
        public string path;
        public string speechToText;
        public Thread thread;
        public ExperimentForm frontend;
        public string key;
        public string region;

        public Controller(EngineMain engineMain)
        {
            this.key = "69a12462814f4df1a7b1d38c67963adf";
            this.region = "westeaurope";
            this.engineMain = engineMain;
            this.frontend = new ExperimentForm(this);
            WireEventMessageFromEngine(this.engineMain);
            this.path = "";
            this.speechToText = "EyeGaze.SpeechToText.MicrosoftCloudSpeechToText";
            Application.Run(frontend);
            
        }

        private void WireEventMessageFromEngine(EngineMain engineMain)
        {
            TriggerHandlerMessage handler = new TriggerHandlerMessage(frontend.handlerMessageFromEngine);
            engineMain.messageToForm += handler;
        }

        public string getSpellChecker(string chosenSpellChecker)
        {
            string spellChecker = "";
            switch (chosenSpellChecker)
            {
                case "Microsoft Word (Recommended)":
                    spellChecker = "EyeGaze.SpellChecker.WordSpell";
                    break;
                case "NHunspell":
                    spellChecker = "EyeGaze.SpellChecker.NHunspellSpellChecker";
                    break;
            }
            return spellChecker;
        }

        public void StartProgram(string spellChecker, string speechToText)
        {
            this.thread = new Thread(() =>
                this.engineMain.Start(path, speechToText, key, region, "EyeGaze.EyeTracking.MousePoint", spellChecker));
            this.thread.Start();
        }

        public void StartProgramReg(string spellChecker, string speechToText)
        {
            this.thread = new Thread(() =>
                this.engineMain.StartReg(path, speechToText, key, region, "EyeGaze.EyeTracking.MousePoint", spellChecker));
            this.thread.Start();
        }

    }
}
