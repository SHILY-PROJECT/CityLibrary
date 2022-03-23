using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CityLibrary.DataAccess.Entities;
using CityLibrary.Domain.Interfaces.Repositories;
using CityLibrary.Domain.Models;

namespace CityLibrary.DataAccess.Repositories;

public sealed class BookRepository : BaseRepository<Book, BookDb>, IBookRepository
{
    private readonly CityLibraryDbContext _context;
    private readonly IMapper _mapper;

    public BookRepository(CityLibraryDbContext context, IMapper mapper) : base(context, context.Books, mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Book>> GetBooksByGenreAsync(Guid genreId)
    {
        var books = await _context.Books.Where(book => book.GenreId == genreId).ToArrayAsync();
        return _mapper.Map<IEnumerable<Book>>(books);
    }

    public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(Guid authorId)
    {
        var books = await _context.Books.Where(book => book.AuthorId == authorId).ToArrayAsync();
        return _mapper.Map<IEnumerable<Book>>(books);
    }

    public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(Author author)
    {
        var predicates = new List<Predicate<BookDb>>();

        if (!string.IsNullOrWhiteSpace(author.FirstName))
            predicates.Add(new Predicate<BookDb>((BookDb book) => book.Author.FirstName.Equals(author.FirstName, StringComparison.OrdinalIgnoreCase)));
        if (!string.IsNullOrWhiteSpace(author.LastName))
            predicates.Add(new Predicate<BookDb>((BookDb book) => book.Author.LastName.Equals(author.LastName, StringComparison.OrdinalIgnoreCase)));
        if (!string.IsNullOrWhiteSpace(author.MiddleName))
            predicates.Add(new Predicate<BookDb>((BookDb book) => book.Author.MiddleName.Equals(author.MiddleName, StringComparison.OrdinalIgnoreCase)));

        var booksEntities = await _context.Books.Where(book => predicates.All(p => p.Invoke(book))).ToArrayAsync();

        return _mapper.Map<IEnumerable<Book>>(booksEntities);
    }
}