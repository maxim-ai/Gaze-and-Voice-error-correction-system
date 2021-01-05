using System;
using System.Collections.Generic;
using EyeGaze.Engine;
using Microsoft.Office.Interop.Word;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace EyeGaze.TextEditor
{
    public abstract class AbstractTextEditor<T>
    {
        //public (List<String> list, int x, int y) fixedWord = (null, 0, 0);
        Thread t;
        public (List<String> list, CoordinateRange coord) fixedWord = (null, new CoordinateRange(0,0,null,""));
        public Boolean choosingSuggestion = false;
        private volatile suggestionPopup sp = null;

        public event TriggerHandlerMessage sendMessageToEngine;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cursorPosition"></param>
        /// <param name="word"> after this word add the sentence</param>
        /// <param name="wordsToAdd"> the sentence to add</param>
        /// <returns></returns>
        protected virtual void CloseFile(MessageEvent m)
        {
            sendMessageToEngine(this, m);
        }
        public abstract void SetCursorPosition(Range cursorPosition);
        public abstract void ReplaceWord(T wordToChange, string newWord);
        public abstract void CloseFile();
        public abstract List<CoordinateRange> GetCursorPositionWordsInArea();
        public abstract System.Drawing.Point GetPointOfCursorPosition();
        public abstract List<CoordinateRange> GetAllWordsInArea(System.Drawing.Point position);
        public abstract void MoveCursor(System.Drawing.Point position);
        public abstract List<CoordinateRange> GetAllWordsInRange(Range range);
        public abstract List<CoordinateRange> GetRangesForAllSameWords(string word);
        public abstract void ReplaceAllWords(List<CoordinateRange> wordsToChange, string oldWord, string newWord);
        public abstract void ReplaceAllDone();
        public abstract bool fileReadOnly();

         public void ShowMoreSuggestions()
        {
            //if (fixedWord.list != null && fixedWord.list.Count > 0)
            //{
            //    suggestionPopup sp = new suggestionPopup(fixedWord.x - 90, fixedWord.y - 50, fixedWord.list);
            //    sp.Refresh();
            //    sp.Show();
            //    sp.TopMost = true;
            //    System.Windows.Forms.Application.DoEvents();
            //}
            List<string> emptyList = new List<string>();
            emptyList.Add("NO MATCH");
            if (fixedWord.list != null && fixedWord.list.Count > 0)
            {
                sp = new suggestionPopup(fixedWord.coord.X - 90, fixedWord.coord.Y - 50, fixedWord.list);
                sp.Refresh();
                sp.Show();
                sp.TopMost = true;
                System.Windows.Forms.Application.DoEvents();
            }
            else
            {
                sp = new suggestionPopup(fixedWord.coord.X - 90, fixedWord.coord.Y - 50, emptyList);

                sp.Refresh();
                sp.Show();
                sp.TopMost = true;
                System.Windows.Forms.Application.DoEvents();
            }

            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Interval = 2000;
            aTimer.Elapsed += timer_Tick;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            //System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            //timer.Interval = 5000;
            //timer.Tick += new EventHandler(timer_Tick);
            ////timer.Tick +=  new EventHandler((object sender, EventArgs e) => HideMoreSuggestions());
            //t = Thread.CurrentThread;
            ////timer.Enabled = true;
            //timer.Start();
            //Console.WriteLine(timer.ToString());
            //System.Windows.Forms.Application.DoEvents();
            //System.Timers.Timer timer = new System.Timers.Timer(2000);
            //timer.Enabled = true;
            //timer.Elapsed += new ElapsedEventHandler((object sender, ElapsedEventArgs e) => HideMoreSuggestions());
            //timer.Start();
        }


        public void HideMoreSuggestions()
        {
            if (sp != null)
            {
                sp.Opacity = 0;
                sp.Close();
                sp.SendToBack();
                sp.TopMost = false;
                choosingSuggestion = false;
                                
            }
        }

        async void timer_Tick(Object source, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("ttt");

            //sp.Invoke((MethodInvoker)delegate { Console.WriteLine("hhh" + sp.ToString()); });
            //Console.WriteLine("hhh" + sp.ToString());

            //ProcessThreadCollection currentThreads = Process.GetCurrentProcess().Threads;

            //foreach (ProcessThread thread in currentThreads)
            //{
                try 
                {
                    sp.Opacity = 0.1;
                    Console.WriteLine("3");
                    sp.Close();
                    sp.SendToBack();
                    Console.WriteLine("3");
                    sp.TopMost = false;
                System.Windows.Forms.Application.DoEvents();

            }
            catch { Console.WriteLine("fsdfsdfsdfsd"); }

            //}

            //try
            //{
            //    while (sp.Opacity > 0.0)
            //    {
            //        Console.WriteLine("1");
            //        await System.Threading.Tasks.Task.Delay(50);
            //        sp.Opacity -= 0.05;
            //        Console.WriteLine("2");
            //    }
            //    sp.Close();
            //    sp.SendToBack();
            //    Console.WriteLine("3");
            //    sp.TopMost = false;
            //}
            //catch (Exception)
            //{

            //}
        }

    }
}
