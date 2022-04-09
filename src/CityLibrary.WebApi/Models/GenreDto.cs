using System;

namespace CityLibrary.WebApi.Models;

public record GenreDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}