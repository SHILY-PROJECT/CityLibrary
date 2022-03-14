using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Domain.Models;
using Domain.Interfaces.Services;
using WebApi.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("/api/person")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _service;
    private readonly IMapper _mapper;

    public PersonController(IPersonService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("{personId}")]
    public async Task<ActionResult<PersonDto>> GetPerson([FromRoute] Guid personId)
    {
        var person = await _service.GetAsync(personId);
        return _mapper.Map<PersonDto>(person);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<PersonDto>>> GetPersons()
    {
        var persons = await _service.GetAllAsync();
        var personsResult = _mapper.Map<IReadOnlyCollection<PersonDto>>(persons);
        return Ok(personsResult);
    }

    [HttpPost]
    public async Task<ActionResult<PersonDto>> AddPerson([FromQuery] PersonDto personDto)
    {
        var person = _mapper.Map<Person>(personDto);
        var personResult = await _service.NewAsync(person);
        return _mapper.Map<PersonDto>(personResult);
    }

    [HttpGet("{personId}/books")]
    public async Task<ActionResult<IReadOnlyCollection<BookDto>>> GetPersonBooks([FromRoute] Guid personId)
    {
        var books = await _service.GetPersonBooksAsync(personId);
        var booksResult = _mapper.Map<IReadOnlyCollection<BookDto>>(books);
        return Ok(booksResult);
    }


    [HttpPost]
    public async Task<ActionResult<bool>> TakeBook([FromQuery] Guid personeId, [FromQuery] Guid bookId)
    {
        return await _service.TakeBookAsync(personeId, bookId);
    }

    [HttpPost]
    public async Task<ActionResult<bool>> ReturnBook([FromQuery] Guid personeId, [FromQuery] Guid bookId)
    {
        return await _service.ReturnBookAsync(personeId, bookId);
    }

    [HttpPut]
    public async Task<ActionResult<PersonDto>> UpdatePerson([FromBody] PersonDto personDto)
    {
        var person = _mapper.Map<Person>(personDto);
        var personResult = await _service.UpdateAsync(personDto.Id, person);
        return _mapper.Map<PersonDto>(personResult);
    }

    [HttpDelete]
    public async Task<ActionResult<bool>> DeletePerson([FromQuery] Guid personId)
    {
        return await _service.DeleteAsync(personId);
    }

    [HttpDelete]
    public async Task<ActionResult<bool>> DeletePerson([FromQuery] PersonDto personDto)
    {
        var person = _mapper.Map<Person>(personDto);
        return await _service.DeleteAsync(person);
    }
}