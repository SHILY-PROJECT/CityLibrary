using Domain.Models;
using Domain.Interfaces.Services;
using Domain.Interfaces.Repositories;

namespace Domain.Services;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;

    public GenreService(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public Genre? Get(Guid id)
    {
        return _genreRepository.Get(id);
    }

    public IReadOnlyCollection<Genre> GetAll()
    {
        return _genreRepository.GetAll().ToArray();
    }

    public Genre New(Genre model)
    {
        model.Id = Guid.NewGuid();
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

    public IReadOnlyCollection<GenreStats> GetStats()
    {
        return _genreRepository.GenreStats().ToArray();
    }
}