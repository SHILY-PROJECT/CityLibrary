using System;

namespace SimbirSoftWorkshop.API.Models.Dto
{
    public class UpdatePersonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; } = default;
    }
}
