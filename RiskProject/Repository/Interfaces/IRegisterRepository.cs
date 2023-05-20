using RiskProject.Repository.Interfaces;

namespace RiskBackend.Repository
{
    public interface IRegisterRepository : IExtendedRepository<TblRegister>
    {
        void RemoveRelated(string id);
    }
}
