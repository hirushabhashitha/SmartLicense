using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartLicenseAPI.Data;
using SmartLicenseAPI.Entities;
using SmartLicenseAPI.Models;

namespace SmartLicenseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseApplicationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public LicenseApplicationController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> Submit([FromForm] LicenseApplicationRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Ensure UserId is provided
            if (request.UserId == 0)
                return BadRequest(new { message = "UserId is required." });

            // Ensure upload folder
            string uploadPath = Path.Combine(_env.ContentRootPath, "Uploads");
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            // Save files
            string birthFile = Path.Combine(uploadPath, Guid.NewGuid() + "_" + request.BirthCertificate.FileName);
            using (var stream = new FileStream(birthFile, FileMode.Create))
            {
                await request.BirthCertificate.CopyToAsync(stream);
            }

            string medicalFile = Path.Combine(uploadPath, Guid.NewGuid() + "_" + request.MedicalCertificate.FileName);
            using (var stream = new FileStream(medicalFile, FileMode.Create))
            {
                await request.MedicalCertificate.CopyToAsync(stream);
            }

            // Save to DB
            var entity = new LicenseApplication
            {
                IdType = request.IdType,
                IdNumber = request.IdNumber,
                Surname = request.Surname,
                OtherNames = request.OtherNames,
                PrintedName = request.PrintedName,
                HeightFeet = request.HeightFeet,
                HeightInches = request.HeightInches,
                BloodGroup = request.BloodGroup,
                OrganDonor = request.OrganDonor == "yes",
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                Secretariat = request.Secretariat,
                DriverRestrictions = request.Restrictions != null ? string.Join(",", request.Restrictions) : "",
                BirthCertificatePath = Path.GetFileName(birthFile),
                MedicalCertificatePath = Path.GetFileName(medicalFile),
                Status = ApplicationTypes.Pending,
                UserId = request.UserId,  // ✅ Add UserId here
                SubmittedAt = DateTime.UtcNow
            };

            _context.LicenseApplications.Add(entity);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Application submitted successfully!", id = entity.Id, userId = entity.UserId });
        }

        [HttpGet("user/{Id}")]
        public async Task<IActionResult> GetApplicationsByUser(int Id)
        {
            // Fetch all applications for this user
            var applications = await _context.LicenseApplications
                .Where(a => a.Id == Id)
                .Select(a => new
                {
                    a.Id,
                    a.IdType,
                    a.IdNumber,
                    a.Surname,
                    a.OtherNames,
                    a.PrintedName,
                    a.HeightFeet,
                    a.HeightInches,
                    a.BloodGroup,
                    a.OrganDonor,
                    a.Address,
                    a.PhoneNumber,
                    a.Secretariat,
                    a.DriverRestrictions,
                    a.BirthCertificatePath,
                    a.MedicalCertificatePath,
                    a.Status,
                    a.SubmittedAt
                })
                .ToListAsync();

            if (!applications.Any())
                return NotFound(new { message = "No applications found for this user." });

            return Ok(applications);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllApplications()
        {
            var applications = await _context.LicenseApplications
                .OrderByDescending(a => a.SubmittedAt)
                .Select(a => new
                {
                    a.Id,
                    a.IdNumber,
                    a.Surname,
                    a.Status,
                    a.SubmittedAt
                })
                .ToListAsync();

            return Ok(applications);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetApplicationDetails(int id)
        {
            var application = await _context.LicenseApplications.FindAsync(id);
            
            if (application == null)
                return NotFound(new { message = "Application not found." });

            return Ok(new
            {
                application.Id,
                application.IdType,
                application.IdNumber,
                application.Surname,
                application.OtherNames,
                application.PrintedName,
                application.HeightFeet,
                application.HeightInches,
                application.BloodGroup,
                application.OrganDonor,
                application.Address,
                application.PhoneNumber,
                application.Secretariat,
                application.DriverRestrictions,
                application.BirthCertificatePath,
                application.MedicalCertificatePath,
                application.Status,
                application.SubmittedAt
            });
        }

        [HttpPut("updateStatus/{id}")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateStatusRequest request)
        {
            var application = await _context.LicenseApplications.FindAsync(id);
            
            if (application == null)
                return NotFound(new { message = "Application not found." });

            application.Status = request.Status;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Status updated successfully!", status = application.Status });
        }

        [HttpGet("download/{fileName}")]
        public IActionResult DownloadFile(string fileName)
        {
            try
            {
                string uploadPath = Path.Combine(_env.ContentRootPath, "Uploads");
                string filePath = Path.Combine(uploadPath, fileName);

                if (!System.IO.File.Exists(filePath))
                    return NotFound(new { message = "File not found." });

                var fileBytes = System.IO.File.ReadAllBytes(filePath);
                var contentType = "application/octet-stream";

                // Determine content type based on extension
                var extension = Path.GetExtension(fileName).ToLowerInvariant();
                contentType = extension switch
                {
                    ".pdf" => "application/pdf",
                    ".jpg" or ".jpeg" => "image/jpeg",
                    ".png" => "image/png",
                    ".gif" => "image/gif",
                    _ => "application/octet-stream"
                };

                return File(fileBytes, contentType, fileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error downloading file.", error = ex.Message });
            }
        }

        [HttpGet("view/{fileName}")]
        public IActionResult ViewFile(string fileName)
        {
            try
            {
                string uploadPath = Path.Combine(_env.ContentRootPath, "Uploads");
                string filePath = Path.Combine(uploadPath, fileName);

                if (!System.IO.File.Exists(filePath))
                    return NotFound(new { message = "File not found." });

                var extension = Path.GetExtension(fileName).ToLowerInvariant();
                var contentType = extension switch
                {
                    ".pdf" => "application/pdf",
                    ".jpg" or ".jpeg" => "image/jpeg",
                    ".png" => "image/png",
                    ".gif" => "image/gif",
                    _ => "application/octet-stream"
                };

                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                return File(fileStream, contentType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error viewing file.", error = ex.Message });
            }
        }
    }
}
