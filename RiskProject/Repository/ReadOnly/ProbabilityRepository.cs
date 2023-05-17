using RiskBackend.Repository;

namespace RiskProject.Repository.ReadOnly
{
    public class ProbabilityRepository : IProbabilityRepository
    {
        private readonly RiskContext _context;

        public ProbabilityRepository()
        {
            _context = new RiskContext();
        }

        public IEnumerable<TblProbability> GetAll()
        {
            return _context.TblProbabilities.OrderBy(e => e.Value).ToList();
        }

    }
}
