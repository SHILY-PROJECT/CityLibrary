using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IAuthorService : ICRUDServiceOperations<Author>
{
    (Author Author, IReadOnlyCollection<Book> Books) New(Author author, IEnumerable<Book> books);
    IReadOnlyCollection<Book> GetBooksByAuthor(Guid authorId);
}