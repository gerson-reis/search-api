using search_model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace search_data
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task Save();
    }
}
