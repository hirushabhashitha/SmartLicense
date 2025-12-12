namespace SmartLicenseAPI.Model
{
    public class LicenseApplicationResponse
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
        public string Status { get; set; }
        public DateTime SubmittedAt { get; set; }
    }
}
