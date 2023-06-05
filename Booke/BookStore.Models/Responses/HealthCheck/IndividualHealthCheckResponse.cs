namespace BookStore.Models.Responses.HealthCheck
{
    public class IndividualHealthCheckResponse
    {
        public string Status { get; set; } = string.Empty;

        public string? Component { get; set; }

        public string? Description { get; set; }
    }
}
