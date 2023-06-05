using MongoDB.Bson.Serialization.Attributes;


namespace BookStore.Models.Data.Users
{
    public class UserInfo
    {
        [BsonId]
        [BsonElement("_id")]
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
