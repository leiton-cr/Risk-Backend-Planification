
using RiskBackend.Repository;

namespace RiskProject.Repository
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly RiskContext _context;
        public RegisterRepository() {
            _context = new RiskContext(); 
        }

        public void Delete(Guid registerID)
        {
            TblRegister? result = _context.TblRegisters.Find(registerID);

            if (result == null || result.Active == false)
            {
                throw new Exception($"Not found register with id {registerID}");
            }

            result.Active = false;

            _context.Update(result);
            _context.SaveChanges();
        }

        public IEnumerable<TblRegister> GetAll()
        {
            return _context.TblRegisters.Where(x => x.Active == true).ToList();
        }

        public TblRegister GetById(Guid registerID)
        {
            TblRegister? result = _context.TblRegisters.Find(registerID);

            if (result == null || result.Active == false)
            {
                throw new Exception($"Not found register with id {registerID}");
            }

            return result;
        }

        public void Insert(TblRegister register)
        {
            _context.Add(register);
            _context.SaveChanges();
        }

        public void Update(TblRegister register)
        {
            _context.Update(register);
            _context.SaveChanges();
        }
    }
}
