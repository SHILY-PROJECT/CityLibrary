using CityLibrary.DataAccess.Interfaces;

namespace CityLibrary.DataAccess.Entities;

public record BookDb : IGuidProperty
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Guid GenreId { get; set; }
    public GenreDb Genre { get; set; }

    public Guid AuthorId { get; set; }
    public AuthorDb Author { get; set; }
}