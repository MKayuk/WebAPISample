using System.Collections.Generic;

namespace WebAPI.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        T Get(int id);
        long Insert(T entity);
        bool InsertRange(List<T> entities);
        bool Update(T entity);
        bool Delete(T entity);
        IEnumerable<T> FindAll(string query);
    }
}
