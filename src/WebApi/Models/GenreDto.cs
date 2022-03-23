using System;

namespace WebApi.Models;

public record GenreDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}