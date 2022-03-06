using System;
using System.Collections.Generic;
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
    public ActionResult<PersonDto> GetPerson([FromRoute] Guid personId)
    {
        var person = _service.Get(personId);
        return _mapper.Map<PersonDto>(person);
    }

    [HttpGet]
    public ActionResult<IReadOnlyCollection<PersonDto>> GetPersons()
    {
        var persons = _service.GetAll();
        var personsDto = _mapper.Map<IReadOnlyCollection<PersonDto>>(persons);
        return Ok(personsDto);
    }

    [HttpPost]
    public ActionResult<PersonDto> AddPerson([FromQuery] PersonDto personDto)
    {
        var person = _mapper.Map<Person>(personDto);
        var res = _service.New(person);
        return _mapper.Map<PersonDto>(res);
    }

    [HttpGet("{personId}/books")]
    public ActionResult<IReadOnlyCollection<BookDto>> GetPersonBooks([FromRoute] Guid personId)
    {
        var books = _service.GetPersonBooks(personId);
        var res = _mapper.Map<IReadOnlyCollection<BookDto>>(books);
        return Ok(res);
    }


    [HttpPost]
    public ActionResult<bool> TakeBook([FromQuery] Guid personeId, [FromQuery] Guid bookId)
    {
        return _service.TakeBook(personeId, bookId);
    }

    [HttpPost]
    public ActionResult<bool> ReturnBook([FromQuery] Guid personeId, [FromQuery] Guid bookId)
    {
        return _service.ReturnBook(personeId, bookId);
    }

    [HttpPut]
    public ActionResult<PersonDto> UpdatePerson([FromBody] PersonDto personDto)
    {
        var person = _mapper.Map<Person>(personDto);
        var res = _service.Update(personDto.Id, person);
        return _mapper.Map<PersonDto>(res);
    }

    [HttpDelete]
    public ActionResult<bool> DeletePerson([FromQuery] Guid personId)
    {
        return _service.Delete(personId);
    }

    [HttpDelete]
    public ActionResult<bool> DeletePerson([FromQuery] PersonDto personDto)
    {
        var person = _mapper.Map<Person>(personDto);
        return _service.Delete(person);
    }
}