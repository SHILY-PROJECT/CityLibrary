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
    public class BooksService_Tests
    {
        [Fact]
        public void AddBook_ReturnStatusCode200()
        {
            // Arrange
            var book = new NewBookDto { Name = "book", AuthorId = 1, GenreId = 1 };
            var resultContent = new ResultContent<Book>().Ok();
            var authorRepositoryMock = new Mock<IBookRepository>();

            authorRepositoryMock.Setup(x => x.Add(book)).Returns(resultContent);

            var service = new BooksController(authorRepositoryMock.Object);

            // Act
            var result = service.AddBook(book) as OkObjectResult;

            // Assert
            authorRepositoryMock.Verify(x => x.Add(book), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void DeleteBook_ReturnStatusCode200()
        {
            // Arrange
            var bookId = 1;
            var resultContent = new ResultContent<Book>().Ok();
            var authorRepositoryMock = new Mock<IBookRepository>();

            authorRepositoryMock.Setup(x => x.Delete(bookId)).Returns(resultContent);

            var service = new BooksController(authorRepositoryMock.Object);

            // Act
            var result = service.DeleteBook(bookId) as OkObjectResult;

            // Assert
            authorRepositoryMock.Verify(x => x.Delete(bookId), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void UpdateGenreBook_ReturnStatusCode200()
        {
            // Arrange
            var bookUpdateGenre = new UpdateGenreOfBookDto { BookId = 1, NewGenreId = 2, OldGenreId = 3 };
            var resultContent = new ResultContent<BookDetailsDto>().Ok();
            var authorRepositoryMock = new Mock<IBookRepository>();

            authorRepositoryMock.Setup(x => x.UpdateGenre(bookUpdateGenre)).Returns(resultContent);

            var service = new BooksController(authorRepositoryMock.Object);

            // Act
            var result = service.UpdateGenreBook(bookUpdateGenre) as OkObjectResult;

            // Assert
            authorRepositoryMock.Verify(x => x.UpdateGenre(bookUpdateGenre), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void GetListBooksByAuthor_ReturnStatusCode200()
        {
            // Arrange
            var authorSearch = new AuthorDto { FirstName = "Carl", LastName = "Sagan"};
            var sortType = BookSortingTypeEnum.NoSort;
            var resultContent = new ResultContent<IEnumerable<BookDetailsDto>>().Ok();
            var authorRepositoryMock = new Mock<IBookRepository>();

            authorRepositoryMock.Setup(x => x.GetListBooksByAuthor(authorSearch, sortType)).Returns(resultContent);

            var service = new BooksController(authorRepositoryMock.Object);

            // Act
            var result = service.GetListBooksByAuthor(authorSearch, sortType) as OkObjectResult;

            // Assert
            authorRepositoryMock.Verify(x => x.GetListBooksByAuthor(authorSearch, sortType), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void GetListBooksByGenre_ReturnStatusCode200()
        {
            // Arrange
            var genreId = 1;
            var sortType = BookSortingTypeEnum.NoSort;
            var resultContent = new ResultContent<IEnumerable<BookDetailsDto>>().Ok();
            var authorRepositoryMock = new Mock<IBookRepository>();

            authorRepositoryMock.Setup(x => x.GetListBooksByGenre(genreId, sortType)).Returns(resultContent);

            var service = new BooksController(authorRepositoryMock.Object);

            // Act
            var result = service.GetListBooksByGenre(genreId, sortType) as OkObjectResult;

            // Assert
            authorRepositoryMock.Verify(x => x.GetListBooksByGenre(genreId, sortType), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
