using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Core.IO.Contracts
{
   public interface IWriter
    {
        void WriteLine(string message);
    }
}
