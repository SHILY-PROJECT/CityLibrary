using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimbirSoftWorkshop.API.Models;

namespace SimbirSoftWorkshop.API.Controllers
{
    /// <summary>
    /// 1.4 - Контроллер книги
    /// </summary>
    [ApiController]
    [Route("Book")]
    public class BookController : ControllerBase
    {
        /// <summary>
        /// 1.4.1.1 - Список всех книг
        /// </summary>
        [HttpGet("listAllBooks")]
        public IActionResult GetBooks()
            => Ok(DataStore.Books);

        /// <summary>
        /// 1.4.1.2 - Список всех книг автора
        /// </summary>
        /// <returns></returns>
        [HttpGet("listBooksByAuthorId")]
        public IActionResult GetBooksByAuthorId(long authorId)
            => Ok(DataStore.Books.Where(x => x.AuthorId == authorId).ToList());
        
        /// <summary>
        /// 1.4.2 - Добавление новой книги
        /// </summary>
        /// <param name="title">Название</param>
        /// <param name="genre">Жанр</param>
        /// <param name="nameAuthor">Имя автора</param>
        /// <param name="surnameAuthor">Фамилия автора</param>
        /// <returns></returns>
        [HttpPost("addNewBookToList")]
        public IActionResult PostAddBook(string title, string genre, string nameAuthor, string surnameAuthor)
        {
            var variables = new List<(string nameVar, string valueVar)>
            {
                (nameof(title), title), (nameof(genre), genre), (nameof(nameAuthor), nameAuthor), (nameof(surnameAuthor), surnameAuthor),
            }
            .Where(x => string.IsNullOrWhiteSpace(x.valueVar)).ToList();

            if (variables.Count != 0)
                return ValidationProblem(string.Join(", ", variables.Select(x => $"['{x.nameVar}' - не может быть нулевым или пустым.]")));

            var book = new BookDto()
            {
                Title = title,
                Genre = genre,
                Author = $"{FormatString(nameAuthor)} {FormatString(surnameAuthor)}",
            };
            var existingAuthor = DataStore.Books.FirstOrDefault(x => x.Author == book.Author);
            book.AuthorId = existingAuthor != null ? existingAuthor.AuthorId : (DataStore.Books.Max(x => x.AuthorId) + 1);

            if (DataStore.Books.FirstOrDefault(x => x.Author == book.Author && x.AuthorId == book.AuthorId && x.Title.Contains(book.Title)) != null)
                return BadRequest("Книга уже существует");

            DataStore.Books.Add(book);

            if (!DataStore.Books.Contains(book))
                return BadRequest("Не удалось добавить книгу");

            return Ok("Книга успешно добавлен");
        }

        /// <summary>
        /// 1.4.3 - Удаление книги
        /// </summary>
        /// <param name="title">Название</param>
        /// <param name="authorName">Имя автора</param>
        /// <param name="authorSurname">Фамилия автора</param>
        /// <returns></returns>
        [HttpDelete("deleteBookFromList")]
        public IActionResult DeleteBook(string title, string authorName, string authorSurname)
        {
            var variables = new List<(string nameVar, string valueVar)>
            {
                (nameof(title), title), (nameof(authorName), authorName), (nameof(authorSurname), authorSurname),
            }
            .Where(x => string.IsNullOrWhiteSpace(x.valueVar)).ToList();

            if (variables.Count != 0)
                return ValidationProblem(string.Join(", ", variables.Select(x => $"['{x.nameVar}' - не может быть нулевым или пустым.]")));

            for (int i = 0; i < DataStore.Books.Count;)
            {
                var item = DataStore.Books[i];

                if (item.Title.Contains(title, StringComparison.OrdinalIgnoreCase) && item.Author.Equals($"{authorName} {authorSurname}", StringComparison.OrdinalIgnoreCase))
                {
                    DataStore.Books.RemoveAt(i);
                    return Ok("Книга успешно удалена");
                }
                else i++;
            }

            return BadRequest("Не удалось удалить книгу");
        }

        private static string FormatString(string author)
            => new(author.Select((value, index) => index == 0 ? char.ToUpper(value) : char.ToLower(value)).ToArray());
    }
}
