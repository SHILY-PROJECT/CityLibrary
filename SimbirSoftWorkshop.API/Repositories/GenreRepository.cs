using System.Linq;
using System.Collections.Generic;
using SimbirSoftWorkshop.API.Interfaces;
using SimbirSoftWorkshop.API.Models.ViewModel;
using SimbirSoftWorkshop.API.Models.DatabaseModels;

namespace SimbirSoftWorkshop.API.Repositories
{
    /// <summary>
    /// 2.6 - Репозиторий жанра
    /// </summary>
    public class GenreRepository : IGenreRepository
    {
        private readonly DataContext _context;
        
        public GenreRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetListGenres()
        {
            return _context.Genres;
        }

        public void Add(string genreName)
        {
            _context.Genres.Add(new() { GenreName = genreName });
            _context.SaveChanges();
        }

        public IEnumerable<GenreStatisticsDto> GetStatisticsByGenres()
        {
            return _context.Genres.Select(g => new GenreStatisticsDto
            {
                GenreId = g.Id,
                GenreName = g.GenreName,
                NumberOfBooks = g.BookGenre.Count()
            });
        }
    }
}
