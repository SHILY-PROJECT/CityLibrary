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
    public class GenresService_Tests
    {
        [Fact]
        public void GetListGenres_ReturnStatusCode200()
        {
            // Arrange
            var resultContent = new ResultContent<IEnumerable<Genre>>().Ok();
            var authorRepositoryMock = new Mock<IGenreRepository>();

            authorRepositoryMock.Setup(x => x.GetListGenres()).Returns(resultContent);

            var service = new GenresController(authorRepositoryMock.Object);

            // Act
            var result = service.GetListGenres() as OkObjectResult;

            // Assert
            authorRepositoryMock.Verify(x => x.GetListGenres(), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void AddGenre_ReturnStatusCode200()
        {
            // Arrange
            var addGenre = new AddGenre { Name = "Fantasy"};
            var resultContent = new ResultContent<Genre>().Ok();
            var authorRepositoryMock = new Mock<IGenreRepository>();

            authorRepositoryMock.Setup(x => x.Add(addGenre)).Returns(resultContent);

            var service = new GenresController(authorRepositoryMock.Object);

            // Act
            var result = service.AddGenre(addGenre) as OkObjectResult;

            // Assert
            authorRepositoryMock.Verify(x => x.Add(addGenre), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void GetStatisticsByGenres_ReturnStatusCode200()
        {
            // Arrange
            var resultContent = new ResultContent<IEnumerable<GenreStatisticsDto>>().Ok();
            var authorRepositoryMock = new Mock<IGenreRepository>();

            authorRepositoryMock.Setup(x => x.GetStatisticsByGenres()).Returns(resultContent);

            var service = new GenresController(authorRepositoryMock.Object);

            // Act
            var result = service.GetStatisticsByGenres() as OkObjectResult;

            // Assert
            authorRepositoryMock.Verify(x => x.GetStatisticsByGenres(), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
