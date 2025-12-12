using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartLicenseAPI.Entity
{
   
        [Table("DrivingSchools")] // Table name
        public class DrivingSchool
        {
            [Key] // Primary Key
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Required]
            [MaxLength(150)]
            public string DrivingSchoolName { get; set; }  // ⚡️ renamed to avoid confusion

            [Required]
            [MaxLength(200)]
            public string Location { get; set; }

            [Required]
            [MaxLength(50)]
            public string Contact { get; set; }
        }
    
}
