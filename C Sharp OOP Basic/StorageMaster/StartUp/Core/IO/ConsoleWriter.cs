using StorageMaster.Core.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Core.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
