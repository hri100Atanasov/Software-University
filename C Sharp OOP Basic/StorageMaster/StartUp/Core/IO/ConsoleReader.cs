using StorageMaster.Core.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Core.IO
{
   public class ConsoleReader : IReader
    {
        public string ReadLine()
        {

            return Console.ReadLine();
        }
    }
}
