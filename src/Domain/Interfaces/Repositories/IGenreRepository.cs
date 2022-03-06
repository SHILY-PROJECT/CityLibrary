using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IGenreRepository : IRepository<Genre>
{
    IEnumerable<GenreStats> GetStatistics();
}