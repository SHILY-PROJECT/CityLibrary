using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Domain.Models;
using Domain.Interfaces.Repositories;
using DataAccess.Entities;

namespace DataAccess.Repositories;

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
        var predicates = new List<Predicate<PersonDb>>();

        if (new[] { person.FirstName, person.LastName, person.MiddleName }.All(p => string.IsNullOrEmpty(p))) return false;

        if (!string.IsNullOrEmpty(person.FirstName))
            predicates.Add(new Predicate<PersonDb>((PersonDb personEntity) => personEntity.FirstName.Equals(person.FirstName, StringComparison.OrdinalIgnoreCase)));
        if (!string.IsNullOrEmpty(person.LastName))
            predicates.Add(new Predicate<PersonDb>((PersonDb personEntity) => personEntity.LastName.Equals(person.LastName, StringComparison.OrdinalIgnoreCase)));
        if (!string.IsNullOrEmpty(person.MiddleName))
            predicates.Add(new Predicate<PersonDb>((PersonDb personEntity) => personEntity.MiddleName.Equals(person.MiddleName, StringComparison.OrdinalIgnoreCase)));

        var personsEntities = await _context.Persons.Where(personEntity => predicates.All(p => p.Invoke(personEntity))).ToArrayAsync();

        _context.Persons.RemoveRange(personsEntities);
        await _context.SaveChangesAsync();

        return true;
    }
}