using CityLibrary.Domain.Models;

namespace CityLibrary.Domain.Interfaces.Services;

public interface IAuthorService : ICRUDServiceOperations<Author>
{
    Task<IReadOnlyCollection<Book>> GetBooksByAuthorAsync(Guid authorId);
}