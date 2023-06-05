using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.Models.Responses;

namespace BookStore.BL.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public LibraryService(
            IAuthorRepository authorRepository,
            IBookRepository bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }

        public async Task<GetAllBooksByAuthorResponse>
            GetAllBooksByAuthor(Guid authorId)
        {
            var response = new GetAllBooksByAuthorResponse
            {
                Author = await _authorRepository.GetById(authorId),
                Books = await _bookRepository.GetAllByAuthorId(authorId)
            };

            return response;
        }
    }
}
