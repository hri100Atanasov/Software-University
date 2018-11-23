using _02.CustomLinkedList;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace _02.CustomLinkedListTests
{
    public class Class1
    {
        private DynamicList<int> dl;

        [SetUp]
        public void DynamicListInit()
        {
            dl = new DynamicList<int>();
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.AreNotSame(null, dl);
        }

        [Test]
        public void ConstructorSetsFieldsTest()
        {
            var type = typeof(DynamicList<int>);
            var requiredFieldsNames = new string[] { "head", "tail", "count" };

           var fieldInfos = type
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance|BindingFlags.NonPublic)
                .Where(fi => requiredFieldsNames.Contains(fi.Name)).ToArray();

            
                Assert.AreEqual(ListNode, field);
            

            var expected = fieldInfos.First(f => f.Name == "count");
            Assert.AreEqual(expected, 0);
        }
    }
}
