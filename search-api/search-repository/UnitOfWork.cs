using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace search_data
{
    public class UnitOfWork : IUnitOfWork
    {
        private SearchContext context;

        public UnitOfWork(SearchContext databaseContext)
        { 
            context = databaseContext; 
        }


        public async Task Commit()
        {
            context.SaveChanges();
        }

        public async Task Rollback()
        { 
            context.Dispose(); 
        }
    }
}
