using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CityLibrary.Domain.Models;
using CityLibrary.Domain.Interfaces.Repositories;
using CityLibrary.DataAccess.Entities;

namespace CityLibrary.DataAccess.Repositories;

public sealed class PersonRepository : BaseRepository<Person, PersonDb>, IPersonRepository
{
    private readonly CityLibraryDbContext _context;
    private readonly IMapper _mapper;

    public PersonRepository(CityLibraryDbContext context, IMapper mapper) : base(context, context.Persons, mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Book>> GetPersonBooksAsync(Guid personId)
    {
        var books = await _context.LibraryCards
            .Where(card => card.PersonId == personId)
            .Include(card => card.Book)
            .ToArrayAsync();

        return _mapper.Map<IEnumerable<Book>>(books);
    }

    public async Task<bool> ReturnBookAsync(Guid personeId, Guid bookId)
    {
        var card = await _context.LibraryCards.FirstOrDefaultAsync(card => card.PersonId == personeId && card.BookId == bookId);

        if (card is null) return false;

        _context.Entry(card).State = EntityState.Deleted;
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> TakeBookAsync(Guid personeId, Guid bookId)
    {
        var personEntity = await _context.Persons.FirstOrDefaultAsync(person => person.Id == personeId);
        var bookEntity = await _context.Books.FirstOrDefaultAsync(book => book.Id == bookId);

        if (personEntity is null || bookEntity is null) return false;

        var card = new LibraryCardDb
        {
            DateBookReceived = DateTime.Now,
            PersonId = personeId,
            Person = personEntity,
            BookId = bookId,
            Book = bookEntity
        };

        _context.LibraryCards.Add(card);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(Person person)
    {
        var personsEntities = _context.Persons.AsQueryable();

        if (!string.IsNullOrEmpty(person.FirstName))
            personsEntities = personsEntities.Where(personEntity =>
                EF.Functions.Like(personEntity.FirstName, person.FirstName) && personEntity.FirstName.Length == person.FirstName.Length);

        if (!string.IsNullOrEmpty(person.LastName))
            personsEntities = personsEntities.Where(personEntity =>
                EF.Functions.Like(personEntity.LastName, person.LastName) && personEntity.LastName.Length == person.LastName.Length);

        if (!string.IsNullOrEmpty(person.MiddleName))
            personsEntities = personsEntities.Where(personEntity =>
                EF.Functions.Like(personEntity.MiddleName, person.MiddleName) && personEntity.MiddleName.Length == person.MiddleName.Length);

        if (!string.IsNullOrEmpty(person.MiddleName))
            personsEntities = personsEntities.Where(personEntity =>
                EF.Functions.Like(personEntity.Email, person.Email) && personEntity.Email.Length == person.Email.Length);

        var filteredPersons = await personsEntities.ToArrayAsync();

        if (!filteredPersons.Any()) return false;

        _context.Persons.RemoveRange(filteredPersons);
        await _context.SaveChangesAsync();

        return true;
    }
}