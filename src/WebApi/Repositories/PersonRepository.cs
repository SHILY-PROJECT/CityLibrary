using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApi.WebApi.Models.Dto;
using WebApi.WebApi.Models.Entity;
using WebApi.WebApi.Models.Dto.Persons;
using WebApi.WebApi.Toolkit;

namespace WebApi.WebApi.Repositories
{

    //public class PersonRepository : IPersonRepository
    //{
    //    private readonly DataContext _context;

    //    /// <summary>
    //    /// 3.1.1 - Конструктор для реализации DI.
    //    /// </summary>
    //    public PersonRepository(DataContext context)
    //    {
    //        _context = context;
    //    }

    //    /// <summary>
    //    /// Добавление нового пользователя.
    //    /// </summary>
    //    public ResultContent<Person> Add(PersonDto personCreate)
    //    {
    //        try
    //        {
    //            var person = new Person
    //            {
    //                FirstName = personCreate.FirstName,
    //                LastName = personCreate.LastName,
    //                MiddleName = personCreate.MiddleName,
    //                BirthDate = personCreate.BirthDate,
    //            };

    //            _context.Persons.Add(person);
    //            _context.SaveChanges();

    //            return new ResultContent<Person>().Ok(person);
    //        }
    //        catch (Exception ex)
    //        {
    //            return new ResultContent<Person>().Error(ex);
    //        }
    //    }

    //    /// <summary>
    //    /// Обновить информацию пользователя.
    //    /// </summary>
    //    public ResultContent<Person> Update(UpdatePersonDto updatePerson)
    //    {
    //        try
    //        {
    //            var person = _context.Persons.Find(updatePerson.Id);

    //            if (person is null)
    //                return new ResultContent<Person>().Error($"'{nameof(updatePerson.Id)}:{updatePerson.Id}' - Пользователь не найден");

    //            person.FirstName = updatePerson.FirstName;
    //            person.LastName = updatePerson.LastName;
    //            person.MiddleName = updatePerson.MiddleName;
    //            person.BirthDate = updatePerson.BirthDate;

    //            _context.SaveChanges();

    //            return new ResultContent<Person>().Ok(person);
    //        }
    //        catch(Exception ex)
    //        {
    //            return new ResultContent<Person>().Error(ex);
    //        }
    //    }

    //    /// <summary>
    //    /// Удаление пользователя.
    //    /// </summary>
    //    public ResultContent<Person> Delete(int personId)
    //    {
    //        try
    //        {
    //            var person = _context.Persons.Find(personId);

    //            if (person is null)
    //                return new ResultContent<Person>().Error($"'{nameof(personId)}:{personId}' - Пользователь не найден");

    //            _context.Persons.Remove(person);
    //            _context.SaveChanges();

    //            return new ResultContent<Person>().Ok(person, "Пользователь успешно удален");
    //        }
    //        catch (Exception ex)
    //        {
    //            return new ResultContent<Person>().Error(ex);
    //        }
    //    }

    //    /// <summary>
    //    /// Удаление пользователя.
    //    /// </summary>
    //    public ResultContent<IEnumerable<Person>> Delete(PersonDto person)
    //    {
    //        var firstName = person.FirstName;
    //        var lastName = person.LastName;
    //        var middleName = person.MiddleName;

    //        try
    //        {
    //            var persons = _context.Persons
    //                .Where(x => EF.Functions.Like(x.FirstName, firstName) && EF.Functions.Like(x.LastName, lastName) &&
    //                    (string.IsNullOrEmpty(middleName) || EF.Functions.Like(x.MiddleName, middleName)))
    //                .ToList();

    //            if (persons.Any() is false)
    //                return new ResultContent<IEnumerable<Person>>().Error(
    //                    $"'{nameof(firstName)}:{firstName} | {nameof(lastName)}:{lastName} | {nameof(middleName)}:{middleName}' - Пользователь не найден");

    //            persons.ForEach(x => _context.Remove(x));
    //            _context.SaveChanges();

    //            return new ResultContent<IEnumerable<Person>>().Ok(persons, "Пользователь успешно удален");
    //        }
    //        catch (Exception ex)
    //        {
    //            return new ResultContent<IEnumerable<Person>>().Error(ex);
    //        }
    //    }

    //    /// <summary>
    //    /// Получение книг пользователя.
    //    /// </summary>
    //    public ResultContent<IEnumerable<Book>> GetPersonBooks(int personId)
    //    {
    //        try
    //        {
    //            var books = _context.LibraryCards
    //                .Where(lc => lc.PersonId == personId)
    //                .Include(lc => lc.Book)
    //                    .ThenInclude(b => b.Author)
    //                .Include(lc => lc.Book.BooksGenres)
    //                    .ThenInclude(bg => bg.Genre)
    //                    .Select(x => x.Book);

    //            return new ResultContent<IEnumerable<Book>>().Ok(books);
    //        }
    //        catch (Exception ex)
    //        {
    //            return new ResultContent<IEnumerable<Book>>().Error(ex);
    //        }
    //    }

    //    /// <summary>
    //    /// Получение книги пользователем на руки.
    //    /// </summary>
    //    public ResultContent<LibraryCard> TakeBook(PersonBookDto personBook)
    //    {
    //        try
    //        {
    //            var libraryCard = new LibraryCard
    //            {
    //                BookId = personBook.BookId,
    //                PersonId = personBook.PersoneId
    //            };
    //            _context.LibraryCards.Add(libraryCard);
    //            _context.SaveChanges();

    //            return new ResultContent<LibraryCard>().Ok(libraryCard, "Пользователью успешно выдана книга");
    //        }
    //        catch (Exception ex)
    //        {
    //            return new ResultContent<LibraryCard>().Error(ex);
    //        }
    //    }

    //    /// <summary>
    //    /// Возврат книги пользователем с рук.
    //    /// </summary>
    //    public ResultContent<LibraryCard> ReturnBook(PersonBookDto personBook)
    //    {
    //        var bookId = personBook.BookId;
    //        var personId = personBook.PersoneId;

    //        try
    //        {
    //            var libraryCard = _context.LibraryCards.FirstOrDefault(x => x.BookId == bookId && x.PersonId == personId);

    //            if (libraryCard is null)
    //                return new ResultContent<LibraryCard>().Error(
    //                    $"'{nameof(bookId)}:{bookId} | {nameof(personId)}:{personId}' - Карточка пользователя не найдена");

    //            _context.LibraryCards.Remove(libraryCard);
    //            _context.SaveChanges();

    //            return new ResultContent<LibraryCard>().Ok(libraryCard, "Пользователь успешно вернул книгу");
    //        }
    //        catch (Exception ex)
    //        {
    //            return new ResultContent<LibraryCard>().Error(ex);
    //        }
    //    }

    //}
}
