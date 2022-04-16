using System.Collections.Generic;
using CityLibrary.WebApi.Models.Books;

namespace CityLibrary.WebApi.Models.Authors;

public record AuthorWithBooksDto(AuthorDto Author, IEnumerable<BookDto> Books);