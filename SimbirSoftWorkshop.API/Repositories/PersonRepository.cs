using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SimbirSoftWorkshop.API.Interfaces;
using SimbirSoftWorkshop.API.Models.DatabaseModels;
using SimbirSoftWorkshop.API.Models.ViewModel;

namespace SimbirSoftWorkshop.API.Repositories
{
    /// <summary>
    /// 2.6 - Репозиторий пользователя
    /// </summary>
    public class PersonRepository : IPersonRepository
    {
        private readonly DataContext _context;

        public PersonRepository(DataContext context)
        {
            _context = context;
        }

        public Person Add(FullNameDto fullNameDto, DateTime birthDate)
        {
            var person = new Person
            {
                FirstName = fullNameDto.FirstName,
                LastName = fullNameDto.LastName,
                MiddleName = fullNameDto.MiddleName,
                BirthDate = birthDate,
            };

            _context.Persons.Add(person);
            _context.SaveChanges();

            return person;
        }

        public Person Update(PersonUpdateDto personUpdateDto)
        {
            var person = _context.Persons.Find(personUpdateDto.Id);

            if (person is null)
                throw new Exception($"'{nameof(personUpdateDto.Id)}:{personUpdateDto.Id}' - Пользователь не найден");

            person.FirstName = personUpdateDto.FirstName;
            person.LastName = personUpdateDto.LastName;
            person.MiddleName = personUpdateDto.MiddleName;
            person.BirthDate = personUpdateDto.BirthDate;

            _context.SaveChanges();

            return person;
        }

        public void Delete(int personId)
        {
            var person = _context.Persons.Find(personId);

            if (person is null)
                throw new Exception($"'{nameof(personId)}:{personId}' - Пользователь не найден");

            _context.Persons.Remove(person);
            _context.SaveChanges();
        }

        public void Delete(string firstName, string lastName, string middleName)
        {
            var personList = _context.Persons.Where
            (x =>
                EF.Functions.Like(x.FirstName, firstName) && EF.Functions.Like(x.LastName, lastName) &&
                ((string.IsNullOrWhiteSpace(middleName) && string.IsNullOrWhiteSpace(x.MiddleName)) ||
                (!string.IsNullOrWhiteSpace(middleName) && !string.IsNullOrWhiteSpace(x.MiddleName) && EF.Functions.Like(x.MiddleName, middleName)))
            )
            .ToList();

            if (!personList.Any())
                throw new Exception($"'{nameof(firstName)}:{firstName} | {nameof(lastName)}:{lastName} | {nameof(middleName)}:{middleName}' - Пользователь не найден");

            personList.ForEach(x => _context.Remove(x));
            _context.SaveChanges();
        }

        public IEnumerable<Book> GetPersonBooks(int personId)
        {
            return _context.LibraryCards
                .Where(lc => lc.PersonId == personId)
                .Include(lc => lc.Book)
                .ThenInclude(b => b.Author)
                .Include(lc => lc.Book.BooksGenres)
                .ThenInclude(bg => bg.Genre)
                .Select(x => x.Book);
        }

        public void TakeBook(int bookId, int personId)
        {
            var libraryCard = new LibraryCard
            {
                BookId = bookId,
                PersonId = personId
            };
            _context.LibraryCards.Add(libraryCard);
            _context.SaveChanges();
        }

        public void ReturnBook(int bookId, int personId)
        {           
            var libraryCard = _context.LibraryCards.FirstOrDefault(x => x.BookId == bookId && x.PersonId == personId);

            if (libraryCard is null)
                throw new Exception($"'{nameof(bookId)}:{bookId} | {nameof(personId)}:{personId}' - Карточка не найдена");

            _context.LibraryCards.Remove(libraryCard);
            _context.SaveChanges();
        }

    }
}
