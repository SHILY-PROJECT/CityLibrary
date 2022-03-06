using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Domain.Models;
using Domain.Interfaces.Services;
using WebApi.Models;

namespace WebApi.WebApi.Controllers;

[ApiController]
[Route("/api/author")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _service;
    private readonly IMapper _mapper;

    public AuthorController(IAuthorService authorService, IMapper mapper)
    {
        _service = authorService;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IReadOnlyCollection<AuthorDto>> GetAuthors()
    {
        var authors = _service.GetAll();
        var authorsDto = _mapper.Map<IReadOnlyCollection<AuthorDto>>(authors);
        return Ok(authorsDto);
    }

    [HttpGet("{authorId}/books")]
    public ActionResult<IReadOnlyCollection<AuthorDto>> GetBooksByAuthor([FromRoute] Guid authorId)
    {
        var books = _service.GetBooksByAuthor(authorId);
        var booksDto = _mapper.Map<IReadOnlyCollection<AuthorDto>>(books);
        return Ok(booksDto);
    }

    [HttpPost]
    public ActionResult<AuthorDto> AddAuthor([FromBody] AuthorDto authorDto)
    {
        var author = _mapper.Map<Author>(authorDto);
        var res = _service.New(author);
        return _mapper.Map<AuthorDto>(res);
    }

    [HttpPost]
    public ActionResult AddAuthor([FromBody] (AuthorDto authorDto, IEnumerable<BookDto> booksDto) authorWithBooks)
    {
        var author = _mapper.Map<Author>(authorWithBooks.authorDto);
        var books = _mapper.Map<IEnumerable<Book>>(authorWithBooks.booksDto);
        var res = _service.New(author, books);
        return Ok(_mapper.Map<(AuthorDto authorDto, IEnumerable<BookDto> booksDto)>(res));
    }

    [HttpDelete]
    public ActionResult<bool> DeleteAuthor([FromQuery] Guid authorId)
    {
        return _service.Delete(authorId);
    }
}