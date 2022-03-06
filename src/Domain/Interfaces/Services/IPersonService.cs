using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IPersonService : ICRUDServiceOperations<Person>
{
    bool Delete(Person person);
    IReadOnlyCollection<Book> GetPersonBooks(Guid personId);
    bool TakeBook(Guid personeId, Guid bookId);
    bool ReturnBook(Guid personeId, Guid bookId);
}