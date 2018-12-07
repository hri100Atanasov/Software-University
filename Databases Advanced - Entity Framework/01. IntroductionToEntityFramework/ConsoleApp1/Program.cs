using _01._IntroductionToEntityFramework.Data;
using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new SoftUniContext())
            {
                var project = dbContext.Projects.Find(2);
                dbContext.EmployeesProjects.Where(ep => ep.ProjectId == 2).ToList().ForEach(ep => dbContext.EmployeesProjects.Remove(ep));
                dbContext.Remove(project);
                dbContext.SaveChanges();

                dbContext.Projects.Take(10).ToList().ForEach(p => Console.WriteLine($"{p.Name}"));
            }
        }
    }
}
