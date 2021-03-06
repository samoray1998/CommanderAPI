using System.Collections.Generic;
using System.Linq;
using Commander.Models;
using System;

namespace Commander.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepo(CommanderContext context)
        {
            _context=context;
        }

        public void CreateCommand(Command cmd)
        {
            if (cmd==null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
                _context.commands.Add(cmd);
            
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd==null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
                _context.commands.Remove(cmd);
        }

        public IEnumerable<Command> GetAppCommands()
        {
            return _context.commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.commands.FirstOrDefault(x=>x.Id==id);
        }

        public bool SavaChanges()
        {
           return (_context.SaveChanges()>=0);
        }

        public void UpDateCommand(Command cmd)
        {
            //Nothing ....
        }
    }
}