using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaming_Store_Data.Request
{
    public class UpdateGameRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Guid DeveloperId { get; set; }
        public string Description { get; set; }
        public string Developer { get; set; }
    }
}
