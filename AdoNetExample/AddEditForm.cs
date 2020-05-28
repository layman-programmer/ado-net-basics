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
using AdoNetExample.Common;

namespace AdoNetExample
{
    public partial class AddEditForm : Form
    {
        private bool isEditing = false;

        public AddEditForm()
        {
            InitializeComponent();
        }

        public void EditMe(Dictionary<String, Object> data)
        {
            FillMgr();
            FillDept();
            isEditing = true;
            txtEmpNo.ReadOnly = true;
            txtComm.Text = Convert.ToString(data["COMM"]);
            txtEmpNo.Text = Convert.ToString(data["EMPNO"]);
            txtEname.Text = Convert.ToString(data["ENAME"]);
            txtJob.Text = Convert.ToString(data["JOB"]);
            txtSal.Text = Convert.ToString(data["SAL"]);
            dtpHireDate.Value = Convert.ToDateTime(data["HIREDATE"]);
            if (data["DEPTNO"] != DBNull.Value)
            {
                cbDept.SelectedValue = Convert.ToInt32(data["DEPTNO"]);
            }
            if (data["MGR"] != DBNull.Value)
            {
                cbMgr.SelectedValue = Convert.ToInt32(data["MGR"]);
            }
            ShowDialog();
        }

        public void AddNew()
        {
            FillMgr();
            FillDept();
            ShowDialog();
        }

        private void AddEditForm_Load(object sender, EventArgs e)
        {

        }

        private void FillMgr()
        {
            var dataSet = DbHelper.GetDataSet("SELECT * FROM EMP;");
            var dt = dataSet.Tables[0];
            var emptyRow = dt.NewRow();
            emptyRow["ENAME"] = "--EMPTY--";
            emptyRow["EMPNO"] = "-1";
            dt.Rows.InsertAt(emptyRow, 0);
            cbMgr.DisplayMember = "ENAME";
            cbMgr.ValueMember = "EMPNO";
            cbMgr.DataSource = null;
            cbMgr.DataSource = dt.DefaultView;
        }

        private void FillDept()
        {
            var dataSet = DbHelper.GetDataSet("SELECT * FROM DEPT;");
            var dt = dataSet.Tables[0];
            var emptyRow = dt.NewRow();
            emptyRow["DNAME"] = "--EMPTY--";
            emptyRow["DEPTNO"] = "-1";
            dt.Rows.InsertAt(emptyRow, 0);
            cbDept.DisplayMember = "DNAME";
            cbDept.ValueMember = "DEPTNO";
            cbDept.DataSource = null;
            cbDept.DataSource = dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var parameters = new Dictionary<String, Object>();
            parameters.Add("@EMPNO", txtEmpNo.Text.Trim());
            parameters.Add("@ENAME", txtEname.Text.Trim());
            parameters.Add("@JOB", txtJob.Text.Trim());
            parameters.Add("@MGR", cbMgr.SelectedValue);
            parameters.Add("@HIREDATE", dtpHireDate.Value.ToString("yyyy-MM-dd"));
            parameters.Add("@SAL", txtSal.Text.Trim());
            parameters.Add("@COMM", txtComm.Text.Trim());
            parameters.Add("@DEPTNO", cbDept.SelectedValue);
            if (String.IsNullOrWhiteSpace(txtComm.Text.Trim()))
            {
                parameters["@COMM"] = DBNull.Value;
            }
            if (String.IsNullOrWhiteSpace(txtSal.Text.Trim()))
            {
                parameters["@SAL"] = DBNull.Value;
            }
            var sql = @"INSERT INTO [EMP]([EMPNO],[ENAME],[JOB],[MGR],[HIREDATE],[SAL],[COMM],[DEPTNO])
                                        VALUES(@EMPNO,@ENAME,@JOB,@MGR,@HIREDATE,@SAL,@COMM,@DEPTNO)";
            if (isEditing)
            {
                sql = @"UPDATE [EMP]
                                           SET [ENAME] = @ENAME
                                              ,[JOB] = @JOB
                                              ,[MGR] = @MGR
                                              ,[HIREDATE] = @HIREDATE
                                              ,[SAL] = @SAL
                                              ,[COMM] = @COMM
                                              ,[DEPTNO] = @DEPTNO
                                         WHERE [EMPNO] = @EMPNO";
            }
            var effectedRows = DbHelper.ExecuteNonQuery(sql, parameters);
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
