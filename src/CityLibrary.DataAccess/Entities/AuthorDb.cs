using CityLibrary.DataAccess.Interfaces;

namespace CityLibrary.DataAccess.Entities;

public record AuthorDb : IGuidProperty
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string MiddleName { get; init; }
}