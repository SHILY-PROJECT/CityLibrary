using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SimbirSoftWorkshop.API.Interfaces;

namespace SimbirSoftWorkshop.API.Controllers
{
    /// <summary>
    /// 2.7 - Контроллер жанра книг
    /// </summary>
    [ApiController]
    [Route("Genres")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository _iGenreRepository;

        public GenresController(IGenreRepository iGenreRepository)
        {
            _iGenreRepository = iGenreRepository;
        }

        /// <summary>
        /// 2.7.4.1 - Получение списка всех жанров
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListAllGenre")]
        public IActionResult GetListGenres()
        {
            try
            {
                return Ok(_iGenreRepository.GetListGenres());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 2.7.4.3 - Получение статистики жанров (жанр - количество книг)
        /// </summary>
        [HttpGet("NumberOfBooksByGenre")]
        public IActionResult GetStatisticsByGenres()
        {
            try
            {
                return Ok(_iGenreRepository.GetStatisticsByGenres());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 2.7.4.2 - Добавление нового жанра
        /// </summary>
        [HttpPost("AddNewGenre")]
        public IActionResult AddGenre([FromQuery][Required][StringLength(200, MinimumLength = 1)] string genreName)
        {
            try
            {
                _iGenreRepository.Add(genreName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Жанр успешно добавлен");
        }

    }
}
