using DungeonsAndCodeWizards.Core;
using DungeonsAndCodeWizards.Core.IO;
using DungeonsAndCodeWizards.Core.IO.Contracts;
using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Entities.Enums;
using DungeonsAndCodeWizards.Entities.Factories;
using DungeonsAndCodeWizards.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ReadLIne();
            IWriter writer = new WriteLine();
            var engihe = new Engine(reader, writer);
            engihe.Run();
        }
    }
}
