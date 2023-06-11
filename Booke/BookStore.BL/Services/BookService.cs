using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.DL.Repo.Mongo;
using BookStore.Models.Data;
using BookStore.Models.Request;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace BookStore.BL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BookService> _logger;

        public BookService(IBookRepository bookRepository,
            ILogger<BookService> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            var result =
                 await _bookRepository.GetAll();

            return result;

        }

        public async Task<Book?> GetById(Guid id)
        {
            var book = await _bookRepository.GetById(id);

            if (book == null)
            {
                _logger.LogError($"GetById:{id} returns null!");
                return null;
            }

            return book;
        }

        public async Task Add(AddBookRequest bookRequest)
        {
            var book = new Book()
            {
                Id = Guid.NewGuid(),
                Description = bookRequest.Description,
                AuthorId = bookRequest.AuthorId,
                Title = bookRequest.Name
            };

            await _bookRepository.Add(book);
        }

        public async Task Delete(Guid id)
        {
            await _bookRepository.Delete(id);
        }
    }
}