using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugoeidesRewrite.Terminal.Commands
{
    class CommandChangeLL : ICommand
    {
        public string HandledCommand { get; } = "cloglevel";

        public void Handle(params object[] parameters)
        {
            Console.WriteLine("stop servur");
        }
    }
}
