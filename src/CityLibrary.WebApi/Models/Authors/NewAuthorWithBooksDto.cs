using System.Collections.Generic;
using CityLibrary.WebApi.Models.Books;

namespace CityLibrary.WebApi.Models.Authors;

public record NewAuthorWithBooksDto(AuthorDto Author, IEnumerable<NewBookWithoutAuthorDto> Books);