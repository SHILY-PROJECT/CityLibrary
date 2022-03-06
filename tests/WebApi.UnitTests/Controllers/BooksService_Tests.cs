using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using SimbirSoftWorkshop.API.Interfaces;
using SimbirSoftWorkshop.API.Toolkit;
using SimbirSoftWorkshop.API.Enums;
using SimbirSoftWorkshop.API.Controllers;
using SimbirSoftWorkshop.API.Models.Entity;
using SimbirSoftWorkshop.API.Models.Dto.Books;
using SimbirSoftWorkshop.API.Models.Dto.Authors;

namespace SimbirSoftWorkshop.API.Tests.Controllers
{
    /// <summary>
    /// 3.1.3 - Покрытие тестами.
    /// </summary>
    public class BooksService_Tests
    {
        private readonly Mock<IBookRepository> _bookRepositoryMock;
        private readonly BooksController _service;

        public BooksService_Tests()
        {
            _bookRepositoryMock = new Mock<IBookRepository>();
            _service = new BooksController(_bookRepositoryMock.Object);
        }

        [Fact]
        public void AddBook_ReturnStatusCode200()
        {
            // Arrange
            var inputData = new NewBookDto { Name = "book", AuthorId = 1, GenreId = 1 };
            var respContent = new ResultContent<Book>().Ok();

            _bookRepositoryMock.Setup(x => x.Add(inputData)).Returns(respContent);

            // Act
            var result = _service.AddBook(inputData) as OkObjectResult;

            // Assert
            _bookRepositoryMock.Verify(x => x.Add(inputData), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void DeleteBook_ReturnStatusCode200()
        {
            // Arrange
            var inputData = 1;
            var respContent = new ResultContent<Book>().Ok();

            _bookRepositoryMock.Setup(x => x.Delete(inputData)).Returns(respContent);

            // Act
            var result = _service.DeleteBook(inputData) as OkObjectResult;

            // Assert
            _bookRepositoryMock.Verify(x => x.Delete(inputData), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void UpdateGenreBook_ReturnStatusCode200()
        {
            // Arrange
            var inputData = new UpdateGenreOfBookDto { BookId = 1, NewGenreId = 2, OldGenreId = 3 };
            var respContent = new ResultContent<BookDetailsDto>().Ok();

            _bookRepositoryMock.Setup(x => x.UpdateGenre(inputData)).Returns(respContent);

            // Act
            var result = _service.UpdateGenreBook(inputData) as OkObjectResult;

            // Assert
            _bookRepositoryMock.Verify(x => x.UpdateGenre(inputData), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void GetListBooksByAuthor_ReturnStatusCode200()
        {
            // Arrange
            var inputData1 = new AuthorDto { FirstName = "Carl", LastName = "Sagan"};
            var inputData2 = BookSortingTypeEnum.NoSort;
            var respContent = new ResultContent<IEnumerable<BookDetailsDto>>().Ok();

            _bookRepositoryMock.Setup(x => x.GetListBooksByAuthor(inputData1, inputData2)).Returns(respContent);

            // Act
            var result = _service.GetListBooksByAuthor(inputData1, inputData2) as OkObjectResult;

            // Assert
            _bookRepositoryMock.Verify(x => x.GetListBooksByAuthor(inputData1, inputData2), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void GetListBooksByGenre_ReturnStatusCode200()
        {
            // Arrange
            var inputData1 = 1;
            var inputData2 = BookSortingTypeEnum.NoSort;
            var respContent = new ResultContent<IEnumerable<BookDetailsDto>>().Ok();

            _bookRepositoryMock.Setup(x => x.GetListBooksByGenre(inputData1, inputData2)).Returns(respContent);

            // Act
            var result = _service.GetListBooksByGenre(inputData1, inputData2) as OkObjectResult;

            // Assert
            _bookRepositoryMock.Verify(x => x.GetListBooksByGenre(inputData1, inputData2), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
