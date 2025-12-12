namespace SmartLicenseAdmin
{
    partial class dashboardcomponent
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
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            panel4 = new Panel();
            label6 = new Label();
            label7 = new Label();
            panel3 = new Panel();
            label4 = new Label();
            label5 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightGreen;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(18, 102);
            panel1.Name = "panel1";
            panel1.Size = new Size(126, 118);
            panel1.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(3, 78);
            label3.Name = "label3";
            label3.Size = new Size(114, 17);
            label3.TabIndex = 1;
            label3.Text = "Total Application";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(31, 24);
            label2.Name = "label2";
            label2.Size = new Size(57, 35);
            label2.TabIndex = 0;
            label2.Text = "358";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(50, 41);
            label1.Name = "label1";
            label1.Size = new Size(444, 31);
            label1.TabIndex = 0;
            label1.Text = "Driving School Management DashBoard";
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(panel1);
            panel2.Location = new Point(3, 53);
            panel2.Name = "panel2";
            panel2.Size = new Size(546, 381);
            panel2.TabIndex = 6;
            panel2.Paint += panel2_Paint;
            // 
            // panel4
            // 
            panel4.BackColor = Color.LightGreen;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(label6);
            panel4.Controls.Add(label7);
            panel4.Location = new Point(379, 102);
            panel4.Name = "panel4";
            panel4.Size = new Size(126, 118);
            panel4.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(3, 78);
            label6.Name = "label6";
            label6.Size = new Size(117, 17);
            label6.TabIndex = 1;
            label6.Text = "Register D School";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(37, 24);
            label7.Name = "label7";
            label7.Size = new Size(29, 35);
            label7.TabIndex = 0;
            label7.Text = "5";
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightGreen;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label5);
            panel3.Location = new Point(200, 102);
            panel3.Name = "panel3";
            panel3.Size = new Size(126, 118);
            panel3.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(3, 78);
            label4.Name = "label4";
            label4.Size = new Size(125, 17);
            label4.TabIndex = 1;
            label4.Text = "Pending Approvals";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(31, 24);
            label5.Name = "label5";
            label5.Size = new Size(43, 35);
            label5.TabIndex = 0;
            label5.Text = "15";
            // 
            // dashboardcomponent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Name = "dashboardcomponent";
            Size = new Size(799, 535);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private Label label3;
        private Panel panel4;
        private Label label6;
        private Label label7;
        private Panel panel3;
        private Label label4;
        private Label label5;
    }
}
