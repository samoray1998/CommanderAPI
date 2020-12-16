using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAppCommands()
        {
            var Commands=new List<Command>{
                new Command{Id=0,HowTo="how to boil an egg",Line="boil water",Platform="kettle & pen"},
                new Command{Id=1,HowTo="how to boil an egg",Line="boil water",Platform="kettle & pen"},
                new Command{Id=2,HowTo="how to boil an egg",Line="boil water",Platform="kettle & pen"},
                new Command{Id=3,HowTo="how to boil an egg",Line="boil water",Platform="kettle & pen"},
                new Command{Id=4,HowTo="how to boil an egg",Line="boil water",Platform="kettle & pen"},
            };
            return Commands;
        }
        public Command GetCommandById(int id)
        {
       return new Command{Id=0,HowTo="how to boil an egg",Line="boil water",Platform="kettle & pen"};

        }

        public bool SavaChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpDateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}