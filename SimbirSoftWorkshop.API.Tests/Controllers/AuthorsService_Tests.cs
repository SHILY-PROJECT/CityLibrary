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
    public class AuthorsService_Tests
    {
        [Fact]
        public void GetListAuthors_ReturnStatusCode200()
        {
            // Arrange
            IEnumerable<Author> content = new List<Author> { new Author{ FirstName = "Fil", LastName = "Clazy"} };
            var resultContent = new ResultContent<IEnumerable<Author>>().Ok(content);
            var authorRepositoryMock = new Mock<IAuthorRepository>();

            authorRepositoryMock.Setup(x => x.GetListAuthors()).Returns(resultContent);

            var service = new AuthorsController(authorRepositoryMock.Object);

            // Act
            var result = service.GetListAuthors() as OkObjectResult;

            // Assert
            authorRepositoryMock.Verify(x => x.GetListAuthors(), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void GetListBooksByAuthor_ReturnStatusCode200()
        {
            // Arrange
            var authorId = new AuthorIdDto { Id = 1 };
            var resultContent = new ResultContent<IEnumerable<AuthorBookDetailsDto>>().Ok();
            var authorRepositoryMock = new Mock<IAuthorRepository>();

            authorRepositoryMock.Setup(x => x.GetListBooksByAuthor(authorId)).Returns(resultContent);

            var service = new AuthorsController(authorRepositoryMock.Object);

            // Act
            var result = service.GetListBooksByAuthor(authorId) as OkObjectResult;

            // Assert
            authorRepositoryMock.Verify(x => x.GetListBooksByAuthor(authorId), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void AddAuthor_ReturnStatusCode200()
        {
            // Arrange
            var author = new AuthorDto { FirstName = "Kail", LastName = "Next" };
            var resultContent = new ResultContent<Author>().Ok();
            var authorRepositoryMock = new Mock<IAuthorRepository>();

            authorRepositoryMock.Setup(x => x.Add(author, null)).Returns(resultContent);

            var service = new AuthorsController(authorRepositoryMock.Object);

            // Act
            var result = service.AddAuthor(author) as OkObjectResult;

            // Assert
            authorRepositoryMock.Verify(x => x.Add(author, null), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void DeleteAuthor_ReturnStatusCode200()
        {
            // Arrange
            var author = new AuthorIdDto { Id = 1 };
            var resultContent = new ResultContent<Author>().Ok();
            var authorRepositoryMock = new Mock<IAuthorRepository>();

            authorRepositoryMock.Setup(x => x.Delete(author)).Returns(resultContent);

            var service = new AuthorsController(authorRepositoryMock.Object);

            // Act
            var result = service.DeleteAuthor(author) as OkObjectResult;

            // Assert
            authorRepositoryMock.Verify(x => x.Delete(author), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
