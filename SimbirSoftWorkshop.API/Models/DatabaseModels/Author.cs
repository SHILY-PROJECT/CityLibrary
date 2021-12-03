using System.Collections.Generic;

namespace SimbirSoftWorkshop.API.Models.DatabaseModels
{
    /// <summary>
    /// 2.2 - Класс автора (описывающий сущность для БД)
    /// </summary>
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
