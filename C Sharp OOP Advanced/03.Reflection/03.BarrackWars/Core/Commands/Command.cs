using _03BarracksFactory.Contracts;
using System;

namespace _03.BarrackWars.Core.Commands
{
    public abstract class Command : IExecutable
    {
        private string[] data;
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Command(string[] data, IRepository repository, IUnitFactory unitFactory)
        {
            Data = data;
            Repository = repository;
            UnitFactory = unitFactory;
        }

        public abstract string Execute();

        protected string[] Data
        {
            get { return data; }
            private set { data = value; }
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
