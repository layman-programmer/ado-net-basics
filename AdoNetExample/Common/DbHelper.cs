using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace AdoNetExample.Common
{
    public class DbHelper
    {
        public SqlConnection DbConnection
        {
            get
            {
                var connectionString = new SqlConnectionStringBuilder();
                connectionString.DataSource = "DESKTOP-OGMGVV9\\SQLEXPRESS";
                connectionString.InitialCatalog = "DbScott";
                connectionString.IntegratedSecurity = true;
                return new SqlConnection(connectionString.ToString());
            }
        }

        public void OpenConnection(SqlConnection con)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void CloseConnection(SqlConnection con)
        {
            if (con.State != System.Data.ConnectionState.Closed)
            {
                con.Close();
            }
        }
    }
}
