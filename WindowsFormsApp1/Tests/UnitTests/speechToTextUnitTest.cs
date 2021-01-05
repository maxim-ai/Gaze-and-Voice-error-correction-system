using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SpeechToTextClass = EyeGaze.SpeechToText.SpeechToText;
using EyeGaze.SpeechToText;
using EyeGaze.Engine;
using Moq;
using EyeGaze.Tests.Mocks;

namespace EyeGaze.Tests.UnitTests
{
    [TestFixture]
    class speechToTextUnitTest
    {
        static SpeechToTextClass speech;
        TriggerWordEvent actualWord;
        MessageEvent message;

        [SetUp]
        public void setup()
        {
            message = null;
            speech = new SpeechToTextClass("EyeGaze.Tests.Mocks.mockSpeechToText");
            WireEventHandlersTriggerWord(speech);
            WireEventHandlersException(speech);
        }


        private void WireEventHandlersTriggerWord(SpeechToTextClass stt)
        {
             TriggerWordHandler handler = new TriggerWordHandler(triggerWordHandler);
             stt.triggerHandler += handler;
        }
        public void triggerWordHandler(object sender, TriggerWordEvent e)
        {
            speech.finishListen();
            actualWord = e;
        }

        private void WireEventHandlersException(SpeechToTextClass stt)
        {
            TriggerHandlerMessage handler = new TriggerHandlerMessage(handleMessageFromSpeechToText);
            stt.sendMessageToEngine += handler;
        }

        public void handleMessageFromSpeechToText(object sender, MessageEvent e)
        {
            if(message == null)
                message = e;
        }


        [Test]
        public void TestFix_happy()
        {
            string[] result = { "fix" };
            TriggerWordEvent m = speech.parseResult(result);
            Assert.AreEqual(m.triggerWord, "fix");
            Assert.AreEqual(m.content.Length, 0);
        }

        [Test]
        public void TestFixWord_happy()
        {
            string[] result = { "fix", "world" };
            TriggerWordEvent m = speech.parseResult(result);
            Assert.AreEqual(m.triggerWord, "fix word");
            Assert.AreEqual(m.content.Length, 1);
            Assert.AreEqual(m.content[0], "world");
        }

        [Test]
        public void TestAdd_happy()
        {
            string[] result = { "add", "world", "hello" };
            TriggerWordEvent m = speech.parseResult(result);
            Assert.AreEqual(m.triggerWord, "add");
            Assert.AreEqual(m.content.Length, 2);
            Assert.AreEqual(m.content[0], "world");
            Assert.AreEqual(m.content[1], "hello");
        }

        [Test]
        public void TestAdd_Sad()
        {
            string[] result = { "add", "world" };
            TriggerWordEvent m = speech.parseResult(result);
            Assert.AreEqual(m, null);
        }

        [Test]
        public void TestAdd_Sad2()
        {
            string[] result = { "add" };
            TriggerWordEvent m = speech.parseResult(result);
            Assert.AreEqual(m, null);
        }

        [Test]
        public void TestMoveCursor_happy()
        {
            string[] result = { "move" };
            TriggerWordEvent m = speech.parseResult(result);
            Assert.AreEqual(m.triggerWord, "move");
            Assert.AreEqual(m.content.Length, 0);
        }

        [Test]
        public void TestChange_happy()
        {
            string[] result = { "change" };
            TriggerWordEvent m = speech.parseResult(result);
            Assert.AreEqual(m.triggerWord, "change");
            Assert.AreEqual(m.content.Length, 0);
        }

        [Test]
        public void TestFindActionFromSpeech_happy()
        {
            speech.FindActionFromSpeech("good", "Fix");
            Assert.AreEqual("fix", actualWord.triggerWord);
            Assert.AreEqual(0, actualWord.content.Length);
        }

        [Test]
        public void TestFindActionFromSpeech_happy2()
        {
            speech.FindActionFromSpeech("good", "Add hello word");
            Assert.AreEqual("add", actualWord.triggerWord);
            Assert.AreEqual("hello", actualWord.content[0]);
            Assert.AreEqual("word", actualWord.content[1]);
        }

        [Test]
        public void TestFindActionFromSpeech_happy3()
        {
            speech.FindActionFromSpeech("good", "change");
            Assert.AreEqual("change", actualWord.triggerWord);
            Assert.AreEqual(0, actualWord.content.Length);
        }

        [Test]
        public void TestFindActionFromSpeech_happy4()
        {
            speech.FindActionFromSpeech("good", "move");
            Assert.AreEqual("move", actualWord.triggerWord);
            Assert.AreEqual(0, actualWord.content.Length);
        }

        [Test]
        public void TestFindActionFromSpeech_happy5()
        {
            speech.FindActionFromSpeech("good", "fix hello");
            Assert.AreEqual("fix word", actualWord.triggerWord);
            Assert.AreEqual("hello", actualWord.content[0]);
        }

        [Test]
        public void TestFindActionFromSpeech_bad()
        {
            speech.FindActionFromSpeech("badAuthentication", "Fix");
            Assert.AreEqual("wrong authentication", message.message);
            Assert.AreEqual(MessageEvent.messageType.WrongAuthentication, message.type);
        }

        [Test]
        public void TestFindActionFromSpeech_bad2()
        {
            speech = new mocMainSpeechToText("EyeGaze.Tests.Mocks.mockSpeechToText");
            WireEventHandlersTriggerWord(speech);
            WireEventHandlersException(speech);
            speech.FindActionFromSpeech("badConnection", "fix");
            Assert.AreEqual("connection failed switch to system lib", message.message);
            Assert.AreEqual(MessageEvent.messageType.ConnectionFail, message.type);
            Assert.AreEqual("fix", actualWord.triggerWord);
            Assert.AreEqual(0, actualWord.content.Length);

        }
    }
}
