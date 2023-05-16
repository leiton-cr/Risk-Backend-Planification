
using RiskBackend.Dto;
using RiskBackend.Repository;
using RiskBackend.Utils;
using RiskProject.Models;
using RiskProject.Repository.Interfaces;

namespace RiskBackend.Services
{
    public class UserService 
    {
        IAuthRepository _repo = new AuthRepository();

        public bool Exist(string email)
        {
            return _repo.Exists(email);
        }

        public bool Validate(UserDTO user)
        {

            if (String.IsNullOrEmpty(user.Email))
            {
                throw new Exception("Email can't be null");
            }

            if (String.IsNullOrEmpty(user.Pass))
            {
                throw new Exception("Password can't be null");
            }

            TblUser foundUser;
            try
            {
                foundUser = _repo.GetByEmail(user.Email);
            }
            catch 
            { 
                return false;
            }

            return Security.VerifyPassword(user.Pass, foundUser.Pass, foundUser.Salt, foundUser.Pepper);

        }

        public TblUser Create(UserDTO user)
        {
            if (String.IsNullOrEmpty(user.Email))
            {
                throw new Exception("Email can't be null");
            }

            if (String.IsNullOrEmpty(user.Pass))
            {
                throw new Exception("Password can't be null");
            }

            if (_repo.Exists(user.Email))
            {
                throw new Exception("Email already exists on db");
            }

            String hashedPassword;
            int salt;
            string pepper;

            Security.HashPassword(user.Pass, out hashedPassword, out salt, out pepper);

            user.Pass = hashedPassword;

            return _repo.Create(user, salt, pepper);
        }

    }
}
