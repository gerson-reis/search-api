using Microsoft.EntityFrameworkCore;
using search_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace search_data.Repositories
{
    public class QuestionRepository : Repository<Question>, IRepository<Question>
    {
        public QuestionRepository(SearchContext context) : base(context)
        {
        }

        public override async Task<Question> GetById(int id) => entities.Include(x => x.Choices).SingleOrDefault(s => s.Id == id);

        public override async Task<IEnumerable<Question>> GetPage(int limit, int offset, Expression<Func<Question, bool>> where = null)
        {
            IQueryable<Question> querable = entities;
            if (where != null)
                querable = querable.Where(where);

            querable = querable.Include(x => x.Choices);

            return querable.Skip(offset).Take(limit).AsEnumerable();
        }
    }
}
