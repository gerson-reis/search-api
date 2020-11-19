using Microsoft.Extensions.Diagnostics.HealthChecks;
using search_data;
using System.Threading;
using System.Threading.Tasks;

namespace search_api
{
    public class ApiHealthCheck : IHealthCheck
    {
        private readonly SearchContext searchContext;

        public ApiHealthCheck(SearchContext searchContext)
        {
            this.searchContext = searchContext;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,CancellationToken cancellationToken = default(CancellationToken))
        {
            var healthCheckResultHealthy = searchContext.Database.CanConnect();

            if (healthCheckResultHealthy)
            {
                return Task.FromResult(HealthCheckResult.Healthy());
            }
            return Task.FromResult(HealthCheckResult.Unhealthy());
        }
    }
}
