using Microsoft.EntityFrameworkCore;
using search_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace search_data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        protected readonly SearchContext context;
        protected DbSet<T> entities;
        string errorMessage = string.Empty;
        public Repository(SearchContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll() => entities.AsEnumerable();

        public async virtual Task<IEnumerable<T>> GetPage(Expression<Func<T, bool>> where, int limit, int offset) => 
                                entities.Where(where).Skip(offset).Take(limit).AsEnumerable();

        public async Task<T> GetFirst(Expression<Func<T, bool>> where) => await entities.FirstOrDefaultAsync(where);

        public virtual async Task<T> GetById(int id) => entities.SingleOrDefault(s => s.Id == id);

        public async Task<T> Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity is null");
            await entities.AddAsync(entity);
            context.SaveChanges();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity is null");
            context.Update(entity);
            context.SaveChanges();
            return entity;
        }

        public async Task Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity is null");
            entities.Remove(entity);
        }
    }
}
