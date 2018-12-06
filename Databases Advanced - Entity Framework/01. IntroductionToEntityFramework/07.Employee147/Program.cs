using _01._IntroductionToEntityFramework.Data;
using System;
using System.Linq;

namespace _07.Employee147
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new SoftUniContext())
            {
                var emp = dbContext.Employees.Single(e => e.EmployeeId == 147);
                Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                var projList = dbContext.EmployeesProjects.Where(p => p.EmployeeId == 147)
                    .OrderBy(p=>p.Project.Name)
                    .Select(p=>p.Project.Name)
                    .ToList();
                foreach (var proj in projList)
                {
                    Console.WriteLine(proj);
                }
            }
        }
    }
}
