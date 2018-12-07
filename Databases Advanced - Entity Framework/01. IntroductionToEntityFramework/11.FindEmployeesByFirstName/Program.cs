using _01._IntroductionToEntityFramework.Data;
using System;
using System.Linq;

namespace _11.FindEmployeesByFirstName
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new SoftUniContext())
            {
                dbContext.Employees.Where(e => e.FirstName.StartsWith("Sa")).OrderBy(e => e.FirstName).ThenBy(e => e.LastName).ToList()
                    .ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})"));
            }
        }
    }
}
