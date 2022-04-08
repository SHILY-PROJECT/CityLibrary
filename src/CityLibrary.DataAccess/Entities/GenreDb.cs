using CityLibrary.DataAccess.Interfaces;

namespace CityLibrary.DataAccess.Entities;

public record GenreDb : IGuidProperty
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}