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
    [TestFixture]
    class ChangeTest : IntegrationTest
    {

        [OneTimeSetUp]
        public static void Setup()
        {
            SetupIntegrationTest();
        }

        [OneTimeTearDown]
        public void tearDown()
        {
            TearDownIntegrationTest();
        }

        [Test]
        public void ChangeTest1()
        {
            Word.Range rng = document.Range(463, 463);
            rng.Text = "I need to fixx my computer ";
            Word.Range rng2 = document.Range(489, 489);
            System.Drawing.Point point = getPoint(rng2);    
            wordTextEditor.MoveCursor(point);
            engine.Change();

            Word.Range fixedWordRange = document.Range(463, 488);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            Assert.AreEqual(fixedWord[0].word, "I");
            Assert.AreEqual(fixedWord[1].word, "need");
            Assert.AreEqual(fixedWord[2].word, "to");
            Assert.AreEqual(fixedWord[3].word, "fix");
            Assert.AreEqual(fixedWord[4].word, "my");
            Assert.AreEqual(fixedWord[5].word, "computer");
        }

        [Test]
        public void ChangeTest2()
        {
            Word.Range rng = document.Range(463, 463);
            rng.Text = "for my school homework";
            Word.Range rng2 = document.Range(485, 485);
            System.Drawing.Point point = getPoint(rng2);
            wordTextEditor.MoveCursor(point);
            engine.Change();

            Word.Range fixedWordRange = document.Range(463, 485);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            Assert.AreEqual(fixedWord[0].word, "for");
            Assert.AreEqual(fixedWord[1].word, "my");
            Assert.AreEqual(fixedWord[2].word, "school");
            Assert.AreEqual(fixedWord[3].word, "homework");
        }

        [Test]
        public void ChangeTest3()
        {
            Word.Range rng = document.Range(463, 463);
            rng.Text = "I neeed to fixx my computer ";
            Word.Range rng2 = document.Range(489, 489);
            System.Drawing.Point point = getPoint(rng2);
            wordTextEditor.MoveCursor(point);
            engine.Change();

            Word.Range fixedWordRange = document.Range(463, 488);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            Assert.AreEqual(fixedWord[0].word, "I");
            Assert.AreEqual(fixedWord[1].word, "neeed");
            Assert.AreEqual(fixedWord[2].word, "to");
            Assert.AreEqual(fixedWord[3].word, "fix");
            Assert.AreEqual(fixedWord[4].word, "my");
            Assert.AreEqual(fixedWord[5].word, "computer");
        }
    }
}