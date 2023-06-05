using BookStore.DL.InMemoryDb;
using BookStore.DL.Interfaces;
using BookStore.Models.Data;

namespace BookStore.DL.Repo
{
    public class BookInMemoryRepository
    {
        //public IEnumerable<Book> GetAll()
        //{
        //    return DataStore.Books;
        //}

        //public IEnumerable<Book>
        //    GetAllByAuthorId(Guid authorId)
        //{
        //    return DataStore.Books;
        //    // .Where(b => b.AuthorId == authorId);
        //}

        //public Book? GetById(int id)
        //{
        //    return DataStore.Books
        //        .FirstOrDefault(x => x.Id == id);
        //}

        //public void Add(Book book)
        //{
        //    DataStore.Books.Add(book);
        //}

        //public void Delete(int id)
        //{
        //    var book = GetById(id);
        //    if (book != null)
        //    {
        //        DataStore.Books.Remove(book);
        //    }
        //}
    }
}
