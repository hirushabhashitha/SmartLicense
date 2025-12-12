namespace SmartLicenseAdmin
{
    partial class addschoolcomponents
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
            dataGridView1 = new DataGridView();
            txtContactNo = new TextBox();
            txtLocation = new TextBox();
            txtSchoolName = new TextBox();
            label1 = new Label();
            btnDeleteSchool = new Button();
            label4 = new Label();
            btnEditSchool = new Button();
            btnAddSchool = new Button();
            label3 = new Label();
            lbltittle = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lbltittle);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(txtContactNo);
            panel1.Controls.Add(txtLocation);
            panel1.Controls.Add(txtSchoolName);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnDeleteSchool);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btnEditSchool);
            panel1.Controls.Add(btnAddSchool);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(16, 18);
            panel1.Name = "panel1";
            panel1.Size = new Size(597, 453);
            panel1.TabIndex = 10;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(5, 295);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(545, 129);
            dataGridView1.TabIndex = 13;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // txtContactNo
            // 
            txtContactNo.Location = new Point(123, 178);
            txtContactNo.Name = "txtContactNo";
            txtContactNo.Size = new Size(152, 27);
            txtContactNo.TabIndex = 12;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(123, 139);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(152, 27);
            txtLocation.TabIndex = 11;
            // 
            // txtSchoolName
            // 
            txtSchoolName.Location = new Point(123, 100);
            txtSchoolName.Name = "txtSchoolName";
            txtSchoolName.Size = new Size(152, 27);
            txtSchoolName.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(2, 103);
            label1.Name = "label1";
            label1.Size = new Size(120, 23);
            label1.TabIndex = 5;
            label1.Text = "Driving School";
            // 
            // btnDeleteSchool
            // 
            btnDeleteSchool.Location = new Point(410, 236);
            btnDeleteSchool.Name = "btnDeleteSchool";
            btnDeleteSchool.Size = new Size(116, 41);
            btnDeleteSchool.TabIndex = 4;
            btnDeleteSchool.Text = "Delete School";
            btnDeleteSchool.UseVisualStyleBackColor = true;
            btnDeleteSchool.Click += btnDeleteSchool_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(2, 179);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 8;
            label4.Text = "Contact_No";
            // 
            // btnEditSchool
            // 
            btnEditSchool.Location = new Point(209, 236);
            btnEditSchool.Name = "btnEditSchool";
            btnEditSchool.Size = new Size(113, 41);
            btnEditSchool.TabIndex = 3;
            btnEditSchool.Text = "Edit School";
            btnEditSchool.UseVisualStyleBackColor = true;
            btnEditSchool.Click += btnEditSchool_Click;
            // 
            // btnAddSchool
            // 
            btnAddSchool.Location = new Point(5, 236);
            btnAddSchool.Name = "btnAddSchool";
            btnAddSchool.Size = new Size(117, 41);
            btnAddSchool.TabIndex = 2;
            btnAddSchool.Text = "Add School";
            btnAddSchool.UseVisualStyleBackColor = true;
            btnAddSchool.Click += btnAddSchool_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(2, 139);
            label3.Name = "label3";
            label3.Size = new Size(75, 23);
            label3.TabIndex = 7;
            label3.Text = "Location";
            // 
            // lbltittle
            // 
            lbltittle.AutoSize = true;
            lbltittle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbltittle.ForeColor = Color.Navy;
            lbltittle.Location = new Point(47, 42);
            lbltittle.Name = "lbltittle";
            lbltittle.Size = new Size(420, 41);
            lbltittle.TabIndex = 11;
            lbltittle.Text = "Driving School Management";
            lbltittle.Click += lbltittle_Click;
            // 
            // addschoolcomponents
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "addschoolcomponents";
            Size = new Size(632, 496);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtContactNo;
        private TextBox txtLocation;
        private TextBox txtRegisterID;
        private TextBox txtSchoolName;
        private Label label1;
        private Button btnDeleteSchool;
        private Label label4;
        private Button btnEditSchool;
        private Label label2;
        private Button btnAddSchool;
        private Label label3;
        private DataGridViewTextBoxColumn register_id;
        private Label lbltittle;
        private DataGridView dataGridView1;
    }
}
