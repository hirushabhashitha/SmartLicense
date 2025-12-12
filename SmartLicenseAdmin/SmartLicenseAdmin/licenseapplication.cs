using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.Json;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace SmartLicenseAdmin
{
    public partial class licenseapplication : UserControl
    {
        private static readonly HttpClient client = new HttpClient();
        private const string API_URL = "https://localhost:7077/api/LicenseApplication";
        private int selectedApplicationId = -1;

        public licenseapplication()
        {
            InitializeComponent();
            LoadApplications();
        }

        private async void LoadApplications()
        {
            try
            {
                // Accept all SSL certificates for development
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                using (HttpClient client = new HttpClient(handler))
                {
                    var response = await client.GetAsync($"{API_URL}/all");
                    response.EnsureSuccessStatusCode();
                    
                    var content = await response.Content.ReadAsStringAsync();
                    var applications = JsonSerializer.Deserialize<List<LicenseApplicationDto>>(content, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    dataGridView1.Rows.Clear();
                    
                    foreach (var app in applications)
                    {
                        string statusText = app.Status == 0 ? "Pending" : app.Status == 1 ? "Approved" : "Rejected";
                        dataGridView1.Rows.Add(
                            app.Id,
                            app.IdNumber,
                            app.SubmittedAt.ToString("yyyy-MM-dd HH:mm"),
                            statusText
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading applications: " + ex.Message);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Approve button
            await UpdateStatus(1); // 1 = Approved
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // Reject button
            await UpdateStatus(2); // 2 = Rejected
        }

        private async Task UpdateStatus(int status)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an application first.");
                return;
            }

            try
            {
                int applicationId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                using (HttpClient client = new HttpClient(handler))
                {
                    var updateData = new { Status = status };
                    var json = JsonSerializer.Serialize(updateData);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    
                    var response = await client.PutAsync($"{API_URL}/updateStatus/{applicationId}", content);
                    response.EnsureSuccessStatusCode();
                    
                    string statusText = status == 1 ? "Approved" : "Rejected";
                    MessageBox.Show($"Application {statusText} successfully!");
                    LoadApplications(); // Refresh the grid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating status: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // View button - open details form
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an application first.");
                return;
            }

            int applicationId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            ApplicationDetailsForm detailsForm = new ApplicationDetailsForm(applicationId);
            detailsForm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            
        }

    }

    public class LicenseApplicationDto
    {
        public int Id { get; set; }
        public string IdNumber { get; set; }
        public string Surname { get; set; }
        public int Status { get; set; }
        public DateTime SubmittedAt { get; set; }
    }
}