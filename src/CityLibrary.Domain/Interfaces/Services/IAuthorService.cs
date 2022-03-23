using CityLibrary.Domain.Models;

namespace CityLibrary.Domain.Interfaces.Services;

public interface IAuthorService : ICRUDServiceOperations<Author>
{
    Task<(Author Author, IReadOnlyCollection<Book> Books)> NewAsync(Author author, IEnumerable<Book> books);
    Task<IReadOnlyCollection<Book>> GetBooksByAuthorAsync(Guid authorId);
}