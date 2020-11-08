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
    class ReplaceAllTest : IntegrationTest
    {

        [SetUp]
        public static void Setup()
        {
            SetupIntegrationTest();
        }
        [TearDown]
        public void TearDown()
        {
            TearDownIntegrationTest();
        }

        public void SetupText()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var combinedPath = Path.Combine(outPutDirectory, "..\\..\\..\\Utils\\TextEditorReplaceAll.txt");
            var relativePath = new Uri(combinedPath).LocalPath;
            string text = File.ReadAllText(relativePath);
            Word.Range range = document.Range(0, 1);
            range.WholeStory();
            range.Delete();
            application.Selection.TypeText(text);
        }
        [Test]
        public void ReplaceAllTest1()
        {
            SetupText();
            string replaceWord = "the";
            string replaceTo = "that";
            string[] sentence = { "all", replaceWord, replaceTo };
            engine.ReplaceAll(sentence);
            Word.Range documentRange = document.Range(0, 1);
            documentRange.WholeStory();
            string wordText = documentRange.Text;
            string textAfterChange = File.ReadAllText(new Uri(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), "..\\..\\..\\Utils\\TextEditorTextReplaceTheToThat.txt")).LocalPath);
            Assert.AreEqual(textAfterChange + "\r", wordText);
        }
        [Test]
        public void ReplaceTestAll2()
        {
            SetupText();
            string replaceWord = "a";
            string replaceTo = "an";
            string[] sentence = { "all", replaceWord, replaceTo };
            engine.ReplaceAll(sentence);
            Word.Range documentRange = document.Range(0, 1);
            documentRange.WholeStory();
            string wordText = documentRange.Text;
            string textAfterChange = File.ReadAllText(new Uri(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), "..\\..\\..\\Utils\\TextEditorReplaneAToAn.txt")).LocalPath);
            Assert.AreEqual(textAfterChange + "\r", wordText);
        }
        [Test]
        public void ReplaceTestAll3()
        {
            SetupText();
            string replaceWord = "with";
            string replaceTo = "without";
            string[] sentence = { "all", replaceWord, replaceTo };
            engine.ReplaceAll(sentence);
            Word.Range documentRange = document.Range(0, 1);
            documentRange.WholeStory();
            string wordText = documentRange.Text;
            string textAfterChange = File.ReadAllText(new Uri(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), "..\\..\\..\\Utils\\TextEditorReplateWithToWithout.txt")).LocalPath);
            Assert.AreEqual(textAfterChange + "\r", wordText);
        }

    }
}
