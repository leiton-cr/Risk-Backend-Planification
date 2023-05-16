
using Microsoft.AspNetCore.Mvc;
using RiskBackend.Repository;

namespace RiskProject.Controllers.ReadOnly
{

    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        // Uses directly the repo because only will need get all
        IProjectRepository _repo = new ProjectRepository();

        [HttpGet(Name = "Get Projects")]
        public IActionResult GetProjects()
        {
            return Ok(_repo.GetAll());
        }

    }
}
