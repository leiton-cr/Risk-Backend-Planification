
using Microsoft.AspNetCore.Mvc;
using RiskBackend.Repository;

namespace RiskProject.Controllers.ReadOnly
{

    [ApiController]
    [Route("[controller]")]
    public class ImpactsController : ControllerBase
    {
        // Uses directly the repo because only will need get all
        IImpactRepository _repo = new ImpactRepository();

        [HttpGet(Name = "Get Impact")]
        public IActionResult GetImpacts()
        {
            return Ok(_repo.GetAll());
        }

    }
}
