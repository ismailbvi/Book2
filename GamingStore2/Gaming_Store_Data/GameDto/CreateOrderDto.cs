using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaming_Store_Data.GameDto
{
    public class CreateOrderDto
    {
        public int GameId { get; set; }
        public int Quantity { get; set; }

        public string CustomerName { get; set; }
    }
}
