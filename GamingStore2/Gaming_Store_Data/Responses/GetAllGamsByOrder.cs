using Gaming_Store_Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaming_Store_Data.Responses
{
    public class GetAllGamsByOrder
    {
        public Game Game { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
