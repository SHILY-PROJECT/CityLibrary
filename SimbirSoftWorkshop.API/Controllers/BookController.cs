using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimbirSoftWorkshop.API.Models;
using SimbirSoftWorkshop.API.Enums;
using System.ComponentModel.DataAnnotations;

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
        public IActionResult GetBooks([FromQuery] BookSortingTypeEnum bookSortingType)
            => Ok(bookSortingType switch
            {
                BookSortingTypeEnum.NoSort => DataStore.Books,
                BookSortingTypeEnum.Title => DataStore.Books.OrderBy(x => x.Title).ToList(),
                BookSortingTypeEnum.TitleReversed => DataStore.Books.OrderByDescending(y => y.Title).ToList(),
                BookSortingTypeEnum.Author => DataStore.Books.OrderBy(x => x.Author).ToList(),
                BookSortingTypeEnum.AuthorReversed => DataStore.Books.OrderByDescending(y => y.Author).ToList(),
                BookSortingTypeEnum.Genre => DataStore.Books.OrderBy(x => x.Genre).ToList(),
                BookSortingTypeEnum.GenreReversed => DataStore.Books.OrderByDescending(y => y.Genre).ToList(),
                _ => DataStore.Books
            });       

        /// <summary>
        /// 1.4.1.2 - Список всех книг автора
        /// </summary>
        /// <returns></returns>
        [HttpGet("listBooksByAuthorId")]
        public IActionResult GetBooksByAuthorId([Required][FromQuery] long authorId)
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
        public IActionResult PostAddBook([FromForm] BookDto book)
        {
            var bookDetail = (BookDetailDto)book;
            var existingAuthor = DataStore.Books.FirstOrDefault(x => x.Author.Equals(bookDetail.Author, StringComparison.OrdinalIgnoreCase));
            bookDetail.AuthorId = existingAuthor != null ? existingAuthor.AuthorId : (DataStore.Books.Max(x => x.AuthorId) + 1);

            if (DataStore.Books.FirstOrDefault(x => x.Author == bookDetail.Author && x.AuthorId == bookDetail.AuthorId && x.Title.Contains(bookDetail.Title)) != null)
                return BadRequest("Книга уже существует");

            bookDetail.Id = (DataStore.Books.Max(x => x.Id) + 1);
            DataStore.Books.Add(bookDetail);

            return Ok("Книга успешно добавлен");
        }

        /// <summary>
        /// 1.4.3 - Удаление книги
        /// </summary>
        /// <param name="title">Название</param>
        /// <param name="authorName">Имя автора</param>
        /// <param name="authorSurname">Фамилия автора</param>
        /// <returns></returns>
        [HttpDelete("removingBookFromList")]
        public IActionResult DeleteBook([Required][FromQuery] long bookId)
        {
            for (int i = 0; i < DataStore.Books.Count;)
            {
                if (DataStore.Books[i].Id == bookId)
                {
                    DataStore.Books.RemoveAt(i);
                    return Ok("Книга успешно удалена");
                }
                else i++;
            }

            return BadRequest("Не удалось удалить книгу");
        }


        
    }
}
