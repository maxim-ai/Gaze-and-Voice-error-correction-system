using EyeGaze.SpeechToText;
using System;
using System.Collections.Generic;
using System.Linq;
using SpeechToTextClass = EyeGaze.SpeechToText.SpeechToText;
using System.Windows.Forms;
using WindowsFormsApp1;
using TriggerWordEvent = EyeGaze.SpeechToText.TriggerWordEvent;
using System.Drawing;
using eyeGaze = EyeGaze.EyeTracking.GazePoint;
using EyeGaze.TextEditor;
using EyeGaze.SpellChecker;
using EyeGaze.Logger;
using System.Threading;
using EyeGaze.EyeTracking;
using System.IO;
using Microsoft.Win32;
using EyeGaze.GazeTracker;
using System.Timers;

namespace EyeGaze.Engine
{
    public class EngineMain
    {
        //private List<String> fixing = null;
        private (List<String> list,int x,int y) fixing = (null,0,0);

        private AbstractTextEditor<CoordinateRange> textEditor;
        private SpellCheckerAbstract spellChecker;
        public event TriggerHandlerMessage messageToForm;
        private SpeechToTextClass speechToText;
        private ManualResetEvent completedEvent;
        private EyeGazeInterface eyeGaze;

        //[System.Runtime.InteropServices.DllImport("DpiHelper.dll")]
        //static public extern void PrintDpiInfo();

        //[System.Runtime.InteropServices.DllImport("DpiHelper.dll")]
        //static public extern int SetDPIScaling(Int32 adapterIDHigh, UInt32 adapterIDlow, UInt32 sourceID, UInt32 dpiPercentToSet);
        //[System.Runtime.InteropServices.DllImport("DpiHelper.dll")]
        //static public extern void RestoreDPIScaling();


        [STAThread]
        static public void Main(String[] args)
        {
            //List<String> words = new List<string>();
            //words.Add("word one");
            //words.Add("word two");
            //words.Add("word three");
            //words.Add("word four");
            //words.Add("word five");
            //suggestionPopup sugg = new suggestionPopup(900,500,words);
            //sugg.Show();
            //sugg.TopMost = true;
            //Application.Run(sugg);

            
            EngineMain engine = new EngineMain();
            SystemLogger.getEventLog().Info("----------------------Starting System-------------------------");
            SystemLogger.getErrorLog().Info("----------------------Starting System-------------------------");
            //Application.Run(new Form1(engine));
            Controller c = new Controller(engine);
        }

        public EngineMain()
        {
            SystemLogger.configureLogs();
        }

        public void SetTextEditor(WordTextEditor textEditor)
        {
            this.textEditor = textEditor;

        }
        public void SetSpellChecker(NHunspellSpellChecker spellChecker)
        {
            this.spellChecker = spellChecker;
        }
        public void Start(string textEditorPath, string speechToTextNamespace, string key, string keyInfo, string eyeGazeNamespace, string spellChecker)
        {
            if(eyeGazeNamespace== "EyeGaze.EyeTracking.GazePoint")
            {
                GazeTracker.GazeTracker GT = GazeTracker.GazeTracker.getInstance();
                GT.connect();
                GT.listen();
            }
            
            completedEvent = new ManualResetEvent(false);
            SystemLogger.getEventLog().Info("Starting initialization of the system");
            Type eyeGazeType = Type.GetType(eyeGazeNamespace);
            this.eyeGaze = (EyeGazeInterface)Activator.CreateInstance(eyeGazeType);
            Type spellCheckerType = Type.GetType(spellChecker);
            this.spellChecker = (SpellCheckerAbstract)Activator.CreateInstance(spellCheckerType);
            Type textEditorType = Type.GetType("EyeGaze.TextEditor.WordTextEditor");
            this.textEditor = (AbstractTextEditor<CoordinateRange>)Activator.CreateInstance(textEditorType, textEditorPath);
            this.speechToText = new SpeechToTextClass(speechToTextNamespace);
            WireEventHandlersTriggerWord(speechToText);
            WireEventHandlersException(speechToText);
            WireEventHandlersCloseFile(this.textEditor);
            this.speechToText.FindActionFromSpeech(key, keyInfo);
            completedEvent.Set();
            this.End();
        }

