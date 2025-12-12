namespace SmartLicenseAdmin
{
    partial class Dashboard
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
            lbldschoolclick = new Label();
            label2 = new Label();
            payments = new Label();
            label3 = new Label();
            label1 = new Label();
            panel1 = new Panel();
            applicationFeeComponents1 = new ApplicationFeeComponents();
            paymentcomponent1 = new paymentcomponent();
            licenseapplication1 = new licenseapplication();
            addschoolcomponents1 = new addschoolcomponents();
            dashboardcomponent1 = new dashboardcomponent();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lbldschoolclick
            // 
            lbldschoolclick.AutoSize = true;
            lbldschoolclick.Cursor = Cursors.Hand;
            lbldschoolclick.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbldschoolclick.Location = new Point(18, 110);
            lbldschoolclick.Name = "lbldschoolclick";
            lbldschoolclick.Size = new Size(135, 23);
            lbldschoolclick.TabIndex = 0;
            lbldschoolclick.Text = "Driving Schools";
            lbldschoolclick.Click += lblDrivingSchool_Click_;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Cursor = Cursors.Hand;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(18, 152);
            label2.Name = "label2";
            label2.Size = new Size(103, 23);
            label2.TabIndex = 1;
            label2.Text = "Application";
            label2.Click += label2_Click;
            // 
            // payments
            // 
            payments.AutoSize = true;
            payments.Cursor = Cursors.Hand;
            payments.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            payments.Location = new Point(18, 197);
            payments.Name = "payments";
            payments.Size = new Size(87, 23);
            payments.TabIndex = 2;
            payments.Text = "Payments";
            payments.Click += payments_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Cursor = Cursors.Hand;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(18, 62);
            label3.Name = "label3";
            label3.Size = new Size(97, 23);
            label3.TabIndex = 3;
            label3.Text = "DashBoard";
            label3.Click += label3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Cursor = Cursors.Hand;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(18, 243);
            label1.Name = "label1";
            label1.Size = new Size(135, 23);
            label1.TabIndex = 4;
            label1.Text = "Application Fee";
            label1.Click += label1_Click_2;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(payments);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lbldschoolclick);
            panel1.Location = new Point(3, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(205, 578);
            panel1.TabIndex = 3;
            panel1.Paint += panel1_Paint;
            // 
            // applicationFeeComponents1
            // 
            applicationFeeComponents1.Location = new Point(225, 12);
            applicationFeeComponents1.Name = "applicationFeeComponents1";
            applicationFeeComponents1.Size = new Size(468, 406);
            applicationFeeComponents1.TabIndex = 4;
            // 
            // paymentcomponent1
            // 
            paymentcomponent1.Location = new Point(225, 39);
            paymentcomponent1.Name = "paymentcomponent1";
            paymentcomponent1.Size = new Size(654, 379);
            paymentcomponent1.TabIndex = 5;
            // 
            // licenseapplication1
            // 
            licenseapplication1.Location = new Point(214, 12);
            licenseapplication1.Name = "licenseapplication1";
            licenseapplication1.Size = new Size(718, 406);
            licenseapplication1.TabIndex = 6;
            // 
            // addschoolcomponents1
            // 
            addschoolcomponents1.Location = new Point(225, 12);
            addschoolcomponents1.Name = "addschoolcomponents1";
            addschoolcomponents1.Size = new Size(790, 505);
            addschoolcomponents1.TabIndex = 7;
            // 
            // dashboardcomponent1
            // 
            dashboardcomponent1.Location = new Point(214, 12);
            dashboardcomponent1.Name = "dashboardcomponent1";
            dashboardcomponent1.Size = new Size(810, 552);
            dashboardcomponent1.TabIndex = 8;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1104, 592);
            Controls.Add(dashboardcomponent1);
            Controls.Add(addschoolcomponents1);
            Controls.Add(licenseapplication1);
            Controls.Add(paymentcomponent1);
            Controls.Add(applicationFeeComponents1);
            Controls.Add(panel1);
            Name = "Dashboard";
            Text = "Dashboard";
            Load += Dashboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lbldschoolclick;
        private Label label2;
        private Label payments;
        private Label label3;
        private Panel panel1;
        private Label label1;
        private dashboardcomponent dashboardcomponent1;
        private addschoolcomponents addschoolcomponents1;
        private licenseapplication licenseapplication1;
        private ApplicationFeeComponents applicationFeeComponents1;
        private paymentcomponent paymentcomponent1;
    }
}