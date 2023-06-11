using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.DL.Repo.Mongo;
using BookStore.Models.Data;
using BookStore.Models.Request;

namespace BookStore.BL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookService _bookService;
            
        public AuthorService(
            IAuthorRepository authorRepository,
            IBookService bookService)
        {
            _authorRepository = authorRepository;
  
            _bookService = bookService;

        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _authorRepository.GetAll();
        }

        public async Task<Author> GetById(Guid id)
        {
            var result = await _authorRepository.GetById(id);
            if (result != null) { 
                result.Name = $"!{result.Name}";
            }
            return result;
        }

        public async Task<Author?> Add(Author author)
        {
            author.Id = Guid.NewGuid();

            var book =
                await _bookService.GetById(author.BookId);

            if (author == null) return null;
            var authorBooks =
                await _authorRepository
                    .GetAllByBookId(author.BookId);

            var titleForBookExist =
                authorBooks.Any(b => b.Name == author.Name);
                
            if (titleForBookExist) return null;

            await _authorRepository.Add(author);    

            return author;
        }
        public async Task Delete(Guid id)
        {
            await _authorRepository.Delete(id);
        }

        public async Task Update(Author author)
        { 
            await _authorRepository.Update(author);
        }
    }
}
