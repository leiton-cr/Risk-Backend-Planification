
namespace RiskBackend.Repository
{
    public class PriorityRepository : IPriorityRepository
    {
        private readonly RiskContext _context;

        public PriorityRepository()
        {
            _context = new RiskContext();
        }

        public IEnumerable<TblPriority> GetAll()
        {
            return _context.TblPriorities.OrderBy(e => e.Value).ToList();
        }
    }
}
