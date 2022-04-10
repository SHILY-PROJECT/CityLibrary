using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CityLibrary.Domain.Models;
using CityLibrary.Domain.Interfaces.Services;
using CityLibrary.WebApi.Models;

namespace CityLibrary.WebApi.Controllers;

[ApiController]
[Route("/api/genre")]
public class GenreController : ControllerBase
{
    private readonly IGenreService _service;
    private readonly IMapper _mapper;

    public GenreController(IGenreService genreService, IMapper mapper)
    {
        _service = genreService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<GenreDto>>> GetGenres()
    {
        var genres = await _service.GetAllAsync();
        return _mapper.Map<GenreDto[]>(genres);
    }

    [HttpGet("stats")]
    public async Task<ActionResult<IReadOnlyCollection<GenreStatsDto>>> GetStats()
    {
        var stats = await _service.GetStatsAsync();
        return _mapper.Map<GenreStatsDto[]>(stats)
    }

    [HttpPost]
    public async Task<ActionResult<GenreDto>> AddGenre([FromBody] GenreDto genreDto)
    {
        var genre = _mapper.Map<Genre>(genreDto);
        var newGenre = await _service.NewAsync(genre);
        return _mapper.Map<GenreDto>(newGenre);
    }
}