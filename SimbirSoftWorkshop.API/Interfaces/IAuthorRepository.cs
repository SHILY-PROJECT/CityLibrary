using System.Collections.Generic;
using SimbirSoftWorkshop.API.Toolkit;
using SimbirSoftWorkshop.API.Models.Dto.Authors;
using SimbirSoftWorkshop.API.Models.Entity;

namespace SimbirSoftWorkshop.API.Interfaces
{
    /// <summary>
    /// 3.1.1 - Интерфейс автора для реализации DI.
    /// </summary>
    public interface IAuthorRepository
    {
        /// <summary>
        /// Получение списка всех авторов.
        /// </summary>
        public ResultContent<IEnumerable<Author>> GetListAuthors();

        /// <summary>
        /// Получение списка всех книг автора по ID.
        /// </summary>
        public ResultContent<IEnumerable<AuthorBookDetailsDto>> GetListBooksByAuthor(AuthorIdDto authorId);

        /// <summary>
        /// Добавление нового автора (с книгами/без).
        /// </summary>
        public ResultContent<Author> Add(AuthorDto author, IEnumerable<AuthorNewBookDto> books = null);

        /// <summary>
        /// Удаление автора по ID.
        /// </summary>
        public ResultContent<Author> Delete(AuthorIdDto authorId);
    }
}
