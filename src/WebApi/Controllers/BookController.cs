using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Domain.Interfaces.Services;
using WebApi.Models;

namespace WebApi.WebApi.Controllers;

[ApiController]
[Route("/api/book")]
public class BookController : ControllerBase
{
    private readonly IBookService _service;
    private readonly IMapper _mapper;

    public BookController(IBookService bookService, IMapper mapper)
    {
        _service = bookService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<BookDto>>> GetBooks()
    {
        var books = await _service.GetAllAsync();
        var booksResult = _mapper.Map<IReadOnlyCollection<BookDto>>(books);
        return Ok(booksResult);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<BookDto>>> GetBooksByAuthor([FromBody] (AuthorDto authorDto, BookSortType sortType) authorSearch)
    {
        var author = _mapper.Map<Author>(authorSearch.authorDto);
        var books = await _service.GetBooksByAuthorAsync(author, authorSearch.sortType);
        var booksResult = _mapper.Map<IReadOnlyCollection<BookDto>>(books);
        return Ok(booksResult);
    }

    [HttpGet("author/{authorId}")]
    public async Task<ActionResult<IReadOnlyCollection<BookDto>>> GetBooksByAuthor([FromRoute] Guid authorId, [FromQuery] BookSortType sortType)
    {
        var books = await _service.GetBooksByAuthorAsync(authorId, sortType);
        var booksResult = _mapper.Map<IReadOnlyCollection<BookDto>>(books);
        return Ok(booksResult);
    }

    [HttpGet("genre/{genreId}")]
    public async Task<ActionResult<IReadOnlyCollection<BookDto>>> GetListBooksByGenre([FromRoute] Guid genreId, [FromQuery] BookSortType sortType)
    {
        var books = await _service.GetBooksByGenreAsync(genreId, sortType);
        var booksResult = _mapper.Map<IReadOnlyCollection<BookDto>>(books);
        return Ok(booksResult);
    }

    [HttpPost]
    public async Task<ActionResult<BookDto>> AddBook([FromQuery] BookDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);
        var bookResult = await _service.NewAsync(book);
        return _mapper.Map<BookDto>(bookResult);
    }

    [HttpPut]
    public async Task<ActionResult<BookDto>> UpdateGenreBook([FromBody] BookDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);
        var bookResult = await _service.UpdateAsync(bookDto.Id, book);
        return _mapper.Map<BookDto>(bookResult);
    }

    [HttpDelete]
    public async Task<ActionResult<bool>> DeleteBook([FromBody] Guid bookId)
    {
        return await _service.DeleteAsync(bookId);
    }
}