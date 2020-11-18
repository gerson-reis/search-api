using Microsoft.EntityFrameworkCore;
using search_model;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
