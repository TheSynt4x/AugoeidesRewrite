using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugoeidesRewrite.Terminal.Commands
{
    class CommandStart : ICommand
    {
        public string HandledCommand { get; } = "start";

        public void Handle(params object[] parameters)
        {
            Console.WriteLine("big xd");
        }
    }
}
