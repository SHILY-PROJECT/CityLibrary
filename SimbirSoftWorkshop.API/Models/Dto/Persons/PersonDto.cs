using System;

namespace SimbirSoftWorkshop.API.Models.Dto.Persons
{
    public class PersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
