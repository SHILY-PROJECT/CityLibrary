using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using SimbirSoftWorkshop.API.Controllers;
using SimbirSoftWorkshop.API.Interfaces;
using SimbirSoftWorkshop.API.Models.Dto.Authors;
using SimbirSoftWorkshop.API.Models.Entity;
using SimbirSoftWorkshop.API.Toolkit;

namespace SimbirSoftWorkshop.API.Tests
{
    /// <summary>
    /// 3.1.3 - Покрытие тестами.
    /// </summary>
    public class AuthorsService_Tests
    {
        private readonly Mock<IAuthorRepository> _authorRepositoryMock;
        private readonly AuthorsController _service;

        public AuthorsService_Tests()
        {
            _authorRepositoryMock = new Mock<IAuthorRepository>();
            _service = new AuthorsController(_authorRepositoryMock.Object);
        }

        [Fact]
        public void GetListAuthors_ReturnStatusCode200()
        {
            // Arrange
            var respContent = new ResultContent<IEnumerable<Author>>().Ok();

            _authorRepositoryMock.Setup(x => x.GetListAuthors()).Returns(respContent);

            // Act
            var result = _service.GetListAuthors() as OkObjectResult;

            // Assert
            _authorRepositoryMock.Verify(x => x.GetListAuthors(), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void GetListBooksByAuthor_ReturnStatusCode200()
        {
            // Arrange
            var inputData = new AuthorIdDto { Id = 1 };
            var respContent = new ResultContent<IEnumerable<AuthorBookDetailsDto>>().Ok();

            _authorRepositoryMock.Setup(x => x.GetListBooksByAuthor(inputData)).Returns(respContent);

            // Act
            var result = _service.GetListBooksByAuthor(inputData) as OkObjectResult;

            // Assert
            _authorRepositoryMock.Verify(x => x.GetListBooksByAuthor(inputData), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void AddAuthor_ReturnStatusCode200()
        {
            // Arrange
            var inputData = new AuthorDto { FirstName = "Kail", LastName = "Next" };
            var respContent = new ResultContent<Author>().Ok();

            _authorRepositoryMock.Setup(x => x.Add(inputData, null)).Returns(respContent);

            // Act
            var result = _service.AddAuthor(inputData) as OkObjectResult;

            // Assert
            _authorRepositoryMock.Verify(x => x.Add(inputData, null), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void DeleteAuthor_ReturnStatusCode200()
        {
            // Arrange
            var inputData = new AuthorIdDto { Id = 1 };
            var respContent = new ResultContent<Author>().Ok();

            _authorRepositoryMock.Setup(x => x.Delete(inputData)).Returns(respContent);

            // Act
            var result = _service.DeleteAuthor(inputData) as OkObjectResult;

            // Assert
            _authorRepositoryMock.Verify(x => x.Delete(inputData), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
