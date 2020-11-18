using search_model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace search_data
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetPage(Expression<Func<T, bool>> where, int limit, int offset);
        Task<T> GetFirst(Expression<Func<T, bool>> where);
        Task<T> GetById(int id);
        Task<T> Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
