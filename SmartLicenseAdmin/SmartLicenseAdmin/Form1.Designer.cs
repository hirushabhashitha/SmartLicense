namespace SmartLicenseAdmin
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panellogin = new Panel();
            btnlogin = new Button();
            txtpassword = new TextBox();
            txtemail = new TextBox();
            password = new Label();
            email = new Label();
            label1 = new Label();
            panellogin.SuspendLayout();
            SuspendLayout();
            // 
            // panellogin
            // 
            panellogin.BackColor = Color.WhiteSmoke;
            panellogin.BorderStyle = BorderStyle.FixedSingle;
            panellogin.Controls.Add(btnlogin);
            panellogin.Controls.Add(txtpassword);
            panellogin.Controls.Add(txtemail);
            panellogin.Controls.Add(password);
            panellogin.Controls.Add(email);
            panellogin.Location = new Point(82, 100);
            panellogin.Name = "panellogin";
            panellogin.Size = new Size(600, 360);
            panellogin.TabIndex = 4;
            panellogin.Paint += panellogin_Paint;
            // 
            // btnlogin
            // 
            btnlogin.BackColor = Color.RoyalBlue;
            btnlogin.FlatStyle = FlatStyle.Flat;
            btnlogin.Font = new Font("Segoe UI", 10F);
            btnlogin.ForeColor = Color.White;
            btnlogin.Location = new Point(209, 225);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(94, 37);
            btnlogin.TabIndex = 4;
            btnlogin.Text = "Login";
            btnlogin.UseVisualStyleBackColor = false;
            btnlogin.Click += btnlogin_Click;
            // 
            // txtpassword
            // 
            txtpassword.Location = new Point(209, 171);
            txtpassword.Name = "txtpassword";
            txtpassword.Size = new Size(231, 27);
            txtpassword.TabIndex = 3;
            // 
            // txtemail
            // 
            txtemail.Location = new Point(209, 117);
            txtemail.Name = "txtemail";
            txtemail.Size = new Size(231, 27);
            txtemail.TabIndex = 2;
            txtemail.TextChanged += txtemail_TextChanged;
            // 
            // password
            // 
            password.AutoSize = true;
            password.Font = new Font("Segoe UI", 10F);
            password.ForeColor = Color.Black;
            password.Location = new Point(115, 171);
            password.Name = "password";
            password.Size = new Size(80, 23);
            password.TabIndex = 1;
            password.Text = "Password";
            // 
            // email
            // 
            email.AutoSize = true;
            email.Font = new Font("Segoe UI", 10F);
            email.ForeColor = Color.Black;
            email.Location = new Point(115, 118);
            email.Name = "email";
            email.Size = new Size(51, 23);
            email.TabIndex = 0;
            email.Text = "Email";
            email.Click += email_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkBlue;
            label1.Location = new Point(292, 48);
            label1.Name = "label1";
            label1.Size = new Size(153, 31);
            label1.TabIndex = 5;
            label1.Text = "Admin Login";
            label1.Click += label1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(782, 553);
            Controls.Add(label1);
            Controls.Add(panellogin);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Smart License Admin - Login";
            panellogin.ResumeLayout(false);
            panellogin.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panellogin;
        private Label label1;
        private TextBox txtpassword;
        private TextBox txtemail;
        private Label email;
        private Label password;
        private Button btnlogin;
    }
}
