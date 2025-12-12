namespace SmartLicenseAdmin
{
    partial class licenseapplication
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
            panel1 = new Panel();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            applicant = new DataGridViewTextBoxColumn();
            date = new DataGridViewTextBoxColumn();
            status = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(19, 18);
            panel1.Name = "panel1";
            panel1.Size = new Size(633, 356);
            panel1.TabIndex = 0;
            // 
            // button3
            // 
            button3.Location = new Point(285, 234);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 4;
            button3.Text = "View";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(168, 234);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 3;
            button2.Text = "Reject";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(52, 234);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "Approve";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(188, 9);
            label1.Name = "label1";
            label1.Size = new Size(255, 35);
            label1.TabIndex = 1;
            label1.Text = "License Applications";
            label1.Click += label1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id, applicant, date, status });
            dataGridView1.Location = new Point(27, 47);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(585, 141);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_2;
            // 
            // id
            // 
            id.HeaderText = "ID";
            id.MinimumWidth = 6;
            id.Name = "id";
            id.ReadOnly = true;
            id.Visible = false;
            // 
            // applicant
            // 
            applicant.HeaderText = "ID Number";
            applicant.MinimumWidth = 6;
            applicant.Name = "applicant";
            applicant.ReadOnly = true;
            // 
            // date
            // 
            date.HeaderText = "Date";
            date.MinimumWidth = 6;
            date.Name = "date";
            date.ReadOnly = true;
            // 
            // status
            // 
            status.HeaderText = "Status";
            status.MinimumWidth = 6;
            status.Name = "status";
            status.ReadOnly = true;
            // 
            // licenseapplication
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "licenseapplication";
            Size = new Size(664, 408);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private DataGridView dataGridView1;
        private DataGridViewButtonColumn ApproveColumn;
        private DataGridViewButtonColumn RejectColumn;
        private Button button3;
        private Button button2;
        private Button button1;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn applicant;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn status;
    }
}
