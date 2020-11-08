using EyeGaze.Engine;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using Application = Microsoft.Office.Interop.Word.Application;
using Microsoft.Office.Interop.Word;

namespace EyeGaze.Tests.SystemTests
{
    [TestFixture]
    class SystemTest
    {
        EngineMain engine;
        Thread thread;
        string copyRelativePathTestWordInstance;
        Document document;
        Application application;

        [SetUp]
        public void setup()
        {
            engine = new EngineMain();
            this.thread = new Thread(() =>
            {
                Thread.Sleep(20000);
                this.engine.finishListen();
            });
            this.thread.Start();
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var combinedPathTestWordInstance = Path.Combine(outPutDirectory, "..\\..\\..\\Tests\\WordTextEditorInstances\\template.docx");
            var copyCombinedPathTestWordInstance = Path.Combine(outPutDirectory, "..\\..\\..\\Tests\\WordTextEditorInstances\\WordTextEditor_test.docx");
            string relativePathTestWordInstance = new Uri(combinedPathTestWordInstance).LocalPath;
            copyRelativePathTestWordInstance = new Uri(copyCombinedPathTestWordInstance).LocalPath;
            File.Copy(relativePathTestWordInstance, copyRelativePathTestWordInstance, true);
        }


        [Test]
        public void FixTest()
        {

            this.engine.Start(this.copyRelativePathTestWordInstance, "EyeGaze.Tests.Mocks.mockSpeechToText", "good", "fix", "EyeGaze.Tests.Mocks.mockMouseFix", "EyeGaze.SpellChecker.NHunspellSpellChecker");

            this.application = new Application();
            application.Visible = true;
            this.document = application.Documents.Open(this.copyRelativePathTestWordInstance);
            Word.Range fixedWordRange = document.Range(486, 493);
          
            Assert.AreEqual(fixedWordRange.Words[1].Text, "giraffe ");
        }

        [Test]
        public void FixWordTest()
        {

            this.engine.Start(this.copyRelativePathTestWordInstance, "EyeGaze.Tests.Mocks.mockSpeechToText", "good", "fix lioness", "EyeGaze.Tests.Mocks.mockMouseFixWord", "EyeGaze.SpellChecker.NHunspellSpellChecker");

            this.application = new Application();
            application.Visible = true;
            this.document = application.Documents.Open(this.copyRelativePathTestWordInstance);
            Word.Range fixedWordRange = document.Range(29, 36);
          
            Assert.AreEqual(fixedWordRange.Words[1].Text, "lioness ");
        }

        [Test]
        public void AddWordsTest()
        {

            this.engine.Start(this.copyRelativePathTestWordInstance, "EyeGaze.Tests.Mocks.mockSpeechToText", "good", "add Once hello world", "EyeGaze.Tests.Mocks.mockMouseAdd", "EyeGaze.SpellChecker.NHunspellSpellChecker");

            this.application = new Application();
            application.Visible = true;
            this.document = application.Documents.Open(this.copyRelativePathTestWordInstance);
            Word.Range fixedWordRange = document.Range(0, 15);
            
            Assert.AreEqual(fixedWordRange.Words[1].Text, "Once ");
            Assert.AreEqual(fixedWordRange.Words[2].Text, "hello ");
            Assert.AreEqual(fixedWordRange.Words[3].Text, "world ");
        }

        [Test]
        public void moveAndchangeTest()
        {
            this.engine.Start(this.copyRelativePathTestWordInstance, "EyeGaze.Tests.Mocks.mockSpeechToText", "good", "move", "EyeGaze.Tests.Mocks.mockMouseMove", "EyeGaze.SpellChecker.NHunspellSpellChecker");

            this.application = new Application();
            application.Visible = true;
            this.document = application.Documents.Open(this.copyRelativePathTestWordInstance);
            Word.Range fixedWordRange = document.Range(637, 668);

            Assert.AreEqual(fixedWordRange.Words[1].Text, "standing ");
        }

        [Test]
        public void ReplaceTest()
        {
            this.engine.Start(this.copyRelativePathTestWordInstance, "EyeGaze.Tests.Mocks.mockSpeechToText", "good", "replace lion tiger", "EyeGaze.Tests.Mocks.mockMouseReplace", "EyeGaze.SpellChecker.NHunspellSpellChecker");
            this.application = new Application();
            application.Visible = true;
            this.document = application.Documents.Open(this.copyRelativePathTestWordInstance);
            Word.Range fixedWordRange = document.Range(29, 40);

            Assert.AreEqual(fixedWordRange.Words[1].Text, "tiger ");
        }

        [Test]
        public void ReplaceAllTest()
        {
            this.engine.Start(this.copyRelativePathTestWordInstance, "EyeGaze.Tests.Mocks.mockSpeechToText", "good", "replace all this the", "EyeGaze.Tests.Mocks.mockMouseReplaceAll", "EyeGaze.SpellChecker.NHunspellSpellChecker");

            this.application = new Application();
            application.Visible = true;
            this.document = application.Documents.Open(this.copyRelativePathTestWordInstance);
            Word.Range documentRange = document.Range(0, 1);
            documentRange.WholeStory();
            Assert.IsTrue(!documentRange.Text.Contains("this") && !documentRange.Text.Contains("This"));
        }


        [TearDown]
        public void tearDown()
        {
            this.document.Close();
            this.application.Quit(false);
            File.Delete(this.copyRelativePathTestWordInstance);
        }
    }
}
