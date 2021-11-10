using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimbirSoftWorkshop.API.Models;

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
        public IActionResult PostAddHumanReaderToLibraryCard(long humanId, string titleBook, string nameAuthorBook, string surnameAuthorBook)
        {
            var variables = new List<(string nameVar, string valueVar)>
            {
                (nameof(titleBook), titleBook), (nameof(nameAuthorBook), nameAuthorBook), (nameof(surnameAuthorBook), surnameAuthorBook)
            }
            .Where(x => string.IsNullOrWhiteSpace(x.valueVar)).ToList();

            if (variables.Count != 0)
                return ValidationProblem(string.Join(", ", variables.Select(x => $"['{x.nameVar}' - не может быть нулевым или пустым.]")));

            var human = DataStore.Humans.FirstOrDefault(x => x.HumanId == humanId);

            if (human == null)
                return ValidationProblem(string.Join(", ", variables.Select(x => $"['{humanId}' - данный пользователь отсутствует в базе.")));

            var book = DataStore.Books.FirstOrDefault(x => x.Title.Contains(titleBook, StringComparison.OrdinalIgnoreCase)
                && x.Author.Equals($"{nameAuthorBook} {surnameAuthorBook}", StringComparison.OrdinalIgnoreCase));

            if (book == null)
                return ValidationProblem(string.Join(", ", variables.Select(x => $"['{humanId}' - книги по вашему запросу не найдено.")));

            var libraryCard = new LibraryCardDto
            {
                Human = human,
                Book = book,
                BookReceiptDate = DateTime.Now
            };

            DataStore.LibraryCards.Add(libraryCard);

            if (!DataStore.LibraryCards.Contains(libraryCard))
                return BadRequest("Не удалось добавить библиотечную карточку");

            return Ok(libraryCard);
        }
    }
}
