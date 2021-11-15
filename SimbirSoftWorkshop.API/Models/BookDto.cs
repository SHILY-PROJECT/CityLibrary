using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SimbirSoftWorkshop.API.Models
{
    /// <summary>
    /// 1.2.2 - Класс книги
    /// </summary>
    public class BookDto
    {
        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        [StringLength(201, MinimumLength = 2)]
        [RegularExpression(@"[A-Za-zА-Я]{1,100}\s[A-Za-zА-Я]{1,100}", ErrorMessage = "Wrong format! Correct format: 'NameAuthor SurnameAuthor' (without quotes)")]
        public string Author { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Genre { get; set; }
    }
}