        public void setSpellChecker(string spellchecker)
        {
            if (spellchecker.Equals("Hunspell"))
            {
                this.spellChecker = new NHunspellSpellChecker();
            }
            else if (spellchecker.Equals("Word"))
            {
                this.spellChecker = new WordSpell();
            }
        }

        public void End()
        {
            this.speechToText.disconnect();
            this.spellChecker.CloseSpellChecker();
            this.textEditor.CloseFile();
        }

        public void finishListen()
        {
            if(this.speechToText != null)
                this.speechToText.finishListen();
        }
        private void WireEventHandlersTriggerWord(SpeechToTextClass stt)
        {
            TriggerWordHandler handler = new TriggerWordHandler(triggerWordHandler);
            stt.triggerHandler += handler;
        }
        private void WireEventHandlersException(SpeechToTextClass stt)
        {
            TriggerHandlerMessage handler = new TriggerHandlerMessage(handleMessageFromSpeechToText);
            stt.sendMessageToEngine += handler;
        }
        
        private void WireEventHandlersCloseFile(AbstractTextEditor<CoordinateRange> file)
        {
            TriggerHandlerMessage handler = new TriggerHandlerMessage(handleMessageFromTextEditor);
            file.sendMessageToEngine += handler;
        }

        public void handleMessageFromTextEditor(object sender, MessageEvent e)
        {
            if (e.type == MessageEvent.messageType.closeFile)
            {
                this.finishListen();
                if(messageToForm != null)
                    messageToForm(this, e);
                this.completedEvent.WaitOne();
                this.completedEvent.Reset();

            }
        }
        public void handleMessageFromSpeechToText(object sender, MessageEvent e)
        {
            try
            {
                if (e.type == MessageEvent.messageType.ConnectionFail || e.type == MessageEvent.messageType.WrongAuthentication)
                    messageToForm(this, e);
                else if (e.type == MessageEvent.messageType.TriggerWord)
                {
                    if (this.textEditor.fileReadOnly())
                        e.message = "Editing cannot be done because the file is read-only";
                    messageToForm(this, e);
                }

            }
            catch { }

        }

        public void triggerWordHandler(object sender, TriggerWordEvent e)
        {

            if (e.triggerWord.Equals("fix"))
                Fix(eyeGaze.GetEyeGazePosition());

            else if (e.triggerWord.Equals("fix word"))
                FixWord(e.content[1], eyeGaze.GetEyeGazePosition());

            //Meirav's will
            else if (e.triggerWord.Equals("change"))
                Change();

            else if (e.triggerWord.Equals("move"))
                Move();

            else if (e.triggerWord.Equals("add"))
                Add(e.content, eyeGaze.GetEyeGazePosition());

            else if (e.triggerWord.Equals("replace") && (e.content[0].Equals("all") || e.content[0].Equals("all,")))
                ReplaceAll(e.content);

            else if (e.triggerWord.Equals("replace"))
                Replace(e.content, eyeGaze.GetEyeGazePosition());

            else if (e.triggerWord.Equals("done"))
                ReplaceAllDone();
            else if (e.triggerWord.Equals("more"))
                MoreSuggestions();
            else if (e.triggerWord.Equals("1") || e.triggerWord.Equals("2") || e.triggerWord.Equals("3") || e.triggerWord.Equals("4") || e.triggerWord.Equals("5"))
                FixFromSuggestions(e.triggerWord);

        }

        public void Fix(Point position)
        {
            try
            {
                SystemLogger.getEventLog().Info("Trigger word Fix");
                List<CoordinateRange> wordsInSight = textEditor.GetAllWordsInArea(position);
                List<CoordinateRange> misspelledWords = GetMisspelledWords(wordsInSight);
                List<KeyValuePair<CoordinateRange, double>> distanceFromCoordinate = FindDistanceFromCoordinate(misspelledWords, position).ToList();
                List<KeyValuePair<CoordinateRange, double>> sortedPoints = SortByDistance(distanceFromCoordinate);
                FixClosestMisspelledWord(sortedPoints);
            }
            catch (Exception e)
            {
                SystemLogger.getErrorLog().Info(e.Message);
            }
        }
        public void Change()
        {
            try
            {
                SystemLogger.getEventLog().Info("Trigger word Change");
                List<CoordinateRange> wordsInSight = textEditor.GetCursorPositionWordsInArea();
                List<CoordinateRange> misspelledWords = GetMisspelledWords(wordsInSight);
                FixLatestMisspelledWord(misspelledWords);
            }
            catch (Exception e)
            {
                SystemLogger.getErrorLog().Info(e.Message);
            }
        }

