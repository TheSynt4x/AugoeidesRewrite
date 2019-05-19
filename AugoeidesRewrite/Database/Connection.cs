using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugoeidesRewrite.Database
{
    class Connection
    {
        public MySqlConnection MySqlConnection { get; }

        public Connection()
        {
            MySqlConnection = new MySqlConnection(
                new ConnectionBuilder()
                {
                    ServerName = "127.0.0.1",
                    Username = "root",
                    Database = "meh"
                }.ToString()
            );

            MySqlConnection.Open();
        }
    }
}
