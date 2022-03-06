using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using WebApi.Models.Dto.Genres;

namespace WebApi.Controllers;

[ApiController]
[Route("/api/genre")]
public class GenresController : ControllerBase
{
    private readonly IGenreRepository _iGenreRepository;

    public GenresController(IGenreRepository iGenreRepository)
    {
        _iGenreRepository = iGenreRepository;
    }

    [HttpGet]
    public IActionResult GetGenres()
    {
        var result = _iGenreRepository.GetListGenres();

        if (result.IsSuccess is false)
            return BadRequest(result.Message);

        return Ok(result.Content);
    }

    [HttpGet]
    public IActionResult GetStats()
    {
        var result = _iGenreRepository.GetStatisticsByGenres();

        if (result.IsSuccess is false)
            return BadRequest(result.Message);

        return Ok(result.Content);
    }

    [HttpPost]
    public IActionResult AddGenre([FromQuery] AddGenre genreName)
    {
        var result = _iGenreRepository.Add(genreName);

        if (result.IsSuccess is false)
            return BadRequest(result.Message);

        return Ok(result.Message);
    }
}