using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IAuthorRepository : IRepository<Author>
{
    Task<IEnumerable<Book>> GetBooksByAuthorAsync(Guid authorId);
}