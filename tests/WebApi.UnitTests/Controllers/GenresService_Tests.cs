using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using SimbirSoftWorkshop.API.Interfaces;
using SimbirSoftWorkshop.API.Toolkit;
using SimbirSoftWorkshop.API.Controllers;
using SimbirSoftWorkshop.API.Models.Entity;
using SimbirSoftWorkshop.API.Models.Dto.Genres;

namespace SimbirSoftWorkshop.API.Tests.Controllers
{
    /// <summary>
    /// 3.1.3 - Покрытие тестами.
    /// </summary>
    public class GenresService_Tests
    {
        private readonly Mock<IGenreRepository> _genreRepositoryMock;
        private readonly GenresController _service;

        public GenresService_Tests()
        {
            _genreRepositoryMock = new Mock<IGenreRepository>();
            _service = new GenresController(_genreRepositoryMock.Object);
        }

        [Fact]
        public void GetListGenres_ReturnStatusCode200()
        {
            // Arrange
            var respContent = new ResultContent<IEnumerable<Genre>>().Ok();

            _genreRepositoryMock.Setup(x => x.GetListGenres()).Returns(respContent);

            // Act
            var result = _service.GetListGenres() as OkObjectResult;

            // Assert
            _genreRepositoryMock.Verify(x => x.GetListGenres(), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void AddGenre_ReturnStatusCode200()
        {
            // Arrange
            var inputData = new AddGenre { Name = "Fantasy"};
            var respContent = new ResultContent<Genre>().Ok();

            _genreRepositoryMock.Setup(x => x.Add(inputData)).Returns(respContent);

            // Act
            var result = _service.AddGenre(inputData) as OkObjectResult;

            // Assert
            _genreRepositoryMock.Verify(x => x.Add(inputData), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void GetStatisticsByGenres_ReturnStatusCode200()
        {
            // Arrange
            var respContent = new ResultContent<IEnumerable<GenreStatisticsDto>>().Ok();

            _genreRepositoryMock.Setup(x => x.GetStatisticsByGenres()).Returns(respContent);

            // Act
            var result = _service.GetStatisticsByGenres() as OkObjectResult;

            // Assert
            _genreRepositoryMock.Verify(x => x.GetStatisticsByGenres(), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
