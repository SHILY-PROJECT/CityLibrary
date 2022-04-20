using System;

namespace CityLibrary.WebApi.Models.Books;

public class NewBookWithoutAuthorDto
{
    public string Name { get; init; }
    public Guid GenreId { get; init; }
}