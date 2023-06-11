using Gaming_Store_Data.Config;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Gaming_Store.Healthchecks
{
    public class MongoHealthCheck : IHealthCheck
    {
        private readonly IOptionsMonitor<MongoConfiguration> _config;

        public MongoHealthCheck(IOptionsMonitor<MongoConfiguration> config)
        {
            _config = config;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                var client =
                    new MongoClient(_config.CurrentValue.ConnectionString);
                var database =
                    client.GetDatabase(_config.CurrentValue.DatabaseName);
            }
            catch (Exception)
            {
                return Task.FromResult(HealthCheckResult.Unhealthy("Ne rAboti"));
            }

            return Task.FromResult(HealthCheckResult.Healthy("Mongo si e OK"));
        }
    }
}
