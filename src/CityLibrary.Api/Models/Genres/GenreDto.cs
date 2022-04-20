using System;

namespace CityLibrary.Api.Models.Genres;

public record GenreDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}