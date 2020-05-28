using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdoNetExample.Common;

namespace AdoNetExample
{
    public partial class CrudForm : Form
    {
        public CrudForm()
        {
            InitializeComponent();
        }

        private void CrudForm_Load(object sender, EventArgs e)
        {
            FillEmployeeData();
        }

        private void FillEmployeeData()
        {
            var dataSet = DbHelper.GetDataSet("SELECT * FROM EMP;");
            dgvEmployeeList.DataSource = null;
            dgvEmployeeList.DataSource = dataSet.Tables[0];
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtSearch.Text))
            {
                return;
            }
            var dataSet = DbHelper.GetDataSet("SELECT * FROM EMP WHERE ENAME LIKE '%" + txtSearch.Text.Trim() + "%'");
            dgvEmployeeList.DataSource = null;
            dgvEmployeeList.DataSource = dataSet.Tables[0];
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            FillEmployeeData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddEditForm();
            addForm.AddNew();
            FillEmployeeData();
        }

        private void menuEdit_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvEmployeeList.Rows)
            {
                row.Selected = false;
            }
            var rowIndex = Convert.ToInt32(((ToolStripItem)sender).Owner.Tag);
            dgvEmployeeList.Rows[rowIndex].Selected = true;

            var selectedRow = dgvEmployeeList.Rows[rowIndex];
            var data = new Dictionary<String, Object>();
            foreach (DataGridViewColumn col in dgvEmployeeList.Columns)
            {
                data.Add(col.Name, selectedRow.Cells[col.Name].Value);
            }
            var addForm = new AddEditForm();
            addForm.EditMe(data);
            FillEmployeeData();
        }

        private void dgvEmployeeList_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            e.ContextMenuStrip.Tag = e.RowIndex;
        }

        private void menuDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvEmployeeList.Rows)
            {
                row.Selected = false;
            }
            var rowIndex = Convert.ToInt32(((ToolStripItem)sender).Owner.Tag);
            dgvEmployeeList.Rows[rowIndex].Selected = true;

            var selectedRow = dgvEmployeeList.Rows[rowIndex];
            var empno = Convert.ToInt32(selectedRow.Cells["EMPNO"].Value);

            var parameters = new Dictionary<String, Object>();
            parameters.Add("@EMPNO", empno);
            var sql = @"DELETE FROM [EMP] WHERE [EMPNO] = @EMPNO;";
            var effectedRows = DbHelper.ExecuteNonQuery(sql, parameters);
            if (effectedRows > 0)
            {
                MessageBox.Show("Record deleted successfully,", "Success", MessageBoxButtons.OK);
                FillEmployeeData();
            }
        }
    }
}
