
using Microsoft.AspNetCore.Mvc;
using RiskBackend.Dto;
using RiskProject.Services;

namespace RiskBackend.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController()
        {
            _service = new UserService();
        }

        [HttpPost(Name = "Create User")]
        public IActionResult Post(UserDTO user)
        {
            TblUser newUser;

            try
            {
                newUser = _service.Create(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = "error", message = ex.Message });
            }

            return Ok(newUser);
        }

    }
}