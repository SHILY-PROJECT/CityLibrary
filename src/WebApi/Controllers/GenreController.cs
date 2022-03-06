using System.Collections.Generic;
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
    public ActionResult<IReadOnlyCollection<GenreDto>> GetGenres()
    {
        var genres = _service.GetAll();
        var genresDto = _mapper.Map<IReadOnlyCollection<GenreDto>>(genres);
        return Ok(genresDto);
    }

    [HttpGet("stats")]
    public ActionResult<IReadOnlyCollection<GenreStatsDto>> GetStats()
    {
        var stats = _service.GetStats();
        var statsDto = _mapper.Map<IReadOnlyCollection<GenreStatsDto>>(stats);
        return Ok(statsDto);
    }

    [HttpPost]
    public ActionResult<GenreDto> AddGenre([FromBody] GenreDto genreDto)
    {
        var genre = _mapper.Map<Genre>(genreDto);
        var res = _service.New(genre);
        return _mapper.Map<GenreDto>(res);
    }
}