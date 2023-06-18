using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaming_Store_Data.HealthChecks
{
    public class HealthResponse
    {
        public string Status { get; set; }

        public IEnumerable<IndividualHealthCheckResponse>
            HealthChecks
        { get; set; } = Enumerable.Empty<IndividualHealthCheckResponse>();

        public TimeSpan HealthCheckDuration { get; set; }
    }
}
