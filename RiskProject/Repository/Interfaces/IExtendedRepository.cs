namespace RiskProject.Repository.Interfaces
{
    public interface IExtendedRepository<T> : IRepository
    {
        IEnumerable<T> GetAll();
        T GetById(Guid RegisterID);
        void Insert(T register);
        void Update(T register);
        void Delete(Guid Register);
    }
}
