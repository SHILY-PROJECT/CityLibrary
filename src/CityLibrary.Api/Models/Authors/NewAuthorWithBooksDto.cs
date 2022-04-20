using System.Collections.Generic;
using CityLibrary.Api.Models.Books;

namespace CityLibrary.Api.Models.Authors;

public record NewAuthorWithBooksDto(AuthorDto Author, IEnumerable<NewBookWithoutAuthorDto> Books);