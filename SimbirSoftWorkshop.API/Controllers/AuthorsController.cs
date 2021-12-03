using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimbirSoftWorkshop.API.Interfaces;
using SimbirSoftWorkshop.API.Models.ViewModel;

namespace SimbirSoftWorkshop.API.Controllers
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
            try
            {
                return Ok(_iAuthorRepository.GetListAuthors());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 2.7.3.2 - Получение списока всех книг конкретного автора 
        /// </summary>
        [HttpGet("ListBooksByAuthor")]
        public IActionResult GetListBooksByAuthor([FromQuery] int authorId)
        {
            try
            {
                return Ok(_iAuthorRepository.GetListBooksByAuthor(authorId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 2.7.3.3 - Добавление автора
        /// </summary>
        [HttpPost("AddNewAuthorAndHisBooks")]
        public IActionResult AddAuthor([FromQuery] FullNameDto fullName, [FromQuery] List<string> books = null)
        {
            try
            {
                return Ok(_iAuthorRepository.Add(fullName, books));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 2.7.3.4.	Удаление автора 
        /// </summary>
        [HttpDelete("RemoveAuthor")]
        public IActionResult DeleteAuthor([FromQuery] int authorId)
        {
            try
            {
                _iAuthorRepository.Delete(authorId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Автор успешно удален");
        }


    }
}
