using StorageMaster.Core;
using StorageMaster.Core.IO;
using StorageMaster.Core.IO.Contracts;

namespace StorageMaster
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();

            var engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
