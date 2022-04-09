using CityLibrary.Domain.Models;

namespace CityLibrary.Domain.Interfaces.Repositories;

public interface IGenreRepository : IRepository<Genre>
{
    Task<IEnumerable<GenreStats>> GenreStatsAsync();
}