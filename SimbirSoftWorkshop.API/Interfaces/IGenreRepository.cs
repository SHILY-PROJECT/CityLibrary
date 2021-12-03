using System.Collections.Generic;
using SimbirSoftWorkshop.API.Models.DatabaseModels;
using SimbirSoftWorkshop.API.Models.ViewModel;

namespace SimbirSoftWorkshop.API.Interfaces
{
    public interface IGenreRepository
    {
        public IEnumerable<Genre> GetListGenres();
        public void Add(string genreNmae);
        public IEnumerable<GenreStatisticsDto> GetStatisticsByGenres();
    }
}
