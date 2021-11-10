using System;

namespace SimbirSoftWorkshop.API.Models
{
    /// <summary>
    /// 1.2.2 - Класс книги
    /// </summary>
    public class BookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public long AuthorId { get; set; }
        public string Genre { get; set; }
    }
}
