using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace _03.BarrackWars.Core.Commands
{
    public class AddCommand : Command
    {
        public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitType = Data[1];
            IUnit unitToAdd = UnitFactory.CreateUnit(unitType);
            Repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
