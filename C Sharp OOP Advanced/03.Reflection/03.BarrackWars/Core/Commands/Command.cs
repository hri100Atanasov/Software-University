using _03BarracksFactory.Contracts;

namespace _03.BarrackWars.Core.Commands
{
    public abstract class Command : IExecutable
    {
        private string[] data;

        public Command(string[] data)
        {
            Data = data;
        }

        public abstract string Execute();

        protected string[] Data
        {
            get { return data; }
            private set { data = value; }
        }
    }
}
