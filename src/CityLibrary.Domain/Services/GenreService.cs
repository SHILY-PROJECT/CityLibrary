using CityLibrary.Domain.Models;
using CityLibrary.Domain.Interfaces.Services;
using CityLibrary.Domain.Interfaces.Repositories;

namespace CityLibrary.Domain.Services;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;

    public GenreService(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<Genre?> GetAsync(Guid id)
    {
        return await _genreRepository.GetAsync(id);
    }

    public async Task<IReadOnlyCollection<Genre>> GetAllAsync()
    {
        var genres = await _genreRepository.GetAllAsync();
        return genres.ToArray();
    }

    public async Task<Genre> NewAsync(Genre model)
    {
        return await _genreRepository.NewAsync(model with { Id = Guid.NewGuid() });
    }

    public async Task<Genre> UpdateAsync(Guid id, Genre model)
    {
        return await _genreRepository.UpdateAsync(id, model);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _genreRepository.DeleteAsync(id);
    }

    public async Task<IReadOnlyCollection<GenreStats>> GetStatsAsync()
    {
        var stats = await _genreRepository.GenreStatsAsync();
        return stats.ToArray();
    }
}