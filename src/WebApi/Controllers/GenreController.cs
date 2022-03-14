using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Domain.Models;
using Domain.Interfaces.Services;
using WebApi.Models;

namespace WebApi.Controllers;

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
        var genresResult = _mapper.Map<IReadOnlyCollection<GenreDto>>(genres);
        return Ok(genresResult);
    }

    [HttpGet("stats")]
    public async Task<ActionResult<IReadOnlyCollection<GenreStatsDto>>> GetStats()
    {
        var stats = await _service.GetStatsAsync();
        var statsResult = _mapper.Map<IReadOnlyCollection<GenreStatsDto>>(stats);
        return Ok(statsResult);
    }

    [HttpPost]
    public async Task<ActionResult<GenreDto>> AddGenre([FromBody] GenreDto genreDto)
    {
        var genre = _mapper.Map<Genre>(genreDto);
        var genreResult = await _service.NewAsync(genre);
        return _mapper.Map<GenreDto>(genreResult);
    }
}