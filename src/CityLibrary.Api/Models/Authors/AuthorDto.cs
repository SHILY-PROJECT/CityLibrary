using System;

namespace CityLibrary.Api.Models.Authors;

public record AuthorDto
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string MiddleName { get; init; }
}