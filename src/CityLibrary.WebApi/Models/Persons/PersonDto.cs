using System;

namespace CityLibrary.WebApi.Models.Persons;

public record PersonDto
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string MiddleName { get; init; }
    public string Email { get; init; }
    public DateTime BirthDate { get; init; }
}