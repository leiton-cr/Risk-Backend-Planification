
using Microsoft.AspNetCore.Mvc;
using RiskBackend.Dto;
using RiskProject.Services;
using System.Net.Mail;
using System.Net;
using System.Text;
using RiskBackend.Utils;

namespace RiskBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserService _service;

        public AuthController()
        {
            _service = new UserService();
        }

        [HttpPost(Name = "Validate Auth")]
        public IActionResult Post(UserDTO user)
        {
            try
            {
                bool isValidate = _service.Validate(user);
                if (isValidate)
                {
                    string jwt = Security.GenerateJWT(user.Email);
                    return Ok(new { validation = isValidate, jwt });
                }

                return Ok(new { validation = isValidate });

            }
            catch (Exception ex)
            {
                return BadRequest(new { status = "error", message = ex.Message });
            }

        }

        [HttpGet("EmailExists/{email}")]
        public IActionResult CheckEmailExists([FromRoute] string email)
        {
            try
            {
                bool emailExists = _service.Exist(email);

                if (emailExists)
                {
                    // Logic to return user with JWT if email exists
                    TblUser existingUser = _service.GetUserByEmail(email);
                    string jwt = Security.GenerateJWT(email);
                    return Ok(new { validation = true, jwt });
                }
                else
                {

                    UserDTO user = new UserDTO();
                    user.Email = email;
                    user.Pass = "googleLogin";
                    // Logic to create a new user and return JWT
                    TblUser newUser = _service.Create(user);
                    string jwt = Security.GenerateJWT(email);
                    return Ok(new { validation = true, jwt });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = "error", message = ex.Message });
            }
        }
    }
}