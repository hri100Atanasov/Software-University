using _01._IntroductionToEntityFramework.Data;
using System.Linq;

namespace _08.DepartmentsWithMoreThan5Emp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new SoftUniContext())
            {
                var departments = dbContext.Departments.Where(e => e.Employees.Count() > 5)
                      .Select(d => new
                      {
                          DepartmentName = d.Name,
                          ManagerFirstName = d.Manager.FirstName,
                          ManagerLastName = d.Manager.LastName,
                          Emps = d.Employees.Select(e => new
                          {
                              e.FirstName,
                              e.LastName,
                              e.JobTitle
                          })
                          .OrderBy(e => e.FirstName)
                          .ThenBy(e => e.LastName)
                      })
                      .OrderBy(e => e.Emps.Count()).ThenBy(di => di.DepartmentName)
                  .ToList();

                foreach (var department in departments)
                {
                    System.Console.WriteLine($"{department.DepartmentName} - {department.ManagerFirstName} {department.ManagerLastName}");

                    foreach (var employee in department.Emps)
                    {
                        System.Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                    }

                    System.Console.WriteLine(new string('-', 10));
                }
            }
        }
    }
}
