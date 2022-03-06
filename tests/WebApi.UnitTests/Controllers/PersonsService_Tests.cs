using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using SimbirSoftWorkshop.API.Interfaces;
using SimbirSoftWorkshop.API.Toolkit;
using SimbirSoftWorkshop.API.Controllers;
using SimbirSoftWorkshop.API.Models.Entity;
using SimbirSoftWorkshop.API.Models.Dto.Persons;
using SimbirSoftWorkshop.API.Models.Dto;

namespace SimbirSoftWorkshop.API.Tests.Controllers
{
    /// <summary>
    /// 3.1.3 - Покрытие тестами.
    /// </summary>
    public class PersonsService_Tests
    {
        private readonly Mock<IPersonRepository> _personRepositoryMock;
        private readonly PersonsController _service;

        public PersonsService_Tests()
        {
            _personRepositoryMock = new Mock<IPersonRepository>();
            _service = new PersonsController(_personRepositoryMock.Object);
        }

        [Fact]
        public void AddPerson_ReturnStatusCode200()
        {
            // Arrange
            var person = new PersonDto { FirstName = "Katy", LastName = "Peir" };
            var respContent = new ResultContent<Person>().Ok();

            _personRepositoryMock.Setup(x => x.Add(person)).Returns(respContent);

            // Act
            var result = _service.AddPerson(person) as OkObjectResult;

            // Assert
            _personRepositoryMock.Verify(x => x.Add(person), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void UpdatePerson_ReturnStatusCode200()
        {
            // Arrange
            var inputData = new UpdatePersonDto {  Id = 1, FirstName = "Boby", LastName = "Kalistor" };
            var respContent = new ResultContent<Person>().Ok();

            _personRepositoryMock.Setup(x => x.Update(inputData)).Returns(respContent);

            // Act
            var result = _service.UpdatePerson(inputData) as OkObjectResult;

            // Assert
            _personRepositoryMock.Verify(x => x.Update(inputData), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void DeletePersonById_ReturnStatusCode200()
        {
            // Arrange
            var inputData = 1;
            var respContent = new ResultContent<Person>().Ok();

            _personRepositoryMock.Setup(x => x.Delete(inputData)).Returns(respContent);

            // Act
            var result = _service.DeletePerson(inputData) as OkObjectResult;

            // Assert
            _personRepositoryMock.Verify(x => x.Delete(inputData), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void DeletePersonByFirstLastMiddleName_ReturnStatusCode200()
        {
            // Arrange
            var inputData = new PersonDto { FirstName = "Boby", LastName = "Kalistor", MiddleName = "Zairov" };
            var respContent = new ResultContent<IEnumerable<Person>>().Ok();

            _personRepositoryMock.Setup(x => x.Delete(inputData)).Returns(respContent);

            // Act
            var result = _service.DeletePerson(inputData) as OkObjectResult;

            // Assert
            _personRepositoryMock.Verify(x => x.Delete(inputData), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void GetPersonBooks_ReturnStatusCode200()
        {
            // Arrange
            var inputData = 1;
            var respContent = new ResultContent<IEnumerable<Book>>().Ok();

            _personRepositoryMock.Setup(x => x.GetPersonBooks(inputData)).Returns(respContent);

            // Act
            var result = _service.GetPersonBooks(inputData) as OkObjectResult;

            // Assert
            _personRepositoryMock.Verify(x => x.GetPersonBooks(inputData), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void TakeBook_ReturnStatusCode200()
        {
            // Arrange
            var inputData = new PersonBookDto { BookId = 1, PersoneId = 1 };
            var respContent = new ResultContent<LibraryCard>().Ok();

            _personRepositoryMock.Setup(x => x.TakeBook(inputData)).Returns(respContent);

            // Act
            var result = _service.TakeBook(inputData) as OkObjectResult;

            // Assert
            _personRepositoryMock.Verify(x => x.TakeBook(inputData), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void ReturnBook_ReturnStatusCode200()
        {
            // Arrange
            var inputData = new PersonBookDto { BookId = 1, PersoneId = 1 };
            var respContent = new ResultContent<LibraryCard>().Ok();

            _personRepositoryMock.Setup(x => x.ReturnBook(inputData)).Returns(respContent);

            // Act
            var result = _service.ReturnBook(inputData) as OkObjectResult;

            // Assert
            _personRepositoryMock.Verify(x => x.ReturnBook(inputData), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
