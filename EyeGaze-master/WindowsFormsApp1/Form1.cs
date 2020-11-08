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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private EngineMain engineMain;
        private string path;
        private string speechToText;
        private Thread thread;
        private List<PopUpDisappear> popupDisappearQueue;

        public Form1(EngineMain engineMain)
        {
            InitializeComponent();
            this.engineMain = engineMain;
            WireEventMessageFromEngine(this.engineMain);
            this.path = "";
            this.speechToText = "";
            this.speechToTextCombox.SelectedIndex = 0;
            this.spellCheckerComboBox.SelectedIndex = 0;
            popupDisappearQueue = new List<PopUpDisappear>();
        }
        private void WireEventMessageFromEngine(EngineMain engineMain)
        {
            TriggerHandlerMessage handler = new TriggerHandlerMessage(handlerMessageFromEngine);
            engineMain.messageToForm += handler;
        }

        private void handlerMessageFromEngine(object sender, MessageEvent e)
        {
                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)delegate
                    {                        //change back to main thread
                        if (e.type == MessageEvent.messageType.WrongAuthentication)
                        {
                            this.TopMost = true;
                            showPopUp(e.message);
                            runButton.Enabled = true;
                            //if (this.thread != null)
                            //    this.thread.Abort();
                        }
                        if (e.type == MessageEvent.messageType.ConnectionFail)
                        {
                            PopTimer pt = new PopTimer(e.message);
                        }
                        if (e.type == MessageEvent.messageType.TriggerWord)
                        {
                            PopTimer pt = new PopTimer(e.message);
                        }
                        if (e.type == MessageEvent.messageType.closeFile)
                        {
                            this.runButton.Enabled = true;
                        }
                    });
                    return;
                }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                PopUpDisappear p = popupDisappearQueue.First();
                popupDisappearQueue.RemoveAt(0);
                p.Close();
                p.SendToBack();
                p.TopMost = false;
            }
            catch(Exception)
            {

            }
        }
        private void runButton_Click(object sender, EventArgs e)
        {
            if (this.path.Equals(""))
            {
                showPopUp("Please choose a file to work with.");
            }
            else if (this.speechToText.Equals(""))
            {
                showPopUp("Please choose speech to text to work with.");
            }
            else if (speechToTextCombox.SelectedItem.ToString() != "System Lib (Offline)" && (keyInfoText.Text.Equals("") || keyText.Text.Equals("")))
            {
                showPopUp("Please enter key and info of the cloud.\n    Go to \"Credentials\"");
                //TODO: check if there are more endings for a word file
            }
            else if(!path.EndsWith(".docx"))
            {
                showPopUp("The text editor that is chosen is Word. Please choose a Word file to work with. It should have a .docx ending");
            }
            else
            {
                runButton.Enabled = false;
                this.TopMost = false;
                string spellChecker = getSpellChecker();
                this.thread = new Thread(() =>
                this.engineMain.Start(path, this.speechToText, keyText.Text, keyInfoText.Text, "EyeGaze.EyeTracking.MousePoint", spellChecker));
                this.thread.Start();
            }
        }

        private string getSpellChecker()
        {
            string chosenSpellChecker = spellCheckerComboBox.SelectedItem.ToString();
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

        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Word Documents|*.docx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.path = ofd.FileName;
                WorkspaceText.Text = path;

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.engineMain.finishListen();
        }

        private void speechToTextCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string chosenSpeechToText = speechToTextCombox.SelectedItem.ToString();
            switch (chosenSpeechToText)
            {
                case "Microsoft Azure Cloud (Recommended)":
                    isAuthenticationVisible(true);
                    keyLabel.Text = "Subscription Key :";
                    keyInfoLabel.Text = "Region :";
                    keyText.Text = "4ed9a9d9ba4741f68c455b160ae0d57c";
                    keyInfoText.Text = "westeurope";
                    this.speechToText = "EyeGaze.SpeechToText.MicrosoftCloudSpeechToText";
                    this.crerdentialsButton.Enabled = true;
                    break;
                case "IBM Watson Cloud":
                    isAuthenticationVisible(true);
                    keyLabel.Text = "API Key:";
                    keyInfoLabel.Text = "URL Path:";
                    keyText.Text = "y6vLeWANkSwvbLXmqRihAMudCQS_r7zuOQUDR28O6AaB";
                    keyInfoText.Text = "wss://api.eu-gb.speech-to-text.watson.cloud.ibm.com/instances/6ca2c958-936a-4b8a-a41c-76011cc0a451/v1/recognize";
                    this.speechToText = "EyeGaze.SpeechToText.IBMCloudSpeechToText";
                    this.crerdentialsButton.Enabled = true;
                    break;
                case "System Lib (Offline)":
                    isAuthenticationVisible(false);
                    this.speechToText = "EyeGaze.SpeechToText.SystemLibSpeechToText";
                    this.crerdentialsButton.Enabled = false;
                    break;
            }
        }

        private void isAuthenticationVisible(bool val)
        {
            keyInfoLabel.Visible = val;
            keyLabel.Visible = val;
            keyInfoText.Visible = val;
            keyText.Visible = val;
        }

        private void showPopUp(string message)
        {
            PopUp popup = new PopUp();
            popup.changeLabel(message);
            popup.TopMost = true;
            popup.Show();
        }

        private void openFileTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void keyInfoText_TextChanged(object sender, EventArgs e)
        {

        }

        private void WorkspaceText_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelCredentials.BringToFront();
        }

        private void keyText_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void homebutton_Click(object sender, EventArgs e)
        {
            panelHome.BringToFront();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://zoharmoneta8.wixsite.com/mysite-fixer1/user-s-guide");
            }
            catch { }
        }
    }
}
