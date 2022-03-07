using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IBookRepository : IRepository<Book>
{
    IEnumerable<Book> GetBooksByGenre(Guid genreId);
    IEnumerable<Book> GetBooksByAuthor(Guid authorId);
    IEnumerable<Book> GetBooksByAuthor(Author author);
}