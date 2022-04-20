using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CityLibrary.DataAccess.Entities;
using CityLibrary.Domain.Interfaces.Repositories;
using CityLibrary.Domain.Models;

namespace CityLibrary.DataAccess.Repositories;

internal class BookRepository : BaseRepository<Book, BookDb>, IBookRepository
{
    private readonly CityLibraryDbContext _context;
    private readonly IMapper _mapper;

    public BookRepository(CityLibraryDbContext context, IMapper mapper) : base(context, context.Books, mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    protected virtual IQueryable<BookDb> BooksAsEagerIQueryable
    {
        get => _context.Books.Include(book => book.Genre).Include(book => book.Author);
    }

    public async Task<IEnumerable<Book>> NewAsync(IEnumerable<Book> books)
    {
        var entities = _mapper.Map<BookDb[]>(books);

        await _context.Books.AddRangeAsync(entities);
        await _context.SaveChangesAsync();

        return _mapper.Map<Book[]>(entities);
    }

    public override async Task<IEnumerable<Book>> GetAllAsync()
    {
        var entities = await BooksAsEagerIQueryable.ToArrayAsync();
        return _mapper.Map<Book[]>(entities);
    }

    public async Task<IEnumerable<Book>> GetBooksByGenreAsync(Guid genreId)
    {
        var books = await BooksAsEagerIQueryable.Where(book => book.GenreId == genreId).ToArrayAsync();
        return _mapper.Map<Book[]>(books);
    }

    public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(Guid authorId)
    {
        var books = await BooksAsEagerIQueryable.Where(book => book.AuthorId == authorId).ToArrayAsync();
        return _mapper.Map<Book[]>(books);
    }

    public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(Author author)
    {
        var booksEntities = BooksAsEagerIQueryable;

        if (!string.IsNullOrWhiteSpace(author.FirstName))
            booksEntities = booksEntities.Where(book => EF.Functions.Like(book.Author.FirstName, author.FirstName));
        if (!string.IsNullOrWhiteSpace(author.LastName))
            booksEntities = booksEntities.Where(book => EF.Functions.Like(book.Author.LastName, author.LastName));
        if (!string.IsNullOrWhiteSpace(author.MiddleName))
            booksEntities = booksEntities.Where(book => EF.Functions.Like(book.Author.MiddleName, author.MiddleName));

        var filteredBooks = await booksEntities.ToArrayAsync();

        return _mapper.Map<Book[]>(filteredBooks);
    }
}