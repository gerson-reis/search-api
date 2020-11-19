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
        Task<IEnumerable<T>> GetPage(int limit, int offset, Expression<Func<T, bool>> where = null);
        Task<T> GetFirst(Expression<Func<T, bool>> where);
        Task<T> GetById(int id);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
    }
}
