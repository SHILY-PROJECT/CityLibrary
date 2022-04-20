using CityLibrary.Domain.Enums;
using CityLibrary.Domain.Models;
using CityLibrary.Domain.Interfaces.Services;
using CityLibrary.Domain.Interfaces.Repositories;
using CityLibrary.Domain.Toolkit.Extensions;

namespace CityLibrary.Domain.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Book?> GetAsync(Guid id)
    {
        return await _bookRepository.GetAsync(id);
    }

    public async Task<IReadOnlyCollection<Book>> GetAllAsync()
    {
        return (await _bookRepository.GetAllAsync()).ToArray();
    }

    public async Task<Book> NewAsync(Book model)
    {
        return await _bookRepository.NewAsync(model with { Id = Guid.NewGuid() });
    }

    public async Task<IReadOnlyCollection<Book>> NewAsync(IEnumerable<Book> books)
    {
        return (await _bookRepository.NewAsync(books.Select(b => b with { Id = Guid.NewGuid() }))).ToArray();
    }

    public async Task<Book> UpdateAsync(Guid id, Book model)
    {
        return await _bookRepository.UpdateAsync(id, model);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _bookRepository.DeleteAsync(id);
    }

    public async Task<IReadOnlyCollection<Book>> GetBooksByAuthorAsync(Guid authorId, BookSortType sortType)
    {
        return (await _bookRepository.GetBooksByAuthorAsync(authorId)).SortBooks(sortType).ToArray();
    }

    public async Task<IReadOnlyCollection<Book>> GetBooksByAuthorAsync(Author author, BookSortType sortType)
    {
        return (await _bookRepository.GetBooksByAuthorAsync(author)).SortBooks(sortType).ToArray();
    }

    public async Task<IReadOnlyCollection<Book>> GetBooksByGenreAsync(Guid genreId, BookSortType sortType)
    {
        return (await _bookRepository.GetBooksByGenreAsync(genreId)).SortBooks(sortType).ToArray();
    }
}