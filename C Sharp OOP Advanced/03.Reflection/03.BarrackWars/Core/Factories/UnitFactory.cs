namespace _03BarracksFactory.Core.Factories
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type model = assembly.GetTypes().First(t => t.Name == unitType);

            if (model == null)
            {
                throw new ArgumentException("Invalid unit type!");
            }

            if (!typeof(IUnit).IsAssignableFrom(model))
            {
                throw new ArgumentException($"{unitType} is not a valid unit type");
            }

            IUnit unit = (IUnit)Activator.CreateInstance(model, true);

            return unit;
        }
    }
}
