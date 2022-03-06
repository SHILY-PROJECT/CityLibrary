using System.Collections.Generic;
using Xunit;
using SimbirSoftWorkshop.API.Toolkit;
using SimbirSoftWorkshop.API.Models.Entity;
using SimbirSoftWorkshop.API.Models.Dto.Persons;
using SimbirSoftWorkshop.API.Models.Dto;
using SimbirSoftWorkshop.API.Repositories;

namespace SimbirSoftWorkshop.API.Tests.Repositories
{
    public class PersonRepository_Tests
    {
        private readonly DataContext _context;
        private readonly PersonRepository _service;

        public PersonRepository_Tests()
        {
            _context = FakeDbContext.GetFakeDbContext();
            _service = new PersonRepository(_context);
        }

        [Fact]
        public void AddPerson_ReturnStatusCode200()
        {
            // Arrange
            var person = new PersonDto { FirstName = "Katy", LastName = "Peir" };
            var respContent = new ResultContent<Person>().Ok();

            // Act
            var result = _service.Add(person);

            // Assert
            Assert.Equal(respContent.IsSuccess, result.IsSuccess);
        }

        [Fact]
        public void UpdatePerson_ReturnStatusCode200()
        {
            // Arrange
            var inputData = new UpdatePersonDto { Id = 1, FirstName = "Boby", LastName = "Kalistor" };
            var respContent = new ResultContent<Person>().Ok();

            // Act
            var result = _service.Update(inputData);

            // Assert
            Assert.Equal(respContent.IsSuccess, result.IsSuccess);
        }

        [Fact]
        public void DeletePersonById_ReturnStatusCode200()
        {
            // Arrange
            var inputData = 1;
            var respContent = new ResultContent<Person>().Ok();

            // Act
            var result = _service.Delete(inputData);

            // Assert
            Assert.Equal(respContent.IsSuccess, result.IsSuccess);
        }

        [Fact]
        public void DeletePersonByFirstLastMiddleName_ReturnStatusCode200()
        {
            // Arrange
            var inputData = new PersonDto { FirstName = "Igor", LastName = "Izmailov" };
            var respContent = new ResultContent<IEnumerable<Person>>().Ok();

            // Act
            var result = _service.Delete(inputData);

            // Assert
            Assert.Equal(respContent.IsSuccess, result.IsSuccess);
        }

        [Fact]
        public void GetPersonBooks_ReturnStatusCode200()
        {
            // Arrange
            var inputData = 1;
            var respContent = new ResultContent<IEnumerable<Book>>().Ok();

            // Act
            var result = _service.GetPersonBooks(inputData);

            // Assert
            Assert.Equal(respContent.IsSuccess, result.IsSuccess);
        }

        [Fact]
        public void TakeBook_ReturnStatusCode200()
        {
            // Arrange
            var inputData = new PersonBookDto { BookId = 1, PersoneId = 1 };
            var respContent = new ResultContent<LibraryCard>().Ok();

            // Act
            var result = _service.TakeBook(inputData);

            // Assert
            Assert.Equal(respContent.IsSuccess, result.IsSuccess);
        }

        [Fact]
        public void ReturnBook_ReturnStatusCode200()
        {
            // Arrange
            var inputData = new PersonBookDto { BookId = 3, PersoneId = 1 };
            var respContent = new ResultContent<LibraryCard>().Ok();

            // Act
            var result = _service.ReturnBook(inputData);

            // Assert
            Assert.Equal(respContent.IsSuccess, result.IsSuccess);
        }
    }
}
