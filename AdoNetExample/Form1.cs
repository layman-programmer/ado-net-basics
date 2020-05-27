using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdoNetExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnShowEmpData_Click(object sender, EventArgs e)
        {
            var connectionString = new SqlConnectionStringBuilder();
            connectionString.DataSource = "DESKTOP-OGMGVV9\\SQLEXPRESS";
            connectionString.InitialCatalog = "DbScott";
            connectionString.IntegratedSecurity = true;
            using (var con = new SqlConnection(connectionString.ToString())) // 1) get the connection
            {
                con.Open(); // 2) open the connection
                var cmd = new SqlCommand(); // 3) prepare the command
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM EMP;";

                using (var reader = cmd.ExecuteReader()) // 4) execute the command
                {
                    this.ShowData(reader);
                    con.Close(); // 5) close the connection
                }
            }
        }

        private void ShowData(SqlDataReader reader)
        {
            lbEmpData.Items.Clear();
            while (reader.Read())
            {
                var item = String.Format("#{0} - {1}",
                    Convert.ToInt32(reader["EMPNO"]),
                    Convert.ToString(reader["ENAME"]));
                lbEmpData.Items.Add(item);
            }
        }
    }
}
