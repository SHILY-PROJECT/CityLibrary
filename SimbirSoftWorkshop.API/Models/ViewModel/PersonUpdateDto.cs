using System;
using System.ComponentModel.DataAnnotations;

namespace SimbirSoftWorkshop.API.Models.ViewModel
{
    public class PersonUpdateDto : FullNameDto
    {
        [Required]
        public int Id { get; set; }

        public DateTime BirthDate { get; set; } = default;
    }
}
