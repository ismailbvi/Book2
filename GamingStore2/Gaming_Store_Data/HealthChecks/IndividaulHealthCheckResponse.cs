using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaming_Store_Data.HealthChecks
{
    public class IndividualHealthCheckResponse
    {
        public string Status { get; set; }

        public string? Component { get; set; }

        public string? Description { get; set; }
    }
}
