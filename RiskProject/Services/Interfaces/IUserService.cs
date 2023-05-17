using RiskBackend.Dto;

namespace RiskProject.Services.Interfaces
{
    public interface IUserService
    {
        public bool Exist(string email);
        public bool Validate(UserDTO user);
        public TblUser Create(UserDTO user);
    }
}
