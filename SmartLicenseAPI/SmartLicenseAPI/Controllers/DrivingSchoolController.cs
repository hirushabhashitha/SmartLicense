using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using SmartLicenseAPI.Model;
using System.Collections.Generic;

namespace SmartLicenseAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrivingSchoolsController : ControllerBase
    {
        // MySQL connection string
        private readonly string connStr = "Server=localhost;Port=3306;Database=smartlicensedb;Uid=root;Pwd=Hirusha1234..;";

        // GET api/drivingschools
        [HttpGet]
        public IActionResult GetDrivingSchools()
        {
            var schools = new List<DrivingSchoolResponse>();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                // Select only fields we want to return
                string query = "SELECT DrivingSchoolName, Location, Contact FROM DrivingSchools";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        schools.Add(new DrivingSchoolResponse
                        {
                            DrivingSchoolName = reader["DrivingSchoolName"].ToString(),
                            Location = reader["Location"].ToString(),
                            Contact = reader["Contact"].ToString()
                        });
                    }
                }
            }

            return Ok(schools); // Return JSON array to frontend
        }
    }
}

