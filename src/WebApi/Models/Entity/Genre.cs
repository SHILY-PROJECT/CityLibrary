using System.Collections.Generic;

namespace WebApi.WebApi.Models.Entity
{
    /// <summary>
    /// 2.2 - Класс жанра книги (описывающий сущность для БД)
    /// </summary>
    public class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; }

        public IEnumerable<BookGenre> BookGenre { get; set; }
    }
}
