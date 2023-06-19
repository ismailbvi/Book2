using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaming_Store_Data.Data
{
    public class Game
    {
        [BsonId]
        [BsonElement("_id")]
        public Guid Id { get; set; }
        public string Developer { get; set; }
        public string Title { get; set; }
    }
}
