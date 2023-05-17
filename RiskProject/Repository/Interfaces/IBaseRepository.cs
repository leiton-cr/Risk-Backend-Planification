namespace RiskProject.Repository.Interfaces
{
    public interface IBaseRepository<T> : IRepository
    {
        IEnumerable<T> GetAll();
    }
}
