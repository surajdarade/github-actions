using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase {
        [HttpGet]
        public IActionResult Get() {
            return Ok(new
            {
                Code = 200,
                Status = "Healthy",
                Message = "Student Management API is running successfully."
            });
        }
    }
}
