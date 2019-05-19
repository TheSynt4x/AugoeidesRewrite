using AugoeidesRewrite.Misc;
using AugoeidesRewrite.Terminal.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugoeidesRewrite.Terminal
{
    class Terminal
    {
        private List<ICommand> _commands = new List<ICommand>()
        {
            new CommandStart(),
            new CommandStop(),
            new CommandChangeLL()
        };
        
        public Terminal()
        {
            string command = "";
             
            while (command != "quit") {
                command = ConsoleInput.Get<string>("Enter a command: ");

                foreach (var cmd in _commands.Where(x => x.HandledCommand.Contains(command))) {
                    cmd.Handle(command.Split(' '));
                }
            }
        }
    }
}
