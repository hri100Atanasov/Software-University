using _01._IntroductionToEntityFramework.Data;
using System;
using System.Globalization;
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
                    $"{string.Join(Environment.NewLine, e.Projects.Select(p => $"--{p.Name} - {GetDate(p.StartDate)} - {(p.EndDate == null ? "not finished" : GetDate(p.EndDate))}"))}"));
            }
        }

        static string GetDate(DateTime? date)
        {
            if (date is null)
            {
                return "not finished";
            }
            DateTime result = (DateTime)date;
            return result.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
        }
    }
}