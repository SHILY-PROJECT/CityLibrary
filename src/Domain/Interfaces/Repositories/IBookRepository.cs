using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IBookRepository : IRepository<Book>
{
    IEnumerable<Book> GetListBooksByGenre(Guid genreId);
    IEnumerable<Book> GetListBooksByAuthor(Author author);
}