using CityLibrary.WebApi.Models.Author;
using CityLibrary.WebApi.Models.Genre;
using System;

namespace CityLibrary.WebApi.Models.Book;

public record BookDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public GenreDto Genre { get; init; }
    public AuthorDto Author { get; init; }
}