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
        var books = await _context.Books
            .Where(book => book.GenreId == genreId)
            .Include(book => book.Genre)
            .Include(book => book.Author)
            .ToArrayAsync();

        return _mapper.Map<IEnumerable<Book>>(books);
    }

    public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(Guid authorId)
    {
        var books = await _context.Books
            .Where(book => book.AuthorId == authorId)
            .Include(book => book.Genre)
            .Include(book => book.Author)
            .ToArrayAsync();

        return _mapper.Map<IEnumerable<Book>>(books);
    }

    public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(Author author)
    {
        var booksEntities = _context.Books.AsQueryable();

        if (!string.IsNullOrWhiteSpace(author.FirstName))
            booksEntities = booksEntities.Where(book => EF.Functions.Like(book.Author.FirstName, author.FirstName));
        if (!string.IsNullOrWhiteSpace(author.LastName))
            booksEntities = booksEntities.Where(book => EF.Functions.Like(book.Author.LastName, author.LastName));
        if (!string.IsNullOrWhiteSpace(author.MiddleName))
            booksEntities = booksEntities.Where(book => EF.Functions.Like(book.Author.MiddleName, author.MiddleName));

        var filteredBooks = await booksEntities
            .Include(book => book.Genre)
            .Include(book => book.Author)
            .ToArrayAsync();

        return _mapper.Map<IEnumerable<Book>>(filteredBooks);
    }
}