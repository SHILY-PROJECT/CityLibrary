using System;

namespace CityLibrary.Api.Models.Books;

public class NewBookWithoutAuthorDto
{
    public string Name { get; init; }
    public Guid GenreId { get; init; }
}