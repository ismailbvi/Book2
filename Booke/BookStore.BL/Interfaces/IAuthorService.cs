using BookStore.Models.Data;
using BookStore.Models.Request;

namespace BookStore.BL.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAll();
        Task<Author?> GetById(Guid id);
        Task<Author?> Add(Author book); 
        Task Delete(Guid id);
        Task Update(Author author);
    }
}
