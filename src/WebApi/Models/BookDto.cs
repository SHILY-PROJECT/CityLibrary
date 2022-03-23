using System;

namespace WebApi.Models;

public record BookDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}