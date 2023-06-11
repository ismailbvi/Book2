using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Request
{
    public class UpdateBookRequest
    {
        public int Id { get; set; }

        public string Bio { get; set; }

        public string Name { get; set; }
    }
}
