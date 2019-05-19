using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AugoeidesRewrite.Networking;
using AugoeidesRewrite.Game;
using AugoeidesRewrite.Game.Data;

namespace AugoeidesRewrite.Networking.Handlers.Xt
{
    class HandlerFirstJoin : IXtMessageHandler
    {
        public string[] HandledCommands { get; } = { "firstJoin" };

        public void Handle(XtMessage message)
        {
            Cache.Instance.Maps.TryGetValue(1, out Maps map);

        }
    }
}
