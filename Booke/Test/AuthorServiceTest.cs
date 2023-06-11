using BookStore.BL.Interfaces;
using BookStore.BL.Services;
using BookStore.DL.Interfaces;
using BookStore.DL.Repo.Mongo;
using BookStore.Models.Data;
using Moq;

namespace Test
{
    public class AuthorServiceTest
    {
        private Mock<IAuthorRepository> _authorRepository;
        private Mock<IBookService> _bookService;

        private IList<Author> Authors = new List<Author>()
        {
            new Author()
            {
                Id = new Guid("b5de2576-121f-4a38-9fb4-36362e3714f5"),
                BookId = new Guid("5534e5d5-a588-43b7-be8a-20f6521cdcb0"),
                Name = "ZaHarry Baharov "

            },
             new Author()
            {
                Id = new Guid("b5de2576-121f-4a38-9fb4-36362e3714f5"),
                BookId = new Guid("5534e5d5-a588-43b7-be8a-20f6521cdcb0"),
                Name = "J.K Rowling"

            },
        };

        private IList<Book> Books = new List<Book>()
        {
            new Book()
            {
                Id = new Guid("cc7bc0c0-cf25-493d-bf18-68d8fce5a0aa"),
                Description = "FUNtazi",
                Title = "Book0"
            },

        };
        public AuthorServiceTest()
        {
            _authorRepository = new Mock<IAuthorRepository>();
            _bookService = new Mock<IBookService>();
        }
        [Fact]
        public async Task Author_GetAll_Count()
        {
            var expectedCount = 2;

            _authorRepository.Setup(
                r => r.GetAll())
                .Returns(async () =>
                Authors.AsEnumerable());

            //inject
            var service = new AuthorService(
                    _authorRepository.Object, _bookService.Object);

            //Act
            var result = await service.GetAll();

            //Assert
            var authors = result.ToList();
            Assert.NotNull(authors);
            Assert.Equal(expectedCount, authors.Count);
            Assert.Equal(Authors, authors);
        }

        [Fact]
        public async Task Author_GetById_Ok()
        {
            //setup
            var authorId = new Guid();
            var expectedAuthor = Authors.First(r => r.Id == authorId);
            var expectedName = $"!{expectedAuthor.Name}";

            _authorRepository.Setup(
                r => r.GetById(authorId))
                .Returns(async () =>
                Authors.FirstOrDefault(r => r.Id == authorId));
            //inject
            var service = new AuthorService(_authorRepository.Object, _bookService.Object);

            //Act
            var result = await service.GetById(authorId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedAuthor, result);
            Assert.Equal(expectedName, result?.Name);
        }
        [Fact]
        public async Task Author_GetById_Not_Found()
        {
            //setup
            var authorId = new Guid("1c18f6ae-a16c-477e-b267-9184c4819742");


            _authorRepository.Setup(
                    x => x.GetById(authorId))
                .Returns(async () =>
                    Books.FirstOrDefault(x => x.Id == authorId));
            //inject
            var service = new AuthorService(_authorRepository.Object, _bookService.Object);

            //Act
            var result = await service.GetById(authorId);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Author_Add_Ok()
        {
            //setup 
            var authorToAdd = new Author()
            {
                Id = new Guid("b5de2576-121f-4a38-9fb4-36362e3714f5"),
                BookId = new Guid("5534e5d5-a588-43b7-be8a-20f6521cdcb0"),
                Name = "J.K Rowling"

            };
            var expectedAuthorCount = 3;

            _bookService.Setup(a =>
                a.GetById(authorToAdd.BookId)).Returns(() => Task.FromResult(Books.FirstOrDefault()));

            _authorRepository.Setup(
                    r =>
                        r.GetAllByBookId(authorToAdd.BookId))
                    .Returns(() =>
                        Task.FromResult(Authors.Where(r => r.BookId == authorToAdd.BookId)));

            _authorRepository.Setup(r =>
                r.Add(It.IsAny<Author>()))
                .Callback(() =>
                {
                    Authors.Add(authorToAdd);
                }).Returns(Task.CompletedTask);

            //inject
            var service = new AuthorService(_authorRepository.Object, _bookService.Object);

            //Act
            await service.Add(authorToAdd);

            //Assert
            Assert.Equal(expectedAuthorCount, Authors.Count);
            Assert.Equal(authorToAdd, Authors.LastOrDefault());
        }

        [Fact]
        public async Task Author_Add_Book_Not_Found()
        {
            //setup
            var authorToAdd = new Author()
            {
                Id = new Guid("b5de2576-121f-4a38-9fb4-36362e3714f5"),
                BookId = new Guid("5534e5d5-a588-43b7-be8a-20f6521cdcb0"),
                Name = "J.K Rowling"
            };
            var expectedAuthorCount = 2;

            _bookService.Setup(a =>
                a.GetById(authorToAdd.BookId)).Returns(() =>
                Task.FromResult(Books.FirstOrDefault(r => r.Id == authorToAdd.BookId)));

            _authorRepository.Setup(
                    r =>
                        r.GetAllByBookId(authorToAdd.BookId))
                .Returns(() =>
                    Task.FromResult(Authors.Where(x => x.BookId == authorToAdd.BookId)));

            _authorRepository.Setup(x =>
                x.Add(It.IsAny<Author>()));

            //inject
            var service = new AuthorService(_authorRepository.Object, _bookService.Object);

            //Act
            var result = await service.Add(authorToAdd);

            //Assert    
            Assert.Equal(expectedAuthorCount, Authors.Count);
            Assert.Null(result);
        }
    }

}
