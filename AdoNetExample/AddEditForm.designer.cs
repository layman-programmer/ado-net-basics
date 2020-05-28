namespace AdoNetExample
{
    partial class AddEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.txtEname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtJob = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMgr = new System.Windows.Forms.ComboBox();
            this.txtSal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpHireDate = new System.Windows.Forms.DateTimePicker();
            this.txtComm = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbDept = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "EMPNO";
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.Location = new System.Drawing.Point(15, 25);
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.Size = new System.Drawing.Size(130, 20);
            this.txtEmpNo.TabIndex = 1;
            // 
            // txtEname
            // 
            this.txtEname.Location = new System.Drawing.Point(176, 25);
            this.txtEname.Name = "txtEname";
            this.txtEname.Size = new System.Drawing.Size(208, 20);
            this.txtEname.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ENAME";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "MGR";
            // 
            // txtJob
            // 
            this.txtJob.Location = new System.Drawing.Point(15, 73);
            this.txtJob.Name = "txtJob";
            this.txtJob.Size = new System.Drawing.Size(130, 20);
            this.txtJob.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "JOB";
            // 
            // cbMgr
            // 
            this.cbMgr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMgr.FormattingEnabled = true;
            this.cbMgr.Location = new System.Drawing.Point(176, 73);
            this.cbMgr.Name = "cbMgr";
            this.cbMgr.Size = new System.Drawing.Size(208, 21);
            this.cbMgr.TabIndex = 4;
            // 
            // txtSal
            // 
            this.txtSal.Location = new System.Drawing.Point(176, 119);
            this.txtSal.Name = "txtSal";
            this.txtSal.Size = new System.Drawing.Size(86, 20);
            this.txtSal.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(173, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "SAL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "HIRE DATE";
            // 
            // dtpHireDate
            // 
            this.dtpHireDate.CustomFormat = "     dd/MM/yyyy";
            this.dtpHireDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHireDate.Location = new System.Drawing.Point(15, 119);
            this.dtpHireDate.Name = "dtpHireDate";
            this.dtpHireDate.Size = new System.Drawing.Size(130, 20);
            this.dtpHireDate.TabIndex = 5;
            // 
            // txtComm
            // 
            this.txtComm.Location = new System.Drawing.Point(298, 119);
            this.txtComm.Name = "txtComm";
            this.txtComm.Size = new System.Drawing.Size(86, 20);
            this.txtComm.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(295, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "COMM";
            // 
            // cbDept
            // 
            this.cbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDept.FormattingEnabled = true;
            this.cbDept.Location = new System.Drawing.Point(15, 172);
            this.cbDept.Name = "cbDept";
            this.cbDept.Size = new System.Drawing.Size(130, 21);
            this.cbDept.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "DEPT";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(147, 239);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 274);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbDept);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtComm);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpHireDate);
            this.Controls.Add(this.txtSal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbMgr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtJob);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEmpNo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddEditForm";
            this.Load += new System.EventHandler(this.AddEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmpNo;
        private System.Windows.Forms.TextBox txtEname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtJob;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbMgr;
        private System.Windows.Forms.TextBox txtSal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpHireDate;
        private System.Windows.Forms.TextBox txtComm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbDept;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSave;
    }
}