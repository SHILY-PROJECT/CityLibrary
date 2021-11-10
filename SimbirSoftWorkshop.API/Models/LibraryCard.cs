using System;

namespace SimbirSoftWorkshop.API.Models
{
    /// <summary>
    /// 2.1.1 - Библиотечкая карточка
    /// </summary>
    public class LibraryCard
    {
        public HumanDto Human { get; private set; }
        public BookDto Book { get; private set; }
        public DateTimeOffset BookReceiptDate { get; private set; }

        public LibraryCard(HumanDto human, BookDto book)
        {
            Human = human;
            Book = book;
            BookReceiptDate = DateTime.Now;
        }
    }
}
