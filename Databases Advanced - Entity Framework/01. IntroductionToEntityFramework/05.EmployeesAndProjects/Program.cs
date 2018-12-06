using _01._IntroductionToEntityFramework.Data;
using System;
using System.Linq;

namespace _05.EmployeesAndProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new SoftUniContext())
            {
                dbContext.Employees
                    .Where(e => e.EmployeesProjects
                        .Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                    .Take(30)
                    .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        ManagerFirstName = e.Manager.FirstName,
                        ManagerLastName = e.Manager.LastName,
                        Projects = e.EmployeesProjects
                            .Select(ep => ep.Project)
                    })
                    .ToList()
                    .ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}{Environment.NewLine}" +
                    $"{String.Join(Environment.NewLine, e.Projects.Select(p => $"--{p.Name} - {p.StartDate.ToString()} - {(p.EndDate == null ? "not finished" : p.EndDate.ToString())}"))}"));
            }
        }
    }
}