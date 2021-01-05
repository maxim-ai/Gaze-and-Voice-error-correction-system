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
    class FixWordTest : IntegrationTest
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
        public void FixWordTest1()
        {
            Word.Range rng = findRangeOfWord(320, 340, "lion");
            System.Drawing.Point point = getPoint(rng);
            engine.FixWord("big elephant", point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 12);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            Assert.AreEqual(fixedWord[0].word, "lion");
            Assert.AreEqual(fixedWord[1].word, "jumped");
        }

        [Test]
        public void FixWordTest2()
        {
            Word.Range rng = findRangeOfWord(0, 50, "lion");
            System.Drawing.Point point = getPoint(rng);
            engine.FixWord("lioness", point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 12);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            Assert.AreEqual(fixedWord[0].word, "lioness");
        }

        [Test]
        public void FixWordTest3()
        {
            Word.Range rng = findRangeOfWord(0, 100, "heavy");
            System.Drawing.Point point = getPoint(rng);
            engine.FixWord("gravy", point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 12);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            Assert.AreEqual(fixedWord[0].word, "gravy");
        }
        //check that bold words after being  fixed stayBold
        [Test]
        public void FixWordTestBold()
        {
            Word.Range rng = findRangeOfWord(0, 100, "meal");
            rng.Bold = 1;
            System.Drawing.Point point = getPoint(rng);
            engine.FixWord("steal", point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 8);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            Assert.AreEqual(fixedWord[0].word, "steal");
            Assert.IsTrue(fixedWord[0].range.Bold != 0);
        }

        //check that underlined words after being  fixed stayUnderlined
        [Test]
        public void FixWordTestUnderline()
        {
            Word.Range rng = findRangeOfWord(400, 620, "was");
            rng.Underline = Word.WdUnderline.wdUnderlineSingle;
            System.Drawing.Point point = getPoint(rng);
            engine.FixWord("has", point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 8);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            Assert.AreEqual(fixedWord[0].word, "has");
            Assert.IsTrue(fixedWord[0].range.Underline.Equals(Word.WdUnderline.wdUnderlineSingle));
        }

        //check that highlighted words after being fixed return to the same highlight color
        [Test]
        public void FixWordTestHighlight()
        {
            Word.Range rng = findRangeOfWord(580, 650, "lived");
            rng.HighlightColorIndex = Word.WdColorIndex.wdBrightGreen;
            System.Drawing.Point point = getPoint(rng);
            engine.FixWord("dived", point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 8);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            Assert.AreEqual(fixedWord[0].word, "dived");
            Thread.Sleep(4000);
            Assert.IsTrue(fixedWord[0].range.HighlightColorIndex.Equals(Word.WdColorIndex.wdBrightGreen));
        }

        //check that a punctuation stays the same after fixing a word
        [Test]
        public void FixWordTestCheckPunctuation()
        { 
            Word.Range rng = findRangeOfWord(400, 620, "net");
            System.Drawing.Point point = getPoint(rng);
            engine.FixWord("met", point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 8);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            fixedWord[0].range.End += 1;
            //check that the dot after the word stays.
            Assert.AreEqual(fixedWord[0].range.Text, "met.");
        }

        [Test]
        public void FixWordTestApostrophes()
        {
            Word.Range rng = findRangeOfWord(400, 620, "Then");
            System.Drawing.Point point = getPoint(rng);
            engine.FixWord("when", point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 8);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            fixedWord[0].range.Start -= 1;
            //check that the apostrophe after the word stays.
            Assert.AreEqual(fixedWord[0].range.Text, "\"When");
        }

        [Test]
        public void FixWordTestParanthesisAndUpperCase()
        {
            Word.Range rng = findRangeOfWord(400, 620, "Thus");
            System.Drawing.Point point = getPoint(rng);
            engine.FixWord("this", point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 8);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            fixedWord[0].range.Start -= 1;
            //check that the paranthes before and the comma after the word stays afte the word is  fixed.
            Assert.AreEqual(fixedWord[0].range.Text, "(This");
        }
    }
}
