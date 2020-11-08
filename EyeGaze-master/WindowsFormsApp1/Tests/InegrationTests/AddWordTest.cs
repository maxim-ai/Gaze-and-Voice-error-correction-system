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
    class AddWordTest : IntegrationTest
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
        public void AddWordTest1()
        {
            Word.Range rng = findRangeOfWord(10, 70, "One");
            System.Drawing.Point point = getPoint(rng);
            string[] sentence = {"One", "cold", "and", "rainy" };
            engine.Add(sentence, point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 15);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            Assert.AreEqual(fixedWord[0].word, "One");
            Assert.AreEqual(fixedWord[1].word, "cold");
            Assert.AreEqual(fixedWord[2].word, "and");
            Assert.AreEqual(fixedWord[3].word, "rainy");
        }

        [Test]
        public void AddWordTest2()
        {
            Word.Range rng = findRangeOfWord(10, 60, "forest");
            System.Drawing.Point point = getPoint(rng);
            string[] sentence = { "forest", "far", "away" };
            engine.Add(sentence, point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 15);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            Assert.AreEqual(fixedWord[0].word, "forest");
            Assert.AreEqual(fixedWord[1].word, "far");
            Assert.AreEqual(fixedWord[2].word, "away");
        }

        [Test]
        public void AddWordTest3()
        {
            Word.Range rng = findRangeOfWord(150, 400, "small");
            System.Drawing.Point point = getPoint(rng);
            string[] sentence = { "small", "and", "grey" };
            engine.Add(sentence, point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 15);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            Assert.AreEqual(fixedWord[0].word, "small");
            Assert.AreEqual(fixedWord[1].word, "and");
            Assert.AreEqual(fixedWord[2].word, "grey");
        }

        [Test]
        public void AddWordTest4()
        {
            Word.Range rng = findRangeOfWord(200, 300, "amit");
            System.Drawing.Point point = getPoint(rng);
            string[] sentence = { "amit", "and", "Jessica" };
            engine.Add(sentence, point);
            Word.Range fixedWordRange = document.Range(rng.Start-2, rng.Start-2 + 15);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            //The word amit was not found in the text
            //therefore the words and Jessica were not added to the text
            Assert.IsTrue(!rng.Text.Contains("and Jessica"));
        }

        [Test]
        public void AddWordBoldTest()
        {
            Word.Range rng = findRangeOfWord(350, 620, "cat");
            rng.Bold = 1;
            System.Drawing.Point point = getPoint(rng);
            string[] sentence = { "cat", "and", "dog" };
            engine.Add(sentence, point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 15);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);

            //The word amit was not found and did not have a close lexicographical word
            //therefore the words small and grey were not added in the area
            Assert.AreEqual(fixedWord[0].word, "cat");
            Assert.AreEqual(fixedWord[1].word, "and");
            Assert.AreEqual(fixedWord[2].word, "dog");
            Assert.IsTrue(fixedWord[0].range.Bold != 0);
            Assert.IsTrue(fixedWord[1].range.Bold != 0);
            Assert.IsTrue(fixedWord[2].range.Bold != 0);
        }

        [Test]
        public void AddWordPuctuationTest()
        {
            Word.Range rng = findRangeOfWord(60, 200, "while");
            System.Drawing.Point point = getPoint(rng);
            string[] sentence = { "while", "ago"};
            engine.Add(sentence, point);
            Word.Range fixedWordRange = document.Range(rng.Start, rng.Start + 15);
            List<CoordinateRange> fixedWord = wordTextEditor.GetAllWordsInRange(fixedWordRange);
            //increase the range to see the next character after the word.
            fixedWord[1].range.End += 1;
            fixedWord[0].range.End += 1;
            //In the text while has a comma afterwards: "while,"
            //when adding ago we want the text to look as follow: "while ago,"
            Assert.AreEqual(fixedWord[0].range.Text, "while ");
            Assert.AreEqual(fixedWord[1].range.Text, "ago,");
            
        }
    }
}
