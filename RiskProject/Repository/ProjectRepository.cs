
namespace RiskBackend.Repository
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
