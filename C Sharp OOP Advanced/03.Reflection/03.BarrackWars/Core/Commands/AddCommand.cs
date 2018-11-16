using _03BarracksFactory.Contracts;

namespace _03.BarrackWars.Core.Commands
{
    public class AddCommand : Command
    {
        [Inject]
        private IRepository repository;
        [Inject]
        private IUnitFactory unitFactory;

        public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data)
        {
            Repository = repository;
            UnitFactory = unitFactory;
        }

        public override string Execute()
        {
            string unitType = Data[1];
            IUnit unitToAdd = UnitFactory.CreateUnit(unitType);
            Repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }

        protected IRepository Repository
        {
            get { return repository; }
            private set { repository = value; }
        }

        protected IUnitFactory UnitFactory
        {
            get { return unitFactory; }
            private set { unitFactory = value; }
        }
    }
}
