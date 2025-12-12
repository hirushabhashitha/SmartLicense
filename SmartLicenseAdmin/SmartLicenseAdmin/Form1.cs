using MySql.Data.MySqlClient;
using System.Data;
using static SmartLicenseAdmin.Enum.UserRoleContainer;

namespace SmartLicenseAdmin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panellogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void email_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string email = txtemail.Text.Trim();
            string password = txtpassword.Text.Trim();

            string connStr = "Server=localhost;Port=3306;Database=smartlicensedb;Uid=root;Pwd=Hirusha1234..;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {   

                
                conn.Open();
                
                string sql = "SELECT Role FROM Users WHERE Email=@Email AND Password=@Password LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int role = Convert.ToInt32(reader["Role"]);
                            if (role == (int)UserRole.Admin)
                            {
                                MessageBox.Show("Admin Login Success!");
                                Dashboard dashboard = new Dashboard();
                                dashboard.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Access Denied! Only Admins can login.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid email or password.");
                        } 
                    }
                }
            }
        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}