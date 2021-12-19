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
    public class PersonsService_Tests
    {
        [Fact]
        public void AddPerson_ReturnStatusCode200()
        {
            // Arrange
            var person = new PersonDto { FirstName = "Katy", LastName = "Peir" };
            var resultContent = new ResultContent<Person>().Ok();
            var authorRepositoryMock = new Mock<IPersonRepository>();

            authorRepositoryMock.Setup(x => x.Add(person)).Returns(resultContent);

            var service = new PersonsController(authorRepositoryMock.Object);

            // Act
            var result = service.AddPerson(person) as OkObjectResult;

            // Assert
            authorRepositoryMock.Verify(x => x.Add(person), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void UpdatePerson_ReturnStatusCode200()
        {
            // Arrange
            var updatePerson = new UpdatePersonDto {  Id = 1, FirstName = "Boby", LastName = "Kalistor" };
            var resultContent = new ResultContent<Person>().Ok();
            var authorRepositoryMock = new Mock<IPersonRepository>();

            authorRepositoryMock.Setup(x => x.Update(updatePerson)).Returns(resultContent);

            var service = new PersonsController(authorRepositoryMock.Object);

            // Act
            var result = service.UpdatePerson(updatePerson) as OkObjectResult;

            // Assert
            authorRepositoryMock.Verify(x => x.Update(updatePerson), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void DeletePersonById_ReturnStatusCode200()
        {
            // Arrange
            var personId = 1;
            var resultContent = new ResultContent<Person>().Ok();
            var authorRepositoryMock = new Mock<IPersonRepository>();

            authorRepositoryMock.Setup(x => x.Delete(personId)).Returns(resultContent);

            var service = new PersonsController(authorRepositoryMock.Object);

            // Act
            var result = service.DeletePerson(personId) as OkObjectResult;

            // Assert
            authorRepositoryMock.Verify(x => x.Delete(personId), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void DeletePersonByFirstLastMiddleName_ReturnStatusCode200()
        {
            // Arrange
            var person = new PersonDto { FirstName = "Boby", LastName = "Kalistor", MiddleName = "Zairov" };
            var resultContent = new ResultContent<IEnumerable<Person>>().Ok();
            var authorRepositoryMock = new Mock<IPersonRepository>();

            authorRepositoryMock.Setup(x => x.Delete(person)).Returns(resultContent);

            var service = new PersonsController(authorRepositoryMock.Object);

            // Act
            var result = service.DeletePerson(person) as OkObjectResult;

            // Assert
            authorRepositoryMock.Verify(x => x.Delete(person), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void GetPersonBooks_ReturnStatusCode200()
        {
            // Arrange
            var personId = 1;
            var resultContent = new ResultContent<IEnumerable<Book>>().Ok();
            var authorRepositoryMock = new Mock<IPersonRepository>();

            authorRepositoryMock.Setup(x => x.GetPersonBooks(personId)).Returns(resultContent);

            var service = new PersonsController(authorRepositoryMock.Object);

            // Act
            var result = service.GetPersonBooks(personId) as OkObjectResult;

            // Assert
            authorRepositoryMock.Verify(x => x.GetPersonBooks(personId), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void TakeBook_ReturnStatusCode200()
        {
            // Arrange
            var personBook = new PersonBookDto { BookId = 1, PersoneId = 1 };
            var resultContent = new ResultContent<LibraryCard>().Ok();
            var authorRepositoryMock = new Mock<IPersonRepository>();

            authorRepositoryMock.Setup(x => x.TakeBook(personBook)).Returns(resultContent);

            var service = new PersonsController(authorRepositoryMock.Object);

            // Act
            var result = service.TakeBook(personBook) as OkObjectResult;

            // Assert
            authorRepositoryMock.Verify(x => x.TakeBook(personBook), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void ReturnBook_ReturnStatusCode200()
        {
            // Arrange
            var personBook = new PersonBookDto { BookId = 1, PersoneId = 1 };
            var resultContent = new ResultContent<LibraryCard>().Ok();
            var authorRepositoryMock = new Mock<IPersonRepository>();

            authorRepositoryMock.Setup(x => x.ReturnBook(personBook)).Returns(resultContent);

            var service = new PersonsController(authorRepositoryMock.Object);

            // Act
            var result = service.ReturnBook(personBook) as OkObjectResult;

            // Assert
            authorRepositoryMock.Verify(x => x.ReturnBook(personBook), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
