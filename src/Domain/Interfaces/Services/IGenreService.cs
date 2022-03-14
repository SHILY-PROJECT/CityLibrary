using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IGenreService : ICRUDServiceOperations<Genre>
{
    Task<IReadOnlyCollection<GenreStats>> GetStatsAsync();
}