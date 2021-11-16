using System;
using System.ComponentModel.DataAnnotations;

namespace SimbirSoftWorkshop.API.Models
{
    /// <summary>
    /// 2.1.1 - Библиотечкая карточка
    /// </summary>
    public class LibraryCardDto
    {
        [Required]
        public HumanDto Human { get; set; }

        [Required]
        public BookDto Book { get; set; }

        [Required]
        public DateTimeOffset BookReceiptDate { get; set; }

        public LibraryCardDto()
        {
            BookReceiptDate = DateTimeOffset.Now;
        }
    }
}
