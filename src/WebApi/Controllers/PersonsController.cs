using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using WebApi.Models.Dto;
using WebApi.Models.Dto.Persons;

namespace WebApi.Controllers;

[ApiController]
[Route("/api/person")]
public class PersonsController : ControllerBase
{
    private readonly IPersonRepository _iPersonRepository;

    public PersonsController(IPersonRepository iPersonRepository)
    {
        _iPersonRepository = iPersonRepository;
    }

    [HttpGet]
    public IActionResult GetPersonBooks([FromQuery][Required] int personId)
    {
        var result = _iPersonRepository.GetPersonBooks(personId);

        if (result.IsSuccess is false)
            return BadRequest(result.Message);

        return Ok(result.Content);
    }

    [HttpPost]
    public IActionResult AddPerson([FromQuery] PersonDto person)
    {
        var result = _iPersonRepository.Add(person);

        if (result.IsSuccess is false)
            return BadRequest(result.Message);

        return Ok(result.Content);
    }

    [HttpPost]
    public IActionResult TakeBook([FromQuery] PersonBookDto personBook)
    {
        var result = _iPersonRepository.TakeBook(personBook);

        if (result.IsSuccess is false)
            return BadRequest(result.Message);

        return Ok(result.Message);
    }

    [HttpPost]
    public IActionResult ReturnBook([FromQuery] PersonBookDto personBook)
    {
        var result = _iPersonRepository.ReturnBook(personBook);

        if (result.IsSuccess is false)
            return BadRequest(result.Message);

        return Ok(result.Message);
    }

    [HttpPut]
    public IActionResult UpdatePerson([FromQuery] UpdatePersonDto personUpdateDto)
    {
        var result = _iPersonRepository.Update(personUpdateDto);

        if (result.IsSuccess is false)
            return BadRequest(result.Message);

        return Ok(result.Content);
    }

    [HttpDelete]
    public IActionResult DeletePerson([FromQuery] Guid personId)
    {
        var result = _iPersonRepository.Delete(personId);

        if (result.IsSuccess is false)
            return BadRequest(result.Message);

        return Ok(result.Message);
    }

    [HttpDelete("RemoveByFullName")]
    public IActionResult DeletePerson([FromQuery] PersonDto person)
    {
        var result = _iPersonRepository.Delete(person);

        if (result.IsSuccess is false)
            return BadRequest(result.Message);

        return Ok(result.Message);
    }

}