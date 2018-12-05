using _01._IntroductionToEntityFramework.Data;
using System.IO;
using System.Linq;

namespace _01._IntroductionToEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                using (var sw = new StreamWriter("../Exercise.txt"))
                {
                    context.Employees.OrderBy(e => e.EmployeeId)
                         .Select(e => new { e.FirstName, e.MiddleName, e.LastName, e.JobTitle, e.Salary }).ToList()
                         .ForEach(e => sw.WriteLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}"));
                }
            }
        }
    }
}
