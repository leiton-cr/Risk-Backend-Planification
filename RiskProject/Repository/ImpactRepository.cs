
namespace RiskBackend.Repository
{
    public class ImpactRepository : IImpactRepository
    {
        private readonly RiskContext _context;

        public ImpactRepository()
        {
            _context = new RiskContext();
        }

        public IEnumerable<TblImpact> GetAll()
        {
            return _context.TblImpacts.OrderBy(e => e.Value).ToList();
        }
    }
}
