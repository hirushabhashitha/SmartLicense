using Microsoft.AspNetCore.Mvc;
using SmartLicenseAPI.Data;
using SmartLicenseAPI.Entities;
using SmartLicenseAPI.Entity;
using SmartLicenseAPI.Model;
using System.Linq;
using static SmartLicenseAPI.Entity.User;

namespace SmartLicenseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        // --------------------------
        // REGISTER
        // --------------------------
        [HttpPost("register")]
        public IActionResult Register([FromBody] User register)
        {
            // 1️⃣ Model validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            register.Role = UserRole.User; // Default role

            // 2️⃣ Duplicate email check
            var existingUser = _context.Users
                .FirstOrDefault(u => u.Email.ToLower() == register.Email.ToLower());
            if (existingUser != null)
            {
                return BadRequest(new { message = "This email is already registered." });
            }

            // 3️⃣ Save new user
            _context.Users.Add(register);
            _context.SaveChanges();

            // 4️⃣ Return success with UserId
            return Ok(new
            {
                message = "User registration successful.",
                registerId = register.Id,
            });
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthRequest login)
        {
            // 1️⃣ Input validation
            if (string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Password))
            {
                return BadRequest(new { message = "Please enter both Email and Password." });
            }

            // 2️⃣ Find user by email (case-insensitive)
            var user = _context.Users
                .FirstOrDefault(u => u.Email.ToLower() == login.Email.ToLower());

            // 3️⃣ Check if user exists
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid Email or Password." });
            }

            // 4️⃣ Check password (⚠️ hashing recommended in production)
            if (user.Password != login.Password)
            {
                return Unauthorized(new { message = "Invalid Email or Password." });
            }

            // 5️⃣ Return success response (No email & password exposure)
            return Ok(new
            {  
                message = "Login successful.",
                 id = user.Id
            });
        }

    }

}

