using System;

public class Program
{
    static void Main(string[] args)
    {
        var spy = new Spy();

        //Gets the fields values.
        //var result = spy.StealFieldInfo("Hacker", "username", "password");
        //Console.WriteLine(result);

        //Analyzes the access modifiers.
        //var result = spy.AnalyzeAcessModifiers("Hacker");
        //Console.WriteLine(result);

        //Gets all the private methods
        //var result = spy.RevealPrivateMethods("Hacker");
        //Console.WriteLine(result);

        //Gets all getters and setters only.
        var result = spy.CollectGettersAndSetters("Hacker");
        Console.WriteLine(result);
    }
}

