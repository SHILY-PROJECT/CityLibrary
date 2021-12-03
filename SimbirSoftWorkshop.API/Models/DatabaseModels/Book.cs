using System.Collections.Generic;

namespace SimbirSoftWorkshop.API.Models.DatabaseModels
{
    /// <summary>
    /// 2.2 - Класс книги (описывающий сущность для БД)
    /// </summary>
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }

        public Author Author { get; set; }
        public IEnumerable<BookGenre> BooksGenres { get; set; }
        public IEnumerable<LibraryCard> LibraryCards { get; set; }
    }
}
