using System;
using System.Collections.Generic;
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
    public ActionResult<IReadOnlyCollection<BookDto>> GetBooks()
    {
        var books = _service.GetAll();
        var booksDto = _mapper.Map<IReadOnlyCollection<BookDto>>(books);
        return Ok(booksDto);
    }

    [HttpGet]
    public ActionResult<IReadOnlyCollection<BookDto>> GetBooksByAuthor([FromBody] (AuthorDto authorDto, BookSortType sortType) authorSearch)
    {
        var author = _mapper.Map<Author>(authorSearch.authorDto);
        var res = _service.GetBooksByAuthor(author, authorSearch.sortType);
        return Ok(_mapper.Map<IReadOnlyCollection<BookDto>>(res));
    }

    [HttpGet("author/{authorId}")]
    public ActionResult<IReadOnlyCollection<BookDto>> GetBooksByAuthor([FromRoute] Guid authorId, [FromQuery] BookSortType sortType)
    {
        var res = _service.GetBooksByAuthor(authorId, sortType);
        return Ok(_mapper.Map<IReadOnlyCollection<BookDto>>(res));
    }

    [HttpGet("genre/{genreId}")]
    public ActionResult<IReadOnlyCollection<BookDto>> GetListBooksByGenre([FromRoute] Guid genreId, [FromQuery] BookSortType sortType)
    {
        var res = _service.GetBooksByGenre(genreId, sortType);
        return Ok(_mapper.Map<IReadOnlyCollection<BookDto>>(res));
    }

    [HttpPost]
    public ActionResult<BookDto> AddBook([FromQuery] BookDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);
        var res = _service.New(book);
        return _mapper.Map<BookDto>(res);
    }

    [HttpPut]
    public ActionResult<BookDto> UpdateGenreBook([FromBody] BookDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);
        var res = _service.Update(bookDto.Id, book);
        return _mapper.Map<BookDto>(res);
    }

    [HttpDelete]
    public ActionResult<bool> DeleteBook([FromBody] Guid bookId)
    {
        return _service.Delete(bookId);
    }
}