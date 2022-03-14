using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IPersonService : ICRUDServiceOperations<Person>
{
    Task<IReadOnlyCollection<Book>> GetPersonBooksAsync(Guid personId);
    Task<bool> DeleteAsync(Person person);
    Task<bool> TakeBookAsync(Guid personeId, Guid bookId);
    Task<bool> ReturnBookAsync(Guid personeId, Guid bookId);
}