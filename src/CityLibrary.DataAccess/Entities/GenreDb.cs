using CityLibrary.DataAccess.Interfaces;

namespace CityLibrary.DataAccess.Entities;

public record GenreDb : IGuidProperty
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}