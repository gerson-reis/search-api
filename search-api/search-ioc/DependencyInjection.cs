using MediatR;
using Microsoft.Extensions.DependencyInjection;
using search_application.Handler;
using search_data;
using search_data.Repositories;
using search_model;

namespace search_ioc
{
    public class DependencyInjection
    {
        public static void Configure(IServiceCollection serviceProvider)
        {
            serviceProvider.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            serviceProvider.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceProvider.AddScoped<IRepository<Question>, QuestionRepository>();
            serviceProvider.AddMediatR(typeof(CreateQuestionHandler));

            
        }
    }
}
