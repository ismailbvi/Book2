using Gaming_Store_Data.Config;
using Gaming_Store_Data.Data;
using GamingStore.DL.InerFaces;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GamingStore.DL.Repo
{
    public class MongoGameRepo : IGameRepository
    {
        private readonly IMongoCollection<Game> _games;
        private readonly IOptionsMonitor<MongoConfiguration> _config;

        public MongoGameRepo(
            IOptionsMonitor<MongoConfiguration> config)
        {
            _config = config;
            var client =
                new MongoClient(_config.CurrentValue.ConnectionString);
            var database =
                client.GetDatabase(_config.CurrentValue.DatabaseName);

            _games =
                database.GetCollection<Game>($"{nameof(Game)}",
                    new MongoCollectionSettings()
                    {
                        GuidRepresentation = GuidRepresentation.Standard
                    });
        }

        public async Task<IEnumerable<Game>> GetAll()
        {
            return await _games.Find(game => true)
                .ToListAsync();
        }

        public async Task<Game> GetById(Guid id)
        {
            return await _games
                .Find(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task Add(Game game)
        {
            await _games.InsertOneAsync(game);
        }

        public async Task Delete(Guid id)
        {
            await _games
                .DeleteOneAsync(a => a.Id == id);
        }
    }
}
