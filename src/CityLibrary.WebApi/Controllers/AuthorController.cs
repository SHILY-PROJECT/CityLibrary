using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CityLibrary.Domain.Models;
using CityLibrary.Domain.Interfaces.Services;
using CityLibrary.WebApi.Models.Books;
using CityLibrary.WebApi.Models.Authors;
using System.Linq;

namespace CityLibrary.WebApi.WebApi.Controllers;

[ApiController]
[Route("/api/authors")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;

    public AuthorController(IAuthorService authorService, IBookService bookService, IMapper mapper)
    {
        _authorService = authorService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<AuthorDto>>> GetAuthors()
    {
        var authors = await _authorService.GetAllAsync();
        return _mapper.Map<AuthorDto[]>(authors);
    }

    [HttpGet("{authorId}/books")]
    public async Task<ActionResult<IReadOnlyCollection<BookDto>>> GetBooksByAuthor([FromRoute] Guid authorId)
    {
        var books = await _authorService.GetBooksByAuthorAsync(authorId);
        return _mapper.Map<BookDto[]>(books);
    }

    [HttpPost("new")]
    public async Task<ActionResult<AuthorDto>> AddAuthor([FromBody] AuthorDto authorDto)
    {
        var author = _mapper.Map<Author>(authorDto);
        var newAuthor = await _authorService.NewAsync(author);
        return _mapper.Map<AuthorDto>(newAuthor);
    }

    [HttpPost("newWithBooks")]
    public async Task<ActionResult<(AuthorDto, IReadOnlyCollection<BookDto>)>> AddAuthorWithBooks([FromBody] NewAuthorWithBooksDto authorWithBooksDto)
    {
        var author = _mapper.Map<Author>(authorWithBooksDto.Author);
        var books = _mapper.Map<Book[]>(authorWithBooksDto.Books);

        var newAuthor = await _authorService.NewAsync(author);
        var newBooks = await _bookService.NewAsync(
            books.Select(b => b = b with { Author = new Author { Id = newAuthor.Id } }));

        return (_mapper.Map<AuthorDto>(newAuthor), _mapper.Map<BookDto[]>(newBooks));
    }

    [HttpDelete("{authorId}")]
    public async Task<ActionResult<bool>> DeleteAuthor([FromRoute] Guid authorId)
    {
        return await _authorService.DeleteAsync(authorId);
    }
}