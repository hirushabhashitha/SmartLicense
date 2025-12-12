using System;
using System.Drawing;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartLicenseAdmin
{
    public partial class ApplicationDetailsForm : Form
    {
        private const string API_URL = "https://localhost:7077/api/LicenseApplication";
        private int applicationId;

        public ApplicationDetailsForm(int appId)
        {
            InitializeComponent();
            applicationId = appId;
            LoadApplicationDetails();
        }

        private async void LoadApplicationDetails()
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    var response = await client.GetAsync($"{API_URL}/details/{applicationId}");
                    response.EnsureSuccessStatusCode();

                    var content = await response.Content.ReadAsStringAsync();
                    var app = JsonSerializer.Deserialize<ApplicationDetailsDto>(content, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (app != null)
                    {
                        PopulateFields(app);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading application details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateFields(ApplicationDetailsDto app)
        {
            lblIdTypeValue.Text = app.IdType;
            lblIdNumberValue.Text = app.IdNumber;
            lblSurnameValue.Text = app.Surname;
            lblOtherNamesValue.Text = app.OtherNames;
            lblPrintedNameValue.Text = app.PrintedName;
            lblHeightValue.Text = $"{app.HeightFeet}' {app.HeightInches}\"";
            lblBloodGroupValue.Text = app.BloodGroup;
            lblOrganDonorValue.Text = app.OrganDonor ? "Yes" : "No";
            lblAddressValue.Text = app.Address;
            lblPhoneValue.Text = app.PhoneNumber;
            lblSecretariatValue.Text = app.Secretariat;
            lblRestrictionsValue.Text = string.IsNullOrEmpty(app.DriverRestrictions) ? "None" : app.DriverRestrictions;

            string statusText = app.Status == 0 ? "Pending" : app.Status == 1 ? "Approved" : "Rejected";
            lblStatusValue.Text = statusText;
            lblStatusValue.ForeColor = app.Status == 0 ? Color.Orange : app.Status == 1 ? Color.Green : Color.Red;

            lblSubmittedValue.Text = app.SubmittedAt.ToString("MMMM dd, yyyy 'at' hh:mm tt");

            btnViewBirth.Tag = app.BirthCertificatePath;
            btnViewMedical.Tag = app.MedicalCertificatePath;
            btnDownloadBirth.Tag = app.BirthCertificatePath;
            btnDownloadMedical.Tag = app.MedicalCertificatePath;
        }

        private async void btnViewBirth_Click(object sender, EventArgs e)
        {
            await OpenCertificate(btnViewBirth.Tag?.ToString(), "view");
        }

        private async void btnViewMedical_Click(object sender, EventArgs e)
        {
            await OpenCertificate(btnViewMedical.Tag?.ToString(), "view");
        }

        private async void btnDownloadBirth_Click(object sender, EventArgs e)
        {
            await DownloadCertificate(btnDownloadBirth.Tag?.ToString());
        }

        private async void btnDownloadMedical_Click(object sender, EventArgs e)
        {
            await DownloadCertificate(btnDownloadMedical.Tag?.ToString());
        }

        private async Task OpenCertificate(string fileName, string action)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                MessageBox.Show("Certificate file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string url = $"{API_URL}/{action}/{fileName}";
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening certificate: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task DownloadCertificate(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                MessageBox.Show("Certificate file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    FileName = fileName,
                    Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    HttpClientHandler handler = new HttpClientHandler();
                    handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

                    using (HttpClient client = new HttpClient(handler))
                    {
                        var response = await client.GetAsync($"{API_URL}/download/{fileName}");
                        response.EnsureSuccessStatusCode();

                        var fileBytes = await response.Content.ReadAsByteArrayAsync();
                        System.IO.File.WriteAllBytes(saveDialog.FileName, fileBytes);

                        MessageBox.Show("Certificate downloaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error downloading certificate: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }

    public class ApplicationDetailsDto
    {
        public int Id { get; set; }
        public string IdType { get; set; }
        public string IdNumber { get; set; }
        public string Surname { get; set; }
        public string OtherNames { get; set; }
        public string PrintedName { get; set; }
        public int HeightFeet { get; set; }
        public int HeightInches { get; set; }
        public string BloodGroup { get; set; }
        public bool OrganDonor { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Secretariat { get; set; }
        public string DriverRestrictions { get; set; }
        public string BirthCertificatePath { get; set; }
        public string MedicalCertificatePath { get; set; }
        public int Status { get; set; }
        public DateTime SubmittedAt { get; set; }
    }
}
