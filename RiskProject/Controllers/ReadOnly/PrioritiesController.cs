
using Microsoft.AspNetCore.Mvc;
using RiskBackend.Repository;

namespace RiskProject.Controllers.ReadOnly
{

    [ApiController]
    [Route("[controller]")]
    public class PrioritiesController : ControllerBase
    {
        // Uses directly the repo because only will need get all
        IPriorityRepository _repo = new PriorityRepository();

        [HttpGet(Name = "Get Priorities")]
        public IActionResult GetPriorities()
        {
            return Ok(_repo.GetAll());
        }

    }
}
