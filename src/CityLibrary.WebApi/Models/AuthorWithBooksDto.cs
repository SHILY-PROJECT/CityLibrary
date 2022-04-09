using System.Collections.Generic;

namespace CityLibrary.WebApi.Models;

public record AuthorWithBooksDto(AuthorDto Author, IEnumerable<BookDto> Books);