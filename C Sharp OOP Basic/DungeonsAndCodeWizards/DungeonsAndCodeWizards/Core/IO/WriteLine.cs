using DungeonsAndCodeWizards.Core.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Core.IO
{
    class WriteLine : IWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
