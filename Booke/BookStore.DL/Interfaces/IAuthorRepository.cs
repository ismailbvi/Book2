﻿using BookStore.Models.Data;

namespace BookStore.DL.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAll();

        Task<Author> GetById(Guid id);

        Task Add(Author book);  

        Task AddAuthor(Author author);  

        Task DeleteAuthor(Guid id);

        Task Update(Author book);

        Task<IEnumerable<Author>> GetAllByBookId(Guid bookId);
    }
}