using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SimbirSoftWorkshop.API.Enums;
using SimbirSoftWorkshop.API.Interfaces;
using SimbirSoftWorkshop.API.Models.ViewModel;

namespace SimbirSoftWorkshop.API.Controllers
{
    [ApiController]
    [Route("Books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _iBookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _iBookRepository = bookRepository;
        }

        /// <summary>
        /// 2.7.2.4. - Получение списка книг с фильтром по автору
        /// </summary>
        [HttpGet("ListBookByAuthor")]
        public IActionResult GetListBooksByAuthor(
            [FromQuery] FullNameDto fullName,
            [FromQuery] BookSortingTypeEnum sortingType)
        {
            try
            {
                return Ok(_iBookRepository.GetListBooksByAuthor(fullName, sortingType));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 2.7.2.5 - Получение списка книг по жанру
        /// </summary>
        [HttpGet("ListBooksByGenreId")]
        public IActionResult GetListBooksByGenre(
            [FromQuery][Required] int genreId,
            [FromQuery] BookSortingTypeEnum sortingType)
        {
            try
            {
                return Ok(_iBookRepository.GetListBooksByGenre(genreId, sortingType));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 2.7.2.1 - Добавление новой книги
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost("AddNewBook")]
        public IActionResult AddBook(
            [FromQuery][Required][StringLength(500, MinimumLength = 1)] string nameBook,
            [FromQuery][Required] int genreId,
            [FromQuery][Required] int authorId)
        {
            try
            {
                _iBookRepository.Add(nameBook, genreId, authorId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Книга успешно добавлена");
        }

        /// <summary>
        /// 2.7.2.3 - Обновление жанр книги
        /// </summary>
        [HttpPut("UpdateGenreBook")]
        public IActionResult UpdateGenreBook([FromBody] BookUpdateGenreDto bookUpdateGenre)
        {
            try
            {
                return Ok(_iBookRepository.UpdateGenre(bookUpdateGenre));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 7.2.2 - Удаление книги из списка библиотеки 
        /// </summary>
        [HttpDelete("RemoveBookById")]
        public IActionResult DeleteBook([FromBody][Required] int bookId)
        {
            try
            {
                _iBookRepository.Delete(bookId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Книга успешно удалена");
        }
    }
}
