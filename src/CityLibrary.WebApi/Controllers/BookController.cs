using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CityLibrary.Domain.Enums;
using CityLibrary.Domain.Models;
using CityLibrary.Domain.Interfaces.Services;
using CityLibrary.WebApi.Models;

namespace CityLibrary.WebApi.WebApi.Controllers;

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
        return _mapper.Map<BookDto[]>(books);
    }

    [HttpGet("author")]
    public async Task<ActionResult<IReadOnlyCollection<BookDto>>> GetBooksByAuthor([FromQuery] AuthorForSearchDto authorForSearchDto, [FromQuery] BookSortType sortType)
    {
        var author = _mapper.Map<Author>(authorForSearchDto);
        var books = await _service.GetBooksByAuthorAsync(author, sortType);
        return _mapper.Map<BookDto[]>(books); ;
    }

    [HttpGet("author/{authorId}")]
    public async Task<ActionResult<IReadOnlyCollection<BookDto>>> GetBooksByAuthorId([FromRoute] Guid authorId, [FromQuery] BookSortType sortType)
    {
        var books = await _service.GetBooksByAuthorAsync(authorId, sortType);
        return _mapper.Map<BookDto[]>(books);
    }

    [HttpGet("genre/{genreId}")]
    public async Task<ActionResult<IReadOnlyCollection<BookDto>>> GetListBooksByGenre([FromRoute] Guid genreId, [FromQuery] BookSortType sortType)
    {
        var books = await _service.GetBooksByGenreAsync(genreId, sortType);
        return _mapper.Map<BookDto[]>(books);
    }

    [HttpPost]
    public async Task<ActionResult<BookDto>> AddBook([FromQuery] BookDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);
        var newBook = await _service.NewAsync(book);
        return _mapper.Map<BookDto>(newBook);
    }

    [HttpPut]
    public async Task<ActionResult<BookDto>> UpdateGenreBook([FromBody] BookDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);
        var updatedBook = await _service.UpdateAsync(bookDto.Id, book);
        return _mapper.Map<BookDto>(updatedBook);
    }

    [HttpDelete]
    public async Task<ActionResult<bool>> DeleteBook([FromBody] Guid bookId)
    {
        return await _service.DeleteAsync(bookId);
    }
}