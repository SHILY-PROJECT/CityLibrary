using System;
using Microsoft.EntityFrameworkCore;
using SimbirSoftWorkshop.API.Models.Entity;

namespace SimbirSoftWorkshop.API.Tests
{
    public class FakeDbContext
    {
        public static DataContext GetFakeDbContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new DataContext(options);

            context.Database.EnsureCreated();

            context.Authors.AddRange(
                new Author { Id = 1, FirstName = "Eliezer", LastName = "Yudkowsky" },
                new Author { Id = 2, FirstName = "Carl", LastName = "Sagan" },
                new Author { Id = 3, FirstName = "Norman", LastName = "Doidge" },
                new Author { Id = 4, FirstName = "Stephen", LastName = "King" },
                new Author { Id = 5, FirstName = "John", LastName = "Tolkien" });

            context.Genres.AddRange(
                new Genre { Id = 1, GenreName = "Fantasy" },
                new Genre { Id = 2, GenreName = "Scientific literature" },
                new Genre { Id = 3, GenreName = "Self-development literature" },
                new Genre { Id = 4, GenreName = "Science fiction" });

            context.Books.AddRange(
                new Book { Id = 1, Name = "Harry Potter and the Methods of Rationality", AuthorId = 1 },
                new Book { Id = 2, Name = "The Demon-Haunted World: Science as a Candle in the Dark", AuthorId = 2 },
                new Book { Id = 3, Name = "The Brains Way of Healing: Remarkable Discoveries and Recoveries from the Frontiers of Neuroplasticity", AuthorId = 3 },
                new Book { Id = 4, Name = "Contact", AuthorId = 2 },
                new Book { Id = 5, Name = "The Lord of the Rings", AuthorId = 5 },
                new Book { Id = 6, Name = "The Hobbit, or There and Back Again", AuthorId = 5 });

            context.Persons.AddRange(
                new Person { Id = 1, FirstName = "Alexander", LastName = "Statskov", MiddleName = "Dmitrievich"},
                new Person { Id = 2, FirstName = "Igor", LastName = "Izmailov", MiddleName = "Innokentievich" },
                new Person { Id = 3, FirstName = "Eliezer", LastName = "Yudkowsky", MiddleName = "Shlomo" },
                new Person { Id = 4, FirstName = "Yana", LastName = "Sharkelova", MiddleName = "Egorovna" },
                new Person { Id = 5, FirstName = "Igor", LastName = "Premin", MiddleName = "Olegovych" });

            context.LibraryCards.AddRange(
                new LibraryCard { BookId = 2, PersonId = 1 },
                new LibraryCard { BookId = 3, PersonId = 1 },
                new LibraryCard { BookId = 4, PersonId = 1 },
                new LibraryCard { BookId = 1, PersonId = 2 },
                new LibraryCard { BookId = 4, PersonId = 2 });

            context.BooksGenres.AddRange(
                new BookGenre { BookId = 1, GenreId = 1 },
                new BookGenre { BookId = 2, GenreId = 2 },
                new BookGenre { BookId = 3, GenreId = 3 },
                new BookGenre { BookId = 4, GenreId = 4 },
                new BookGenre { BookId = 5, GenreId = 1 },
                new BookGenre { BookId = 6, GenreId = 1 });

            context.SaveChanges();
            return context;
        }
    }
}
