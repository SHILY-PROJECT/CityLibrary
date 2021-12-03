using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbirSoftWorkshop.API.Models.ViewModel
{
    public class PersonUpdateDto : FullNameDto
    {
        [Required]
        public int Id { get; set; }

        public DateTime BirthDate { get; set; } = default;
    }
}
