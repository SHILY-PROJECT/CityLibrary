using CityLibrary.Domain.Models;

namespace CityLibrary.Domain.Interfaces.Services;

public interface IGenreService : ICRUDServiceOperations<Genre>
{
    Task<IReadOnlyCollection<GenreStats>> GetStatsAsync();
}