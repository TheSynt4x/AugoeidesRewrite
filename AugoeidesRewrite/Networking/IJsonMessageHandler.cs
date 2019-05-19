using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugoeidesRewrite.Networking
{
    interface IJsonMessageHandler
    {
        string[] HandledCommands { get; }
        void Handle(JsonMessage message);
    }
}
