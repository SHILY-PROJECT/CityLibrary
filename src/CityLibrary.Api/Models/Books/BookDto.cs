using System;
using CityLibrary.Api.Models.Authors;
using CityLibrary.Api.Models.Genres;

namespace CityLibrary.Api.Models.Books;

public record BookDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public GenreDto Genre { get; init; }
    public AuthorDto Author { get; init; }
}