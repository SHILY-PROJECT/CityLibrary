using CityLibrary.DataAccess.Interfaces;

namespace CityLibrary.DataAccess.Entities;

public record PersonDb : IGuidProperty
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string MiddleName { get; init; }
    public string Email { get; init; }
    public DateTime BirthDate { get; init; }
}