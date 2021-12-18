using System.Collections.Generic;
using SimbirSoftWorkshop.API.Toolkit;
using SimbirSoftWorkshop.API.Models.Dto.Genres;
using SimbirSoftWorkshop.API.Models.Entity;

namespace SimbirSoftWorkshop.API.Interfaces
{
    public interface IGenreRepository
    {
        public ResultContent<IEnumerable<Genre>> GetListGenres();
        public ResultContent<Genre> Add(string genreNmae);
        public ResultContent<IEnumerable<GenreStatisticsDto>> GetStatisticsByGenres();
    }
}
