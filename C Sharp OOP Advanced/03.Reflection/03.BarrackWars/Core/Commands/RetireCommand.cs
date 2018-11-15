using _03BarracksFactory.Contracts;
using System;

namespace _03.BarrackWars.Core.Commands
{
    class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            var unitType = Data[1];
                
            try
            {
                Repository.RemoveUnit(unitType);
                return $"{unitType} retired!";
            }
            catch(Exception e)
            {
                throw new ArgumentException("No such units in repository.", e);
            }

        }
    }
}
