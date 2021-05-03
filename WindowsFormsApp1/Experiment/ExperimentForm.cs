using Experiment;
using EyeGaze;
using EyeGaze.Engine;
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

namespace EyeGaze
{
    public delegate void EndExperiment();

    public partial class ExperimentForm : Form
    {
        private EndExperiment _end;
        private int _expNum;
        Controller controller;
        public ExperimentForm(Controller c)
        {
            InitializeComponent();
            List<Button> btns = new List<Button>(new Button[] { this.exp1Btn, this.exp2Btn, this.pilotBtn, this.CloseBtn, this.finishBtn,
                                                                this.videoBtn, this.SUSbtn, this.hepButton});
            foreach (Button b in btns)
            {
                b.MouseEnter += ChangeBackColorEnter;
                b.MouseLeave += ChangeBackColorLeave;
            }

            this.controller = c;
            controller.engineMain.mainExperiment = new MainClass();
            this.SetEndExpFunc((EndExperiment)(this.controller.engineMain.End));
            controller.key = "69a12462814f4df1a7b1d38c67963adf";
            controller.region = "westeurope";
            controller.speechToText = "EyeGaze.SpeechToText.MicrosoftCloudSpeechToText";
        }
        public void SetEndExpFunc(EndExperiment ee)
        {
            _end = ee;
        }
        private void ChangeBackColorEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = System.Drawing.Color.CadetBlue;
        }
        private void ChangeBackColorLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = System.Drawing.Color.Transparent;
        }

        private void finishBtn_Click(object sender, EventArgs e)
        {
            this._end();
            this.Dispose();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this._end();
            this.Dispose();
        }

        private void IdBtn_Click(object sender, EventArgs e)
        {
            //Check Valid ID
            string id = this.IdTxtBox.Text;
            bool validID = CheckID(id);
            if (true)
            {
                this.IdTxtBox.Visible = false;
                this.IdBtn.Visible = false;
                this.ID_LBL.Visible = false;


                //pilot visible
                this.pilotBtn.Visible = true;
                this.Pilot_LBL.Visible = true;
            }
            else
            {
                // Alert message and try again
            }
        }

        private bool CheckID(string id)
        {
            return true;
        }

        private void pilotBtn_Click(object sender, EventArgs e)
        {
            this.pilotBtn.Enabled = false;
            this.pilotBtn.Visible = false;
            this.Pilot_LBL.Visible = false;
            //Start Pilot
            _expNum = 0;
            RunAppSystem(0);

            this.exp1Btn.Visible = true;
            this.Exp1_LBL.Visible = true;
            this.exp2Btn.Visible = true;
            this.Exp2_LBL.Visible = true;
            this.exp2Btn.Enabled = false;
        }

        private void exp1Btn_Click(object sender, EventArgs e)
        {
            this.exp1Btn.Enabled = false;
            //Start Exp1
            _expNum = 1;
            RunAppSystem(1);
            this.exp2Btn.Enabled = true;

        }

        private void exp2Btn_Click(object sender, EventArgs e)
        {
            this.exp2Btn.Enabled = false;
            //Start Exp1
            _expNum = 2;
            RunAppSystem(2);
            // Add Link BTN releas

        }

        private void RunAppSystem(int expNumber)
        {
            if (expNumber != 0) { this.controller.engineMain.End(); }

            MainClass mainExpreriment = controller.engineMain.mainExperiment;
            String path = mainExpreriment.GetPath(this.IdTxtBox.Text, "VoiceGaze", expNumber);

            controller.path = path;
            controller.StartProgram("EyeGaze.SpellChecker.WordSpell", controller.speechToText);
            Thread.Sleep(5000);

            mainExpreriment.StartExperiment(DateTime.Now);
        }

        private void End()
        {
            if(_expNum == 0)
            {
                this.FinishPilot();
            }
            else if(_expNum == 1)
            {
                this.FinishExp1();
            }
            else if(_expNum == 2)
            {
                this.FinishExp2();
            }
        }

        //private void GetMessageFromApp(UIMessageEvent uime)
        //{
        //    Console.WriteLine(uime.ToString());
        //    string content = "";
        //    if (uime._type == UIMessageType.CommandDetectDispaly)
        //    {
        //        Console.WriteLine("Command UI");
        //        content = $"{uime._command} {string.Join(" ", uime._content)}";
        //    }
        //    else
        //    {
        //        Console.WriteLine("Option UI");
        //        if (uime._content.Count > 0)
        //        {
        //            content += $"1. {uime._content[0]}\r\n";
        //            if (uime._content.Count > 1)
        //            {
        //                content += $"2. {uime._content[1]}\r\n";
        //                if (uime._content.Count > 2)
        //                {
        //                    content += $"3. {uime._content[2]}\r\n";
        //                }
        //            }
        //        }
        //    }
        //    Invoke((MethodInvoker)delegate
        //    {
        //        this.ShowPopUp(content);
        //    });
        //    return;
        //}
        //private void ShowPopUp(string content)
        //{
        //    try
        //    {
        //        if (_popUp != null)
        //        {
        //            _popUp.Close();
        //        }
        //        _popUp = new PopUpOptionForm();
        //        _popUp.SetValues(content);
        //        _popUp.TopMost = true;
        //        _popUp.Show();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine($"Exception in Show POPUP : {e.Message}");
        //    }
        //}
        private void FinishPilot()
        {
            this.pilotBtn.Visible = false;
            this.Pilot_LBL.Visible = false;

            //Experimentsss
            this.Exp1_LBL.Visible = true;
            this.Exp2_LBL.Visible = true;
            this.exp1Btn.Visible = true;
            this.exp2Btn.Visible = true;

            this.exp2Btn.Enabled = false;
        }
        private void FinishExp1()
        {
            this.exp2Btn.Enabled = true;
        }
        private void FinishExp2()
        {
            this.Exp1_LBL.Visible = false;
            this.Exp2_LBL.Visible = false;
            this.exp1Btn.Visible = false;
            this.exp2Btn.Visible = false;

            this.SUSbtn.Visible = true;
            this.SUSlbl.Visible = true;
            
        }

        private void hepButton_Click(object sender, EventArgs e)
        {
            // TODO - Create page for all the commands For The Experiment - Generic to all system
            ExperimentHelpForm help = new ExperimentHelpForm();
            help.Show();
        }

        private void SUSbtn_Click(object sender, EventArgs e)
        {
            this.SUSbtn.Visible = false;
            this.SUSlbl.Visible = false;
            this.finishBtn.Visible = true;
        }

        private void videoBtn_Click(object sender, EventArgs e)
        {

        }
        private void showPopUp(string message)
        {
            PopUp popup = new PopUp();
            popup.changeLabel(message);
            popup.TopMost = true;
            popup.Show();
        }

        public void handlerMessageFromEngine(object sender, MessageEvent e)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {                        //change back to main thread
                    if (e.type == MessageEvent.messageType.WrongAuthentication)
                    {
                        this.TopMost = true;
                        showPopUp(e.message);
                        //if (this.thread != null)
                        //    this.thread.Abort();
                    }
                    if (e.type == MessageEvent.messageType.ConnectionFail)
                    {
                        PopTimer pt = new PopTimer(e.message);
                    }
                    if (e.type == MessageEvent.messageType.TriggerWord)
                    {
                        string[] actions = new string[] { "fix","fix to", "change", "add", "move", "replace", "options","delete", "copy from","copy to" ,"paste before","paste after","cancel","1", "2", "3", "4", "5" };
                        Dictionary<String, int> distances = new Dictionary<string, int>();
                        foreach(String word in actions)
                        {
                            distances.Add(word, controller.engineMain.LevenshteinDistance(e.message.ToLower(), word));
                        }
                        PopTimer pt = new PopTimer(distances.OrderBy(kvp => kvp.Value).First().Key);
                    }
                    if (e.type == MessageEvent.messageType.closeFile)
                    {

                    }
                });
                return;
            }
        }
    }
}
