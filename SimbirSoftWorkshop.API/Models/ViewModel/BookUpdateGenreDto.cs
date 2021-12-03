using System.ComponentModel.DataAnnotations;

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
