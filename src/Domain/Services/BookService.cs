using Domain.Enums;
using Domain.Models;
using Domain.Interfaces.Services;
using Domain.Interfaces.Repositories;
using Domain.Toolkit.Extensions;

namespace Domain.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public Book? Get(Guid id)
    {
        return _bookRepository.Get(id);
    }

    public IReadOnlyCollection<Book> GetAll()
    {
        return _bookRepository.GetAll().ToArray();
    }

    public Book New(Book model)
    {
        model.Id = Guid.NewGuid();
        return _bookRepository.New(model);
    }

    public Book Update(Guid id, Book model)
    {
        return _bookRepository.Update(id, model);
    }

    public bool Delete(Guid id)
    {
        return _bookRepository.Delete(id);
    }

    public IReadOnlyCollection<Book> GetBooksByAuthor(Guid authorId, BookSortType sortType)
    {
        var books = _bookRepository.GetBooksByAuthor(authorId);
        return books.SortBooks(sortType).ToArray();
    }

    public IReadOnlyCollection<Book> GetBooksByAuthor(Author author, BookSortType sortType)
    {
        var books = _bookRepository.GetBooksByAuthor(author);
        return books.SortBooks(sortType).ToArray();
    }

    public IReadOnlyCollection<Book> GetBooksByGenre(Guid genreId, BookSortType sortType)
    {
        var books = _bookRepository.GetBooksByGenre(genreId);
        return books.SortBooks(sortType).ToArray();
    }
}