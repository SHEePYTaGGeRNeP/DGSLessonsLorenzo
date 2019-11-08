using Assets.Scripts.Helpers.Classes;
using NUnit.Framework;
using System.Collections.Generic;

namespace Assets.Tests
{
    class DictionaryListTests
    {
        [Test]
        public void Can_AddingItem_Works()
        {
            DictionaryList<string, int> dictionaryList = new DictionaryList<string, int>();
            dictionaryList.Add("hello", 1);
            CollectionAssert.AreEqual(new[] { 1 }, dictionaryList.Get("hello"));
            dictionaryList.Add("hello", 2);
            CollectionAssert.AreEqual(new[] { 1, 2 }, dictionaryList.Get("hello"));
        }

        [Test]
        public void Get_WhenEmpty_ThrowsException()
        {
            DictionaryList<string, int> dictionaryList = new DictionaryList<string, int>();
            Assert.Throws<KeyNotFoundException>(() => dictionaryList.Get("hai"));
        }

        [Test]
        public void TryGetValue_WhenEmpty_ReturnsFalse()
        {
            DictionaryList<string, int> dictionaryList = new DictionaryList<string, int>();
            Assert.IsFalse(dictionaryList.TryGetValue("hai", out var tmp));
        }
    }
}
