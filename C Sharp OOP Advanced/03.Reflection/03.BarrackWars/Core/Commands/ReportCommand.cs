using _03BarracksFactory.Contracts;

namespace _03.BarrackWars.Core.Commands
{
    public class ReportCommand : Command
    {
        [Inject]
        private IRepository repository;
        public ReportCommand(string[] data, IRepository repository) : base(data)
        {
            Repository = repository;
        }

        public IRepository Repository
        {
            get { return repository; }
            set { repository = value; }
        }

        public override string Execute()
        {
            string output = Repository.Statistics;
            return output;
        }
    }
}
