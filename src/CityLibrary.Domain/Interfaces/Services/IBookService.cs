using CityLibrary.Domain.Enums;
using CityLibrary.Domain.Models;

namespace CityLibrary.Domain.Interfaces.Services;

public interface IBookService : ICRUDServiceOperations<Book>
{
    Task<IReadOnlyCollection<Book>> GetBooksByGenreAsync(Guid genreId, BookSortType sortType);
    Task<IReadOnlyCollection<Book>> GetBooksByAuthorAsync(Guid authorId, BookSortType sortType);
    Task<IReadOnlyCollection<Book>> GetBooksByAuthorAsync(Author author, BookSortType sortType);
}