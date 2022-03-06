using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IBookRepository
{
    IEnumerable<Book> GetListBooksByGenre(Guid genreId);
    IEnumerable<Book> GetListBooksByAuthor(Author author);
}