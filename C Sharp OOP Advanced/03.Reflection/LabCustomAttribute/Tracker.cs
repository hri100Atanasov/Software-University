using System.Reflection;


public class Tracker
{
    public static void PrintMethodsByAuthor()
    {
        var type = typeof(StartuUp);
        foreach (var method in type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public))
        {
            foreach (var attribute in method.GetCustomAttributes<SoftUniAttribute>())
            {
                System.Console.WriteLine(attribute.Name);
            }
        }
    }
}

