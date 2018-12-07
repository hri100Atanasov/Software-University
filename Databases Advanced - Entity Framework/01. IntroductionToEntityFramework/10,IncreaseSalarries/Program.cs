using _01._IntroductionToEntityFramework.Data;
using System;
using System.Linq;

namespace _10_IncreaseSalarries
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new SoftUniContext())
            {
                string[] requiredDepartmentsArray = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

                dbContext.Employees.Where(e => requiredDepartmentsArray.Contains(e.Department.Name))
                      .ToList()
                      .ForEach(e => e.Salary *= 1.12m);
                dbContext.SaveChanges();

                dbContext.Employees
                    .Where(e => requiredDepartmentsArray.Contains(e.Department.Name))
                    .OrderBy(e=>e.FirstName)
                    .ThenBy(e=>e.LastName)
                    .ToList().ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})"));
            }
        }
    }
}
