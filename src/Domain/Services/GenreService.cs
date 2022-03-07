using Domain.Models;
using Domain.Interfaces.Services;
using Domain.Interfaces.Repositories;

namespace Domain.Services;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;
    private readonly IBookRepository _bookRepository;

    public GenreService(IGenreRepository genreRepository, IBookRepository bookRepository)
    {
        _genreRepository = genreRepository;
        _bookRepository = bookRepository;
    }

    public Genre? Get(Guid id)
    {
        return _genreRepository.Get(id);
    }

    public IReadOnlyCollection<Genre> GetAll()
    {
        return _genreRepository.GetAll().ToArray();
    }

    public IReadOnlyCollection<GenreStats> GetStats()
    {
        var books = _bookRepository.GetAll();
        var genres = _genreRepository.GetAll();

        var stats = genres.Select(genre => new GenreStats
        {
            Genre = genre,
            Quantity = books.Count(book => book.Genre.Id == genre.Id)
        });

        return stats.ToArray();
    }

    public Genre New(Genre model)
    {
        return _genreRepository.New(model);
    }

    public Genre Update(Guid id, Genre model)
    {
        return _genreRepository.Update(id, model);
    }

    public bool Delete(Guid id)
    {
        return _genreRepository.Delete(id);
    }
}