using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace AdoNetExample
{
    public partial class AddEditForm : Form
    {
        private Common.DbHelper db = null;
        private bool isEditMode = false;

        public AddEditForm()
        {
            InitializeComponent();
            this.db = new Common.DbHelper();
        }

        private void AddEditForm_Load(object sender, EventArgs e)
        {

        }

        public void AddNew()
        {
            FillMgrDll();
            FillDeptDll();
            this.ShowDialog();
        }

        public void EditMe(Dictionary<string, object> data)
        {
            FillMgrDll();
            FillDeptDll();
            this.isEditMode = true;
            // populate data
            txtComm.Text = Convert.ToString(data["COMM"]);
            txtEmpNo.Text = Convert.ToString(data["EMPNO"]);
            txtEname.Text = Convert.ToString(data["ENAME"]);
            txtJob.Text = Convert.ToString(data["JOB"]);
            txtSal.Text = Convert.ToString(data["SAL"]);
            dtpHireDate.Value = Convert.ToDateTime(data["HIREDATE"]);
            cbDept.SelectedValue = (data["DEPTNO"] != DBNull.Value ? Convert.ToInt32(data["DEPTNO"]) : -1);
            cbMgr.SelectedValue = (data["MGR"] != DBNull.Value ? Convert.ToInt32(data["MGR"]) : -1);
            txtEmpNo.ReadOnly = true;
            this.ShowDialog();
        }

        private void FillMgrDll()
        {
            using (var con = db.DbConnection)
            {
                db.OpenConnection(con);
                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM EMP;";
                using (var reader = cmd.ExecuteReader())
                {
                    var items = new ArrayList();
                    items.Add(new { Text = "Empty", Value = -1 });
                    while (reader.Read())
                    {
                        var text = String.Format("#{0}-{1}",
                            Convert.ToInt32(reader["EMPNO"]),
                            Convert.ToString(reader["ENAME"]));
                        items.Add(new { Text = text, Value = Convert.ToInt32(reader["EMPNO"]) });
                    }
                    cbMgr.DataSource = null;
                    cbMgr.DataSource = items;
                    cbMgr.DisplayMember = "Text";
                    cbMgr.ValueMember = "Value";
                }
                db.CloseConnection(con);
            }
        }

        private void FillDeptDll()
        {
            using (var con = db.DbConnection)
            {
                db.OpenConnection(con);
                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM DEPT;";
                using (var reader = cmd.ExecuteReader())
                {
                    var items = new ArrayList();
                    items.Add(new { Text = "Empty", Value = -1 });
                    while (reader.Read())
                    {
                        var text = String.Format("#{0}-{1}",
                            Convert.ToInt32(reader["DEPTNO"]),
                            Convert.ToString(reader["DNAME"]));
                        items.Add(new { Text = text, Value = Convert.ToInt32(reader["DEPTNO"]) });
                    }
                    cbDept.DataSource = null;
                    cbDept.DataSource = items;
                    cbDept.DisplayMember = "Text";
                    cbDept.ValueMember = "Value";
                }
                db.CloseConnection(con);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var isValid = ValidateForm();
            if (isValid)
            {
                using (var con = db.DbConnection)
                {
                    db.OpenConnection(con);
                    var cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    if (this.isEditMode)
                    {
                        cmd.CommandText = @"UPDATE [EMP]
                                           SET [ENAME] = @ENAME
                                              ,[JOB] = @JOB
                                              ,[MGR] = @MGR
                                              ,[HIREDATE] = @HIREDATE
                                              ,[SAL] = @SAL
                                              ,[COMM] = @COMM
                                              ,[DEPTNO] = @DEPTNO
                                         WHERE [EMPNO] = @EMPNO";
                    }
                    else
                    {
                        cmd.CommandText = @"INSERT INTO [EMP]([EMPNO],[ENAME],[JOB],[MGR],[HIREDATE],[SAL],[COMM],[DEPTNO])
                                        VALUES(@EMPNO,@ENAME,@JOB,@MGR,@HIREDATE,@SAL,@COMM,@DEPTNO)";
                    }
                    cmd.Parameters.AddWithValue("@EMPNO", txtEmpNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@ENAME", txtEname.Text.Trim());
                    cmd.Parameters.AddWithValue("@JOB", txtJob.Text.Trim());
                    cmd.Parameters.AddWithValue("@MGR", cbMgr.SelectedValue);
                    cmd.Parameters.AddWithValue("@HIREDATE", dtpHireDate.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@SAL", txtSal.Text.Trim());
                    cmd.Parameters.AddWithValue("@COMM", txtComm.Text.Trim());
                    cmd.Parameters.AddWithValue("@DEPTNO", cbDept.SelectedValue);
                    if (String.IsNullOrWhiteSpace(txtComm.Text.Trim()))
                    {
                        cmd.Parameters["@COMM"].Value = DBNull.Value;
                    }
                    if (String.IsNullOrWhiteSpace(txtSal.Text.Trim()))
                    {
                        cmd.Parameters["@SAL"].Value = DBNull.Value;
                    }
                    var effectedRows = cmd.ExecuteNonQuery();
                    db.CloseConnection(con);
                    if (effectedRows > 0)
                    {
                        DialogResult dialog = MessageBox.Show("Record saved successfully,", "Success", MessageBoxButtons.OK);
                        if (dialog == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                }
            }
        }

        private bool ValidateForm()
        {
            return true;
        }
    }
}
