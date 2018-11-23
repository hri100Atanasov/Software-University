using System;
using System.Linq;
using System.Reflection;

namespace _02.CustomLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = typeof(DynamicList<int>);
            var requiredFieldsNames = new string[] { "head", "tail", "count" };
            FieldInfo[] fieldInfos = type
                .GetFields(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance|BindingFlags.Public)
                .Where(fi => requiredFieldsNames.Contains(fi.Name)).ToArray();

            foreach (var field in fieldInfos)
            {
                Console.WriteLine(field.Name);
            }
        }
    }
}
