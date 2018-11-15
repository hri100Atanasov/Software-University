namespace _03BarracksFactory.Core
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // TODO: refactor for Problem 4
        private string InterpredCommand(string[] data, string commandName)
        {
            string result = string.Empty;

            Assembly assembly = Assembly.GetCallingAssembly();
            Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == commandName + "command");

            if (commandType == null || !typeof(IExecutable).IsAssignableFrom(commandType))
            {
                throw new ArgumentException("Invalid command!");
            }

            if (!typeof(IExecutable).IsAssignableFrom(commandType))
            {
                throw new ArgumentException($"{commandType} is not a valid command!");
            }

            object[] ctorArgs = new object[] { data, repository, unitFactory };
            object instance = Activator.CreateInstance(commandType, ctorArgs);
            MethodInfo method = typeof(IExecutable).GetMethods().First();
            try
            {
            result = (string)method.Invoke(instance, null);
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }

            //Replaced with reflection
            //switch (commandName)
            //{
            //    case "add":
            //        result = this.AddUnitCommand(data);
            //        break;
            //    case "report":
            //        result = this.ReportCommand(data);
            //        break;
            //    case "fight":
            //        Environment.Exit(0);
            //        break;
            //    default:
            //        throw new InvalidOperationException("Invalid command!");
            //}

            return result;
        }

        //Replaced with reflection
        //private string ReportCommand(string[] data)
        //{
        //    string output = this.repository.Statistics;
        //    return output;
        //}

        //Replaced with reflection
        //private string AddUnitCommand(string[] data)
        //{
        //    string unitType = data[1];
        //    IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
        //    this.repository.AddUnit(unitToAdd);
        //    string output = unitType + " added!";
        //    return output;
        //}
    }
}
