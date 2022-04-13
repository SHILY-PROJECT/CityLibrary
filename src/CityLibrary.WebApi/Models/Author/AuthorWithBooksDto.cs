using CityLibrary.WebApi.Models.Book;
using System.Collections.Generic;

namespace CityLibrary.WebApi.Models.Author;

public record AuthorWithBooksDto(AuthorDto Author, IEnumerable<BookDto> Books);