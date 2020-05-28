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
    public partial class CurdForm : Form
    {
        private Common.DbHelper db = null;

        public CurdForm()
        {
            InitializeComponent();
            this.db = new Common.DbHelper();
        }

        private void CurdForm_Load(object sender, EventArgs e)
        {
            // load complte list
            FillEmployeesGrid();
        }

        private void FillEmployeesGrid()
        {
            using (var con = db.DbConnection)
            {
                db.OpenConnection(con);
                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM EMP;";

                var adapter = new SqlDataAdapter(cmd);
                var dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0)
                {
                    gvEmployees.DataSource = null;
                    gvEmployees.DataSource = dataSet.Tables[0];
                }
                db.CloseConnection(con);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            SearchEmployees();
        }

        private void SearchEmployees()
        {
            if (String.IsNullOrWhiteSpace(txtSearch.Text))
            {
                return;
            }
            // search by text and show data in grid
            using (var con = db.DbConnection)
            {
                db.OpenConnection(con);
                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM EMP WHERE EMPNO=" + txtSearch.Text.Trim();

                var adapter = new SqlDataAdapter(cmd);
                var dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0)
                {
                    gvEmployees.DataSource = null;
                    gvEmployees.DataSource = dataSet.Tables[0];
                }
                db.CloseConnection(con);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // will open a form to add new cord
            var addEditForm = new AddEditForm();
            addEditForm.AddNew();
            FillEmployeesGrid();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            FillEmployeesGrid();
        }

        private void gvEmployees_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //var editOrDelete = MessageBox.Show("Edit or Delete ?","",
            ShowEditForm(e.RowIndex);
        }

        private void ShowEditForm(int rowIndex)
        {
            var row = gvEmployees.Rows[rowIndex];
            var rowData = new Dictionary<string, object>();
            for (int i = 0; i < gvEmployees.ColumnCount; i++)
            {
                rowData.Add(gvEmployees.Columns[i].Name, row.Cells[i].Value);
            }
            var editForm = new AddEditForm();
            editForm.EditMe(rowData);
            FillEmployeesGrid();
        }

        private void gvEmployees_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            foreach (DataGridViewRow item in gvEmployees.Rows)
            {
                item.Selected = false;
            }
            gvEmployees.Rows[e.RowIndex].Selected = true;
            e.ContextMenuStrip.Tag = e.RowIndex;
        }

        private void menuDelete_Click(object sender, EventArgs e)
        {

        }

        private void menuEdit_Click(object sender, EventArgs e)
        {
            ShowEditForm(Convert.ToInt32(((ToolStripItem)sender).Owner.Tag));
        }
    }
}
