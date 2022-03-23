using System;

namespace CityLibrary.WebApi.Models;

public record BookDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}