using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AugoeidesRewrite.Networking
{
    class XmlMessage : Message
    {
        public XmlDocument Body { get; }

        private SimpleTCP.Message _c;

        public XmlMessage(string raw, SimpleTCP.Message c)
        {
            try {
                RawContent = raw;
                _c = c;
                Body = new XmlDocument();
                Body.LoadXml(raw);
                Command = raw.Contains("policy-file-request")
                    ? "policy"
                    : Body.DocumentElement?["body"]?.Attributes["action"]?.Value;
            } catch (XmlException) {

            }
        }

        public void Write(string raw)
        {
            Console.WriteLine($"Sending: {raw}");
            _c.ReplyLine(raw);
        }

        public override string ToString()
        {
            return Body.OuterXml;
        }
    }
}