        public void FixWord(string word, Point position) 
        {
            try
            {
                SystemLogger.getEventLog().Info("Trigger word Fix + Word");
                List<CoordinateRange> wordsInSight = textEditor.GetAllWordsInArea(position);
                List<CoordinateRange> similarWords = getSimilarLexicographicWords(wordsInSight, word);
                if (similarWords.Count == 0)
                    return;
                List<KeyValuePair<CoordinateRange, double>> distanceFromCoordinate = FindDistanceFromCoordinate(similarWords, position).ToList();
                List<KeyValuePair<CoordinateRange, double>> sortedPoints = SortByDistance(distanceFromCoordinate);
                if (sortedPoints.Count > 0)
                {
                    CoordinateRange wordToFix = sortedPoints.First().Key;
                    textEditor.ReplaceWord(wordToFix, word);
                }
            }
            catch (Exception e)
            {
                SystemLogger.getErrorLog().Info(e.Message);
            }
        }

        public void Move()
        {
            try { 
                SystemLogger.getEventLog().Info("Trigger word Move");
                Point position = eyeGaze.GetEyeGazePosition();
                textEditor.MoveCursor(position);
            }
            catch (Exception e)
            {
                SystemLogger.getErrorLog().Info(e.Message);
            }
        }

        public void Add(string[] sentence, Point position)
        {
            try
            {
                sentence = GetSenteceWithoutPunctuation(sentence);
                string firstWord = sentence[0];
                string wordsToAdd = GetSentceFromStringArray(sentence);
                SystemLogger.getEventLog().Info("Trigger word add");
                List<CoordinateRange> wordsInSight = textEditor.GetAllWordsInArea(position);
                List<CoordinateRange> exactWords = GetExactWords(wordsInSight, firstWord);
                if (exactWords.Count == 0)
                    return;
                List<KeyValuePair<CoordinateRange, double>> distanceFromCoordinate = FindDistanceFromCoordinate(exactWords, position).ToList();
                List<KeyValuePair<CoordinateRange, double>> sortedPoints = SortByDistance(distanceFromCoordinate);
                AddWords(sortedPoints.First().Key, wordsToAdd);
            }
            catch (Exception e)
            {
                SystemLogger.getErrorLog().Info(e.Message);
            }
        }

        public void Replace(string[] sentence, Point position)
        {
            try
            {
                sentence = GetSenteceWithoutPunctuation(sentence);
                string wordToReplace = sentence[0];
                string replaceToWord = sentence[2];
                SystemLogger.getEventLog().Info("Trigger word Replace");
                List<CoordinateRange> wordsInSight = textEditor.GetAllWordsInArea(position);
                List<KeyValuePair<CoordinateRange, double>> distanceFromCoordinate = FindDistanceFromCoordinate(wordsInSight, position).ToList();
                List<KeyValuePair<CoordinateRange, double>> sortedPoints = SortByDistance(distanceFromCoordinate);
                if (sortedPoints.Count > 0)
                {
                    while (sortedPoints.Count > 0)
                    {
                        CoordinateRange wordToReplaceCoordinateRange = sortedPoints.First().Key;
                        if (wordToReplaceCoordinateRange.word.ToLower().Equals(wordToReplace.ToLower()))
                        {
                            textEditor.ReplaceWord(wordToReplaceCoordinateRange, replaceToWord);
                            return;
                        }
                        sortedPoints.RemoveAt(0);
                    }
                }
            }
            catch (Exception e)
            {
                SystemLogger.getErrorLog().Info(e.Message);
            }
        }

