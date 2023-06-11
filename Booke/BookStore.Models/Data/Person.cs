using MongoDB.Bson.Serialization.Attributes;

namespace BookStore.Models.Data
{
    public class Person
    {
        [BsonId]
        [BsonElement("_id")]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid BookId { get; set; }
    }
}