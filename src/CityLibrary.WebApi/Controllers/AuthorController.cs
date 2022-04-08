﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CityLibrary.Domain.Models;
using CityLibrary.Domain.Interfaces.Services;
using CityLibrary.WebApi.Models;

namespace CityLibrary.WebApi.WebApi.Controllers;

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
    public async Task<ActionResult<IReadOnlyCollection<AuthorDto>>> GetAuthors()
    {
        var authors = await _service.GetAllAsync();
        var authorsResult = _mapper.Map<IReadOnlyCollection<AuthorDto>>(authors);
        return Ok(authorsResult);
    }

    [HttpGet("{authorId}/books")]
    public async Task<ActionResult<IReadOnlyCollection<AuthorDto>>> GetBooksByAuthor([FromRoute] Guid authorId)
    {
        var books = await _service.GetBooksByAuthorAsync(authorId);
        var booksResult = _mapper.Map<IReadOnlyCollection<AuthorDto>>(books);
        return Ok(booksResult);
    }

    [HttpPost]
    public async Task<ActionResult<AuthorDto>> AddAuthor([FromBody] AuthorDto authorDto)
    {
        var author = _mapper.Map<Author>(authorDto);
        var newAuthor = await _service.NewAsync(author);
        return _mapper.Map<AuthorDto>(newAuthor);
    }

    [HttpPost]
    public async Task<ActionResult> AddAuthor([FromBody] (AuthorDto authorDto, IEnumerable<BookDto> booksDto) authorWithBooksDto)
    {
        var author = _mapper.Map<Author>(authorWithBooksDto.authorDto);
        var books = _mapper.Map<IEnumerable<Book>>(authorWithBooksDto.booksDto);

        var newAuthorWithBooks = await _service.NewAsync(author, books);
        var newAuthorWithBooksResult = _mapper.Map<(AuthorDto authorDto, IEnumerable<BookDto> booksDto)>(newAuthorWithBooks);

        return Ok(newAuthorWithBooksResult);
    }

    [HttpDelete]
    public async Task<ActionResult<bool>> DeleteAuthor([FromQuery] Guid authorId)
    {
        return await _service.DeleteAsync(authorId);
    }
}