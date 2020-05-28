using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetExample.Common
{
    public class DbHelper
    {
        private static string DbConnectionString
        {
            get
            {
                var connectionString = new SqlConnectionStringBuilder();
                connectionString.DataSource = "DESKTOP-OGMGVV9\\SQLEXPRESS";
                connectionString.InitialCatalog = "DbScott";
                connectionString.IntegratedSecurity = true;
                return connectionString.ToString();
            }
        }

        public static DataSet GetDataSet(string sql, Dictionary<String, Object> parameters = null)
        {
            var dataSet = new DataSet();
            using (var con = new SqlConnection(DbHelper.DbConnectionString))
            {
                con.Open();
                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                if (parameters != null && parameters.Count > 0)
                {
                    foreach (KeyValuePair<String,Object> item in parameters)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet);
                con.Close();
            }
            return dataSet;
        }

        public static int ExecuteNonQuery(string sql, Dictionary<String, Object> parameters = null)
        {
            var effectedRecords = -1;
            using (var con = new SqlConnection(DbHelper.DbConnectionString))
            {
                con.Open();
                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                if (parameters != null && parameters.Count > 0)
                {
                    foreach (KeyValuePair<String, Object> item in parameters)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }
                effectedRecords = cmd.ExecuteNonQuery();
                con.Close();
            }
            return effectedRecords;
        }
    }
}
