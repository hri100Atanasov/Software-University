using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Program
{
    static void Main(string[] args)
    {
        var classToExamine = Type.GetType("HarvestingFields");
        var command = string.Empty;
        IEnumerable<FieldInfo> fieldInfos = null;
        while ((command = Console.ReadLine()) != "HARVEST")
        {
            switch (command)
            {
                case "private":
                    fieldInfos = GetPrivateFields(classToExamine);
                    break;
                case "protected":
                    fieldInfos = GetProtectedFields(classToExamine);
                    break;
                case "public":
                    fieldInfos = GetPublicFields(classToExamine);
                    break;
                case "all":
                    fieldInfos = GetAllFields(classToExamine);
                    break;
            }

            foreach (var field in fieldInfos)
            {
                var accessModifier = field.IsPublic ? "public" : field.IsPrivate ? "private" : "protected";
                Console.WriteLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
            }
        }
    }

    private static IEnumerable<FieldInfo> GetAllFields(Type classToExamine)
    {
        return classToExamine.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
    }

    private static IEnumerable<FieldInfo> GetPrivateFields(Type classType)
    {
        return classType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(f => f.IsPrivate);
    }

    private static IEnumerable<FieldInfo> GetProtectedFields(Type classType)
    {
        return classType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(f => f.IsFamily);
    }

    private static IEnumerable<FieldInfo> GetPublicFields(Type classType)
    {
        return classType.GetFields();
    }
}

