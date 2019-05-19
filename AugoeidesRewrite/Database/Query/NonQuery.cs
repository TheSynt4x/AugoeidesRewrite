using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugoeidesRewrite.Database.Query
{
    class NonQuery
    {
        private MySqlCommand cmd;

        public int Execute(string sql, Dictionary<string, object> parameters = null)
        {
            if (parameters == null)
                parameters = new Dictionary<string, object>();

            Connection con = new Connection();

            cmd = new MySqlCommand(sql, con.MySqlConnection);

            foreach (var parameter in parameters) {
                cmd.Parameters.AddWithValue($"@{parameter.Key}", parameter.Value);
            }

            cmd.Prepare();
            
            return cmd.ExecuteNonQuery();
        }
    }
}
