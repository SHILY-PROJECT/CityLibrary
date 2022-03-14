using Domain.Models;
using Domain.Interfaces.Services;
using Domain.Interfaces.Repositories;

namespace Domain.Services;

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
        model.Id = Guid.NewGuid();
        return await _authorRepository.NewAsync(model);
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
        author.Id = Guid.NewGuid();
        var newAuthor = await _authorRepository.NewAsync(author);

        books.ToList().ForEach(async book =>
        {
            book.Id = Guid.NewGuid();
            book.Author = newAuthor;
            book = await _bookRepository.NewAsync(book);
        });

        return (newAuthor, books.ToArray());
    }
}