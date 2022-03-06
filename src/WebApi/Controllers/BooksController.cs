using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using WebApi.WebApi.Enums;
using WebApi.WebApi.Interfaces;
using WebApi.WebApi.Models.Dto.Authors;
using WebApi.WebApi.Models.Dto.Books;

namespace WebApi.WebApi.Controllers
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
            [FromQuery] AuthorDto author,
            [FromQuery] BookSortingTypeEnum sortingType)
        {
            var result = _iBookRepository.GetListBooksByAuthor(author, sortingType);

            if (result.IsSuccess is false)
                return BadRequest(result.Message);

            return Ok(result.Content);
        }

        /// <summary>
        /// 2.7.2.5 - Получение списка книг по жанру
        /// </summary>
        [HttpGet("ListBooksByGenreId")]
        public IActionResult GetListBooksByGenre(
            [FromQuery][Required] int genreId,
            [FromQuery] BookSortingTypeEnum sortingType)
        {
            var result = _iBookRepository.GetListBooksByGenre(genreId, sortingType);

            if (result.IsSuccess is false)
                return BadRequest(result.Message);

            return Ok(result.Content);
        }

        /// <summary>
        /// 2.7.2.1 - Добавление новой книги
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost("AddNewBook")]
        public IActionResult AddBook([FromQuery] NewBookDto newBook)
        {
            var result = _iBookRepository.Add(newBook);

            if (result.IsSuccess is false)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        /// <summary>
        /// 2.7.2.3 - Обновление жанр книги
        /// </summary>
        [HttpPut("UpdateGenreBook")]
        public IActionResult UpdateGenreBook([FromBody] UpdateGenreOfBookDto bookUpdateGenre)
        {
            var result = _iBookRepository.UpdateGenre(bookUpdateGenre);

            if (result.IsSuccess is false)
                return BadRequest(result.Message);

            return Ok(result.Content);
        }

        /// <summary>
        /// 7.2.2 - Удаление книги из списка библиотеки 
        /// </summary>
        [HttpDelete("RemoveBookById")]
        public IActionResult DeleteBook([FromBody][Required] int bookId)
        {
            var result = _iBookRepository.Delete(bookId);

            if (result.IsSuccess is false)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
    }
}
