using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LazyApiPack.Collections.Extensions;

namespace LazyApiPack.Collections.Tests.Extensions
{
    public class CollectionExtensionsTests
    {
        List<string> _target;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestExistingList()
        {
            var src = new List<string>(new[] { "a", "b", "c" });
            var target = new List<string>(new[] { "a", "d", "e", "f" });

            src.Upsert(target);

            Assert.That(src.Count == 6);
            Assert.IsTrue(src.Contains("a"));
            Assert.IsTrue(src.Contains("b"));
            Assert.IsTrue(src.Contains("c"));
            Assert.IsTrue(src.Contains("d"));
            Assert.IsTrue(src.Contains("e"));
            Assert.IsTrue(src.Contains("f"));
            Assert.IsFalse(src.Count(c => c == "a") > 1);
            Assert.Pass();
        }

    }
}
