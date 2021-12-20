using System.Collections.Generic;
using Xunit;
using SimbirSoftWorkshop.API.Toolkit;
using SimbirSoftWorkshop.API.Models.Entity;
using SimbirSoftWorkshop.API.Models.Dto.Genres;
using SimbirSoftWorkshop.API.Repositories;

namespace SimbirSoftWorkshop.API.Tests.Repositories
{
    public class GenreRepository_Tests
    {
        private readonly DataContext _context;
        private readonly GenreRepository _service;

        public GenreRepository_Tests()
        {
            _context = FakeDbContext.GetFakeDbContext();
            _service = new GenreRepository(_context);
        }

        [Fact]
        public void GetListGenres_ReturnStatusCode200()
        {
            // Arrange
            var respContent = new ResultContent<IEnumerable<Genre>>().Ok();

            // Act
            var result = _service.GetListGenres();

            // Assert
            Assert.Equal(respContent.IsSuccess, result.IsSuccess);
        }

        [Fact]
        public void AddGenre_ReturnStatusCode200()
        {
            // Arrange
            var inputData = new AddGenre { Name = "Action fantasy" };
            var respContent = new ResultContent<Genre>().Ok();

            // Act
            var result = _service.Add(inputData);

            // Assert
            Assert.Equal(respContent.IsSuccess, result.IsSuccess);
        }

        [Fact]
        public void GetStatisticsByGenres_ReturnStatusCode200()
        {
            // Arrange
            var respContent = new ResultContent<IEnumerable<GenreStatisticsDto>>().Ok();

            // Act
            var result = _service.GetStatisticsByGenres();

            // Assert
            Assert.Equal(respContent.IsSuccess, result.IsSuccess);
        }
    }
}
