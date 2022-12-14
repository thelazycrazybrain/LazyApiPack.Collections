namespace LazyApiPack.Collections.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAppend()
        {
            var n = new int[] { 0, 1, 2, 3, 4, 5 };
            n = n.Append(new[] { 6, 7, 8, 9 });
            n = n.Append(new int[0]);
            n = n.Append(new[] { 10, 11, 12, 13, 14 });

            Assert.That(n.Length, Is.EqualTo(15), "Array has not the expected size.");
            for (int i = 0; i < n.Length; i++)
            {
                Assert.That(n[i], Is.EqualTo(i), "Item at array is not correct.");
            }

            Assert.Pass();
        }

        [Test]
        public void TestInsert()
        {
            var n = new int[] { 10, 11, 12, 13, 14 }; // 5
            n = n.Insert(new[] { 0, 1, 2, 3, 4, 5 }, 0); // 6
            n = n.Insert(new[] { 6, 7, 8, 9 }, 6);
            n = n.Insert(new int[0], 3);


            Assert.That(n.Length, Is.EqualTo(15), "Array has not the expected size.");
            for (int i = 0; i < n.Length; i++)
            {
                Assert.That(n[i], Is.EqualTo(i), "Item at array is not correct.");
            }

            Assert.Pass();
        }

        [Test]
        public void TestRemove()
        {
            var n = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }; // 15

            n = n.RemoveRange(5, 3);

            Assert.That(n.Length, Is.EqualTo(12), "Array has not the expected size.");
            var check = new int[] { 0, 1, 2, 3, 4, 8, 9, 10, 11, 12, 13, 14 };
            for (int i = 0; i < n.Length; i++)
            {
                Assert.That(n[i], Is.EqualTo(check[i]), "Item at array is not correct.");
            }

            Assert.Pass();
        }

    }
}