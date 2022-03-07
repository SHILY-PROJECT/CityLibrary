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

    public Author? Get(Guid id)
    {
        return _authorRepository.Get(id);
    }

    public IReadOnlyCollection<Author> GetAll()
    {
        return _authorRepository.GetAll().ToArray();
    }

    public IReadOnlyCollection<Book> GetBooksByAuthor(Guid authorId)
    {
        return _authorRepository.GetBooksByAuthor(authorId).ToArray();
    }

    public (Author Author, IReadOnlyCollection<Book> Books) New(Author author, IEnumerable<Book> books)
    {
        author.Id = Guid.NewGuid();
        var newAuthor = _authorRepository.New(author);

        books.ToList().ForEach(book =>
        {
            book.Id = Guid.NewGuid();
            book.Author = newAuthor;
            book = _bookRepository.New(book);
        });

        return (newAuthor, books.ToArray());
    }

    public Author New(Author model)
    {
        return _authorRepository.New(model);
    }

    public Author Update(Guid id, Author model)
    {
        return _authorRepository.Update(id, model);
    }

    public bool Delete(Guid id)
    {
        return _authorRepository.Delete(id);
    }
}