        public void ReplaceAll(string[] sentence)
        {
            try
            {
                if (sentence.Length < 3)
                {
                    SystemLogger.getErrorLog().Info("Trying to replace all, there are not enough words in the command");
                    return;
                }
                sentence = GetSenteceWithoutPunctuation(sentence);
                string wordToReplace = sentence[1];
                string replaceToWord = sentence[2];
                SystemLogger.getEventLog().Info("Trigger word ReplaceAll");
                List<CoordinateRange> wordsCoordinateRanges = textEditor.GetRangesForAllSameWords(wordToReplace);
                textEditor.ReplaceAllWords(wordsCoordinateRanges, wordToReplace, replaceToWord);
            }
            catch (Exception e)
            {
                SystemLogger.getErrorLog().Info(e.Message);
            }
        }

        public void ReplaceAllDone()
        {
            try
            {
                textEditor.ReplaceAllDone();
            }
            catch (Exception e)
            {
                SystemLogger.getErrorLog().Info(e.Message);
            }
        }

        public void MoreSuggestions()
        {
            try
            {
                textEditor.ShowMoreSuggestions();
                textEditor.choosingSuggestion = true;
            }
            catch (Exception e)
            {
                SystemLogger.getErrorLog().Info(e.Message);
            }
            //if (fixing.list != null && fixing.list.Count>0)
            //{
            //    suggestionPopup sp = new suggestionPopup(fixing.x - 90, fixing.y - 50, fixing.list);
            //    sp.Refresh();
            //    sp.Show();
            //    sp.TopMost = true;
            //    Application.DoEvents();
            //}
        }

        public void FixFromSuggestions(String trigger)
        {
            if (!textEditor.choosingSuggestion) return;
            //List<string> numbers = new List<string>();
            //numbers.Add("zero");
            //numbers.Add("one");
            //numbers.Add("two");
            //numbers.Add("three");
            //numbers.Add("four");
            //numbers.Add("five");
            //int index = numbers.IndexOf(trigger);
            int index= Int32.Parse(trigger)-1;
            String fixedWord = textEditor.fixedWord.list[index];
            textEditor.ReplaceWord(textEditor.fixedWord.coord, fixedWord.Trim());
            textEditor.HideMoreSuggestions();
            //textEditor.FixFromSuggestions(index);

        }

        private string[] GetSenteceWithoutPunctuation(string[] sentence)
        {
            for(int i=0; i < sentence.Length; i++)
            {
                if(sentence[i].ElementAt(sentence[i].Length - 1) == ',' || sentence[i].ElementAt(sentence[i].Length - 1) == '.')
                {
                    sentence[i] = sentence[i].Substring(0, sentence[i].Length - 1);
                }
            }
            return sentence;
        }

        private string GetSentceFromStringArray(string[] array)
        {
            string str = "";
            for (int i = 0; i < array.Length; i++)
            {
                str += array[i] + " ";
            }

            return str.Trim();
        }

        private void FixClosestMisspelledWord(List<KeyValuePair<CoordinateRange, double>> sortedMisspelledWordsByDistance)
        {
            if (sortedMisspelledWordsByDistance.Count > 0)
            {
                CoordinateRange wordToFix = sortedMisspelledWordsByDistance.First().Key;
                List<string> suggestions = spellChecker.GetSpellingSuggestions(wordToFix.word);
                if (suggestions.Count > 0)
                {
                    textEditor.ReplaceWord(wordToFix, suggestions.First().Trim());
                    suggestions.RemoveAt(0);
                    //fixing = (suggestions, wordToFix.X, wordToFix.Y);
                    textEditor.fixedWord= (suggestions, wordToFix);
                }
                return;
            }
            SystemLogger.getEventLog().Info("No misspelled word found close to eye gaze");
        }

        private void AddWords(CoordinateRange firstWordCoordinate, string wordsToAdd)
        {
            textEditor.ReplaceWord(firstWordCoordinate, wordsToAdd);
        }

