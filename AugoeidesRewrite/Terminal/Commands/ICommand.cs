using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugoeidesRewrite.Terminal.Commands
{
    interface ICommand
    {
        string HandledCommand { get; }
        void Handle(params object[] parameters);
    }
}
