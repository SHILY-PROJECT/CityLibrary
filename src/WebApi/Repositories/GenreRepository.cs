using System;
using System.Linq;
using System.Collections.Generic;
using WebApi.WebApi.Models.Entity;
using WebApi.WebApi.Models.Dto.Genres;
using WebApi.WebApi.Toolkit;

namespace WebApi.WebApi.Repositories
{
    //public class GenreRepository : IGenreRepository
    //{
    //    private readonly DataContext _context;
        
    //    /// <summary>
    //    /// 3.1.1 - Конструктор для реализации DI.
    //    /// </summary>
    //    public GenreRepository(DataContext context)
    //    {
    //        _context = context;
    //    }

    //    /// <summary>
    //    /// Получение списка жанров.
    //    /// </summary>
    //    public ResultContent<IEnumerable<Genre>> GetListGenres()
    //    {
    //        try
    //        {
    //            return new ResultContent<IEnumerable<Genre>>().Ok(_context.Genres);
    //        }
    //        catch (Exception ex)
    //        {
    //            return new ResultContent<IEnumerable<Genre>>().Error(ex);
    //        }
    //    }

    //    /// <summary>
    //    /// Добавление нового жанра.
    //    /// </summary>
    //    public ResultContent<Genre> Add(AddGenre addGenre)
    //    {
    //        try
    //        {
    //            var genre = new Genre { GenreName = addGenre.Name };

    //            _context.Genres.Add(genre);
    //            _context.SaveChanges();

    //            return new ResultContent<Genre>().Ok(genre, "Жанр успешно добавлен");
    //        }
    //        catch (Exception ex)
    //        {
    //            return new ResultContent<Genre>().Error(ex);
    //        }
    //    }

    //    /// <summary>
    //    /// Получение статистики по жанрам.
    //    /// </summary>
    //    public ResultContent<IEnumerable<GenreStatisticsDto>> GetStatisticsByGenres()
    //    {
    //        try
    //        {
    //            var statistics = _context.Genres.Select(g => new GenreStatisticsDto
    //            {
    //                GenreId = g.Id,
    //                GenreName = g.GenreName,
    //                NumberOfBooks = g.BookGenre.Count()
    //            });

    //            return new ResultContent<IEnumerable<GenreStatisticsDto>>().Ok(statistics);
    //        }
    //        catch (Exception ex)
    //        {
    //            return new ResultContent<IEnumerable<GenreStatisticsDto>>().Error(ex);
    //        }
    //    }
    //}
}
