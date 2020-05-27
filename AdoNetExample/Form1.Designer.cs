namespace AdoNetExample
{
    partial class Form1
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
            this.btnShowEmpData = new System.Windows.Forms.Button();
            this.lbEmpData = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnShowEmpData
            // 
            this.btnShowEmpData.Location = new System.Drawing.Point(12, 12);
            this.btnShowEmpData.Name = "btnShowEmpData";
            this.btnShowEmpData.Size = new System.Drawing.Size(143, 23);
            this.btnShowEmpData.TabIndex = 0;
            this.btnShowEmpData.Text = "Show Employee Data";
            this.btnShowEmpData.UseVisualStyleBackColor = true;
            this.btnShowEmpData.Click += new System.EventHandler(this.btnShowEmpData_Click);
            // 
            // lbEmpData
            // 
            this.lbEmpData.FormattingEnabled = true;
            this.lbEmpData.Location = new System.Drawing.Point(12, 71);
            this.lbEmpData.Name = "lbEmpData";
            this.lbEmpData.Size = new System.Drawing.Size(316, 368);
            this.lbEmpData.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 450);
            this.Controls.Add(this.lbEmpData);
            this.Controls.Add(this.btnShowEmpData);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShowEmpData;
        private System.Windows.Forms.ListBox lbEmpData;
    }
}

