namespace BookStore.Models.Responses.HealthCheck
{
    public class HealthCheckResponse
    {
        public string Status { get; set; }

        public IEnumerable<IndividualHealthCheckResponse> 
            HealthChecks { get; set; } =
            Enumerable.Empty<IndividualHealthCheckResponse>();

        public TimeSpan HealthCheckDuration { get; set; }
    }

  
}
