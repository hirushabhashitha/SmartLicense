namespace SmartLicenseAPI.Model
{
    public class DataCardClickResponse
    {
        
        public string IdNumber { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }  // pending / approved / rejected

        public string Id { get; set; }
    }
}

