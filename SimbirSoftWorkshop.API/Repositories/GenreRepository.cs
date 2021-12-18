using System;
using System.Linq;
using System.Collections.Generic;
using SimbirSoftWorkshop.API.Interfaces;
using SimbirSoftWorkshop.API.Models.Entity;
using SimbirSoftWorkshop.API.Models.Dto.Genres;
using SimbirSoftWorkshop.API.Toolkit;

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

        /// <summary>
        /// Получение списка жанров.
        /// </summary>
        /// <returns></returns>
        public ResultContent<IEnumerable<Genre>> GetListGenres()
        {
            try
            {
                return new ResultContent<IEnumerable<Genre>>().Ok(_context.Genres);
            }
            catch (Exception ex)
            {
                return new ResultContent<IEnumerable<Genre>>().Error(ex);
            }
        }

        /// <summary>
        /// Добавление нового жанра.
        /// </summary>
        /// <param name="genreName"></param>
        public ResultContent<Genre> Add(string genreName)
        {
            try
            {
                var genre = new Genre { GenreName = genreName };

                _context.Genres.Add(genre);
                _context.SaveChanges();

                return new ResultContent<Genre>().Ok(genre);
            }
            catch (Exception ex)
            {
                return new ResultContent<Genre>().Error(ex);
            }
        }

        /// <summary>
        /// Получение статистики по жанрам.
        /// </summary>
        /// <returns></returns>
        public ResultContent<IEnumerable<GenreStatisticsDto>> GetStatisticsByGenres()
        {
            try
            {
                var statistics = _context.Genres.Select(g => new GenreStatisticsDto
                {
                    GenreId = g.Id,
                    GenreName = g.GenreName,
                    NumberOfBooks = g.BookGenre.Count()
                });

                return new ResultContent<IEnumerable<GenreStatisticsDto>>().Ok(statistics);
            }
            catch (Exception ex)
            {
                return new ResultContent<IEnumerable<GenreStatisticsDto>>().Error(ex);
            }
        }
    }
}
