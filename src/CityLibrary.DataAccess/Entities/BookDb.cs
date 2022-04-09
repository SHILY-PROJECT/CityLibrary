using CityLibrary.DataAccess.Interfaces;

namespace CityLibrary.DataAccess.Entities;

public record BookDb : IGuidProperty
{
    public Guid Id { get; init; }
    public string Name { get; init; }

    public Guid GenreId { get; init; }
    public GenreDb Genre { get; init; }

    public Guid AuthorId { get; init; }
    public AuthorDb Author { get; init; }
}