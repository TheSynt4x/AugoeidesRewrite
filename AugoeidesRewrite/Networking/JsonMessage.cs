using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugoeidesRewrite.Networking
{
    class JsonMessage : Message
    {
        public JToken Object { get; }

        public JToken DataObject => Object?["b"]?["o"];

        private SimpleTCP.Message _c;

        public JsonMessage(string raw, SimpleTCP.Message c)
        {
            try {
                _c = c;
                RawContent = raw;
                Object = JObject.Parse(raw);
                Command = DataObject?["cmd"]?.Value<string>();
            } catch (JsonReaderException) {

            }
        }

        public void Write(string raw)
        {
            Console.WriteLine($"Sending: {raw}");
            _c.ReplyLine(raw);
        }

        public override string ToString()
        {
            return Object.ToString(Formatting.None);
        }
    }
}
