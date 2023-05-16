namespace RiskProject.Repository.Interfaces
{
    public interface IExtendedRepository<T> where T : class, IBaseRepository<T>
    {
      
        T GetById(int EmployeeID);
        void Insert(T employee);
        void Update(T employee);
        void Delete(int EmployeeID);
    }
}
