using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugoeidesRewrite.Networking.Handlers.Xml
{
    class HandlerPolicy : IXmlMessageHandler
    {
        public string[] HandledCommands { get; } = { "policy" };

        public void Handle(XmlMessage message)
        {
            message.Write("<cross-domain-policy><allow-access-from domain='*' to-ports='5588'/></cross-domain-policy>");
        }
    }
}
