using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimbirSoftWorkshop.API.Models
{
    /// <summary>
    /// 1.2.1 - Класс человека
    /// </summary>
    public class HumanDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [RegularExpression(@"[A-Za-zА-Яа-я]+", ErrorMessage = "The string can only contain Cyrillic and Latin characters.")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [RegularExpression(@"[a-zA-Zа-яА-Я]+", ErrorMessage = "The string can only contain Cyrillic and Latin characters.")]
        public string Surname { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [RegularExpression(@"[a-zA-Zа-яА-Я]+", ErrorMessage = "The string can only contain Cyrillic and Latin characters.")]
        public string Patronymic { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
    }
}
