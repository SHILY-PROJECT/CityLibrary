using System.Collections.Generic;
using SimbirSoftWorkshop.API.Toolkit;
using SimbirSoftWorkshop.API.Models.Dto.Genres;
using SimbirSoftWorkshop.API.Models.Entity;

namespace SimbirSoftWorkshop.API.Interfaces
{
    /// <summary>
    /// 3.1.1 - Интерфейс жанра для реализации DI.
    /// </summary>
    public interface IGenreRepository
    {
        /// <summary>
        /// Получение списка жанров.
        /// </summary>
        public ResultContent<IEnumerable<Genre>> GetListGenres();

        /// <summary>
        /// Добавление нового жанра.
        /// </summary>
        public ResultContent<Genre> Add(AddGenre genreNmae);

        /// <summary>
        /// Получение статистики по жанрам.
        /// </summary>
        public ResultContent<IEnumerable<GenreStatisticsDto>> GetStatisticsByGenres();
    }
}
