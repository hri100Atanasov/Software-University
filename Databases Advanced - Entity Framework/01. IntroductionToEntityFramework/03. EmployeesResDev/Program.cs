using _01._IntroductionToEntityFramework.Data;
using System.IO;
using System.Linq;

namespace _03._EmployeesResDev
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                using (var sw = new StreamWriter("../../SoftUni.txt"))
                {
                    context.Employees.Where(e => e.Department.Name == "Research and Development")
                        .OrderBy(e => e.Salary)
                        .ThenByDescending(e => e.FirstName)
                        .Select(e => new { e.FirstName, e.LastName, departmentName = e.Department.Name, e.Salary })
                        .ToList()
                        .ForEach(e => sw.WriteLine($"{e.FirstName} {e.LastName} from {e.departmentName} - ${e.Salary:f2}"));
                }
            }
        }
    }
}
