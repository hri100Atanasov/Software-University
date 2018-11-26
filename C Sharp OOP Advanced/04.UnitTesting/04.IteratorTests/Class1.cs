using _04.Iterator;
using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection;

namespace _04.IteratorTests
{
    public class Class1
    {
        private string[] input = new string[] { "iko", "tiko", "piko" };
        private ListIterator listIterator;

        [SetUp]
        public void InitiateListIterator()
        {
            listIterator = new ListIterator(input);
        }

        [Test]
        public void TestIteratorConstructor()
        {
            FieldInfo fieldInfo = typeof(ListIterator).GetField("strings", BindingFlags.NonPublic | BindingFlags.Instance);
            var actual = (List<string>)fieldInfo.GetValue(listIterator);
            Assert.AreEqual(input, actual);
        }

        [Test]
        public void TestMoveMethodCanMove()
        {
            Assert.That(() => listIterator.Move(), Is.True);
        }

        [Test]
        public void MoveMethodCanNotMove()
        {
            listIterator.Move();
            listIterator.Move();
            Assert.That(() => listIterator.Move(), Is.False);
        }

        [Test]
        public void HasNextShouldHasNext()
        {
            Assert.That(() => listIterator.HasNext(), Is.True);
        }

        [Test]
        public void HasNextShoudNotHasNext()
        {
            for (int i = 0; i < input.Length; i++)
            {
                listIterator.Move();
            }

            Assert.That(() => listIterator.HasNext(), Is.False);
        }

        [Test]
        public void PrintShouldThrowAnException()
        {
            var list = new ListIterator();
            Assert.That(() => list.Print(), Throws.InvalidOperationException);
        }
    }
}
