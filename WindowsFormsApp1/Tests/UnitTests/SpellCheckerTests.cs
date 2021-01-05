using System;
using NUnit.Framework;
using EyeGaze.TextEditor;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using EyeGaze.SpellChecker;
using EyeGaze.Engine;



namespace EyeGaze.Tests.UnitTests
{
    [TestFixture]
    class SpellCheckerTests
    {
        static SpellCheckerAbstract spellCheckerNHun;
        static SpellCheckerAbstract spellCheckerWord;

        [SetUp]
        public static void setup()
        {
            EngineMain engine = new EngineMain();
            spellCheckerNHun = new NHunspellSpellChecker();
            spellCheckerWord = new WordSpell();
        }

        [Test]
        public static void NHun_IsMisspelled1()
        {
            string misspelled = "girafffe";
            bool isMisspelled = spellCheckerNHun.IsMisspelled(misspelled);
            Assert.IsTrue(isMisspelled);
        }

        [Test]
        public static void NHun_IsMisspelled2()
        {
            string misspelled = "helllo";
            bool isMisspelled = spellCheckerNHun.IsMisspelled(misspelled);
            Assert.IsTrue(isMisspelled);
        }

        [Test]
        public static void NHun_IsMisspelled3()
        {
            string misspelled = "laksdjflkj";
            bool isMisspelled = spellCheckerNHun.IsMisspelled(misspelled);
            Assert.IsTrue(isMisspelled);
        }

        [Test]
        public static void NHun_IsMisspelled4()
        {
            string word = "person";
            bool isMisspelled = spellCheckerNHun.IsMisspelled(word);
            Assert.IsFalse(isMisspelled);
        }

        [Test]
        public static void NHun_IsMisspelled5()
        {
            string word = "never";
            bool isMisspelled = spellCheckerNHun.IsMisspelled(word);
            Assert.IsFalse(isMisspelled);
        }

        [Test]
        public static void NHun_GetSpellingSuggestionTest1()
        {
            string word = "helllo";
            List<string> suggestions = spellCheckerNHun.GetSpellingSuggestions(word);
            string suggestion = "hello";
            Assert.IsTrue(suggestions.Contains(suggestion));
        }
        [Test]
        public static void NHun_GetSpellingSuggestionTest2()
        {
            string word = "dgo";
            List<string> suggestions = spellCheckerNHun.GetSpellingSuggestions(word);
            string suggestion = "dog";
            Assert.IsTrue(suggestions.Contains(suggestion));
        }
        [Test]
        public static void NHun_GetSpellingSuggestionTest3()
        {
            string word = "girafffe";
            List<string> suggestions = spellCheckerNHun.GetSpellingSuggestions(word);
            string suggestion = "giraffe";
            Assert.IsTrue(suggestions.Contains(suggestion));
        }
        [Test]
        public static void NHun_GetSpellingSuggestionTest4()
        {
            string word = "ifx";
            List<string> suggestions = spellCheckerNHun.GetSpellingSuggestions(word);
            string suggestion = "fix";
            Assert.IsTrue(suggestions.Contains(suggestion));
        }
        [Test]
        public static void NHun_GetSpellingSuggestionTest5()
        {
            string word = "soold";
            List<string> suggestions = spellCheckerNHun.GetSpellingSuggestions(word);
            string suggestion = "sold";
            Assert.IsTrue(suggestions.Contains(suggestion));
        }

        [Test]
        public static void Word_IsMisspelled1()
        {
            //recognize name as correct word
            string misspelled = "Zohar";
            bool isMisspelled = spellCheckerWord.IsMisspelled(misspelled);
            Assert.IsFalse(isMisspelled);

        }


        [Test]
        public static void Word_IsMisspelled2()
        {
            string word = "Oncee";
            bool isMisspelled = spellCheckerWord.IsMisspelled(word);
            List<string> suggestions = spellCheckerWord.GetSpellingSuggestions(word);
            string suggestion = "Once";
            Assert.IsTrue(isMisspelled);
            Assert.IsTrue(suggestions.Contains(suggestion));
        }

        [Test]
        public static void Word_IsMisspelled3()
        {
            string word = "cet";
            bool isMisspelled = spellCheckerWord.IsMisspelled(word);
            List<string> suggestions = spellCheckerWord.GetSpellingSuggestions(word);
            string suggestion = "cat";
            Assert.IsTrue(isMisspelled);
            Assert.AreEqual(suggestions[0], suggestion);
        }

        [Test]
        public static void Word_IsMisspelled4()
        {
            string word = "thhe";
            bool isMisspelled = spellCheckerWord.IsMisspelled(word);
            List<string> suggestions = spellCheckerWord.GetSpellingSuggestions(word);
            string suggestion = "the";
            Assert.IsTrue(isMisspelled);
            Assert.AreEqual(suggestions[0], suggestion);
        }

        [Test]
        public static void Word_IsMisspelled5()
        {
            string word = "the";
            bool isMisspelled = spellCheckerWord.IsMisspelled(word);
            List<string> suggestions = spellCheckerWord.GetSpellingSuggestions(word);

            Assert.IsFalse(isMisspelled);
            Assert.AreEqual(suggestions.Count, 0);
        }




        [TearDown]
        public void tearDown()
        {
            spellCheckerWord.CloseSpellChecker();
        }
    }
}