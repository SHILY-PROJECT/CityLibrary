using CityLibrary.Domain.Models;

namespace CityLibrary.Domain.Interfaces.Repositories;

public interface IAuthorRepository : IRepository<Author>
{
    Task<IEnumerable<Book>> GetBooksByAuthorAsync(Guid authorId);
}