using Microsoft.EntityFrameworkCore;
using CityLibrary.DataAccess.Entities;

namespace CityLibrary.DataAccess.EntityConfigurations;

internal static class TestDataConfiguration
{
    public static ModelBuilder ApplyTestData(this ModelBuilder modelBuilder)
    {
        var person1 = new PersonDb { Id = Guid.NewGuid(), FirstName = "Alexander", LastName = "Statskov", Email = $"person1@gmail.com" };
        var person2 = new PersonDb { Id = Guid.NewGuid(), FirstName = "Alexander", LastName = "Statskov", Email = $"person2@gmail.com" };
        var person3 = new PersonDb { Id = Guid.NewGuid(), FirstName = "Alexander", LastName = "Statskov", MiddleName = "Onlivech", Email = $"person3@gmail.com" };
        var person4 = new PersonDb { Id = Guid.NewGuid(), FirstName = "Igor", LastName = "Izmailov", Email = $"person4@gmail.com" };
        var person5 = new PersonDb { Id = Guid.NewGuid(), FirstName = "Eliezer", LastName = "Yudkowsky", Email = $"person5@gmail.com" };
        var person6 = new PersonDb { Id = Guid.NewGuid(), FirstName = "Yana", LastName = "Sharkelova", Email = $"person6@gmail.com" };
        var person7 = new PersonDb { Id = Guid.NewGuid(), FirstName = "Igor", LastName = "Premin", Email = $"person7@gmail.com" };

        var author1 = new AuthorDb { Id = Guid.NewGuid(), FirstName = "Eliezer", LastName = "Yudkowsky" };
        var author2 = new AuthorDb { Id = Guid.NewGuid(), FirstName = "Carl", LastName = "Sagan" };
        var author3 = new AuthorDb { Id = Guid.NewGuid(), FirstName = "Norman", LastName = "Doidge" };
        var author4 = new AuthorDb { Id = Guid.NewGuid(), FirstName = "Stephen", LastName = "King" };
        var author5 = new AuthorDb { Id = Guid.NewGuid(), FirstName = "John", LastName = "Tolkien" };

        var genre1 = new GenreDb { Id = Guid.NewGuid(), Name = "Fantasy" };
        var genre2 = new GenreDb { Id = Guid.NewGuid(), Name = "Scientific literature" };
        var genre3 = new GenreDb { Id = Guid.NewGuid(), Name = "Self-development literature" };
        var genre4 = new GenreDb { Id = Guid.NewGuid(), Name = "Science fiction" };

        var book1 = new BookDb { Id = Guid.NewGuid(), Name = "Harry Potter and the Methods of Rationality", AuthorId = author1.Id, GenreId = genre1.Id };
        var book2 = new BookDb { Id = Guid.NewGuid(), Name = "The Demon-Haunted World: Science as a Candle in the Dark", AuthorId = author2.Id, GenreId = genre2.Id };
        var book3 = new BookDb { Id = Guid.NewGuid(), Name = "The Brains Way of Healing: Remarkable Discoveries and Recoveries from the Frontiers of Neuroplasticity", AuthorId = author3.Id, GenreId = genre3.Id };
        var book4 = new BookDb { Id = Guid.NewGuid(), Name = "Contact", AuthorId = author2.Id, GenreId = genre4.Id };
        var book5 = new BookDb { Id = Guid.NewGuid(), Name = "The Lord of the Rings", AuthorId = author5.Id, GenreId = genre1.Id };
        var book6 = new BookDb { Id = Guid.NewGuid(), Name = "The Hobbit, or There and Back Again", AuthorId = author5.Id , GenreId = genre1.Id };
        var book7 = new BookDb { Id = Guid.NewGuid(), Name = "It", AuthorId = author4.Id, GenreId = genre1.Id };

        var card1 = new LibraryCardDb { Id = Guid.NewGuid(), PersonId = person1.Id, BookId = book3.Id, DateBookReceived = DateTime.Now };
        var card2 = new LibraryCardDb { Id = Guid.NewGuid(), PersonId = person1.Id, BookId = book4.Id, DateBookReceived = DateTime.Now };
        var card3 = new LibraryCardDb { Id = Guid.NewGuid(), PersonId = person2.Id, BookId = book5.Id, DateBookReceived = DateTime.Now };
        var card4 = new LibraryCardDb { Id = Guid.NewGuid(), PersonId = person3.Id, BookId = book6.Id, DateBookReceived = DateTime.Now };
        var card5 = new LibraryCardDb { Id = Guid.NewGuid(), PersonId = person3.Id, BookId = book2.Id, DateBookReceived = DateTime.Now };

        modelBuilder.Entity<PersonDb>().HasData(person1, person2, person3, person4, person5, person6, person7);
        modelBuilder.Entity<AuthorDb>().HasData(author1, author2, author3, author4, author5);
        modelBuilder.Entity<GenreDb>().HasData(genre1, genre2, genre3, genre4);
        modelBuilder.Entity<BookDb>().HasData(book1, book2, book3, book4, book5, book6, book7);
        modelBuilder.Entity<LibraryCardDb>().HasData(card1, card2, card3, card4, card5);

        return modelBuilder;
    }
}