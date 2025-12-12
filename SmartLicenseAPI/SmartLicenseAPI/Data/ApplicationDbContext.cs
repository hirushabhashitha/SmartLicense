using Microsoft.EntityFrameworkCore;
using SmartLicenseAPI.Entities;
using SmartLicenseAPI.Entity;

namespace SmartLicenseAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<LicenseApplication> LicenseApplications { get; set; }
        public DbSet<DrivingSchool> DrivingSchools { get; set; }
        // Model configuration
       
    }
}

