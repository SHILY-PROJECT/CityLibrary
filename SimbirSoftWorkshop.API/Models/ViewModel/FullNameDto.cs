using System.ComponentModel.DataAnnotations;

namespace SimbirSoftWorkshop.API.Models.ViewModel
{
    public class FullNameDto
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(50, MinimumLength = 0)]
        public string MiddleName { get; set; } = string.Empty;
    }
}
