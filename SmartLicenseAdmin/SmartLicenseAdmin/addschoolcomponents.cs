using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SmartLicenseAdmin
{
    public partial class addschoolcomponents : UserControl
    {
        private string connStr = "Server=localhost;Port=3306;Database=smartlicensedb;Uid=root;Pwd=Hirusha1234..;";

        public addschoolcomponents()
        {
            InitializeComponent();
            LoadSchools();
        }

        private void btnAddSchool_Click(object sender, EventArgs e)
        {
            string schoolName = txtSchoolName.Text.Trim();
            string location = txtLocation.Text.Trim();
            string contact = txtContactNo.Text.Trim();

            if (string.IsNullOrEmpty(schoolName) || string.IsNullOrEmpty(location) || string.IsNullOrEmpty(contact))
            {
                MessageBox.Show("Please fill all fields!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO DrivingSchools (DrivingSchoolName, Location, Contact) " +
                                   "VALUES (@DrivingSchoolName, @Location, @Contact)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DrivingSchoolName", schoolName);
                        cmd.Parameters.AddWithValue("@Location", location);
                        cmd.Parameters.AddWithValue("@Contact", contact);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Driving School added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh DataGridView
                    LoadSchools();
                    dataGridView1.Refresh();
                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
                    }

                    // Clear input fields
                    txtSchoolName.Text = string.Empty;
                    txtLocation.Text = string.Empty;
                    txtContactNo.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadSchools()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM DrivingSchools";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading schools: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // avoid header row
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Set textbox values from the selected row
                txtSchoolName.Text = row.Cells["DrivingSchoolName"].Value.ToString();
                txtLocation.Text = row.Cells["Location"].Value.ToString();
                txtContactNo.Text = row.Cells["Contact"].Value.ToString();
            }
        }

        private void btnEditSchool_Click(object sender, EventArgs e)
        {
            // Make sure a row is selected
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a school to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected school's original name (unique identifier)
            string originalSchoolName = dataGridView1.CurrentRow.Cells["DrivingSchoolName"].Value.ToString();

            // Get updated values from input fields
            string updatedSchoolName = txtSchoolName.Text.Trim();
            string updatedLocation = txtLocation.Text.Trim();
            string updatedContact = txtContactNo.Text.Trim();

            if (string.IsNullOrEmpty(updatedSchoolName) || string.IsNullOrEmpty(updatedLocation) || string.IsNullOrEmpty(updatedContact))
            {
                MessageBox.Show("Please fill all fields!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE DrivingSchools " +
                                   "SET DrivingSchoolName=@UpdatedName, Location=@Location, Contact=@Contact " +
                                   "WHERE DrivingSchoolName=@OriginalName";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UpdatedName", updatedSchoolName);
                        cmd.Parameters.AddWithValue("@Location", updatedLocation);
                        cmd.Parameters.AddWithValue("@Contact", updatedContact);
                        cmd.Parameters.AddWithValue("@OriginalName", originalSchoolName);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("School updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadSchools(); // Refresh DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Update failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Clear input fields
            txtSchoolName.Text = string.Empty;
            txtLocation.Text = string.Empty;
            txtContactNo.Text = string.Empty;
        }


        private void btnDeleteSchool_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a school to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Select record details
            string schoolName = dataGridView1.CurrentRow.Cells["DrivingSchoolName"].Value.ToString();

            // Confirm before delete
            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete this school: " + schoolName + "?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.No)
                return;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM DrivingSchools WHERE DrivingSchoolName=@SchoolName";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SchoolName", schoolName);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("School deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadSchools(); // Refresh DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Delete failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Clear textboxes
            txtSchoolName.Text = "";
            txtLocation.Text = "";
            txtContactNo.Text = "";
        }

        private void lbltittle_Click(object sender, EventArgs e)
        {

        }
    }
}
