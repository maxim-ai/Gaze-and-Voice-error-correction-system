using System;
using NUnit.Framework;
using EyeGaze.TextEditor;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using EyeGaze.Engine;
using EyeGaze.SpellChecker;


namespace EyeGaze.Tests.InegrationTests
{
    public class IntegrationTest
    {
        public static WordTextEditor wordTextEditor;
        public static EngineMain engine;
        public static Word.Application application;
        public static Word.Document document;
        public static Word.Window window;
        public static object relativePathTestWordInstance;

        public static void SetupIntegrationTest()
        {
            engine = new EngineMain();
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var combinedPath = Path.Combine(outPutDirectory, "..\\..\\..\\Utils\\TextEditorText.txt");
            var relativePath = new Uri(combinedPath).LocalPath;
            string text = File.ReadAllText(relativePath);
            var combinedPathTestWordInstance = Path.Combine(outPutDirectory, "..\\..\\..\\Tests\\WordTextEditorInstances\\WordTextEditor2.docx");
            relativePathTestWordInstance = new Uri(combinedPathTestWordInstance).LocalPath;
            wordTextEditor = new WordTextEditor(relativePathTestWordInstance.ToString());
            document = wordTextEditor.GetDocument();
            application = wordTextEditor.GetApplication();
            window = application.ActiveWindow;
            Word.Selection currentSelection = application.Selection;
            currentSelection.TypeText(text);
            engine.SetTextEditor(wordTextEditor);
            engine.SetSpellChecker(new NHunspellSpellChecker());
        }

        public void TearDownIntegrationTest()
        {
            document.Close(Word.WdSaveOptions.wdDoNotSaveChanges);
            application.Quit();
        }
        public System.Drawing.Point getPoint(Word.Range rng)
        {
            int left, top, width, height;
            window.GetPoint(out left, out top, out width, out height, rng);
            System.Drawing.Point point = new System.Drawing.Point(left, top);
            return point;
        }
        public Word.Range findRangeOfWord(object start, object end, string word)
        {
            Word.Range rng = document.Range(ref start, ref end);
            rng.Find.Execute(word);
            return rng;
        }
    }
}
