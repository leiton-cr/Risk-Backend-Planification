
using Microsoft.AspNetCore.Mvc;
using RiskBackend.Repository;

namespace RiskProject.Controllers.ReadOnly
{

    [ApiController]
    [Route("[controller]")]
    public class ProbabilitiesController : ControllerBase
    {
        // Uses directly the repo because only will need get all
        IProbabilityRepository _repo = new ProbabilityRepository();

        [HttpGet(Name = "Get Probabilities")]
        public IActionResult GetProbabilities()
        {
            return Ok(_repo.GetAll());
        }

    }
}
