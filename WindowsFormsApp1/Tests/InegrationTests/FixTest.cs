using System;
using NUnit.Framework;
using EyeGaze.TextEditor;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using EyeGaze.Engine;
using EyeGaze.SpellChecker;
using System.Threading;



namespace EyeGaze.Tests.InegrationTests
{
    [TestFixture]
    class FixTest : IntegrationTest
    {

        [OneTimeSetUp]
        public static void Setup()
        {
            SetupIntegrationTest();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            TearDownIntegrationTest();
        }

        [Test]
        public void FixTest1()
        {
            Word.Range rng = findRangeOfWord(350, 620, "girafffe");
            System.Drawing.Point point = getPoint(rng);
            engine.Fix(point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 7);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            Assert.AreEqual(fixedWord[0].word, "giraffe");
        }

        [Test]
        public void FixTest2()
        {
            Word.Range rng = findRangeOfWord(0, 30, "time");
            System.Drawing.Point point = getPoint(rng);
            engine.Fix(point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 4);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            Assert.AreEqual(fixedWord[0].word, "time");
        }

        [Test]
        public void FixTest3()
        {
            Word.Range rng = findRangeOfWord(50, 300, "standingg");
            System.Drawing.Point point = getPoint(rng);
            engine.Fix(point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 8);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            Assert.AreEqual(fixedWord[0].word, "standing");
        }

        //check that bold words after being  fixed stayBold
        [Test]
        public void FixTestBold()
        {
            Word.Range rng = findRangeOfWord(50, 300, "andd");
            rng.Bold = 1;
            System.Drawing.Point point = getPoint(rng);
            engine.Fix(point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 8);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            Assert.AreEqual(fixedWord[0].word, "and");
            Assert.IsTrue(fixedWord[0].range.Bold != 0);
        }

        //check that underlined words after being  fixed stayUnderlined
       [Test]
        public void FixTestUnderline()
        {
            Word.Range rng = findRangeOfWord(400, 620, "soold");
            rng.Underline = Word.WdUnderline.wdUnderlineSingle;
            System.Drawing.Point point = getPoint(rng);
            engine.Fix(point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 8);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            Assert.AreEqual(fixedWord[0].word, "sold");
            Assert.IsTrue(fixedWord[0].range.Underline.Equals(Word.WdUnderline.wdUnderlineSingle));
        }
        
        //check that highlighted words after being fixed return to the same highlight color
      [Test]
        public void FixTestHighlight()
        {
            Word.Range rng = findRangeOfWord(580, 650, "standingg");
            rng.HighlightColorIndex = Word.WdColorIndex.wdBrightGreen;
            System.Drawing.Point point = getPoint(rng);
            engine.Fix(point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 8);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            Assert.AreEqual(fixedWord[0].word, "standing");
            Thread.Sleep(4000);
            Assert.IsTrue(fixedWord[0].range.HighlightColorIndex.Equals(Word.WdColorIndex.wdBrightGreen));
        }

        //check that a punctuation stays the same after fixing a word
        [Test]
        public void FixTestCheckPunctuation()
        {
            Word.Range rng = findRangeOfWord(650, 810, "huntt");
            System.Drawing.Point point = getPoint(rng);
            engine.Fix(point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 8);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            fixedWord[0].range.End += 1;
            //check that the dot after the word stays.
            Assert.AreEqual(fixedWord[0].range.Text, "hunt.");
        }

        [Test]
        public void FixTestApostrophes1()
        {
            Word.Range rng = findRangeOfWord(650, 810, "kingj");
            System.Drawing.Point point = getPoint(rng);
            engine.Fix(point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 8);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            fixedWord[0].range.End += 1;
            //check that the apostrophe after the word stays.
            Assert.AreEqual(fixedWord[0].range.Text, "king\"");
        }

        [Test]
        public void FixTestApostrophes2()
        {
            Word.Range rng = findRangeOfWord(650, 810, "Onje");
            System.Drawing.Point point = getPoint(rng);
            engine.Fix(point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 8);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            fixedWord[0].range.Start -= 1;
            //check that the paranthesis before the word stays after the fix.
            Assert.AreEqual(fixedWord[0].range.Text, "\"One");
        }

        [Test]
        public void FixTestParanthesis()
        {
            Word.Range rng = findRangeOfWord(650, 810, "Aftenrwards");
            System.Drawing.Point point = getPoint(rng);
            engine.Fix(point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 8);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            fixedWord[0].range.End += 1;
            fixedWord[0].range.Start -= 1;
            //check that the paranthes before and the comma after the word stays afte the word is  fixed.
            Assert.AreEqual(fixedWord[0].range.Text, "(Afterwards,");
        }
        //In a range that has the same mistake twice, make sure the right word is fixed.
        [Test]
        public void FixClosestWord1()
        {
            Word.Range rng = findRangeOfWord(845, 870, "wentt");
            System.Drawing.Point point = getPoint(rng);
            engine.Fix(point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 8);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            Assert.AreEqual(fixedWord[0].range.Text, "went");
        }
        [Test]
        public void FixClosestWord2()
        {
            Word.Range rng = findRangeOfWord(880, 895, "schoool");
            System.Drawing.Point point = getPoint(rng);
            engine.Fix(point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 8);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            Assert.AreEqual(fixedWord[0].range.Text, "school");
        }
    }
}
