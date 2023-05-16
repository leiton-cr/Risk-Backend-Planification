
using System.Collections.Generic;

namespace RiskBackend
{
    public interface IService<T>
    {
        IEnumerable<T> Get();
        T GetById(int id);
        T Create(T task);
        T Update(int id, T task);
        T Delete(int id);
    }
}
