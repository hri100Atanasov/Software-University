using System;

namespace _06.CustomClassAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            var attributes = typeof(Weapon).GetCustomAttributes(false);

            foreach (var attribute in attributes)
            {
                var currAttr = attribute as CustomClassAttribute;

                while (true)
                {
                    var input = Console.ReadLine();
                    if (input == "END")
                    {
                        break;
                    }

                    switch (input)
                    {
                        case "Author":
                            Console.WriteLine($"Author: {currAttr.Author}");
                            break;
                        case "Revision":
                            Console.WriteLine($"Revision: {currAttr.Revision}");
                            break;
                        case "Description":
                            Console.WriteLine($"Class description: {currAttr.Description}");
                            break;
                        case "Reviewers":
                            Console.WriteLine($"Reviewers: {string.Join(", ", currAttr.Reviewers)}");
                            break;
                    }
                }
            }
        }
    }
}
