using System.Collections.Generic;
using SimbirSoftWorkshop.API.Toolkit;
using SimbirSoftWorkshop.API.Models.Dto;
using SimbirSoftWorkshop.API.Models.Dto.Persons;
using SimbirSoftWorkshop.API.Models.Entity;

namespace SimbirSoftWorkshop.API.Interfaces
{
    public interface IPersonRepository
    {
        public ResultContent<Person> Add(PersonDto persone);
        public ResultContent<Person> Update(UpdatePersonDto updatePerson);
        public ResultContent<Person> Delete(int personId);
        public ResultContent<IEnumerable<Person>> Delete(PersonDto persone);
        public ResultContent<IEnumerable<Book>> GetPersonBooks(int personId);
        public ResultContent<LibraryCard> TakeBook(PersonBookDto personBook);
        public ResultContent<LibraryCard> ReturnBook(PersonBookDto personBook);
    }
}
