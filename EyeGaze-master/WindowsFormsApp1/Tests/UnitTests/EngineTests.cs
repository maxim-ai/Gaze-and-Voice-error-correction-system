using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SpeechToTextClass = EyeGaze.SpeechToText.SpeechToText;
using MicrosoftCloudSpeechToText = EyeGaze.SpeechToText.MicrosoftCloudSpeechToText;
using EyeGaze.SpeechToText;
using EyeGaze.Engine;
using System.Drawing;
using EyeGaze.TextEditor;

namespace EyeGaze.Tests.UnitTests
{
    [TestFixture]
    class EngineTests
    {
        static EngineMain engine;

        [SetUp]
        public static void setup()
        {
            engine = new EngineMain();
        }

        [Test]
        public void findDistanceFromCoordinateTest()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void GetMisspelledWordsTest()
        {
            engine.setSpellChecker("Hunspell");
            List<CoordinateRange> words = new List<CoordinateRange>() { new CoordinateRange(0, 0, null, "dad"), new CoordinateRange(0, 0, null, "dogg"), new CoordinateRange(0, 0, null, "dog"), new CoordinateRange(0, 0, null, "and"), new CoordinateRange(0, 0, null, "annd"), new CoordinateRange(0, 0, null, "the"), new CoordinateRange(0, 0, null, "cat"), new CoordinateRange(0, 0, null, "ccat") };
            List<CoordinateRange> misspelledWordsFromEngine = engine.GetMisspelledWords(words);
            Assert.AreEqual(misspelledWordsFromEngine[0].word, "dogg");
            Assert.AreEqual(misspelledWordsFromEngine[1].word, "annd");
            Assert.AreEqual(misspelledWordsFromEngine[2].word, "ccat");
        }

        [Test]
        public void GetExactWordsTests()
        {
            List<CoordinateRange> words = new List<CoordinateRange>() { new CoordinateRange(0, 0, null, "dad"), new CoordinateRange(0, 0, null, "dog"), new CoordinateRange(0, 0, null, "and"), new CoordinateRange(0, 0, null, "the"), new CoordinateRange(0, 0, null, "cat")};
            List<CoordinateRange> exactWords = engine.GetExactWords(words, "dad");
            Assert.AreEqual(exactWords[0].word,  "dad");
            Assert.AreEqual(exactWords.Count, 1);


        }

        [Test]
        public void FindDistanceFromCoordinateTest()
        {
            CoordinateRange cr1 = new CoordinateRange(300, 270, null, null);
            CoordinateRange cr2 = new CoordinateRange(250, 370, null, null);
            CoordinateRange cr3 = new CoordinateRange(250, 280, null, null);
            List<CoordinateRange> coordinateRanges = new List<CoordinateRange>() { cr1, cr2, cr3 };
            Point point = new Point(250, 270);
            Dictionary<CoordinateRange, double> distance = engine.FindDistanceFromCoordinate(coordinateRanges, point);
            Dictionary<CoordinateRange, double> resultDistance = new Dictionary<CoordinateRange, double>();
            resultDistance.Add(cr1, 50);
            resultDistance.Add(cr2, 100);
            resultDistance.Add(cr3, 10);
            Assert.AreEqual(distance, resultDistance);
        }


        [Test]
        public void getSimilarLexicographicWordsTest()
        {
            List<CoordinateRange> words1 = new List<CoordinateRange>() { new CoordinateRange(0, 0, null, "cat"), new CoordinateRange(0, 0, null, "bat"), new CoordinateRange(0, 0, null, "dog"), new CoordinateRange(0, 0, null, "dad") };
            List<CoordinateRange> similarWords1 = engine.getSimilarLexicographicWords(words1, "hat");
            Assert.AreEqual(similarWords1[0].word, "cat");
            Assert.AreEqual(similarWords1[1].word, "bat");

            List<CoordinateRange> words2 = new List<CoordinateRange>() { new CoordinateRange(0, 0, null, "hello"), new CoordinateRange(0, 0, null, "house"), new CoordinateRange(0, 0, null, "goodbye"), new CoordinateRange(0, 0, null, "cyber")};
            List<CoordinateRange> similarWords2 = engine.getSimilarLexicographicWords(words2, "tiger");
            Assert.AreEqual(similarWords2[0].word, "cyber");

            List<CoordinateRange> words3 = new List<CoordinateRange>() { new CoordinateRange(0, 0, null, "hello"), new CoordinateRange(0, 0, null, "mouse"), new CoordinateRange(0, 0, null, "welcome"), new CoordinateRange(0, 0, null, "house")};
            List<CoordinateRange> similarWords3 = engine.getSimilarLexicographicWords(words3, "blouse");
            Assert.AreEqual(similarWords3[0].word, "mouse");
            Assert.AreEqual(similarWords3[1].word, "house");
        }
    }
}
    