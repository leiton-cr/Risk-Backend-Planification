using Microsoft.EntityFrameworkCore;
using RiskBackend.Dto;

namespace RiskProject.Repository.Interfaces
{
    public interface IAuthRepository : IRepository
    {
        Boolean Exists(String email);
        public TblUser GetByEmail(String email);

        public TblUser Create(UserDTO user, int salt, string pepper);
    }
}
