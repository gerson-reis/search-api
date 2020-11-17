using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace search_data
{
    public interface IUnitOfWork
    {
        Task Commit();
        Task Rollback();
    }
}
