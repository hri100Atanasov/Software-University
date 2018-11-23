using _01.DatabaseProblem;
using NUnit.Framework;
using System;
using System.Linq;

namespace _01.DatabaseTests
{
    public class DatabaseTests
    {
        private int?[] nullParamsCollection;
        private int?[] exceedSizeArray;
        private int?[] exactSizeArray;
        private int?[] lessThenSizeArray;
        private Database database;

        [SetUp]
        public void TestInit()
        {
            database = new Database();
            nullParamsCollection = Enumerable.Repeat<int?>(null, 16).ToArray();
            exceedSizeArray = Enumerable.Repeat<int?>(1, 17).ToArray();
            exactSizeArray = Enumerable.Repeat<int?>(1, 16).ToArray();
            lessThenSizeArray = Enumerable.Repeat<int?>(1, 4).ToArray();
        }

        [Test]
        public void ConstructorInitializeTest()
        {
            database = new Database();
            Assert.AreNotEqual(null, database);
        }

        [Test]
        public void ConstructorExceededSizeTest()
        {
            Assert.That(()=>new Database(exceedSizeArray), Throws.InvalidOperationException);
        }

        [Test]
        public void ConstructorCreatesCollection()
        {
            var actual = new Database(exactSizeArray).Fetch();
            Assert.That(actual, Is.EqualTo(exactSizeArray));
        }

        [Test]
        public void ConstructorCreatesCollectionNullable()
        {
            var actual = new Database(nullParamsCollection).Fetch();
            Assert.That(actual, Is.EqualTo(nullParamsCollection));
        }

        [Test]
        public void ConstructorCreatesCollectionLessThenSize()
        {
            var actual = new Database(lessThenSizeArray).Fetch().Where(e=>e!=null).ToArray();
            Assert.That(actual, Is.EqualTo(lessThenSizeArray));
        }

        [Test]
        public void AddMethodTest()
        {
            var db = new Database(lessThenSizeArray);
            db.Add(5);
            var actual = db.Fetch().Where(e => e != null).ToArray();
           var expected = lessThenSizeArray.Concat(new int?[] { 5 }).ToArray();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveMethodTest()
        {
            var db = new Database(lessThenSizeArray);
            db.Remove();
            var actual = db.Fetch().Where(e=>e!=null).ToArray();
            lessThenSizeArray[lessThenSizeArray.Length - 1] = null;
            var expected = lessThenSizeArray.Where(e => e != null).ToArray();
            Assert.AreEqual(expected, actual);
        }
    }
}
