using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IPersonRepository : IRepository<Person>
{
    Task<bool> DeleteAsync(Person person);
    Task<IEnumerable<Book>> GetPersonBooksAsync(Guid personId);
    Task<bool> TakeBookAsync(Guid personeId, Guid bookId);
    Task<bool> ReturnBookAsync(Guid personeId, Guid bookId);
}