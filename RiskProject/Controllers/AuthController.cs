
using Microsoft.AspNetCore.Mvc;
using RiskBackend.Dto;
using RiskBackend.Services;

namespace RiskBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserService _service;

        public AuthController(ILogger<AuthController> logger)
        {
            _service = new UserService();
        }

        [HttpPost(Name = "Validate Auth")]
        public IActionResult Post(UserDTO user)
        {
            try
            {
                return Ok(new { validation = _service.Validate(user) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = "error", message = ex.Message });
            }

        }

    }
}