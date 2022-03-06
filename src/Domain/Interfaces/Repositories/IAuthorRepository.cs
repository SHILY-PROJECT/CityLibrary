using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IAuthorRepository : IRepository<Author>
{
    bool Add(Author author, IEnumerable<Book> books);
    IEnumerable<Book> GetBooksByAuthor(Guid authorId);
}