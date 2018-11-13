using System;
using System.Linq;
using System.Reflection;
using System.Text;


public class Spy
{
    public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
    {
        var sb = new StringBuilder($"Class under investigation: {classToInvestigate}" + Environment.NewLine);
        var fields = Type.GetType(classToInvestigate).GetFields(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance);
        var classInctance = Activator.CreateInstance(Type.GetType(classToInvestigate));
        foreach (var field in fields)
        {
            if (fieldsToInvestigate.Contains(field.Name))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInctance)}");
            }
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        var sb = new StringBuilder();
        var type = Type.GetType(className);
        foreach (var field in type.GetFields())
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (var property in properties)
        {
            if (property.GetMethod?.IsPrivate == true)
            {
                sb.AppendLine($"{property.GetMethod.Name} have to be public!");
            }
        }

        foreach (var property in properties)
        {
            if (property.SetMethod?.IsPublic == true)
            {
                sb.AppendLine($"{property.SetMethod.Name} have to be private!");
            }
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        var sb = new StringBuilder();
        var type = Type.GetType(className);
        var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {type.BaseType.Name}");

        foreach (var method in methods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().Trim();
    }
}

