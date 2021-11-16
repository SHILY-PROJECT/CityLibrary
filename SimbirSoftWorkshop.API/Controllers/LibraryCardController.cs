using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimbirSoftWorkshop.API.Models;
using System.ComponentModel.DataAnnotations;

namespace SimbirSoftWorkshop.API.Controllers
{
    /// <summary>
    /// 2.1.2 - Контроллер библиотечной карточки
    /// </summary>
    [ApiController]
    [Route("LibraryCard")]
    public class LibraryCardController : ControllerBase
    {
        [HttpGet("listAllLibraryCards")]
        public IActionResult GetLibraryCards()
            => Ok(DataStore.LibraryCards);

        /// <summary>
        /// 2.1.4 - Метод отвечающий за взятие книги читателем
        /// </summary>
        /// <param name="humanId">Идентификатор человека</param>
        /// <param name="titleBook">Название книги</param>
        /// <param name="nameAuthorBook">Имя автора</param>
        /// <param name="surnameAuthorBook">Фамилия автора</param>
        [HttpPost("addHumanReaderToLibraryCard")]
        public IActionResult PostAddHumanReaderToLibraryCard([Required] long humanId, [Required] long bookId)
        {
            var human = DataStore.Humans.FirstOrDefault(x => x.Id == humanId);

            if (human == null)
                return ValidationProblem($"['{nameof(humanId)}: {humanId}' - данный пользователь отсутствует в базе.");

            var book = DataStore.Books.FirstOrDefault(x => x.Id == bookId);

            if (book == null)
                return ValidationProblem($"{nameof(bookId)}: {bookId}' - книги по вашему запросу не найдено.");           

            var libraryCard = new LibraryCardDetailDto
            {
                Human = human,
                Book = book,
                Id = (DataStore.LibraryCards.Max(x => x.Id) + 1)
            };
            DataStore.LibraryCards.Add(libraryCard);

            return Ok(libraryCard);
        }
    }
}
