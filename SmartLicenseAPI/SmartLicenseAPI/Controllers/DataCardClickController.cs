using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using SmartLicenseAPI.Entity;
using SmartLicenseAPI.Model;
using System.Collections.Generic;

namespace SmartLicenseAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataCardClickController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DataCardClickController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET api/DataCardClick/{id}
        [HttpGet]
        public IActionResult GetLicenseApplications([FromQuery] string id)
        {
            var responses = new List<DataCardClickResponse>();

            string connStr = _configuration.GetConnectionString("DefaultConnection");

            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"SELECT Id, IdNumber, Surname, PhoneNumber, Status
                                 FROM LicenseApplications
                                 WHERE UserId = @UserId";   // remove LIMIT 1

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())   // loop to get multiple rows
                        {
                            responses.Add(new DataCardClickResponse
                            {
                                IdNumber = reader["IdNumber"].ToString(),
                                Surname = reader["Surname"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Status = reader["Status"].ToString(),
                                Id = reader["Id"].ToString ()
                                
                            });
                        }
                    }
                }
            }

            if (responses.Count == 0)
            {
                return NotFound(new { message = "Applications not found" });
            }

            return Ok(responses);  // return list
        }
    }
}
