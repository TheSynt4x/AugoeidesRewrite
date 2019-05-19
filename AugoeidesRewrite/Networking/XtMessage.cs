using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugoeidesRewrite.Networking
{
    class XtMessage : Message
    {
        public string[] Arguments { get; set; }

        private SimpleTCP.Message _c;

        public XtMessage(string raw, SimpleTCP.Message c)
        {
            if (raw != null) {
                RawContent = raw;
                _c = c;
                
                if ((Arguments = raw.Split('%')).Length >= 4) {
                    Command = Arguments[2] == "zm"
                        ? (Arguments[3] == "cmd" ? Arguments[5] : Arguments[3])
                        : Arguments[2];
                }
            }
        }

        public void Write(string raw)
        {
            Console.WriteLine($"Sending: {raw}");
            _c.ReplyLine(raw);
        }

        public override string ToString()
        {
            return string.Join("%", Arguments);
        }
    }
}
