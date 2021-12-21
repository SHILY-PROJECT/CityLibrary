using System.Collections.Generic;
using Xunit;
using SimbirSoftWorkshop.API.Models.Dto.Authors;
using SimbirSoftWorkshop.API.Models.Entity;
using SimbirSoftWorkshop.API.Toolkit;
using SimbirSoftWorkshop.API.Repositories;

namespace SimbirSoftWorkshop.API.Tests.Repositories
{
    public class AuthorRepository_Tests
    {
        private readonly DataContext _context;
        private readonly AuthorRepository _service;

        public AuthorRepository_Tests()
        {
            _context = FakeDbContext.GetFakeDbContext();
            _service = new AuthorRepository(_context);
        }

        [Fact]
        public void GetListAuthors_ReturnIsSuccessTrue()
        {
            // Arrange
            var respContent = new ResultContent<IEnumerable<Author>>().Ok();

            // Act
            var result = _service.GetListAuthors();

            // Assert
            Assert.Equal(respContent.IsSuccess, result.IsSuccess);
        }

        [Fact]
        public void GetListBooksByAuthor_ReturnIsSuccessTrue()
        {
            // Arrange
            var inputData = new AuthorIdDto { Id = 1 };
            var respContent = new ResultContent<IEnumerable<AuthorBookDetailsDto>>().Ok();

            // Act
            var result = _service.GetListBooksByAuthor(inputData);

            // Assert
            Assert.Equal(respContent.IsSuccess, result.IsSuccess);
        }

        [Fact]
        public void AddAuthor_ReturnIsSuccessTrue()
        {
            // Arrange
            var inputData = new AuthorDto { FirstName = "Kail", LastName = "Next" };
            var respContent = new ResultContent<Author>().Ok();

            // Act
            var result = _service.Add(inputData, null);

            // Assert
            Assert.Equal(respContent.IsSuccess, result.IsSuccess);
        }

        [Fact]
        public void DeleteAuthor_ReturnIsSuccessTrue()
        {
            // Arrange
            var inputData = new AuthorIdDto { Id = 4 };
            var respContent = new ResultContent<Author>().Ok();

            // Act
            var result = _service.Delete(inputData);

            // Assert
            Assert.Equal(respContent.IsSuccess, result.IsSuccess);
        }
    }
}
