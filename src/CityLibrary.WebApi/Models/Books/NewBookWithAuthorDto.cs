using System;

namespace CityLibrary.WebApi.Models.Books;

public record NewBookWithAuthorDto
{
    public string Name { get; init; }
    public Guid GenreId { get; init; }
    public Guid AuthorId { get; init; }
}