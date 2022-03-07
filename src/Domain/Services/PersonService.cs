using Domain.Models;
using Domain.Interfaces.Services;
using Domain.Interfaces.Repositories;

namespace Domain.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;

    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public Person? Get(Guid id)
    {
        return _personRepository.Get(id);
    }

    public IReadOnlyCollection<Person> GetAll()
    {
        return _personRepository.GetAll().ToArray();
    }

    public Person New(Person model)
    {
        return _personRepository.New(model);
    }

    public Person Update(Guid id, Person model)
    {
        return _personRepository.Update(id, model);
    }

    public bool Delete(Guid id)
    {
        return _personRepository.Delete(id);
    }

    public bool Delete(Person person)
    {
        return _personRepository.Delete(person);
    }

    public IReadOnlyCollection<Book> GetPersonBooks(Guid personId)
    {
        return _personRepository.GetPersonBooks(personId).ToArray();
    }

    public bool TakeBook(Guid personeId, Guid bookId)
    {
        return _personRepository.TakeBook(personeId, bookId);
    }

    public bool ReturnBook(Guid personeId, Guid bookId)
    {
        return _personRepository.ReturnBook(personeId, bookId);
    }
}