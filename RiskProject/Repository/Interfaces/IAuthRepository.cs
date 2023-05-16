using Microsoft.EntityFrameworkCore;
using RiskBackend.Dto;

namespace RiskProject.Repository.Interfaces
{
    public interface IAuthRepository
    {
        Boolean Exists(String email);
        public TblUser GetByEmail(String email);

        public TblUser Create(UserDTO user, int salt, string pepper);
    }
}
