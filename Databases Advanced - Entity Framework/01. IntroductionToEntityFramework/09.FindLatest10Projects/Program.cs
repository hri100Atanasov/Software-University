using _01._IntroductionToEntityFramework.Data;
using System;
using System.Globalization;
using System.Linq;

namespace _09.FindLatest10Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new SoftUniContext())
            {
                dbContext.Projects.OrderByDescending(p => p.StartDate).Take(10).OrderBy(p => p.Name).ToList()
                    .ForEach(p => Console
                    .WriteLine($"{p.Name}{Environment.NewLine}{p.Description}{Environment.NewLine}{p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}"));
            }
        }
    }
}
