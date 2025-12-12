namespace SmartLicenseAdmin
{
    partial class paymentcomponent
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            applicationid = new DataGridViewTextBoxColumn();
            aplicant = new DataGridViewTextBoxColumn();
            date = new DataGridViewTextBoxColumn();
            status = new DataGridViewTextBoxColumn();
            label1 = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { applicationid, aplicant, date, status });
            dataGridView1.Location = new Point(26, 55);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(553, 152);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // applicationid
            // 
            applicationid.HeaderText = "Application ID";
            applicationid.MinimumWidth = 6;
            applicationid.Name = "applicationid";
            applicationid.Width = 125;
            // 
            // aplicant
            // 
            aplicant.HeaderText = "Aplicant";
            aplicant.MinimumWidth = 6;
            aplicant.Name = "aplicant";
            aplicant.Width = 125;
            // 
            // date
            // 
            date.HeaderText = "Date";
            date.MinimumWidth = 6;
            date.Name = "date";
            date.Width = 125;
            // 
            // status
            // 
            status.HeaderText = "Status";
            status.MinimumWidth = 6;
            status.Name = "status";
            status.Width = 125;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(220, 12);
            label1.Name = "label1";
            label1.Size = new Size(107, 31);
            label1.TabIndex = 1;
            label1.Text = "Payment";
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(17, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(606, 245);
            panel1.TabIndex = 2;
            // 
            // paymentcomponent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "paymentcomponent";
            Size = new Size(644, 299);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn applicationid;
        private DataGridViewTextBoxColumn aplicant;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn status;
        private Panel panel1;
    }
}
