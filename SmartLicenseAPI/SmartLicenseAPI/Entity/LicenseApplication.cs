using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartLicenseAPI.Entities
{
    [Table("LicenseApplications")]
    public class LicenseApplication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // --- New Column: UserId (Foreign key) ---
        [Required]
        public int UserId { get; set; }

        // --- A. Personal Details ---
        [Required, MaxLength(20)]
        public string IdType { get; set; } = string.Empty;   // NIC / Passport

        [Required, MaxLength(50)]
        public string IdNumber { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Surname { get; set; } = string.Empty;

        [MaxLength(200)]
        public string OtherNames { get; set; } = string.Empty;

        [MaxLength(200)]
        public string PrintedName { get; set; } = string.Empty;

        // --- B. Additional Personal Details ---
        public int HeightFeet { get; set; }
        public int HeightInches { get; set; }

        [MaxLength(5)]
        public string BloodGroup { get; set; } = string.Empty;

        public bool OrganDonor { get; set; }

        [MaxLength(500)]
        public string Address { get; set; } = string.Empty;

        [Required, MaxLength(15)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Secretariat { get; set; } = string.Empty;

        [MaxLength(200)]
        public string DriverRestrictions { get; set; } = string.Empty; // CSV: "None,Corrective Lenses"

        // File paths
        [MaxLength(255)]
        public string BirthCertificatePath { get; set; } = string.Empty;

        [MaxLength(255)]
        public string MedicalCertificatePath { get; set; } = string.Empty;

        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow.ToUniversalTime();
        public ApplicationTypes? Status { get; set; }   //0-pending, 1-approve,2-reject
    }

    public enum ApplicationTypes
    {
        Pending,
        Approve,
        Reject
    }
}