        private void FixLatestMisspelledWord(List<CoordinateRange> misspelledWords)
        {
            if (misspelledWords.Count > 0)
            {
                CoordinateRange wordToFix = misspelledWords.Last();
                List<string> suggestions = spellChecker.GetSpellingSuggestions(wordToFix.word);
                if (suggestions.Count > 0)
                    textEditor.ReplaceWord(wordToFix, suggestions.First());
                return;
            }
            SystemLogger.getEventLog().Info("No misspelled word found close to cursor");
        }
        public List<CoordinateRange> GetMisspelledWords(List<CoordinateRange> allWords)
        {
            List<CoordinateRange> misspelledWords = new List<CoordinateRange>();
            foreach (CoordinateRange word in allWords)
            {
                if (spellChecker.IsMisspelled(word.word))
                {
                    misspelledWords.Add(word);
                }
            }
            return misspelledWords;
        }

        public List<CoordinateRange> GetExactWords(List<CoordinateRange> allWords, string firstWord)
        {
            List<CoordinateRange> sameWord = new List<CoordinateRange>();
            foreach (CoordinateRange word in allWords)
            {
                if (word.word.ToLower().Equals(firstWord.ToLower()))
                {
                    sameWord.Add(word);
                }
            }
            return sameWord;
        }

        public Dictionary<CoordinateRange, double> FindDistanceFromCoordinate(List<CoordinateRange> misspelledWords, Point coordinate)
        {
            Dictionary<CoordinateRange, double> result = new Dictionary<CoordinateRange, double>();
            foreach (CoordinateRange word in misspelledWords)
            {
                double distance = Math.Sqrt(Math.Pow(coordinate.X - word.X, 2) + Math.Pow(coordinate.Y - word.Y, 2));
                if(distance < 170)
                    result.Add(word, distance);
            }
            return result;
        }

        public List<KeyValuePair<T1, T2>> SortByDistance<T1, T2>(List<KeyValuePair<T1, T2>> WordsAndDistance) where T2 : IComparable
        {
            WordsAndDistance.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            return WordsAndDistance;
        }

        public List<CoordinateRange> getSimilarLexicographicWords(List<CoordinateRange> wordsInRange, string word)
        {
            List<CoordinateRange> result = new List<CoordinateRange>();
            List<KeyValuePair<CoordinateRange, int>> similarWordsAndDistance = new List<KeyValuePair<CoordinateRange, int>>();
            foreach (CoordinateRange wordInRange in wordsInRange)
            {
                if (!IsPunctuation(wordInRange.word))
                    similarWordsAndDistance.Add(new KeyValuePair<CoordinateRange, int>(wordInRange, LevenshteinDistance(wordInRange.word, word)));
            }
            similarWordsAndDistance = SortByDistance(similarWordsAndDistance);
            int i = 0;
            while (i< similarWordsAndDistance.Count && similarWordsAndDistance[i].Value == 0)
                i++;
            if (i == similarWordsAndDistance.Count)
                return result;
            int min = similarWordsAndDistance[i].Value;
            if (min <= 3)
            {
                foreach (KeyValuePair<CoordinateRange, int> pair in similarWordsAndDistance)
                    if (pair.Value == min)
                        result.Add(pair.Key);
            }
            return result;
        }

        private int LevenshteinDistance(string left, string right)
        {
            left = left.ToLower();
            right = right.ToLower();

            if (left == null || right == null)
            {
                return -1;
            }

            if (left.Length == 0)
            {
                return right.Length;
            }

            if (right.Length == 0)
            {
                return left.Length;
            }

            int[,] distance = new int[left.Length + 1, right.Length + 1];

            for (int i = 0; i <= left.Length; i++)
            {
                distance[i, 0] = i;
            }

            for (int j = 0; j <= right.Length; j++)
            {
                distance[0, j] = j;
            }

            for (int i = 1; i <= left.Length; i++)
            {
                for (int j = 1; j <= right.Length; j++)
                {
                    if (right[j - 1] == left[i - 1])
                    {
                        distance[i, j] = distance[i - 1, j - 1];
                    }
                    else
                    {
                        distance[i, j] = Math.Min(distance[i - 1, j], Math.Min(distance[i, j - 1], distance[i - 1, j - 1])) + 1;
                    }
                }
            }

            return distance[left.Length, right.Length];
        }
        private Boolean IsPunctuation(string word)
        {
            if (word.Equals("\r") || word.Equals("\t") || word.Equals("\n"))
            {
                return true;
            }
            return false;
        }

    }
}
