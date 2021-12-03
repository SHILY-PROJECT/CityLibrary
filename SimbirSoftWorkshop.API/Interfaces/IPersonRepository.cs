using SimbirSoftWorkshop.API.Models.DatabaseModels;
using SimbirSoftWorkshop.API.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbirSoftWorkshop.API.Interfaces
{
    public interface IPersonRepository
    {
        public Person Add(FullNameDto fullName, DateTime birthDate);
        public Person Update(PersonUpdateDto personUpdateDto);
        public void Delete(int personId);
        public void Delete(string firstName, string lastName, string middleName);
        public IEnumerable<Book> GetPersonBooks(int personId);
        public void TakeBook(int bookId, int personId);
        public void ReturnBook(int bookId, int personId);
    }
}
