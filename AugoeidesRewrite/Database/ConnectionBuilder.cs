using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugoeidesRewrite.Database
{
    class ConnectionBuilder
    {
        public string ServerName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } = "";
        public string Database { get; set; }

        public override string ToString()
        {
            return $"server={ServerName};database={Database};uid={Username};password={Password}";
        }
    }
}
