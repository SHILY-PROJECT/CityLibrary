using SimbirSoftWorkshop.API.Models.DatabaseModels;
using SimbirSoftWorkshop.API.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbirSoftWorkshop.API.Interfaces
{
    public interface IGenreRepository
    {
        public IEnumerable<Genre> GetListGenres();
        public void Add(string genreNmae);
        public IEnumerable<GenreStatisticsDto> GetStatisticsByGenres();
    }
}
