using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartLicenseAPI.Models
{
    public class LicenseApplicationRequest
    {
        // Personal
        [Required] public string IdType { get; set; }
        [Required] public string IdNumber { get; set; }
        [Required] public string Surname { get; set; }
        public string OtherNames { get; set; }
        public string PrintedName { get; set; }

        // Additional
        public int HeightFeet { get; set; }
        public int HeightInches { get; set; }
        public string BloodGroup { get; set; }
        public string OrganDonor { get; set; } // "yes" or "no"
        public string Address { get; set; }
        [Required] public string PhoneNumber { get; set; }
        [Required] public string Secretariat { get; set; }
        public List<string>? Restrictions { get; set; }

        // Files
        [Required] public IFormFile BirthCertificate { get; set; }
        [Required] public IFormFile MedicalCertificate { get; set; }

        // 🔑 Add this
        public int UserId { get; set; }


    }
}

