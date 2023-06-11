using BookStore.DL.Interfaces;
using BookStore.Models.Configs;
using BookStore.Models.Data;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BookStore.DL.Repo.Mongo
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IMongoCollection<Author> _authors;
        private readonly IOptionsMonitor<MongoConfiguration> _config;

        public AuthorRepository(
            IOptionsMonitor<MongoConfiguration> config)
        {
            _config = config;
            var client =
                new MongoClient(_config.CurrentValue.ConnectionString);
            var database =
                client.GetDatabase(_config.CurrentValue.DatabaseName);

            _authors =
                database.GetCollection<Author>($"{nameof(Author)}",
                    new MongoCollectionSettings()
                    {
                        GuidRepresentation = GuidRepresentation.Standard
                    });
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _authors.Find(author => true)
                .ToListAsync();
        }

        public async Task<Author> GetById(Guid id)
        {
            return await _authors
                .Find(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task Add(Author author)
        {
            await _authors.InsertOneAsync(author);
        }

        public async Task Delete(Guid id)
        {
            await _authors
                .DeleteOneAsync(a => a.Id == id);
        }
        public async Task Update(Author author)
        {
            var filter =
                Builders<Author>.Filter.Eq(s => s.Id, author.Id);
            var update = Builders<Author>
                .Update.Set(s =>
                    s.Bio, author.Bio);

            await _authors.UpdateOneAsync(filter, update);
        }

        public async Task<IEnumerable<Author>> GetAllByBookId(Guid bookId)
        {
            return await _authors
                .Find(x => x.BookId == bookId)
                .ToListAsync();
        }
    }
}
