using BookStore.Models.Data;
using BookStore.Models.Request;

namespace BookStore.BL.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAll();
        Task<Author?> GetById(Guid id);
        Task AddAuthor(AddAuthorRequest author);
        Task<Author?> Add(Author book); 
        Task DeleteAuthor(Guid id);
        Task Update(Author author);
    }
}
