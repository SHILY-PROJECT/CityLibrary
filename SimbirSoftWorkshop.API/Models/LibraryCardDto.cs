using System;

namespace SimbirSoftWorkshop.API.Models
{
    /// <summary>
    /// 2.1.1 - Библиотечкая карточка
    /// </summary>
    public class LibraryCardDto
    {
        public HumanDto Human { get; set; }
        public BookDto Book { get; set; }
        public DateTimeOffset BookReceiptDate { get; set; }
    }
}
