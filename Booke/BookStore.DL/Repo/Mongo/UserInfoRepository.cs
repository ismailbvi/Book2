using BookStore.DL.Interfaces;
using BookStore.Models.Configs;
using BookStore.Models.Data.Users;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BookStore.DL.Repo.Mongo
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly IMongoCollection<UserInfo> _users;
        private readonly IOptionsMonitor<MongoConfiguration> _config;

        public UserInfoRepository(IOptionsMonitor<MongoConfiguration> config)
        {
            _config = config;
            var client =
                new MongoClient(_config.CurrentValue.ConnectionString);
            var database =
                client.GetDatabase(_config.CurrentValue.DatabaseName);

            _users =
                database.GetCollection<UserInfo>($"{nameof(UserInfo)}",
                    new MongoCollectionSettings()
                    {
                        GuidRepresentation = GuidRepresentation.Standard
                    });
        }

        public async Task Add(UserInfo userInfo)
        {
            await _users.InsertOneAsync(userInfo);
        }

        public Task<UserInfo?> GetUserInfo(string email, string password)
        {
            var filterBuilder = Builders<UserInfo>.Filter;
            var filter = filterBuilder.Eq(u => u.Email, email) &
                         filterBuilder.Eq(u => u.Password, password);

            var user = _users.Find(filter).FirstOrDefault();

            return Task.FromResult(user);
        }
    }
}
