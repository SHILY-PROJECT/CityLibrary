using System;

namespace CityLibrary.WebApi.Models.Genre;

public record GenreDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}