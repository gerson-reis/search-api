using MediatR;
using Microsoft.Extensions.DependencyInjection;
using search_application.Handler;
using search_data;

namespace search_ioc
{
    public class DependencyInjection
    {
        public static void Configure(IServiceCollection serviceProvider)
        {
            serviceProvider.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            serviceProvider.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceProvider.AddMediatR(typeof(CreateQuestionHandler));
        }
    }
}
