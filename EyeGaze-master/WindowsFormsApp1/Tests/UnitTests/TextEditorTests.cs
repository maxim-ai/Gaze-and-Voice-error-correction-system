using System;
using NUnit.Framework;
using EyeGaze.TextEditor;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using EyeGaze.Engine;



namespace EyeGaze.Tests.UnitTests
{
    [TestFixture]
    class TextEditorTests
    {
        static WordTextEditor wordTextEditor;
        static Word.Application application;
        static Word.Document document;
        static Word.Window window;
        static object relativePathTestWordInstance;

       [OneTimeSetUp]
        public static void setup()
        {
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
        }

        [Test]
        public void GetWordsCoordinateRangesTest()
        {
            object start = 0;
            object end = 150;
            List<string> words = new List<string>() { "lion", "forest", "andd", "sleeping" };
            List<CoordinateRange> list = new List<CoordinateRange>();
            foreach (string word in words)
            {
                Word.Range rng = document.Range(ref start, ref end);
                rng.Find.Execute(word);
                int left, top, width, height;
                window.GetPoint(out left, out top, out width, out height, rng);
                System.Drawing.Point point = new System.Drawing.Point(left, top);
                list.Add(new CoordinateRange(left, top, rng, word));
            }

            CoordinateRange cr0 = list[0];
            CoordinateRange cr1 = list[1];
            CoordinateRange cr2 = list[2];
            CoordinateRange cr3 = list[3];

            Assert.AreEqual(cr0.range.Start, 29);
            Assert.AreEqual(cr0.range.End, 33);

            Assert.AreEqual(cr1.range.Start, 39);
            Assert.AreEqual(cr1.range.End, 45);

            Assert.AreEqual(cr2.range.Start, 139);
            Assert.AreEqual(cr2.range.End, 143);

            Assert.AreEqual(cr3.range.Start, 82);
            Assert.AreEqual(cr3.range.End, 90);
        }

        [Test]
        public void GetAllWordsInRangeTest()
        {
            object start1 = 20;
            object end1 = 72;
            Word.Range rng1 = document.Range(ref start1, ref end1);
            List<CoordinateRange> wordsInRange1 = wordTextEditor.GetAllWordsInRange(rng1);
            List<string> list = new List<string>();
            foreach (CoordinateRange word in wordsInRange1)
                list.Add(word.word);
            List<string> words1 = new List<string>() { "there", "was", "a", "lion", "in", "a",
                "forest", "One", "day", "after", "a", "heavy", "meal"};
            Assert.AreEqual(list, words1);

            object start2 = 12;
            object end2 = 13;
            Word.Range rng2 = document.Range(ref start2, ref end2);
            List<CoordinateRange> wordsInRange2 = wordTextEditor.GetAllWordsInRange(rng2);
            Assert.AreEqual(wordsInRange2[0].word, "time");
        }

       [Test]
        public void MoveCursorTest()
        {
            object start = 2;
            object end = 3;
            Word.Range rng = document.Range(ref start, ref end);
            int left, top, width, height;
            window.GetPoint(out left, out top, out width, out height, rng);
            System.Drawing.Point point = new System.Drawing.Point(left, top);

            wordTextEditor.MoveCursor(point);
            Word.Range cursorRange = application.Selection.Range;
            int cursorLeft, cursorTop, cursorWidth, cursorHeight;
            window.GetPoint(out cursorLeft, out cursorTop, out cursorWidth, out cursorHeight, cursorRange);
            System.Drawing.Point curosrPoint = new System.Drawing.Point(cursorLeft, cursorTop);

            Assert.AreEqual(point, curosrPoint);
        }

        [Test]
        public void ReplaceWordTest()
        {
            object start = 400;
            object end = 620;
            Word.Range rng = document.Range(ref start, ref end);
            //CoordinateRange coordinateRange = wordTextEditor.GetWordsCoordinateRanges(new List<string>() { "girafffe" }, rng)[0];

            rng.Find.Execute("girafffe");
            int left, top, width, height;
            window.GetPoint(out left, out top, out width, out height, rng);
            System.Drawing.Point point = new System.Drawing.Point(left, top);
            CoordinateRange coordinateRange = new CoordinateRange(left, top, rng, "girafffe");
            wordTextEditor.ReplaceWord(coordinateRange, "dolphin");
            Word.Range range = coordinateRange.range;
            string wordInRange = wordTextEditor.GetAllWordsInRange(range)[0].word;
            Assert.AreEqual(wordInRange, "dolphin");
        }

        [OneTimeTearDown]
        public void tearDown()
        {
            document.Close(Word.WdSaveOptions.wdDoNotSaveChanges);
            application.Quit();
        }

    }
}
