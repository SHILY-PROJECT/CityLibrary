using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using WebApi.WebApi.Interfaces;
using WebApi.WebApi.Models.Dto.Authors;

namespace WebApi.WebApi.Controllers
{
    /// <summary>
    /// 2.7 - Контроллер автора
    /// </summary>
    [ApiController]
    [Route("Authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _iAuthorRepository;

        public AuthorsController(IAuthorRepository iAuthorRepository)
        {
            _iAuthorRepository = iAuthorRepository;
        }

        /// <summary>
        /// 2.7.3.1 - Получение списока всех авторов
        /// </summary>
        [HttpGet("ListAllAuthors")]
        public IActionResult GetListAuthors()
        {
            var result = _iAuthorRepository.GetListAuthors();

            if (result.IsSuccess is false)
                return BadRequest(result.Message);

            return Ok(result.Content);
        }

        /// <summary>
        /// 2.7.3.2 - Получение списока всех книг конкретного автора 
        /// </summary>
        [HttpGet("ListBooksByAuthor")]
        public IActionResult GetListBooksByAuthor([FromQuery] AuthorIdDto authorId)
        {
            var result = _iAuthorRepository.GetListBooksByAuthor(authorId);

            if (result.IsSuccess is false)
                return BadRequest(result.Message);

            return Ok(result.Content);
        }

        /// <summary>
        /// 2.7.3.3 - Добавление автора
        /// </summary>
        [HttpPost("AddNewAuthorAndHisBooks")]
        public IActionResult AddAuthor([FromQuery] AuthorDto author, [FromQuery] IEnumerable<AuthorNewBookDto> books = null)
        {
            var result = _iAuthorRepository.Add(author, books);

            if (result.IsSuccess is false)
                return BadRequest(result.Message);

            return Ok(result.Content);
        }

        /// <summary>
        /// 2.7.3.4 - Удаление автора 
        /// </summary>
        [HttpDelete("RemoveAuthor")]
        public IActionResult DeleteAuthor([FromQuery] AuthorIdDto authorId)
        {
            var result = _iAuthorRepository.Delete(authorId);

            if (result.IsSuccess is false)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }


    }
}
