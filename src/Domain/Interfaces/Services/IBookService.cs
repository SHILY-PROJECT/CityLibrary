using Domain.Enums;
using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IBookService : ICRUDServiceOperations<Book>
{
    IReadOnlyCollection<Book> GetBooksByGenre(Guid genreId, BookSortType sortType);
    IReadOnlyCollection<Book> GetBooksByAuthor(Guid authorId, BookSortType sortType);
    IReadOnlyCollection<Book> GetBooksByAuthor(Author author, BookSortType sortType);
}