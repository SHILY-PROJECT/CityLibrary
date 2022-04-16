using System;
using CityLibrary.WebApi.Models.Authors;
using CityLibrary.WebApi.Models.Genres;

namespace CityLibrary.WebApi.Models.Books;

public record BookDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public GenreDto Genre { get; init; }
    public AuthorDto Author { get; init; }
}