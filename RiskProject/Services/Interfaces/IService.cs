
using System.Collections.Generic;

namespace RiskProject.Services.Interfaces
{
    public interface IService<T,I>
    {
        IEnumerable<T> Get();
        T GetById(Guid id);
        T Create(I task);
        T Update(Guid id, I task);
        void Delete(Guid id);
    }
}
