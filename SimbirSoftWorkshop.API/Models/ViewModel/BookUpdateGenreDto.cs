using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbirSoftWorkshop.API.Models.ViewModel
{
    public class BookUpdateGenreDto
    {
        [Required]
        public int BookId { get; set; }

        [Required]
        public int OldGenreId { get; set; }

        [Required]
        public int NewGenreId { get; set; }
    }
}
