using CityLibrary.Domain.Models;
using CityLibrary.Domain.Interfaces.Services;
using CityLibrary.Domain.Interfaces.Repositories;

namespace CityLibrary.Domain.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IBookRepository _bookRepository;

    public AuthorService(IAuthorRepository authorRepository, IBookRepository bookRepository)
    {
        _authorRepository = authorRepository;
        _bookRepository = bookRepository;
    }

    public async Task<Author?> GetAsync(Guid id)
    {
        return await _authorRepository.GetAsync(id);
    }

    public async Task<IReadOnlyCollection<Author>> GetAllAsync()
    {
        var authors = await _authorRepository.GetAllAsync();
        return authors.ToArray();
    }

    public async Task<Author> NewAsync(Author model)
    {
        return await _authorRepository.NewAsync(model with { Id = Guid.NewGuid() });
    }

    public async Task<Author> UpdateAsync(Guid id, Author model)
    {
        return await _authorRepository.UpdateAsync(id, model);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _authorRepository.DeleteAsync(id);
    }

    public async Task<IReadOnlyCollection<Book>> GetBooksByAuthorAsync(Guid authorId)
    {
        var books = await _authorRepository.GetBooksByAuthorAsync(authorId);
        return books.ToArray();
    }

    public async Task<(Author Author, IReadOnlyCollection<Book> Books)> NewAsync(Author author, IEnumerable<Book> books)
    {
        var newAuthor = await _authorRepository.NewAsync(author with { Id = Guid.NewGuid() });

        books.ToList().ForEach(async book =>
        {
            book = await _bookRepository.NewAsync(book with
            {
                Id = Guid.NewGuid(),
                Author = newAuthor
            });
        });

        return (newAuthor, books.ToArray());
    }
}