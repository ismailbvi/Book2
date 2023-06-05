using BookStore.Models.Data;
using BookStore.Models.Request;

namespace BookStore.BL.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book?> GetById(Guid id);
        Task Add(AddBookRequest author);
        Task Delete(Guid id);
    }
}