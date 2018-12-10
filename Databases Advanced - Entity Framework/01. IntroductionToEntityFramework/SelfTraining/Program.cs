using _01._IntroductionToEntityFramework.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SelfTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new SoftUniContext())
            {
                using (var ctx = new SoftUniContext())
                {
                    var nameStartingWithJo = ctx.Employees.Like
                }
            }
        }
    }
}
