using _01._IntroductionToEntityFramework.Data;
using System.Linq;

namespace _06.AddressesByTown
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new SoftUniContext())
            {
                dbContext.Addresses
                    .OrderByDescending(a => a.Employees.Count())
                    .ThenBy(a => a.Town.Name)
                    .ThenBy(a => a.AddressText)
                    .Select(result => new
                    {
                        addressText = result.AddressText,
                        townName = result.Town.Name,
                        employeeCount = result.Employees.Count
                    })
                    .Take(10)
                    .ToList()
                    .ForEach(a => System.Console.WriteLine($"{a.addressText}, {a.townName} - {a.employeeCount} employees"));
            }
        }
    }
}
