using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IAuthorRepository : IRepository<Author>
{
    IEnumerable<Book> GetBooksByAuthor(Guid authorId);
}