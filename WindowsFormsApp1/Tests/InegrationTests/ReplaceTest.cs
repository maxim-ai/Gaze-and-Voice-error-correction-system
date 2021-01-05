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
    class ReplaceTest : IntegrationTest
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
        public void ReplaceTest1()
        {
            Word.Range rng = findRangeOfWord(450, 600, "hunter");
            System.Drawing.Point point = getPoint(rng);
            string replaceTo = "person";
            string[] sentence = { "hunter", replaceTo};
            engine.Replace(sentence, point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + replaceTo.Length);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            Assert.AreEqual(fixedWord[0].word, "person");
        }

        [Test]
        public void ReplaceTest2()
        {
            Word.Range rng = findRangeOfWord(450, 600, "On");
            System.Drawing.Point point = getPoint(rng);
            string replaceTo = "off";
            string[] sentence = { "On", replaceTo };
            engine.Replace(sentence, point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + replaceTo.Length);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            Assert.AreEqual(fixedWord[0].word, "Off");
        }

        [Test]
        public void ReplaceTest3()
        {
            Word.Range rng = findRangeOfWord(450, 600, "another");
            System.Drawing.Point point = getPoint(rng);
            string replaceTo = "also";
            string[] sentence = { "another", replaceTo };
            engine.Replace(sentence, point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + replaceTo.Length);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            Assert.AreEqual(fixedWord[0].word, replaceTo);
        }

        //check that bold words after being  fixed stayBold
        [Test]
        public void ReplaceTestBold()
        {
            string wordToReplace = "meal";
            string replaceTo = "supper";
            string[] replaceArray = { wordToReplace, replaceTo };            
            Word.Range rng = findRangeOfWord(0, 100, wordToReplace);
            rng.Bold = 1;
            System.Drawing.Point point = getPoint(rng);
            engine.Replace(replaceArray, point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 8);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            Assert.AreEqual(fixedWord[0].word, replaceTo);
            Assert.IsTrue(fixedWord[0].range.Bold != 0);
        }

        //check that underlined words after being  fixed stayUnderlined
        [Test]
        public void ReplaceTestUnderline()
        {
            string wordToReplace = "was";
            string replaceTo = "never";
            string[] replaceArray = { wordToReplace, replaceTo };
            Word.Range rng = findRangeOfWord(400, 620, wordToReplace);
            rng.Underline = Word.WdUnderline.wdUnderlineSingle;
            System.Drawing.Point point = getPoint(rng);
            engine.Replace(replaceArray, point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 8);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            Assert.AreEqual(fixedWord[0].word, replaceTo);
            Assert.IsTrue(fixedWord[0].range.Underline.Equals(Word.WdUnderline.wdUnderlineSingle));
        }

        //check that highlighted words after being fixed return to the same highlight color
        [Test]
        public void ReplaceTestHighlight()
        {
            string wordToReplace = "lived";
            string replaceTo = "replace";
            string[] replaceArray = { wordToReplace, replaceTo };
            Word.Range rng = findRangeOfWord(580, 650, wordToReplace);
            rng.HighlightColorIndex = Word.WdColorIndex.wdBrightGreen;
            System.Drawing.Point point = getPoint(rng);
            engine.Replace(replaceArray, point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 8);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            Assert.AreEqual(fixedWord[0].word, replaceTo);
            Thread.Sleep(4000);
            Assert.IsTrue(fixedWord[0].range.HighlightColorIndex.Equals(Word.WdColorIndex.wdBrightGreen));
        }

        //check that a punctuation stays the same after fixing a word
        [Test]
        public void ReplaceTestCheckPunctuation()
        { 
            string wordToReplace = "net";
            string replaceTo = "friend";
            string[] replaceArray = { wordToReplace, replaceTo };
            Word.Range rng = findRangeOfWord(400, 620, wordToReplace);
            System.Drawing.Point point = getPoint(rng);
            engine.Replace(replaceArray, point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 8);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            fixedWord[0].range.End += 1;
            //check that the dot after the word stays.
            Assert.AreEqual(fixedWord[0].range.Text, replaceTo + ".");
        }

        [Test]
        public void ReplaceTestApostrophes()
        {
            string wordToReplace = "Then";
            string replaceTo = "before";
            string[] replaceArray = { wordToReplace, replaceTo };
            Word.Range rng = findRangeOfWord(400, 620, wordToReplace);
            System.Drawing.Point point = getPoint(rng);
            engine.Replace(replaceArray, point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 8);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            fixedWord[0].range.Start -= 1;
            //check that the apostrophe after the word stays.
            Assert.AreEqual(fixedWord[0].range.Text, "\"Before");
        }

        [Test]
        public void ReplaceTestParanthesisAndUpperCase()
        {
            string wordToReplace = "Thus";
            string replaceTo = "because";
            string[] replaceArray = { wordToReplace, replaceTo };
            Word.Range rng = findRangeOfWord(400, 640, wordToReplace);
            System.Drawing.Point point = getPoint(rng);
            engine.Replace(replaceArray, point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 8);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            fixedWord[0].range.Start -= 1;
            //check that the paranthes before and the comma after the word stays afte the word is  fixed.
            Assert.AreEqual(fixedWord[0].range.Text, "(Because");
        }

    }
}
