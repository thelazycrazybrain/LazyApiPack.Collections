using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LazyApiPack.Collections.Extensions;

namespace LazyApiPack.Collections.Tests.Extensions
{
    public class DictionaryExtensionsTests
    {
        Dictionary<string, string> _dictionary;
        [SetUp]
        public void Setup()
        {
            _dictionary = new Dictionary<string, string>();
        }

        [Test]
        public void TestDictionary()
        {
            _dictionary.Upsert("a", "a");
            _dictionary.Upsert("b", "b");
            _dictionary.Upsert("c", "c");
            Assert.That(_dictionary["a"], Is.EqualTo("a"));
            Assert.That(_dictionary["b"], Is.EqualTo("b"));
            Assert.That(_dictionary["c"], Is.EqualTo("c"));

            _dictionary.Upsert("a", "d");
            Assert.That(_dictionary["a"], Is.EqualTo("d"));
            Assert.That(_dictionary.Count, Is.EqualTo(3));


            Assert.Pass();
        }

        [Test]
        public void DuplicateKeyTest()
        {
            _dictionary.Upsert("a", "a");
            _dictionary.Upsert("a", "a");
            _dictionary.Upsert("a", "c");
            Assert.That(_dictionary["a"], Is.EqualTo("c"));
            Assert.That(_dictionary.Count, Is.EqualTo(1));
            Assert.Pass();
        }
    }
}
