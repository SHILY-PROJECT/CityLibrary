using System;

namespace CityLibrary.WebApi.Models.Genres;

public record GenreDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}