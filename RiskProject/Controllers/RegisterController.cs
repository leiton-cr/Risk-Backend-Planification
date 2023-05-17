
using Microsoft.AspNetCore.Mvc;
using RiskProject.Dtos;
using RiskProject.Services;

namespace RiskBackend.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly RegisterService _service;

        public RegisterController()
        {
            _service = new RegisterService();
        }

        [HttpGet(Name = "Get All Registers")]
        public IActionResult GetAll()
        {
            return Ok(_service.Get());
        }

        [HttpGet("{id}", Name = "Get One Register")]
        public IActionResult Get(Guid id)
        {
            TblRegister register;

            try
            {
                register = _service.GetById(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = "error", message = ex.Message });
            }

            return Ok(register);
        }


        [HttpPost(Name = "Create Register")]
        public IActionResult Post(RegisterDTO register)
        {
            TblRegister newRegister;

            try
            {
                newRegister = _service.Create(register);
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = "error", message = ex.Message });
            }

            return Ok(newRegister);
        }

        [HttpPut(Name = "Update Register")]
        public IActionResult Put(Guid id, RegisterDTO register)
        {
            TblRegister updateRegister;

            try
            {
                updateRegister = _service.Update(id, register);
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = "error", message = ex.Message });
            }

            return Ok(updateRegister);
        }

        [HttpDelete(Name = "Delete Register")]
        public IActionResult Delete(Guid id)
        {
            _service.Delete(id);

            return Ok();
        }

    }
}