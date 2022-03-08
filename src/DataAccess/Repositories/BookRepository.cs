using AutoMapper;
using DataAccess.Entities;
using Domain.Interfaces.Repositories;
using Domain.Models;

namespace DataAccess.Repositories;

public class BookRepository : BaseRepository<Book, BookDb>, IBookRepository
{
    private readonly CityLibraryDbContext _context;
    private readonly IMapper _mapper;

    public BookRepository(CityLibraryDbContext context, IMapper mapper) : base(context, context.Books, mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Book> GetBooksByGenre(Guid genreId)
    {
        var books = _context.Books.Where(book => book.GenreId == genreId);
        return _mapper.Map<IEnumerable<Book>>(books);
    }

    public IEnumerable<Book> GetBooksByAuthor(Guid authorId)
    {
        var books = _context.Books.Where(book => book.AuthorId == authorId);
        return _mapper.Map<IEnumerable<Book>>(books);
    }

    public IEnumerable<Book> GetBooksByAuthor(Author author)
    {
        var predicates = new List<Predicate<BookDb>>();

        if (!string.IsNullOrWhiteSpace(author.FirstName))
            predicates.Add(new Predicate<BookDb>((BookDb book) => book.Author.FirstName.Equals(author.FirstName, StringComparison.OrdinalIgnoreCase)));
        if (!string.IsNullOrWhiteSpace(author.LastName))
            predicates.Add(new Predicate<BookDb>((BookDb book) => book.Author.LastName.Equals(author.LastName, StringComparison.OrdinalIgnoreCase)));
        if (!string.IsNullOrWhiteSpace(author.MiddleName))
            predicates.Add(new Predicate<BookDb>((BookDb book) => book.Author.MiddleName.Equals(author.MiddleName, StringComparison.OrdinalIgnoreCase)));

        var booksEntities = _context.Books.Where(book => predicates.All(p => p.Invoke(book)));

        return _mapper.Map<IEnumerable<Book>>(booksEntities);
    }
}