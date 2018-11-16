using System;
using System.Linq;
using System.Reflection;


public class Program
{
    static void Main(string[] args)
    {
        Type type = Type.GetType("BlackBoxInteger");
        FieldInfo fieldInfo = type.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);
        MethodInfo[] methodInfos = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        object instance = Activator.CreateInstance(type, true);

        var command = string.Empty;
        while ((command = Console.ReadLine()) != "END")
        {
            var arguments = command.Split("_");
            var methodName = arguments[0];
            var value = int.Parse(arguments[1]);

            methodInfos.First(m => m.Name == methodName).Invoke(instance, new object[] { value });
            Console.WriteLine(fieldInfo.GetValue(instance));
        }
    }
}