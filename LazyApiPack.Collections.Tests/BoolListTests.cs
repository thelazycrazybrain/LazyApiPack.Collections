namespace LazyApiPack.Collections.Tests
{
    public class BoolListTests
    {
        BoolList _a;
        BoolList _b;
        [SetUp]
        public void Setup()
        {
            _a = new BoolList();
            _b = new BoolList();
        }

        [Test]
        public void TestResultsAndOperatorOverloads()
        {
            _a["Visible A"] = true;
            _a["Active A"] = false;

            Assert.That(!_a, "_a should be false.");
            Assert.That(_a.Value == _a, "Value and the overloaded == operator are not the same.");

            _a["Active A"] = true;
            Assert.That(_a, "_a should be true.");
            Assert.That(_a.Value == _a, "Value and the overloaded == operator are not the same.");


            _b["Visible B"] = true;
            _b["Test B"] = false;
            Assert.That(_a.Value, Is.EqualTo(!_b.Value), "Values of _a and _b should be different, but are not.");
            Assert.That(_a != _b, "Overloaded operator for BoolList != BoolList does not provide the expected result (true).");

            _b["Test B"] = true;
            Assert.That(_a.Value, Is.EqualTo(_b.Value), "Values of _a and _b must be equal but are not.");
            Assert.That(_a == _b, "Operator overload BoolList == BoolList returns an unexpected value.");

            Assert.Pass();

        }

        [Test]
        public void TestModes()
        {
            _a.Mode = BoolListMode.AllTrue;
            _a["a"] = true;
            _a["b"] = true;
            _a["c"] = true;
            Assert.That(_a.Value, Is.EqualTo(true), "Mode AllTrue should be true.");
            _a["a"] = false;
            Assert.That(_a.Value, Is.EqualTo(false), "Mode AllTrue should be false.");

            _a.Mode = BoolListMode.AtLeastOneTrue;
            Assert.That(_a.Value, Is.EqualTo(true), "Mode AtLeastOneTrue should be true.");
            _a["b"] = false;
            _a["c"] = false;
            Assert.That(_a.Value, Is.EqualTo(false), "Mode AtLeastOneTrue should be false.");

            _a.Mode = BoolListMode.ExactlyOneTrue;
            Assert.That(_a.Value, Is.EqualTo(false), "Mode ExactlyOneTrue should be false.");
            _a["a"] = true;
            Assert.That(_a.Value, Is.EqualTo(true), "Mode ExactlyOneTrue should be true.");

            _a["b"] = true;
            Assert.That(_a.Value, Is.EqualTo(false), "Mode ExactlyOneTrue should be false.");

            Assert.Pass();


        }
    }
}
