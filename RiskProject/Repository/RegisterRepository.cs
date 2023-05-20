
using Microsoft.EntityFrameworkCore;

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
            TblRegister? result = _context.TblRegisters.Find(registerID.ToString());

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

            var registers = _context.TblRegisters
                .Where(x => x.Active == true)
                .Include(p => p.TblDetails)
                .ToList();

            foreach (var register in registers)
            { 
                LoadRegister(register);
            }


            return registers;
        }

        public TblRegister GetById(Guid registerID)
        {
            TblRegister? result = _context.TblRegisters
                .Where(r => registerID.ToString() == r.Id)
                .Include(p => p.TblDetails)
                .First();


            if (result == null || result.Active == false)
            {
                throw new Exception($"Not found register with id {registerID}");
            }

            LoadRegister(result);

            return result;
        }



        private void LoadRegister(TblRegister register) {
            register.Project = _context.TblProjects.Find(register.ProjectId);

            foreach (var Detail in register.TblDetails) {
                Detail.Priority = _context.TblPriorities.Find(Detail.PriorityId);
                Detail.Probability = _context.TblProbabilities.Find(Detail.ProbabilityId);
                Detail.Impact = _context.TblImpacts.Find(Detail.ImpactId);
            }

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

        public void RemoveRelated(string idRegister)
        {
            _context.TblDetails.Where(x => x.IdRegister == idRegister).ExecuteDelete();
            _context.SaveChanges();
        }
    }
}
