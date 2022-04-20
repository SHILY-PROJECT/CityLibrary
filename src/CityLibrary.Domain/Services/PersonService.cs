using CityLibrary.Domain.Models;
using CityLibrary.Domain.Interfaces.Services;
using CityLibrary.Domain.Interfaces.Repositories;

namespace CityLibrary.Domain.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;

    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<Person?> GetAsync(Guid id)
    {
        return await _personRepository.GetAsync(id);
    }

    public async Task<IReadOnlyCollection<Person>> GetAllAsync()
    {
        return (await _personRepository.GetAllAsync()).ToArray();
    }

    public async Task<Person> NewAsync(Person model)
    {
        return await _personRepository.NewAsync(model);
    }

    public async Task<Person> UpdateAsync(Guid id, Person model)
    {
        return await _personRepository.UpdateAsync(id, model);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _personRepository.DeleteAsync(id);
    }

    public async Task<bool> DeleteAsync(Person person)
    {
        return await _personRepository.DeleteAsync(person);
    }

    public async Task<IReadOnlyCollection<Book>> GetPersonBooksAsync(Guid personId)
    {
        return (await _personRepository.GetPersonBooksAsync(personId)).ToArray();
    }

    public async Task<bool> TakeBookAsync(Guid personeId, Guid bookId)
    {
        return await _personRepository.TakeBookAsync(personeId, bookId);
    }

    public async Task<bool> ReturnBookAsync(Guid personeId, Guid bookId)
    {
        return await _personRepository.ReturnBookAsync(personeId, bookId);
    }
}