using Data;
using System;

namespace Hospital
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (var ctx = new HospitalContext())
            {
                DatabaseInitializer
            }
        }
    }
}
