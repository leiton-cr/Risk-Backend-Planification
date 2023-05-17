using RiskBackend.Repository;

namespace RiskProject.Repository.ReadOnly
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly RiskContext _context;

        public ProjectRepository()
        {
            _context = new RiskContext();
        }


        public IEnumerable<TblProject> GetAll()
        {
            return _context.TblProjects.ToList();
        }

    }
}
