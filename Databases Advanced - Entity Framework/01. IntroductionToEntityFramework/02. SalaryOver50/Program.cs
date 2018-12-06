using _01._IntroductionToEntityFramework.Data;
using System.IO;
using System.Linq;

namespace _02._SalaryOver50
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                using (var sw = new StreamWriter("../SoftUni.txt"))
                {
                    context.Employees
                        .Where(e => e.Salary > 50000)
                        .OrderBy(e => e.FirstName)
                        .Select(e => new { e.FirstName })
                        .ToList()
                        .ForEach(e => sw.WriteLine(e.FirstName));
                }
            }
        }
    }
}