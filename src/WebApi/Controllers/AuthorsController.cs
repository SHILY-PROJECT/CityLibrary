using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using WebApi.WebApi.Interfaces;
using WebApi.WebApi.Models.Dto.Authors;

namespace WebApi.WebApi.Controllers;

[ApiController]
[Route("Authors")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _service;

    public AuthorsController(IAuthorService authorService)
    {
        _service = authorService;
    }

    [HttpGet("ListAllAuthors")]
    public IActionResult GetAuthors()
    {
        var result = _service.GetListAuthors();

        if (result.IsSuccess is false)
            return BadRequest(result.Message);

        return Ok(result.Content);
    }

    [HttpGet]
    public IActionResult GetBooksByAuthor([FromQuery] Guid authorId)
    {
        var result = _service.GetListBooksByAuthor(authorId);

        if (result.IsSuccess is false)
            return BadRequest(result.Message);

        return Ok(result.Content);
    }

    [HttpPost]
    public IActionResult AddAuthor([FromQuery] AuthorDto author, [FromQuery] IEnumerable<AuthorNewBookDto> books)
    {
        var result = _service.Add(author, books);

        if (result.IsSuccess is false)
            return BadRequest(result.Message);

        return Ok(result.Content);
    }

    [HttpDelete]
    public IActionResult DeleteAuthor([FromQuery] AuthorIdDto authorId)
    {
        var result = _service.Delete(authorId);

        if (result.IsSuccess is false)
            return BadRequest(result.Message);

        return Ok(result.Message);
    }
}