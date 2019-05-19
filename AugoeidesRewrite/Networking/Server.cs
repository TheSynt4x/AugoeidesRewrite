using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using AugoeidesRewrite.Networking.Handlers;
using AugoeidesRewrite.Networking.Handlers.Xml;
using AugoeidesRewrite.Networking.Handlers.Xt;
using AugoeidesRewrite.Game;

namespace AugoeidesRewrite.Networking
{
    class Server
    {
        private SimpleTcpServer _server;

        private List<TcpClient> _clients = new List<TcpClient>();

        private List<IJsonMessageHandler> _handlersJson = new List<IJsonMessageHandler>()
        {

        };

        private List<IXmlMessageHandler> _handlersXml = new List<IXmlMessageHandler>()
        {
            new HandlerPolicy(),
            new HandlerVersionCheck(),
            new HandlerLoginRequest()
        };

        private List<IXtMessageHandler> _handlersXt = new List<IXtMessageHandler>()
        {
            new HandlerFirstJoin()
        };

        public Server()
        {
            _server = new SimpleTcpServer().Start(5588);

            _server.StringEncoder = Encoding.UTF8;

            _server.ClientConnected += OnClientConnected;
            _server.ClientDisconnected += OnClientDisconnected;

            _server.Delimiter = 0x00;
            _server.DelimiterDataReceived += DelimiterDataReceived;

            Console.WriteLine("Server started on port 5588.");

            Cache.Instance.Initialize();
        }

        private void OnClientConnected(object sender, TcpClient e)
        {
            _clients.Add(e);

            Console.WriteLine("Client " + ((IPEndPoint)e.Client.RemoteEndPoint).Address.ToString() + " has been connected.");
        }

        private void OnClientDisconnected(object sender, TcpClient e)
        {
            _clients.Add(e);

            Console.WriteLine("Client " + ((IPEndPoint)e.Client.RemoteEndPoint).Address.ToString() + " has been disconnected.");
        }

        private void DelimiterDataReceived(object sender, SimpleTCP.Message e)
        {
            Console.WriteLine($"Received: {e.MessageString}");

            ProcessMessage(CreateMessage(e.MessageString, e));
        }

        private void ProcessMessage(Message message)
        {
            try {
                switch (message) {
                    case JsonMessage msgJson:
                        foreach (IJsonMessageHandler handler in _handlersJson.Where(h => h.HandledCommands.Contains(msgJson.Command)))
                            handler.Handle(msgJson);
                        break;
                    case XmlMessage msgXml:
                        foreach (IXmlMessageHandler handler in _handlersXml.Where(h => h.HandledCommands.Contains(msgXml.Command)))
                            handler.Handle(msgXml);
                        break;
                    case XtMessage msgXt:
                        foreach (IXtMessageHandler handler in _handlersXt.Where(h => h.HandledCommands.Contains(msgXt.Command)))
                            handler.Handle(msgXt);
                        break;
                }
            } catch {
            }
        }

        private Message CreateMessage(string raw, SimpleTCP.Message m)
        {
            if (raw?.Length > 0) {
                switch (raw[0]) {
                    case '<': return new XmlMessage(raw, m);
                    case '%': return new XtMessage(raw, m);
                    case '{': return new JsonMessage(raw, m); 
                }
            }

            return null;
        }
    }
}
