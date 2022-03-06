using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IGenreService : ICRUDServiceOperations<Genre>
{
    IReadOnlyCollection<GenreStats> GetStats();
}