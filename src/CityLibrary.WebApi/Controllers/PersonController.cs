using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CityLibrary.Domain.Models;
using CityLibrary.Domain.Interfaces.Services;
using CityLibrary.WebApi.Models;

namespace CityLibrary.WebApi.Controllers;

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
        return _mapper.Map<PersonDto[]>(persons);
    }

    [HttpPost]
    public async Task<ActionResult<PersonDto>> AddPerson([FromQuery] PersonDto personDto)
    {
        var person = _mapper.Map<Person>(personDto);
        var newPerson = await _service.NewAsync(person);
        return _mapper.Map<PersonDto>(newPerson);
    }

    [HttpGet("{personId}/books")]
    public async Task<ActionResult<IReadOnlyCollection<BookDto>>> GetPersonBooks([FromRoute] Guid personId)
    {
        var books = await _service.GetPersonBooksAsync(personId);
        return _mapper.Map<BookDto[]>(books);
    }

    [HttpPost("takeBook")]
    public async Task<ActionResult<bool>> TakeBook([FromQuery] Guid personeId, [FromQuery] Guid bookId)
    {
        return await _service.TakeBookAsync(personeId, bookId);
    }

    [HttpPost("returnBook")]
    public async Task<ActionResult<bool>> ReturnBook([FromQuery] Guid personeId, [FromQuery] Guid bookId)
    {
        return await _service.ReturnBookAsync(personeId, bookId);
    }

    [HttpPut]
    public async Task<ActionResult<PersonDto>> UpdatePerson([FromBody] PersonDto personDto)
    {
        var person = _mapper.Map<Person>(personDto);
        var updatedPerson = await _service.UpdateAsync(personDto.Id, person);
        return _mapper.Map<PersonDto>(updatedPerson);
    }

    [HttpDelete("{personId}")]
    public async Task<ActionResult<bool>> DeletePerson([FromRoute] Guid personId)
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