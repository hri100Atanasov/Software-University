using _01._IntroductionToEntityFramework.Data;
using _01._IntroductionToEntityFramework.Data.Models;
using System;
using System.Linq;

namespace _04._AddNewAddresAndUpdateEmp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var address = new Address()
                {
                    AddressText = "Vitoshka 15",
                    TownId = 4
                };

                context.Addresses.Add(address);
                context.Employees.FirstOrDefault(e => e.LastName == "Nakov").Address = address;
                context.SaveChanges();

                context.Employees.OrderByDescending(e => e.Address.AddressId)
                    .Take(10)
                    .Select(e => e.Address.AddressText)
                    .ToList()
                    .ForEach(e => Console.WriteLine(e));
            }
        }
    }
}
