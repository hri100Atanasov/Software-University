using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Core.IO.Contracts
{
    class ReadLIne : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
