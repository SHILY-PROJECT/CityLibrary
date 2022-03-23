using CityLibrary.Domain.Models;

namespace CityLibrary.Domain.Interfaces.Repositories;

public interface IBookRepository : IRepository<Book>
{
    Task<IEnumerable<Book>> GetBooksByGenreAsync(Guid genreId);
    Task<IEnumerable<Book>> GetBooksByAuthorAsync(Guid authorId);
    Task<IEnumerable<Book>> GetBooksByAuthorAsync(Author author);
}