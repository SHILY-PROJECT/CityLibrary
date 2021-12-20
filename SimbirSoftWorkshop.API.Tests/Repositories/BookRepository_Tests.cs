using System.Collections.Generic;
using Xunit;
using SimbirSoftWorkshop.API.Toolkit;
using SimbirSoftWorkshop.API.Enums;
using SimbirSoftWorkshop.API.Models.Entity;
using SimbirSoftWorkshop.API.Models.Dto.Books;
using SimbirSoftWorkshop.API.Models.Dto.Authors;
using SimbirSoftWorkshop.API.Repositories;

namespace SimbirSoftWorkshop.API.Tests.Repositories
{
    public class BookRepository_Tests
    {
        private readonly DataContext _context;
        private readonly BookRepository _service;

        public BookRepository_Tests()
        {
            _context = FakeDbContext.GetFakeDbContext();
            _service = new BookRepository(_context);
        }

        [Fact]
        public void AddBook_ReturnIsSuccessTrue()
        {
            // Arrange
            var inputData = new NewBookDto { Name = "book", AuthorId = 1, GenreId = 1 };
            var respContent = new ResultContent<Book>().Ok();

            // Act
            var result = _service.Add(inputData);

            // Assert
            Assert.Equal(respContent.IsSuccess, result.IsSuccess);
        }

        [Fact]
        public void DeleteBook_ReturnIsSuccessTrue()
        {
            // Arrange
            var inputData = 1;
            var respContent = new ResultContent<Book>().Ok();

            // Act
            var result = _service.Delete(inputData);

            // Assert           
            Assert.Equal(respContent.IsSuccess, result.IsSuccess);
        }

        [Fact]
        public void UpdateGenreBook_ReturnIsSuccessTrue()
        {
            // Arrange
            var inputData = new UpdateGenreOfBookDto { BookId = 1, NewGenreId = 2, OldGenreId = 1 };
            var respContent = new ResultContent<BookDetailsDto>().Ok();

            // Act
            var result = _service.UpdateGenre(inputData);

            // Assert
            Assert.Equal(respContent.IsSuccess, result.IsSuccess);
        }

        [Fact]
        public void GetListBooksByAuthor_ReturnIsSuccessTrue()
        {
            // Arrange
            var inputData1 = new AuthorDto { FirstName = "Carl", LastName = "Sagan" };
            var inputData2 = BookSortingTypeEnum.NoSort;
            var respContent = new ResultContent<IEnumerable<BookDetailsDto>>().Ok();

            // Act
            var result = _service.GetListBooksByAuthor(inputData1, inputData2);

            // Assert
            Assert.Equal(respContent.IsSuccess, result.IsSuccess);
        }

        [Fact]
        public void GetListBooksByGenre_ReturnIsSuccessTrue()
        {
            // Arrange
            var inputData1 = 1;
            var inputData2 = BookSortingTypeEnum.NoSort;
            var respContent = new ResultContent<IEnumerable<BookDetailsDto>>().Ok();

            // Act
            var result = _service.GetListBooksByGenre(inputData1, inputData2);

            // Assert
            Assert.Equal(respContent.IsSuccess, result.IsSuccess);
        }
    }
}
