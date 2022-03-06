using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using WebApi.Enums;
using WebApi.Interfaces;
using WebApi.Models.Dto.Authors;
using WebApi.Models.Dto.Books;

namespace WebApi.WebApi.Controllers;

[ApiController]
[Route("Books")]
public class BooksController : ControllerBase
{
    private readonly IBookRepository _iBookRepository;

    public BooksController(IBookRepository bookRepository)
    {
        _iBookRepository = bookRepository;
    }

    [HttpGet("ListBookByAuthor")]
    public IActionResult GetListBooksByAuthor(
        [FromQuery] AuthorDto author,
        [FromQuery] BookSortTypeEnum sortType)
    {
        var result = _iBookRepository.GetListBooksByAuthor(author, sortType);

        if (result.IsSuccess is false)
            return BadRequest(result.Message);

        return Ok(result.Content);
    }

    [HttpGet("ListBooksByGenreId")]
    public IActionResult GetListBooksByGenre(
        [FromQuery][Required] int genreId,
        [FromQuery] BookSortTypeEnum sortingType)
    {
        var result = _iBookRepository.GetListBooksByGenre(genreId, sortingType);

        if (result.IsSuccess is false)
            return BadRequest(result.Message);

        return Ok(result.Content);
    }

    [HttpPost]
    public IActionResult AddBook([FromQuery] NewBookDto newBook)
    {
        var result = _iBookRepository.Add(newBook);

        if (result.IsSuccess is false)
            return BadRequest(result.Message);

        return Ok(result.Message);
    }

    [HttpPut("UpdateGenreBook")]
    public IActionResult UpdateGenreBook([FromBody] UpdateGenreOfBookDto bookUpdateGenre)
    {
        var result = _iBookRepository.UpdateGenre(bookUpdateGenre);

        if (result.IsSuccess is false)
            return BadRequest(result.Message);

        return Ok(result.Content);
    }

    [HttpDelete("RemoveBookById")]
    public IActionResult DeleteBook([FromBody][Required] int bookId)
    {
        var result = _iBookRepository.Delete(bookId);

        if (result.IsSuccess is false)
            return BadRequest(result.Message);

        return Ok(result.Message);
    }
}