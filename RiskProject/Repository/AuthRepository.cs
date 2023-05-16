

using RiskBackend.Dto;
using RiskProject.Repository.Interfaces;
using System.Globalization;

namespace RiskBackend.Repository
{
    public class AuthRepository:IAuthRepository
    {
        private readonly RiskContext _context;

        public AuthRepository()
        {
            _context = new RiskContext();
        }

        public bool Exists(String email)
        {
            return _context.TblUsers.Any(u => u.Email.Equals(email));
        }

        public TblUser Create(UserDTO user, int salt, string pepper) 
        { 
            TblUser newUser = new TblUser();
            newUser.Id = Guid.NewGuid().ToString();
            newUser.Pass = user.Pass;
            newUser.Email = user.Email;
            newUser.Salt = salt;
            newUser.Pepper = pepper;

            _context.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }

        public TblUser GetByEmail(String email)
        {
            TblUser user = _context.TblUsers.FirstOrDefault(u => u.Email.Equals(email));

            if (user == null) {
                throw new Exception("Email not found");
            }

            return user;
        }



    }
}
