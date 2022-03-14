using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IGenreRepository : IRepository<Genre>
{
    Task<IEnumerable<GenreStats>> GenreStatsAsync();
}