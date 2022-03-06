using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IPersonRepository : IRepository<Person>
{
    bool Delete(Person person);
    IEnumerable<Book> GetPersonBooks(Guid personId);
    bool TakeBook(Guid personeId, Guid bookId);
    bool ReturnBook(Guid personeId, Guid bookId);
}